









# 地磅称重管理系统 MVP 设计文档

## 1. 项目概述

### 1.1 目标
构建地磅称重管理系统 MVP，实现核心称重流程：仪表连接、手动称重（标准+车号配对）、数据保存、磅单打印、基础数据管理、数据查询。

### 1.2 技术选型
| 项目 | 选型 |
|---|---|
| 开发框架 | .NET Framework 4.8+ |
| UI 框架 | WinForms (C#) |
| 数据库 | Access (.mdb)，预留 SQL Server 切换 |
| 报表 | FastReport OpenSource |
| 仪表 | METTLER TOLEDO 标准静态 |
| 通信 | 串口 (RS232) / 网络 (TCP/IP) |

### 1.3 参考文档
- 需求文档：`Requirements.md`
- 数据库结构：`db_struct.rtf`
- 界面效果图：`其他图片/` 目录
- 外设图标：`外设状态/` 目录
- 流程图：`流程图/` 目录

---

## 2. 架构设计

### 2.1 分层架构

```
┌─────────────────────────────────────────────────────┐
│                  ScaleControl.UI                     │
│  WinForms 主界面 │ 登录 │ 基础数据管理 │ 数据查询    │
├─────────────────────────────────────────────────────┤
│                ScaleControl.Core                     │
│  称重流程 │ 重量计算 │ 防作弊检查 │ 磅单号生成      │
├──────────────┬──────────────────────────────────────┤
│  ScaleControl.Hardware  │    ScaleControl.Data        │
│  仪表驱动 │ 协议解析    │  Access │ SQL Server 抽象   │
├──────────────┴──────────────────────────────────────┤
│                ScaleControl.Models                   │
│  称重记录 │ 车皮 │ 货物 │ 用户 │ 配置             │
├─────────────────────────────────────────────────────┤
│              ScaleControl.Reports                    │
│  FastReport 模板 │ 磅单打印 │ 报表生成            │
└─────────────────────────────────────────────────────┘
```

### 2.2 项目结构

| 项目 | 类型 | 职责 |
|---|---|---|
| `ScaleControl.Models` | Class Library | 数据实体、DTO、枚举、接口定义 |
| `ScaleControl.Data` | Class Library | 数据库连接、CRUD 操作、事务 |
| `ScaleControl.Hardware` | Class Library | 仪表通信、协议解析、重量采集 |
| `ScaleControl.Core` | Class Library | 称重流程引擎、计算逻辑、防作弊 |
| `ScaleControl.Reports` | Class Library | FastReport 模板加载、数据绑定、打印 |
| `ScaleControl.UI` | WinForms App | 所有用户界面、事件调度 |

### 2.3 依赖关系
```
UI → Core → (Hardware + Data) → Models
Reports → Models
UI → Reports
```

---

## 3. 核心接口设计

### 3.1 仪表驱动接口
```csharp
public interface IScaleDriver
{
    event EventHandler<WeightData> WeightUpdated;
    bool IsConnected { get; }
    void Connect(ScaleConnectionConfig config);
    void Disconnect();
    WeightData GetCurrentWeight();
}
```

### 3.2 数据访问接口
```csharp
public interface IWeighingRepository
{
    WeighingRecord GetById(long id);
    void Save(WeighingRecord record);
    List<WeighingRecord> Query(WeighingQueryCriteria criteria);
    // 基础数据 CRUD
    TruckInfo GetTruckByNumber(string truckNo);
    void SaveTruck(TruckInfo truck);
    List<ProductInfo> GetProducts();
    List<CustomerInfo> GetSenders();
    List<CustomerInfo> GetReceivers();
    // 用户认证
    UserInfo ValidateUser(string loginName, string password);
    // 磅单号
    string GenerateTicketNo(string stationNo);
}
```

### 3.3 称重流程接口
```csharp
public interface IWeighingWorkflow
{
    void Continue();      // 手动继续
    void ReadWeight();    // 读数
    void SaveRecord();    // 保存
    void PrintTicket();   // 打印
}
```

### 3.4 驱动工厂
```csharp
public static class ScaleDriverFactory
{
    public static IScaleDriver CreateDriver(string scaleType)
    {
        return scaleType switch
        {
            "MettlerToledoStatic" => new MettlerToledoScaleDriver(),
            "MettlerToledoDynamic" => new MettlerToledoDynamicDriver(), // 预留
            "Yaohua" => new YaohuaScaleDriver(),                        // 预留
            _ => throw new NotSupportedException()
        };
    }
}
```

---

## 4. 硬件通信层

### 4.1 METTLER TOLEDO 标准静态仪表

**TOLEDO 连续输出格式（18字节）：**
```
字节: STX(1) | 状态A(1) | 状态B(1) | 状态C(1) | 显示重量(6) | 皮重(6) | CR(1) | CKS(1)
```

**状态字解析：**
- 状态A bit0-2: 小数点位置
- 状态A bit3-4: 分度值因子 (X1/X2/X5)
- 状态B bit0: 毛重=0，净重=1
- 状态B bit1: 符号：正=0，负=1
- 状态B bit2: 超载=1
- 状态B bit4: 单位：kg=1

**稳态判断：**
- 检测时间内重量变化 < 允许范围 → 稳态
- 默认检测时间：3秒
- 默认允许变化：20kg

### 4.2 连接配置
```csharp
public class ScaleConnectionConfig
{
    public string DeviceName { get; set; }
    public ConnectionType ConnectionType { get; set; }
    // 串口参数
    public string PortName { get; set; } = "COM1";
    public int BaudRate { get; set; } = 9600;
    public int DataBits { get; set; } = 8;
    public StopBits StopBits { get; set; } = StopBits.One;
    public Parity Parity { get; set; } = Parity.None;
    // 网络参数
    public string IpAddress { get; set; }
    public int Port { get; set; } = 8000;
    // 稳态判断
    public int StableDetectTime { get; set; } = 3;
    public int StableAllowChange { get; set; } = 20;
    public int MinWeight { get; set; } = 1000;
}
```

### 4.3 驱动状态机
```
Disconnected → Connecting → Connected → Receiving → Disconnecting → Disconnected
```

---

## 5. 数据库设计

### 5.1 MVP 数据表（16 张，TOLEDO AVS 完整结构）

| 表名 | AVS编号 | 用途 |
|---|---|---|
| Trade | 221 | 称重记录（临时+正式） |
| TruckList | 224 | 车皮信息 |
| ProductList | 206 | 货物信息 |
| SenderList | 208 | 发货单位 |
| ReceiverList | 207 | 收货单位 |
| TransporterList | 223 | 运输单位 |
| CardInfo | 201 | 卡管理/车辆登记 |
| Contractlist | 202 | 订单管理 |
| UserList | 225 | 用户信息 |
| UserGroup | 229 | 角色信息 |
| UserRoleCtrl | 226 | 角色权限 |
| StationList | 218 | 磅站信息 |
| LogInfo | 204 | 操作日志 |
| SysMenuClassList | 219 | 一级菜单 |
| SysMenuList | 220 | 二级菜单 |
| Report | 230 | 报表/磅单格式 |
| TFieldNameList | 101 | 字段名属性 |
| MainPosition | 208 | 主界面自定义布局 |

### 5.2 磅单号生成规则
```
格式: [磅站号(1-2位)] + [年(4位)] + [月(2位)] + [日(2位)] + [流水号(4位)]
示例: A202610100001
```

### 5.3 Access 数据库密码
```
sss2014aw
```

---

## 6. 核心业务流程

### 6.1 标准称重流程
```
1. [继续] → 清空输入区
2. 输入车号 → 查询车皮表带出皮重
3. 车辆上秤 → 稳态判断 → 读数按钮激活
4. [读数] → 采集重量 → 填入毛重 → 计算净重(净重=毛重-皮重)
5. [保存] → 防作弊检查 → 生成磅单号 → 写入Trade表
6. [打印] → 加载FastReport模板 → 填充数据 → 打印磅单
```

### 6.2 车号配对称重流程
```
第一次称重:
  输入车号 → [读数] → 保存到Trade（临时记录, finalflag=0）

第二次称重:
  输入车号 → 系统查找临时记录 → [读数] →
  比较两次重量 → 大=毛重, 小=皮重 → 计算净重 →
  保存到Trade（正式记录, finalflag=1）→ 删除临时记录
```

### 6.3 防作弊检查链（保存前按序执行）
```
1. 皮重有效期检查
2. 净重区间检查
3. 毛重区间检查
4. 皮重差异报警
5. 配对时间差报警
6. 交易时间差报警
7. 收发货重量检查
8. 超载检查
9. 净重差异报警
```
每项可独立启用/禁用，失败时设置报警标志，根据配置决定是否阻止保存。

---

## 7. UI 界面设计

### 7.1 主界面布局

```
┌──────────────────────────────────────────────────────────────────────┐
│  LOGO │ 产品名称: 地磅称重管理系统              │用户│班次│切换│退出 │
├───────┴──────────────────────────────────────────┴────┴────┴────┴─────┤
│ ┌────┐ ┌───────────┐ ┌────────────────────────────────────────┐┌────┐│
│ │    │ │称重读数显示│ │                                        ││视频││
│ │ 二 │ │  ┌─────┐  │ │         数 据 输 入 区                  ││监控││
│ │ 级 │ │  │磅1磅2│  │ │                                        ││┌──┐││
│ │ 菜 │ │  │重量   │  │ │  车号│货物│规格│业务类型│司机│身份证  │││1格│││
│ │ 单 │ │  │状态   │  │ │  发货│收货│运输│订单号  │业务│超载类型│││2格│││
│ │    │ │  └─────┘  │ │  毛重│皮重│净重│扣水    │扣杂│货物净重│││3格│││
│ │ 上 │ │ [称重方式▼]│ │  [自定义字段1-8...]                    │││4格│││
│ │ 区 │ │  ┌─────┐  │ │                                        ││├──┤││
│ │    │ │  │外设  │  │ │  [继续] [读数] [保存] [打印]           │││PB│││
│ │    │ │  │状态  │  │ │                                        │││  │││
│ │    │ │  │      │  │ │                                        │││  │││
│ │    │ │  │      │  │ │                                        │││  │││
│ │    │ │  └─────┘  │ │                                        ││└──┘││
│ ├────┤ └───────────┘ └────────────────────────────────────────┘└────┘│
│ │    │ ┌──────────────────┐ ┌──────────────────────────────────────┐│
│ │ 一 │ │ 历史皮重显示 (左) │ │ 快速数据浏览区 (右)                   ││
│ │ 级 │ │ ┌──────────────┐ │ │ [交易][临时][曲线]                    ││
│ │ 菜 │ │ │车牌: xxx     │ │ │ ┌──────────────────────────────────┐ ││
│ │ 单 │ │ │平均皮重: xx  │ │ │ │ 数据网格 (最近N条记录)           │ ││
│ │    │ │ │┌────────────┐│ │ │ │                                  │ ││
│ │ 下 │ │ ││磅单│皮重│时间│ │ │ │                                  │ ││
│ │ 区 │ │ │└────────────┘│ │ │ └──────────────────────────────────┘ ││
│ │    │ │ └──────────────┘ │ │ [刷新][详细][放大][缩小]             ││
│ │    │ └──────────────────┘ └──────────────────────────────────────┘│
│ └────┘                                                              │
├──────────────────────────────────────────────────────────────────────┤
│  状态栏 (全宽): 数据库:本地Access | 版本:1.0 | 产品编号:xxx | 网络:已连接 │
└──────────────────────────────────────────────────────────────────────┘
```

### 7.2 区域说明

| 区域 | 位置 | 说明 |
|---|---|---|
| 顶部条 | 全宽 | LOGO + 产品名 + 用户/班次/切换/退出 |
| 菜单栏 | 左侧 | 一级菜单(下) + 二级菜单(上)，贯穿除顶条/状态栏外全部高度 |
| 称重读数 | 左上方 | 磅号选择 + 重量显示(粗体大字) + 状态 |
| 称重方式 | 左中 | 标准称重/车号配对 下拉选择 |
| 外设状态 | 左下方 | 地磅图形 + 外设图标 + 流程状态 + 识别结果 |
| 数据输入区 | 中间 | 动态加载字段控件，占满右侧高度 |
| 视频监控 | 右侧 | 布局按钮 + PictureBox，紧贴右边框，可隐藏 |
| 历史皮重 | 左下 | 车牌 + 平均皮重 + 最近N条记录 |
| 快速数据浏览 | 右下 | 交易记录/临时记录/称重曲线 切换 |
| 状态栏 | 全宽 | 数据库信息 + 版本号 + 产品编号 + 网络状态 |

### 7.3 数据输入区动态加载

从 `MainPosition` 表加载字段控件配置，支持：
- 位置/大小/字体/颜色自定义
- 隐藏/只读/自动清屏/必填/存在性检查属性
- 不同称重方式可有不同布局

### 7.4 视频监控控件

- 上部：布局按钮 [1格] [2格] [3格] [4格]
- 下部：PictureBox 实时画面
- 支持布局：1×1、2×1、1+2、2×2、1+3
- 可隐藏/显示切换
- 使用海康威视 SDK (HCNetSDK)

### 7.5 MVP 窗体清单

| 窗体 | 用途 | 优先级 |
|---|---|---|
| frmSplash | 启动画面 | P0 |
| frmLogin | 登录验证 | P0 |
| frmMain | 主界面 | P0 |
| frmTruckEdit | 车皮管理 | P0 |
| frmProductEdit | 货物管理 | P1 |
| frmCustomerEdit | 收/发货单位管理 | P1 |
| frmUserManage | 用户管理 | P1 |
| frmRoleManage | 角色管理 | P1 |
| frmWeighingQuery | 数据查询 | P1 |
| frmDetailRecord | 详细记录查看 | P1 |
| frmPasswordChange | 口令修改 | P1 |
| frmDatabaseConfig | 数据库设置 | P1 |
| frmScaleConfig | 仪表参数设置 | P1 |
| frmAbout | 关于 | P2 |

---

## 8. 配置文件

### 8.1 目录结构
```
ScaleControl/
├── settings/
│   └── dbsettings.xml          ← 数据库连接配置
│   └── hardware.xml            ← 硬件设备连接配置
├── Reports/
│   ├── StandardTicket.frx
│   ├── PairTicket.frx
│   ├── DetailReport.frx
│   └── SummaryReport.frx
├── Logs/
```

### 8.2 dbsettings.xml
```xml
<?xml version="1.0" encoding="utf-8"?>
<DatabaseSettings>
  <Provider>Access</Provider>
  <Access>
    <DatabasePath>Data\ScaleDB.mdb</DatabasePath>
    <Password>sss2014aw</Password>
  </Access>
  <SqlServer>
    <Server>192.168.1.100</Server>
    <Database>ScaleDB</Database>
    <User>sa</User>
    <Password></Password>
  </SqlServer>
</DatabaseSettings>
```

### 8.3 hardware.xml
```xml
<?xml version="1.0" encoding="utf-8"?>
<HardwareSettings>
  <Terminals>
    <Terminal id="1" name="1#磅" type="MettlerToledoStatic">
      <Enabled>true</Enabled>
      <ConnectionType>Serial</ConnectionType>
      <PortName>COM1</PortName>
      <BaudRate>9600</BaudRate>
      <DataBits>8</DataBits>
      <StopBits>One</StopBits>
      <Parity>None</Parity>
      <StableDetectTime>3</StableDetectTime>
      <StableAllowChange>20</StableAllowChange>
      <MinWeight>1000</MinWeight>
    </Terminal>
  </Terminals>
</HardwareSettings>
```

---

## 9. 报表与打印

### 9.1 报表模板

| 模板文件 | 用途 |
|---|---|
| StandardTicket.frx | 标准称重磅单 |
| PairTicket.frx | 车号配对称重磅单 |
| DetailReport.frx | 明细报表 |
| SummaryReport.frx | 汇总报表 |

### 9.2 打印流程
```
保存称重记录 → 查询完整记录 → 加载.frx模板 →
注册DataTable数据源 → Prepare → 预览/直接打印
```

### 9.3 打印设置
- 临时称重磅单打印：启用/关闭
- 交易称重磅单打印：启用/关闭
- 自动打印：保存后自动打印
- 打印份数：可配置
- 打印前预览：启用/关闭

---

## 10. 错误处理与日志

### 10.1 分层错误处理

| 层级 | 错误类型 | 处理方式 |
|---|---|---|
| Hardware | 串口断开、仪表无数据、协议解析失败 | 自动重连(3次/5秒)，状态通知UI，日志记录 |
| Data | 数据库连接失败、SQL异常、事务回滚 | 连接池检测，异常包装向上传递，UI提示 |
| Core | 称重条件不满足、防作弊报警、计算异常 | 业务规则校验，报警标志设置，UI弹窗 |
| UI | 用户输入验证、界面操作异常 | 输入校验提示，Try-Catch，友好错误消息 |

### 10.2 操作日志

| 操作类型 | 触发时机 |
|---|---|
| 启动软件 | 程序启动 |
| 登录操作 | 用户登录 |
| 新增记录 | 保存称重数据 |
| 修改记录 | 修改称重数据 |
| 删除记录 | 删除称重数据 |
| 防作弊报警 | 防作弊检查触发 |
| 手工补单 | 手工输入重量 |
| 补打磅单 | 重新打印磅单 |
| 数据清理 | 清理历史数据 |
| 读数授权 | 临时授权操作 |

---

## 11. 启动流程

```
1. 显示启动画面 (frmSplash)
2. 加载 settings/dbsettings.xml
3. 加载 settings/hardware.xml
4. 初始化数据库连接
5. 初始化仪表驱动
6. 加载系统参数
7. 显示登录窗体 (frmLogin)
8. 验证成功 → 加载菜单 → 显示主界面 (frmMain)
```

---

## 12. 后续迭代方向

MVP 完成后，可按以下优先级扩展：

| 阶段 | 功能 |
|---|---|
| Phase 2 | 控制柜连接（IND9AE/IND9AX/IND9AA/ARM100）+ IO控制 |
| Phase 3 | 读卡器 + 车牌识别 + 自动称重流程 |
| Phase 4 | 称重曲线 + 抓拍图片 + 大屏幕显示 |
| Phase 5 | 数据远传 + 网络数据库 + 多磅站联网 |
| Phase 6 | 操作终端 + 第三方系统接口 |
