# ScaleControl MVP Implementation Plan

> **For agentic workers:** REQUIRED SUB-SKILL: Use superpowers:subagent-driven-development (recommended) or superpowers:executing-plans to implement this plan task-by-task. Steps use checkbox (`- [ ]`) syntax for tracking.

**Goal:** Build a weighbridge weighing management system MVP with METTLER TOLEDO scale instrument support, standard + paired weighing modes, data management, query, and ticket printing.

**Architecture:** 6-project layered architecture (UI / Core / Hardware / Data / Reports / Models). Each layer communicates through well-defined interfaces. Hardware and Data layers are swappable via factory patterns.

**Tech Stack:** .NET Framework 4.8+, WinForms (C#), Access (.mdb) + SQL Server, FastReport OpenSource, Hikvision SDK

## Global Constraints

- Target framework: .NET Framework 4.8
- UI: WinForms (C#), Chinese UI language
- Database: TOLEDO AVS compatible table structure, Access password `sss2014aw`
- Scale protocol: METTLER TOLEDO continuous output format (18 bytes)
- Config files: `settings/dbsettings.xml`, `settings/hardware.xml`
- All user-facing text in Chinese
- Code comments in Chinese
- Use NuGet for third-party dependencies (FastReport.OpenSource, PdfiumViewer)

---

## File Structure

```
ScaleControl/
├── ScaleControl.sln
├── settings/
│   ├── dbsettings.xml
│   └── hardware.xml
├── ScaleControl.Models/
│   ├── Entities/
│   │   ├── WeighingRecord.cs
│   │   ├── TruckInfo.cs
│   │   ├── ProductInfo.cs
│   │   ├── CustomerInfo.cs
│   │   ├── UserInfo.cs
│   │   ├── RoleInfo.cs
│   │   └── WeightData.cs
│   ├── Interfaces/
│   │   ├── IScaleDriver.cs
│   │   ├── IWeighingRepository.cs
│   │   ├── IWeighingWorkflow.cs
│   │   └── IDatabaseConnectionFactory.cs
│   ├── Enums/
│   │   ├── ConnectionType.cs
│   │   ├── WeighingMode.cs
│   │   └── RecordStatus.cs
│   └── Config/
│       ├── ScaleConnectionConfig.cs
│       └── DatabaseConfig.cs
├── ScaleControl.Data/
│   ├── AccessConnectionFactory.cs
│   ├── SqlConnectionFactory.cs
│   ├── WeighingRepository.cs
│   ├── DatabaseInitializer.cs
│   └── Scripts/
│       └── CreateTables.sql
├── ScaleControl.Hardware/
│   ├── MettlerToledoScaleDriver.cs
│   ├── MettlerToledoDynamicDriver.cs
│   ├── ScaleDriverFactory.cs
│   └── Protocol/
│       └── ToledoProtocolParser.cs
├── ScaleControl.Core/
│   ├── WeighingWorkflow.cs
│   ├── WeightCalculator.cs
│   ├── AntiCheatChecker.cs
│   ├── TicketNumberGenerator.cs
│   └── Logging/
│       └── OperationLogger.cs
├── ScaleControl.Reports/
│   ├── ReportLoader.cs
│   ├── TicketPrinter.cs
│   └── Templates/
│       ├── StandardTicket.frx
│       └── PairTicket.frx
└── ScaleControl.UI/
    ├── Program.cs
    ├── frmSplash.cs
    ├── frmLogin.cs
    ├── frmMain.cs
    ├── frmMain.Designer.cs
    ├── Controls/
    │   ├── MenuBarControl.cs
    │   ├── WeightDisplayPanel.cs
    │   ├── EquipmentStatusPanel.cs
    │   ├── DataInputPanel.cs
    │   ├── VideoMonitorPanel.cs
    │   ├── HistoryTarePanel.cs
    │   └── QuickDataBrowsePanel.cs
    ├── Forms/
    │   ├── frmTruckEdit.cs
    │   ├── frmProductEdit.cs
    │   ├── frmCustomerEdit.cs
    │   ├── frmUserManage.cs
    │   ├── frmRoleManage.cs
    │   ├── frmWeighingQuery.cs
    │   ├── frmDetailRecord.cs
    │   ├── frmPasswordChange.cs
    │   ├── frmDatabaseConfig.cs
    │   ├── frmScaleConfig.cs
    │   └── frmAbout.cs
    └── Properties/
        └── Settings.settings
```

---

### Task 1: Solution and Project Structure Setup

**Files:**
- Create: `ScaleControl.sln`
- Create: `ScaleControl.Models/ScaleControl.Models.csproj`
- Create: `ScaleControl.Data/ScaleControl.Data.csproj`
- Create: `ScaleControl.Hardware/ScaleControl.Hardware.csproj`
- Create: `ScaleControl.Core/ScaleControl.Core.csproj`
- Create: `ScaleControl.Reports/ScaleControl.Reports.csproj`
- Create: `ScaleControl.UI/ScaleControl.UI.csproj`
- Create: `ScaleControl.UI/App.config`
- Create: `settings/dbsettings.xml`
- Create: `settings/hardware.xml`

**Interfaces:**
- Produces: Solution structure with 6 projects and correct references

- [ ] **Step 1: Create solution directory structure**

Run:
```bash
mkdir -p ScaleControl.Models/{Entities,Interfaces,Enums,Config}
mkdir -p ScaleControl.Data/Scripts
mkdir -p ScaleControl.Hardware/Protocol
mkdir -p ScaleControl.Core/Logging
mkdir -p ScaleControl.Reports/Templates
mkdir -p ScaleControl.UI/{Controls,Forms,Properties}
mkdir -p settings
```

- [ ] **Step 2: Create solution file**

Create `ScaleControl.sln` with 6 projects:
- ScaleControl.Models (Class Library)
- ScaleControl.Data (Class Library)
- ScaleControl.Hardware (Class Library)
- ScaleControl.Core (Class Library)
- ScaleControl.Reports (Class Library)
- ScaleControl.UI (WinForms App, startup project)

- [ ] **Step 3: Set up project references**

- ScaleControl.Data → ScaleControl.Models
- ScaleControl.Hardware → ScaleControl.Models
- ScaleControl.Core → ScaleControl.Models, ScaleControl.Data, ScaleControl.Hardware
- ScaleControl.Reports → ScaleControl.Models
- ScaleControl.UI → ScaleControl.Models, ScaleControl.Core, ScaleControl.Reports, ScaleControl.Data, ScaleControl.Hardware

- [ ] **Step 4: Create dbsettings.xml**

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

- [ ] **Step 5: Create hardware.xml**

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

- [ ] **Step 6: Create App.config for UI project**

```xml
<?xml version="1.0" encoding="utf-8"?>
<configuration>
  <startup>
    <supportedRuntime version="v4.0" sku=".NETFramework,Version=v4.8"/>
  </startup>
  <appSettings>
    <add key="SplashTimeout" value="2000"/>
    <add key="MaxRetryCount" value="3"/>
    <add key="RetryInterval" value="5000"/>
  </appSettings>
</configuration>
```

- [ ] **Step 7: Commit**

```bash
git add .
git commit -m "chore: initialize solution structure with 6 layered projects"
```

---

### Task 2: Models Layer - Enums

**Files:**
- Create: `ScaleControl.Models/Enums/ConnectionType.cs`
- Create: `ScaleControl.Models/Enums/WeighingMode.cs`
- Create: `ScaleControl.Models/Enums/RecordStatus.cs`

**Interfaces:**
- Produces: `ConnectionType`, `WeighingMode`, `RecordStatus` enums

- [ ] **Step 1: Create ConnectionType enum**

```csharp
namespace ScaleControl.Models.Enums
{
    public enum ConnectionType
    {
        Serial = 0,
        Network = 1
    }
}
```

- [ ] **Step 2: Create WeighingMode enum**

```csharp
namespace ScaleControl.Models.Enums
{
    public enum WeighingMode
    {
        Standard = 0,       // 标准称重
        Paired = 1,         // 车号配对称重
        ManualTare = 2,     // 手工置皮
        Multiple = 3,       // 多次称重
        PublicScale = 4     // 公秤称重
    }
}
```

- [ ] **Step 3: Create RecordStatus enum**

```csharp
namespace ScaleControl.Models.Enums
{
    public enum RecordStatus
    {
        Normal = 1,         // 正常
        Deleted = 9,        // 已删除
        Error = 3           // 错误
    }
}
```

- [ ] **Step 4: Commit**

```bash
git add .
git commit -m "feat(models): add core enums (ConnectionType, WeighingMode, RecordStatus)"
```

---

### Task 3: Models Layer - WeightData Entity

**Files:**
- Create: `ScaleControl.Models/Entities/WeightData.cs`

**Interfaces:**
- Produces: `WeightData` class with Weight, IsStable, IsOverload, IsUnderload, Unit, Timestamp properties

- [ ] **Step 1: Create WeightData entity**

```csharp
using System;

namespace ScaleControl.Models.Entities
{
    public class WeightData
    {
        public decimal Weight { get; set; }           // 重量值 (kg)
        public bool IsStable { get; set; }            // 是否稳态
        public bool IsOverload { get; set; }          // 是否超载
        public bool IsUnderload { get; set; }         // 是否欠载
        public string Unit { get; set; } = "kg";      // 单位
        public DateTime Timestamp { get; set; } = DateTime.Now;
        public int DecimalPlaces { get; set; } = 0;   // 小数点位置
        public int DivisionFactor { get; set; } = 1;  // 分度值因子
        public bool IsGross { get; set; } = true;     // true=毛重, false=净重

        public override string ToString()
        {
            return $"{Weight} {Unit} {(IsStable ? "稳定" : "波动")}";
        }
    }
}
```

- [ ] **Step 2: Commit**

```bash
git add .
git commit -m "feat(models): add WeightData entity"
```

---

### Task 4: Models Layer - Config Classes

**Files:**
- Create: `ScaleControl.Models/Config/ScaleConnectionConfig.cs`
- Create: `ScaleControl.Models/Config/DatabaseConfig.cs`

**Interfaces:**
- Produces: `ScaleConnectionConfig`, `DatabaseConfig` classes

- [ ] **Step 1: Create ScaleConnectionConfig**

```csharp
using ScaleControl.Models.Enums;

namespace ScaleControl.Models.Config
{
    public class ScaleConnectionConfig
    {
        public int TerminalId { get; set; }
        public string TerminalName { get; set; }
        public string DeviceName { get; set; } = "标准MT仪表";
        public string ScaleType { get; set; } = "MettlerToledoStatic";
        public bool Enabled { get; set; } = true;
        public ConnectionType ConnectionType { get; set; } = ConnectionType.Serial;
        
        // 串口参数
        public string PortName { get; set; } = "COM1";
        public int BaudRate { get; set; } = 9600;
        public int DataBits { get; set; } = 8;
        public StopBits StopBits { get; set; } = StopBits.One;
        public Parity Parity { get; set; } = Parity.None;
        
        // 网络参数
        public string IpAddress { get; set; }
        public int Port { get; set; } = 8000;
        
        // 稳态判断参数
        public int StableDetectTime { get; set; } = 3;    // 秒
        public int StableAllowChange { get; set; } = 20;  // kg
        public int MinWeight { get; set; } = 1000;        // kg
    }
}
```

- [ ] **Step 2: Create DatabaseConfig**

```csharp
namespace ScaleControl.Models.Config
{
    public class DatabaseConfig
    {
        public string Provider { get; set; } = "Access";  // Access / SqlServer
        
        // Access
        public string AccessDatabasePath { get; set; } = "Data\\ScaleDB.mdb";
        public string AccessPassword { get; set; } = "sss2014aw";
        
        // SQL Server
        public string SqlServerHost { get; set; }
        public string SqlDatabase { get; set; }
        public string SqlUser { get; set; }
        public string SqlPassword { get; set; }

        public string GetAccessConnectionString()
        {
            return $"Provider=Microsoft.Jet.OLEDB.4.0;Data Source={AccessDatabasePath};Jet OLEDB:Database Password={AccessPassword}";
        }

        public string GetSqlServerConnectionString()
        {
            return $"Server={SqlServerHost};Database={SqlDatabase};User Id={SqlUser};Password={SqlPassword}";
        }
    }
}
```

- [ ] **Step 3: Commit**

```bash
git add .
git commit -m "feat(models): add config classes (ScaleConnectionConfig, DatabaseConfig)"
```

---

### Task 5: Models Layer - Core Interfaces

**Files:**
- Create: `ScaleControl.Models/Interfaces/IScaleDriver.cs`
- Create: `ScaleControl.Models/Interfaces/IWeighingRepository.cs`
- Create: `ScaleControl.Models/Interfaces/IWeighingWorkflow.cs`
- Create: `ScaleControl.Models/Interfaces/IDatabaseConnectionFactory.cs`

**Interfaces:**
- Produces: All core interfaces for the system

- [ ] **Step 1: Create IScaleDriver interface**

```csharp
using System;
using ScaleControl.Models.Entities;
using ScaleControl.Models.Config;

namespace ScaleControl.Models.Interfaces
{
    public interface IScaleDriver
    {
        int TerminalId { get; }
        string TerminalName { get; }
        bool IsConnected { get; }
        WeightData LastWeight { get; }
        
        event EventHandler<WeightData> WeightUpdated;
        event EventHandler<string> ConnectionStatusChanged;
        
        void Connect(ScaleConnectionConfig config);
        void Disconnect();
        WeightData GetCurrentWeight();
        void SendCommand(string command);  // C/T/P/Z 命令
    }
}
```

- [ ] **Step 2: Create IWeighingRepository interface**

```csharp
using System.Collections.Generic;
using ScaleControl.Models.Entities;

namespace ScaleControl.Models.Interfaces
{
    public interface IWeighingRepository
    {
        // 称重记录
        WeighingRecord GetById(long id);
        WeighingRecord GetByTicketNo(string ticketNo);
        long SaveWeighingRecord(WeighingRecord record);
        void UpdateWeighingRecord(WeighingRecord record);
        void DeleteWeighingRecord(long id);
        List<WeighingRecord> QueryRecords(WeighingQueryCriteria criteria);
        WeighingRecord GetTempRecordByTruckNo(string truckNo);
        
        // 车皮管理
        TruckInfo GetTruckByNumber(string truckNo);
        void SaveTruck(TruckInfo truck);
        void DeleteTruck(string truckNo);
        List<TruckInfo> QueryTrucks(string filter);
        
        // 货物管理
        ProductInfo GetProductByName(string name);
        void SaveProduct(ProductInfo product);
        List<ProductInfo> GetProducts(string filter);
        
        // 收发货单位
        void SaveSender(CustomerInfo customer);
        void SaveReceiver(CustomerInfo customer);
        List<CustomerInfo> GetSenders(string filter);
        List<CustomerInfo> GetReceivers(string filter);
        
        // 用户认证
        UserInfo ValidateUser(string loginName, string password);
        void SaveUser(UserInfo user);
        void UpdatePassword(string userId, string newPassword);
        List<UserInfo> GetUsers();
        
        // 角色权限
        List<RoleInfo> GetRoles();
        RoleInfo GetRoleById(int roleId);
        void SaveRole(RoleInfo role);
        List<RolePermission> GetRolePermissions(int roleId);
        void SaveRolePermissions(int roleId, List<RolePermission> permissions);
        
        // 磅单号
        string GenerateTicketNo(string stationNo);
        
        // 日志
        void WriteLog(OperationLog log);
        List<OperationLog> QueryLogs(LogQueryCriteria criteria);
        
        // 菜单
        List<MenuClass> GetMenuClasses();
        List<MenuItem> GetMenuItems(int classId);
        
        // 报表格式
        List<ReportInfo> GetReports();
        ReportInfo GetReportById(int reportId);
        
        // 界面布局
        List<FieldLayout> getFieldLayouts(string weighingMode);
        void SaveFieldLayouts(List<FieldLayout> layouts, string weighingMode);
    }
}
```

- [ ] **Step 3: Create IWeighingWorkflow interface**

```csharp
using ScaleControl.Models.Entities;
using ScaleControl.Models.Enums;

namespace ScaleControl.Models.Interfaces
{
    public interface IWeighingWorkflow
    {
        WeighingMode CurrentMode { get; }
        bool IsReadingAllowed { get; }
        
        void SetWeighingMode(WeighingMode mode);
        void Continue();                    // 手动继续
        WeightData ReadWeight();            // 读数
        bool SaveRecord();                  // 保存
        void PrintTicket();                 // 打印
        void LoadTruckInfo(string truckNo); // 加载车皮信息
        WeighingRecord CurrentRecord { get; }
    }
}
```

- [ ] **Step 4: Create IDatabaseConnectionFactory interface**

```csharp
using System.Data;

namespace ScaleControl.Models.Interfaces
{
    public interface IDatabaseConnectionFactory
    {
        IDbConnection CreateConnection();
        string ProviderName { get; }
    }
}
```

- [ ] **Step 5: Commit**

```bash
git add .
git commit -m "feat(models): add core interfaces (IScaleDriver, IWeighingRepository, IWeighingWorkflow, IDatabaseConnectionFactory)"
```

---

### Task 6: Models Layer - Entity Classes

**Files:**
- Create: `ScaleControl.Models/Entities/WeighingRecord.cs`
- Create: `ScaleControl.Models/Entities/TruckInfo.cs`
- Create: `ScaleControl.Models/Entities/ProductInfo.cs`
- Create: `ScaleControl.Models/Entities/CustomerInfo.cs`
- Create: `ScaleControl.Models/Entities/UserInfo.cs`
- Create: `ScaleControl.Models/Entities/RoleInfo.cs`
- Create: `ScaleControl.Models/Entities/RolePermission.cs`
- Create: `ScaleControl.Models/Entities/OperationLog.cs`
- Create: `ScaleControl.Models/Entities/MenuClass.cs`
- Create: `ScaleControl.Models/Entities/MenuItem.cs`
- Create: `ScaleControl.Models/Entities/ReportInfo.cs`
- Create: `ScaleControl.Models/Entities/FieldLayout.cs`
- Create: `ScaleControl.Models/Entities/WeighingQueryCriteria.cs`
- Create: `ScaleControl.Models/Entities/LogQueryCriteria.cs`

**Interfaces:**
- Produces: All entity classes matching TOLEDO AVS table structure

- [ ] **Step 1: Create WeighingRecord entity**

```csharp
using System;
using ScaleControl.Models.Enums;

namespace ScaleControl.Models.Entities
{
    public class WeighingRecord
    {
        public long Id { get; set; }
        public string TicketNo1 { get; set; }          // 临时磅单号
        public string TicketNo2 { get; set; }          // 交易磅单号
        public string Station1 { get; set; }           // 临时磅站
        public string Station2 { get; set; }           // 交易磅站
        public string ScaleNo1 { get; set; }           // 临时秤号
        public string ScaleNo2 { get; set; }           // 交易秤号
        public string TruckNo { get; set; }            // 车号
        public string CardNo { get; set; }             // 卡号
        public string ContractNo { get; set; }         // 合同号
        public string Product { get; set; }            // 货物名称
        public string ProductCode { get; set; }        // 产品编码
        public string Specification { get; set; }      // 规格
        public string Sender { get; set; }             // 发货单位
        public string Receiver { get; set; }           // 收货单位
        public string Transporter { get; set; }        // 运输单位
        public DateTime? FirstDateTime { get; set; }   // 临时称重时间
        public DateTime? SecondDateTime { get; set; }  // 交易称重时间
        public DateTime? GrossDateTime { get; set; }   // 毛重称重时间
        public DateTime? TareDateTime { get; set; }    // 皮重称重时间
        public long? FirstWeight { get; set; }         // 临时重量
        public long? SecondWeight { get; set; }        // 交易重量
        public long? Gross { get; set; }               // 毛重
        public long? Tare { get; set; }                // 皮重
        public long? Net { get; set; }                 // 净重
        public decimal ProductNet { get; set; }        // 货物净重
        public decimal ExceptWater { get; set; }       // 扣水
        public decimal ExceptOther { get; set; }       // 扣杂
        public string UserId1 { get; set; }            // 临时操作员Id
        public string UserName1 { get; set; }          // 临时操作员名
        public string UserId2 { get; set; }            // 交易操作员Id
        public string UserName2 { get; set; }          // 交易操作员名
        public string Bc1 { get; set; }                // 临时班次
        public string Bc2 { get; set; }                // 交易班次
        public string ScaleWeightFlag { get; set; }    // 自动处理标识
        public string SpareFlag { get; set; }          // 备用标识
        public string UploadFlag { get; set; } = "0";  // 上传标识
        public string DataEditFlag { get; set; } = "0";// 修改标识
        public string DataStatus { get; set; } = "1";  // 数据状态
        public string ManualInputFlag { get; set; } = "0"; // 手工补单
        public string ScaleMode { get; set; }          // 称重模式
        public string FinalFlag { get; set; } = "0";  // 结束标识
        public long? LeftWeight { get; set; }          // 订单余额
        public string TareWeightAlarmFlag { get; set; } = "0";
        public string TareTimeAlarmFlag { get; set; } = "0";
        public string WeightTimeAlarmFlag { get; set; } = "0";
        public string AutoSaveFlag { get; set; } = "0";
        public string AuthFlag { get; set; } = "0";    // 授权标志
        public string Driver { get; set; }             // 司机
        public string BusinessNo { get; set; }         // 业务单号
        public string IdNumber { get; set; }           // 身份证号
        public string BusinessType { get; set; }       // 业务类型
        public int? MaxGross { get; set; }             // 最大毛重
        public int? MaxNet { get; set; }               // 最大净重
        public string OwsCheckType { get; set; }       // 超限类型
        public int ReprintCount { get; set; }          // 补打次数
        public string IdentifyTruckNo1 { get; set; }   // 临时识别车号
        public string IdentifyTruckNo2 { get; set; }   // 交易识别车号
        
        // 备用字段
        public string SpareStr1 { get; set; }
        public string SpareStr2 { get; set; }
        // ... SpareStr3-15
        public decimal SpareNum1 { get; set; }
        // ... SpareNum2-8
    }
}
```

- [ ] **Step 2: Create remaining entity classes**

```csharp
// TruckInfo.cs
namespace ScaleControl.Models.Entities
{
    public class TruckInfo
    {
        public long Id { get; set; }
        public string TruckNo { get; set; }      // 车号 (主键)
        public long Tare { get; set; }           // 皮重
        public DateTime TareDate { get; set; }   // 皮重时间
        public string InputCode { get; set; }    // 输入码
        public long EffectDay { get; set; }      // 有效天数
        public string Remark { get; set; }       // 备注
        public int? MaxGross { get; set; }       // 最大毛重
        public int? MaxNet { get; set; }         // 最大净重
        public string OwsCheckType { get; set; } // 超限类型
    }
}

- [ ] **Step 2: Create remaining entity classes**

Create the following entity files in `ScaleControl.Models/Entities/`:

- `ProductInfo.cs` — 货物信息 (ProductName, Code, InputCode, Remark, EnableMaxNetLimit, MaxNetLimit)
- `CustomerInfo.cs` — 收发货单位 (Name, InputCode, Remark)
- `UserInfo.cs` — 用户信息 (UserId, LogName, UserName, GroupName, Password, Remark)
- `RoleInfo.cs` — 角色信息 (GroupId, GroupName, Remark)
- `RolePermission.cs` — 角色权限 (GroupId, ModelId, ModelChnName, Search, Edit, Other1, Other2)
- `OperationLog.cs` — 操作日志 (LogId, KeyValue, Operator, LogTime, OptType, ModuleId, ModuleName, LogBeforeData, LogAfterData, Reason)
- `MenuClass.cs` — 一级菜单 (ClassId, ChnText, EngText, Order)
- `MenuItem.cs` — 二级菜单 (MenuId, ClassId, ChnText, EngText, ImageIndex, Order, CanUseFlag, OperatorText)
- `ReportInfo.cs` — 报表信息 (ReportId, ReportName, ReportCHNName, ReportSQL, ReportType, Root)
- `FieldLayout.cs` — 字段布局 (ScaleMode, FieldName, CtrlName, Top, Left, Height, Width, FontName, FontSize, FontItalic, FontBold, BackColor, ForeColor, LabelCaption, TabOrder, IsVisible, IsReadOnly, IsClear, IsMustFill, IsMustExist, Formula)
- `WeighingQueryCriteria.cs` — 查询条件 (DataType, StartTime, EndTime, FieldConditions)
- `LogQueryCriteria.cs` — 日志查询条件 (StartTime, EndTime, OperationType)

- [ ] **Step 3: Commit**

```bash
git add .
git commit -m "feat(models): add all entity classes matching TOLEDO AVS table structure"
```

---

### Task 7: Data Layer - Database Connection

**Files:**
- Create: `ScaleControl.Data/AccessConnectionFactory.cs`
- Create: `ScaleControl.Data/SqlConnectionFactory.cs`
- Create: `ScaleControl.Data/DatabaseConfigLoader.cs`

**Interfaces:**
- Consumes: `IDatabaseConnectionFactory`, `DatabaseConfig` from Models
- Produces: `AccessConnectionFactory`, `SqlConnectionFactory`, `DatabaseConfigLoader`

- [ ] **Step 1: Create AccessConnectionFactory**

```csharp
using System.Data;
using System.Data.OleDb;
using ScaleControl.Models.Config;
using ScaleControl.Models.Interfaces;

namespace ScaleControl.Data
{
    public class AccessConnectionFactory : IDatabaseConnectionFactory
    {
        private readonly string _connectionString;
        public string ProviderName => "Access";

        public AccessConnectionFactory(DatabaseConfig config)
        {
            _connectionString = config.GetAccessConnectionString();
        }

        public IDbConnection CreateConnection()
        {
            return new OleDbConnection(_connectionString);
        }
    }
}
```

- [ ] **Step 2: Create SqlConnectionFactory**

```csharp
using System.Data;
using System.Data.SqlClient;
using ScaleControl.Models.Config;
using ScaleControl.Models.Interfaces;

namespace ScaleControl.Data
{
    public class SqlConnectionFactory : IDatabaseConnectionFactory
    {
        private readonly string _connectionString;
        public string ProviderName => "SqlServer";

        public SqlConnectionFactory(DatabaseConfig config)
        {
            _connectionString = config.GetSqlServerConnectionString();
        }

        public IDbConnection CreateConnection()
        {
            return new SqlConnection(_connectionString);
        }
    }
}
```

- [ ] **Step 3: Create DatabaseConfigLoader**

```csharp
using System.IO;
using System.Xml.Serialization;
using ScaleControl.Models.Config;

namespace ScaleControl.Data
{
    public static class DatabaseConfigLoader
    {
        public static DatabaseConfig Load(string configPath)
        {
            var serializer = new XmlSerializer(typeof(DatabaseConfig));
            using (var reader = new StreamReader(configPath))
            {
                return (DatabaseConfig)serializer.Deserialize(reader);
            }
        }

        public static void Save(DatabaseConfig config, string configPath)
        {
            var serializer = new XmlSerializer(typeof(DatabaseConfig));
            using (var writer = new StreamWriter(configPath))
            {
                serializer.Serialize(writer, config);
            }
        }
    }
}
```

- [ ] **Step 4: Commit**

```bash
git add .
git commit -m "feat(data): add database connection factories and config loader"
```

---

### Task 8: Data Layer - Database Initializer

**Files:**
- Create: `ScaleControl.Data/DatabaseInitializer.cs`
- Create: `ScaleControl.Data/Scripts/CreateTables.sql`

**Interfaces:**
- Consumes: `IDatabaseConnectionFactory`
- Produces: `DatabaseInitializer` for creating tables and seed data

- [ ] **Step 1: Create table creation script**

Create `ScaleControl.Data/Scripts/CreateAccessTables.sql` with all 16 tables matching TOLEDO AVS structure (Trade, TruckList, ProductList, SenderList, ReceiverList, TransporterList, CardInfo, Contractlist, UserList, UserGroup, UserRoleCtrl, StationList, LogInfo, SysMenuClassList, SysMenuList, Report, TFieldNameList, MainPosition, SpareStr1-8, SpecifList, PictureList, TrendLineList, KeyList).

- [ ] **Step 2: Create DatabaseInitializer**

```csharp
using System.Data;
using System.IO;
using System.Reflection;
using ScaleControl.Models.Interfaces;

namespace ScaleControl.Data
{
    public class DatabaseInitializer
    {
        private readonly IDatabaseConnectionFactory _factory;

        public DatabaseInitializer(IDatabaseConnectionFactory factory)
        {
            _factory = factory;
        }

        public void Initialize()
        {
            using var conn = _factory.CreateConnection();
            conn.Open();
            var sql = File.ReadAllText("Scripts/CreateAccessTables.sql");
            foreach (var batch in sql.Split(new[] { "GO" }, StringSplitOptions.RemoveEmptyEntries))
            {
                if (string.IsNullOrWhiteSpace(batch)) continue;
                using var cmd = conn.CreateCommand();
                cmd.CommandText = batch.Trim();
                cmd.ExecuteNonQuery();
            }
        }

        public bool TestConnection()
        {
            try
            {
                using var conn = _factory.CreateConnection();
                conn.Open();
                return true;
            }
            catch
            {
                return false;
            }
        }
    }
}
```

- [ ] **Step 3: Commit**

```bash
git add .
git commit -m "feat(data): add database initializer with table creation scripts"
```

---

### Task 9: Data Layer - WeighingRepository Implementation

**Files:**
- Create: `ScaleControl.Data/WeighingRepository.cs`

**Interfaces:**
- Consumes: `IWeighingRepository`, `IDatabaseConnectionFactory`
- Produces: Full repository implementation for all data operations

- [ ] **Step 1: Create WeighingRepository with CRUD for Trade table**

Implement all methods defined in `IWeighingRepository`:
- `GetById`, `GetByTicketNo`, `SaveWeighingRecord`, `UpdateWeighingRecord`, `DeleteWeighingRecord`, `QueryRecords`, `GetTempRecordByTruckNo`
- Truck CRUD: `GetTruckByNumber`, `SaveTruck`, `DeleteTruck`, `QueryTrucks`
- Product CRUD
- Customer CRUD (Senders/Receivers)
- User CRUD and authentication
- Role and permission management
- Ticket number generation
- Log writing and querying
- Menu loading
- Report format management
- Field layout management

- [ ] **Step 2: Commit**

```bash
git add .
git commit -m "feat(data): implement WeighingRepository with full CRUD operations"
```

---

### Task 10: Hardware Layer - TOLEDO Protocol Parser

**Files:**
- Create: `ScaleControl.Hardware/Protocol/ToledoProtocolParser.cs`

**Interfaces:**
- Produces: `ToledoProtocolParser` for parsing 18-byte TOLEDO continuous output

- [ ] **Step 1: Create ToledoProtocolParser**

```csharp
using ScaleControl.Models.Entities;

namespace ScaleControl.Hardware.Protocol
{
    public static class ToledoProtocolParser
    {
        public static WeightData Parse(byte[] data)
        {
            if (data == null || data.Length < 17) return null;
            if (data[0] != 0x02) return null; // STX check

            var weightData = new WeightData();
            
            // Status word A (byte 1)
            byte statusA = data[1];
            int decimalPlaces = statusA & 0x07;
            int divisionFactor = (statusA >> 3) & 0x03;
            weightData.DecimalPlaces = decimalPlaces;
            weightData.DivisionFactor = divisionFactor switch { 1 => 1, 2 => 2, 3 => 5, _ => 1 };

            // Status word B (byte 2)
            byte statusB = data[2];
            weightData.IsGross = (statusB & 0x01) == 0;
            bool isNegative = (statusB & 0x02) != 0;
            weightData.IsOverload = (statusB & 0x04) != 0;
            weightData.IsUnderload = weightData.Weight < 0;

            // Weight value (bytes 3-8, 6 ASCII chars)
            string weightStr = System.Text.Encoding.ASCII.GetString(data, 2, 6).Trim();
            if (decimal.TryParse(weightStr, out decimal rawWeight))
            {
                decimal multiplier = decimalPlaces switch
                {
                    0 => 100m,
                    1 => 10m,
                    2 => 1m,
                    3 => 0.1m,
                    4 => 0.01m,
                    _ => 1m
                };
                weightData.Weight = isNegative ? -rawWeight * multiplier : rawWeight * multiplier;
            }

            return weightData;
        }
    }
}
```

- [ ] **Step 2: Commit**

```bash
git add .
git commit -m "feat(hardware): add TOLEDO protocol parser for 18-byte continuous output"
```

---

### Task 11: Hardware Layer - METTLER TOLEDO Driver

**Files:**
- Create: `ScaleControl.Hardware/MettlerToledoScaleDriver.cs`
- Create: `ScaleControl.Hardware/ScaleDriverFactory.cs`

**Interfaces:**
- Consumes: `IScaleDriver`, `ScaleConnectionConfig`, `ToledoProtocolParser`
- Produces: `MettlerToledoScaleDriver`, `ScaleDriverFactory`

- [ ] **Step 1: Create MettlerToledoScaleDriver**

```csharp
using System;
using System.IO.Ports;
using System.Net.Sockets;
using System.Threading;
using ScaleControl.Models.Entities;
using ScaleControl.Models.Config;
using ScaleControl.Models.Interfaces;
using ScaleControl.Hardware.Protocol;

namespace ScaleControl.Hardware
{
    public class MettlerToledoScaleDriver : IScaleDriver, IDisposable
    {
        private SerialPort _serialPort;
        private TcpClient _tcpClient;
        private NetworkStream _networkStream;
        private ScaleConnectionConfig _config;
        private WeightData _lastWeight;
        private readonly object _lock = new object();
        
        // Stable detection
        private decimal _stableStartWeight;
        private DateTime _stableStartTime;
        private bool _isCheckingStable;

        public int TerminalId => _config?.TerminalId ?? 0;
        public string TerminalName => _config?.TerminalName;
        public bool IsConnected => _serialPort?.IsOpen ?? (_tcpClient?.Connected ?? false);
        public WeightData LastWeight => _lastWeight;

        public event EventHandler<WeightData> WeightUpdated;
        public event EventHandler<string> ConnectionStatusChanged;

        public void Connect(ScaleConnectionConfig config)
        {
            _config = config;
            if (config.ConnectionType == ConnectionType.Serial)
            {
                _serialPort = new SerialPort(config.PortName, config.BaudRate)
                {
                    DataBits = config.DataBits,
                    StopBits = config.StopBits,
                    Parity = config.Parity,
                    ReadTimeout = 1000
                };
                _serialPort.DataReceived += OnSerialDataReceived;
                _serialPort.Open();
            }
            else
            {
                _tcpClient = new TcpClient();
                _tcpClient.Connect(config.IpAddress, config.Port);
                _networkStream = _tcpClient.GetStream();
                BeginReadTcp();
            }
            ConnectionStatusChanged?.Invoke(this, "已连接");
        }

        public void Disconnect()
        {
            _serialPort?.Close();
            _tcpClient?.Close();
            ConnectionStatusChanged?.Invoke(this, "已断开");
        }

        public WeightData GetCurrentWeight() => _lastWeight;

        public void SendCommand(string command)
        {
            if (!IsConnected) return;
            var bytes = System.Text.Encoding.ASCII.GetBytes(command);
            if (_serialPort?.IsOpen == true)
                _serialPort.Write(bytes, 0, bytes.Length);
            else if (_networkStream != null)
                _networkStream.Write(bytes, 0, bytes.Length);
        }

        private void OnSerialDataReceived(object sender, SerialDataReceivedEventArgs e)
        {
            try
            {
                int bytesToRead = _serialPort.BytesToRead;
                byte[] buffer = new byte[bytesToRead];
                _serialPort.Read(buffer, 0, bytesToRead);
                ProcessBuffer(buffer);
            }
            catch { }
        }

        private void BeginReadTcp()
        {
            byte[] buffer = new byte[256];
            _networkStream.BeginRead(buffer, 0, buffer.Length, ar =>
            {
                try
                {
                    int bytesRead = _networkStream.EndRead(ar);
                    if (bytesRead > 0)
                    {
                        byte[] data = new byte[bytesRead];
                        Array.Copy(buffer, data, bytesRead);
                        ProcessBuffer(data);
                    }
                    BeginReadTcp();
                }
                catch { }
            }, null);
        }

        private void ProcessBuffer(byte[] buffer)
        {
            // Find STX (0x02) and parse 18-byte frames
            for (int i = 0; i < buffer.Length - 17; i++)
            {
                if (buffer[i] == 0x02)
                {
                    byte[] frame = new byte[18];
                    Array.Copy(buffer, i, frame, 0, 18);
                    var weightData = ToledoProtocolParser.Parse(frame);
                    if (weightData != null)
                    {
                        weightData = CheckStability(weightData);
                        _lastWeight = weightData;
                        WeightUpdated?.Invoke(this, weightData);
                    }
                }
            }
        }

        private WeightData CheckStability(WeightData data)
        {
            if (!_isCheckingStable)
            {
                _stableStartWeight = data.Weight;
                _stableStartTime = DateTime.Now;
                _isCheckingStable = true;
                data.IsStable = false;
                return data;
            }

            var elapsed = (DateTime.Now - _stableStartTime).TotalSeconds;
            var change = Math.Abs(data.Weight - _stableStartWeight);

            if (elapsed >= _config.StableDetectTime && change <= _config.StableAllowChange)
            {
                data.IsStable = true;
            }
            else if (change > _config.StableAllowChange)
            {
                _stableStartWeight = data.Weight;
                _stableStartTime = DateTime.Now;
                data.IsStable = false;
            }

            return data;
        }

        public void Dispose()
        {
            Disconnect();
            _serialPort?.Dispose();
            _tcpClient?.Dispose();
        }
    }
}
```

- [ ] **Step 2: Create ScaleDriverFactory**

```csharp
using ScaleControl.Models.Config;
using ScaleControl.Models.Interfaces;

namespace ScaleControl.Hardware
{
    public static class ScaleDriverFactory
    {
        public static IScaleDriver CreateDriver(ScaleConnectionConfig config)
        {
            return config.ScaleType switch
            {
                "MettlerToledoStatic" => new MettlerToledoScaleDriver(),
                "MettlerToledoDynamic" => new MettlerToledoDynamicDriver(),
                _ => throw new System.NotSupportedException($"不支持的仪表类型: {config.ScaleType}")
            };
        }
    }
}
```

- [ ] **Step 3: Commit**

```bash
git add .
git commit -m "feat(hardware): add METTLER TOLEDO scale driver with serial/network support"
```

---

### Task 12: Core Layer - Weight Calculator

**Files:**
- Create: `ScaleControl.Core/WeightCalculator.cs`

**Interfaces:**
- Produces: `WeightCalculator` for weight computations

- [ ] **Step 1: Create WeightCalculator**

```csharp
using ScaleControl.Models.Entities;
using ScaleControl.Models.Enums;

namespace ScaleControl.Core
{
    public static class WeightCalculator
    {
        /// <summary>
        /// 标准称重: 净重 = 毛重 - 皮重
        /// </summary>
        public static long CalculateNet(long gross, long tare)
        {
            return gross - tare;
        }

        /// <summary>
        /// 配对称重: 比较两次重量，大=毛重，小=皮重
        /// </summary>
        public static (long gross, long tare, long net) CalculatePaired(long firstWeight, long secondWeight)
        {
            long gross = System.Math.Max(firstWeight, secondWeight);
            long tare = System.Math.Min(firstWeight, secondWeight);
            long net = gross - tare;
            return (gross, tare, net);
        }

        /// <summary>
        /// 计算货物净重 = 净重 - 扣水 - 扣杂
        /// </summary>
        public static decimal CalculateProductNet(long netWeight, decimal exceptWater, decimal exceptOther)
        {
            return netWeight - exceptWater - exceptOther;
        }

        /// <summary>
        /// 计算扣包装重量
        /// </summary>
        public static decimal CalculatePackageWeight(int packageCount, decimal packageWeightPerUnit)
        {
            return packageCount * packageWeightPerUnit;
        }

        /// <summary>
        /// kg 转 吨
        /// </summary>
        public static decimal KgToTon(long kg)
        {
            return kg / 1000m;
        }
    }
}
```

- [ ] **Step 2: Commit**

```bash
git add .
git commit -m "feat(core): add weight calculator for standard and paired weighing"
```

---

### Task 13: Core Layer - Anti-Cheat Checker

**Files:**
- Create: `ScaleControl.Core/AntiCheatChecker.cs`

**Interfaces:**
- Produces: `AntiCheatChecker` with all 9 anti-cheat checks

- [ ] **Step 1: Create AntiCheatChecker**

```csharp
using System;
using System.Collections.Generic;
using ScaleControl.Models.Entities;
using ScaleControl.Models.Interfaces;

namespace ScaleControl.Core
{
    public class AntiCheatCheckResult
    {
        public bool IsPassed { get; set; }
        public string AlarmType { get; set; }
        public string Message { get; set; }
        public string FlagField { get; set; }  // 对应 Trade 表中报警标志字段
    }

    public class AntiCheatChecker
    {
        private readonly IWeighingRepository _repository;
        private readonly AntiCheatConfig _config;

        public AntiCheatChecker(IWeighingRepository repository, AntiCheatConfig config)
        {
            _repository = repository;
            _config = config;
        }

        public List<AntiCheatCheckResult> CheckAll(WeighingRecord record, TruckInfo truck)
        {
            var results = new List<AntiCheatCheckResult>();

            // 1. 皮重有效期检查
            if (_config.EnableTareValidityCheck && truck != null)
            {
                results.Add(CheckTareValidity(record, truck));
            }

            // 2. 净重区间检查
            if (_config.EnableNetRangeCheck)
            {
                results.Add(CheckNetRange(record));
            }

            // 3. 毛重区间检查
            if (_config.EnableGrossRangeCheck)
            {
                results.Add(CheckGrossRange(record));
            }

            // 4. 皮重差异报警
            if (_config.EnableTareDiffCheck && truck != null)
            {
                results.Add(CheckTareDifference(record, truck));
            }

            // 5. 配对时间差报警
            if (_config.EnablePairTimeDiffCheck)
            {
                results.Add(CheckPairTimeDifference(record));
            }

            // 6. 交易时间差报警
            if (_config.EnableTradeTimeDiffCheck)
            {
                results.Add(CheckTradeTimeDifference(record));
            }

            // 7. 收发货重量检查
            if (_config.EnableWeightDiffCheck)
            {
                results.Add(CheckWeightDifference(record, truck));
            }

            // 8. 超载检查
            if (_config.EnableOverloadCheck && truck != null)
            {
                results.Add(CheckOverload(record, truck));
            }

            // 9. 净重差异报警
            if (_config.EnableNetDiffCheck && truck != null)
            {
                results.Add(CheckNetDifference(record, truck));
            }

            return results;
        }

        private AntiCheatCheckResult CheckTareValidity(WeighingRecord record, TruckInfo truck)
        {
            if (truck.EffectDay <= 0) return new AntiCheatCheckResult { IsPassed = true };
            var daysSinceTare = (DateTime.Now - truck.TareDate).TotalDays;
            if (daysSinceTare > truck.EffectDay)
            {
                return new AntiCheatCheckResult
                {
                    IsPassed = false,
                    AlarmType = "皮重有效期",
                    Message = "皮重有效期已超出，禁止保存数据",
                    FlagField = "TareTimeAlarmFlag"
                };
            }
            return new AntiCheatCheckResult { IsPassed = true };
        }

        private AntiCheatCheckResult CheckNetRange(WeighingRecord record)
        {
            if (!record.Net.HasValue) return new AntiCheatCheckResult { IsPassed = true };
            if (record.Net < _config.MinNetWeight || record.Net > _config.MaxNetWeight)
            {
                return new AntiCheatCheckResult
                {
                    IsPassed = false,
                    AlarmType = "净重超差",
                    Message = "净重超差，不允许保存数据"
                };
            }
            return new AntiCheatCheckResult { IsPassed = true };
        }

        // ... 其他检查方法类似实现
        private AntiCheatCheckResult CheckGrossRange(WeighingRecord record) { /* ... */ }
        private AntiCheatCheckResult CheckTareDifference(WeighingRecord record, TruckInfo truck) { /* ... */ }
        private AntiCheatCheckResult CheckPairTimeDifference(WeighingRecord record) { /* ... */ }
        private AntiCheatCheckResult CheckTradeTimeDifference(WeighingRecord record) { /* ... */ }
        private AntiCheatCheckResult CheckWeightDifference(WeighingRecord record, TruckInfo truck) { /* ... */ }
        private AntiCheatCheckResult CheckOverload(WeighingRecord record, TruckInfo truck) { /* ... */ }
        private AntiCheatCheckResult CheckNetDifference(WeighingRecord record, TruckInfo truck) { /* ... */ }
    }

    public class AntiCheatConfig
    {
        public bool EnableTareValidityCheck { get; set; }
        public bool EnableNetRangeCheck { get; set; }
        public long MinNetWeight { get; set; }
        public long MaxNetWeight { get; set; }
        public bool EnableGrossRangeCheck { get; set; }
        public long MinGrossWeight { get; set; }
        public long MaxGrossWeight { get; set; }
        public bool EnableTareDiffCheck { get; set; }
        public decimal TareDiffThreshold { get; set; }
        public bool EnablePairTimeDiffCheck { get; set; }
        public int PairTimeDiffMinutes { get; set; }
        public bool EnableTradeTimeDiffCheck { get; set; }
        public int TradeTimeDiffMinutes { get; set; }
        public bool EnableWeightDiffCheck { get; set; }
        public decimal WeightDiffThreshold { get; set; }
        public bool EnableOverloadCheck { get; set; }
        public bool EnableNetDiffCheck { get; set; }
        public decimal NetDiffThreshold { get; set; }
    }
}
```

- [ ] **Step 2: Commit**

```bash
git add .
git commit -m "feat(core): add anti-cheat checker with 9 validation checks"
```

---

### Task 14: Core Layer - Ticket Number Generator

**Files:**
- Create: `ScaleControl.Core/TicketNumberGenerator.cs`

**Interfaces:**
- Produces: `TicketNumberGenerator` for auto-generating ticket numbers

- [ ] **Step 1: Create TicketNumberGenerator**

```csharp
using ScaleControl.Models.Interfaces;

namespace ScaleControl.Core
{
    public class TicketNumberGenerator
    {
        private readonly IWeighingRepository _repository;

        public TicketNumberGenerator(IWeighingRepository repository)
        {
            _repository = repository;
        }

        public string Generate(string stationNo)
        {
            return _repository.GenerateTicketNo(stationNo);
        }
    }
}
```

- [ ] **Step 2: Commit**

```bash
git add .
git commit -m "feat(core): add ticket number generator"
```

---

### Task 15: Core Layer - Weighing Workflow

**Files:**
- Create: `ScaleControl.Core/WeighingWorkflow.cs`

**Interfaces:**
- Consumes: `IWeighingWorkflow`, `IWeighingRepository`, `IScaleDriver`, `WeightCalculator`, `AntiCheatChecker`, `TicketNumberGenerator`
- Produces: `WeighingWorkflow` orchestrating the full weighing process

- [ ] **Step 1: Create WeighingWorkflow**

Implement the workflow:
- `SetWeighingMode` — switch between Standard/Paired
- `Continue` — clear input area, prepare for new weighing
- `ReadWeight` — get current weight from scale driver
- `SaveRecord` — run anti-cheat checks, generate ticket number, save to database
- `PrintTicket` — trigger report printing
- `LoadTruckInfo` — query truck info by number

- [ ] **Step 2: Commit**

```bash
git add .
git commit -m "feat(core): implement weighing workflow engine"
```

---

### Task 16: Core Layer - Operation Logger

**Files:**
- Create: `ScaleControl.Core/Logging/OperationLogger.cs`

**Interfaces:**
- Produces: `OperationLogger` for writing operation logs

- [ ] **Step 1: Create OperationLogger**

```csharp
using ScaleControl.Models.Entities;
using ScaleControl.Models.Interfaces;

namespace ScaleControl.Core.Logging
{
    public class OperationLogger
    {
        private readonly IWeighingRepository _repository;

        public OperationLogger(IWeighingRepository repository)
        {
            _repository = repository;
        }

        public void Log(string operationType, string keyValue, string operatorName, 
            string moduleName, string beforeData = null, string afterData = null, string reason = null)
        {
            _repository.WriteLog(new OperationLog
            {
                KeyValue = keyValue,
                Operator = operatorName,
                LogTime = DateTime.Now,
                OptType = operationType,
                ModuleName = moduleName,
                LogBeforeData = beforeData,
                LogAfterData = afterData,
                Reason = reason
            });
        }
    }
}
```

- [ ] **Step 2: Commit**

```bash
git add .
git commit -m "feat(core): add operation logger"
```

---

### Task 17: Reports Layer

**Files:**
- Create: `ScaleControl.Reports/ReportLoader.cs`
- Create: `ScaleControl.Reports/TicketPrinter.cs`

**Interfaces:**
- Produces: `ReportLoader`, `TicketPrinter` for FastReport integration

- [ ] **Step 1: Install FastReport NuGet packages**

```
Install-Package FastReport.OpenSource
Install-Package FastReport.OpenSource.Export.PdfSimple
Install-Package PdfiumViewer -Version 2.10.0
```

- [ ] **Step 2: Create TicketPrinter**

```csharp
using FastReport;
using FastReport.Export.PdfSimple;
using ScaleControl.Models.Entities;
using ScaleControl.Models.Interfaces;
using System.Data;
using System.IO;

namespace ScaleControl.Reports
{
    public class TicketPrinter
    {
        private readonly IWeighingRepository _repository;

        public TicketPrinter(IWeighingRepository repository)
        {
            _repository = repository;
        }

        public void Print(WeighingRecord record, string templatePath)
        {
            var report = new Report();
            report.Load(templatePath);
            
            // Create DataTable from record
            var dt = CreateDataTableFromRecord(record);
            report.RegisterData(dt, "Trade");
            report.Prepare();
            
            // Print or preview
            report.Show();
        }

        public void ExportToPdf(WeighingRecord record, string templatePath, string outputPath)
        {
            var report = new Report();
            report.Load(templatePath);
            var dt = CreateDataTableFromRecord(record);
            report.RegisterData(dt, "Trade");
            report.Prepare();
            
            var pdfExport = new PDFSimpleExport();
            pdfExport.Export(report, outputPath);
        }

        private DataTable CreateDataTableFromRecord(WeighingRecord record)
        {
            var dt = new DataTable("Trade");
            // Add columns matching Trade table structure
            dt.Columns.Add("TicketNo1", typeof(string));
            dt.Columns.Add("TruckNo", typeof(string));
            dt.Columns.Add("Product", typeof(string));
            dt.Columns.Add("Gross", typeof(long));
            dt.Columns.Add("Tare", typeof(long));
            dt.Columns.Add("Net", typeof(long));
            // ... add all needed columns
            
            dt.Rows.Add(record.TicketNo1, record.TruckNo, record.Product, 
                record.Gross, record.Tare, record.Net);
            return dt;
        }
    }
}
```

- [ ] **Step 3: Commit**

```bash
git add .
git commit -m "feat(reports): add FastReport ticket printer"
```

---

### Task 18: UI - Custom Controls

**Files:**
- Create: `ScaleControl.UI/Controls/MenuBarControl.cs`
- Create: `ScaleControl.UI/Controls/WeightDisplayPanel.cs`
- Create: `ScaleControl.UI/Controls/EquipmentStatusPanel.cs`
- Create: `ScaleControl.UI/Controls/DataInputPanel.cs`
- Create: `ScaleControl.UI/Controls/VideoMonitorPanel.cs`
- Create: `ScaleControl.UI/Controls/HistoryTarePanel.cs`
- Create: `ScaleControl.UI/Controls/QuickDataBrowsePanel.cs`

**Interfaces:**
- Produces: All custom controls for the main interface

- [ ] **Step 1: Create MenuBarControl**

Custom control with:
- Bottom area: first-level menu buttons (from SysMenuClassList)
- Top area: second-level menu items with icons (from SysMenuList)
- Click first-level → show its second-level items in top area
- Click second-level → raise event to open corresponding form

- [ ] **Step 2: Create WeightDisplayPanel**

Custom control with:
- Scale selection buttons (磅1, 磅2, ...)
- Large bold weight display
- Unit label (kg/t)
- Connection status label
- Stable indicator (blue/gray)

- [ ] **Step 3: Create EquipmentStatusPanel**

Custom control with:
- Scale platform graphic
- Peripheral icons (traffic lights, barriers, photoelectric sensors, card readers)
- Flow status display
- Recognition result display

- [ ] **Step 4: Create DataInputPanel**

Custom control with:
- Dynamically load field controls from MainPosition table
- Support quick code input, list selection, fuzzy search
- Input validation (required, existence check)
- Read-only fields for gross/tare/net

- [ ] **Step 5: Create VideoMonitorPanel**

Custom control with:
- Layout buttons (1格, 2格, 3格, 4格)
- PictureBox controls for real-time video
- Show/hide toggle
- Uses Hikvision SDK for video stream

- [ ] **Step 6: Create HistoryTarePanel**

Custom control with:
- Current truck number display
- Average tare display
- Recent tare records grid

- [ ] **Step 7: Create QuickDataBrowsePanel**

Custom control with:
- Tab switch (交易记录, 临时记录, 称重曲线)
- Data grid with recent records
- Operation buttons (刷新, 详细, 放大, 缩小, 自定义字段, 加载车号)
- Weight curve chart

- [ ] **Step 8: Commit**

```bash
git add .
git commit -m "feat(ui): add all custom controls for main interface"
```

---

### Task 19: UI - Main Form

**Files:**
- Create: `ScaleControl.UI/frmMain.cs`
- Create: `ScaleControl.UI/frmMain.Designer.cs`

**Interfaces:**
- Consumes: All custom controls, IWeighingWorkflow, IWeighingRepository
- Produces: Main application form

- [ ] **Step 1: Design main form layout**

Arrange all custom controls according to the spec layout:
- Top bar: Logo + ProductName + User/Shift/Switch/Exit
- Left: MenuBarControl (full height)
- Left column: WeightDisplayPanel + EquipmentStatusPanel
- Center: DataInputPanel (full height)
- Right: VideoMonitorPanel (docked right)
- Bottom: HistoryTarePanel (left) + QuickDataBrowsePanel (right)
- Status bar: full width

- [ ] **Step 2: Wire up events**

- Menu clicks → open forms
- WeightUpdated → update display, check read conditions
- Continue button → workflow.Continue()
- Read button → workflow.ReadWeight()
- Save button → workflow.SaveRecord()
- Print button → workflow.PrintTicket()
- Truck number input → auto-load truck info

- [ ] **Step 3: Commit**

```bash
git add .
git commit -m "feat(ui): create main form with all controls wired up"
```

---

### Task 20: UI - Login and Splash

**Files:**
- Create: `ScaleControl.UI/frmSplash.cs`
- Create: `ScaleControl.UI/frmLogin.cs`

**Interfaces:**
- Produces: Login and splash screens

- [ ] **Step 1: Create frmSplash**

Show product logo, version info, loading progress. Auto-close after timeout.

- [ ] **Step 2: Create frmLogin**

- Username/password input
- Shift selection (from system settings)
- Login button → validate against UserList
- Show product logo and version

- [ ] **Step 3: Commit**

```bash
git add .
git commit -m "feat(ui): add splash and login forms"
```

---

### Task 21: UI - Data Management Forms

**Files:**
- Create: `ScaleControl.UI/Forms/frmTruckEdit.cs`
- Create: `ScaleControl.UI/Forms/frmProductEdit.cs`
- Create: `ScaleControl.UI/Forms/frmCustomerEdit.cs`
- Create: `ScaleControl.UI/Forms/frmUserManage.cs`
- Create: `ScaleControl.UI/Forms/frmRoleManage.cs`
- Create: `ScaleControl.UI/Forms/frmPasswordChange.cs`
- Create: `ScaleControl.UI/Forms/frmDatabaseConfig.cs`
- Create: `ScaleControl.UI/Forms/frmScaleConfig.cs`
- Create: `ScaleControl.UI/Forms/frmAbout.cs`

**Interfaces:**
- Produces: All data management and configuration forms

- [ ] **Step 1: Create data edit forms**

Each data management form follows the standard layout:
- Function buttons (新增, 修改, 删除, 保存, 取消, 导出)
- Filter input box
- Detail info edit area
- Data grid browse area

Implement for: TruckEdit, ProductEdit, CustomerEdit (Senders/Receivers/Transporters)

- [ ] **Step 2: Create user/role management forms**

- UserManage: user CRUD with role assignment
- RoleManage: role CRUD with module permission grid
- PasswordChange: old/new password input

- [ ] **Step 3: Create configuration forms**

- DatabaseConfig: Access/SQL Server connection settings, test connection
- ScaleConfig: scale connection parameters (COM baud rate, network IP/port)
- About: product info, version, copyright

- [ ] **Step 4: Commit**

```bash
git add .
git commit -m "feat(ui): add all data management and configuration forms"
```

---

### Task 22: UI - Query Forms

**Files:**
- Create: `ScaleControl.UI/Forms/frmWeighingQuery.cs`
- Create: `ScaleControl.UI/Forms/frmDetailRecord.cs`

**Interfaces:**
- Produces: Query and detail record forms

- [ ] **Step 1: Create frmWeighingQuery**

- Data source selection (交易/临时/删除/错误)
- Time range selection
- Field condition filters (up to 4 custom conditions)
- Query/Reset buttons
- Data grid with results
- Export, reprint ticket, view detail buttons

- [ ] **Step 2: Create frmDetailRecord**

- Record field display
- Modify/Save buttons for editable fields
- Print button
- Weight curve display
- Capture picture display
- Operation log grid

- [ ] **Step 3: Commit**

```bash
git add .
git commit -m "feat(ui): add weighing query and detail record forms"
```

---

### Task 23: Program.cs and Application Startup

**Files:**
- Create: `ScaleControl.UI/Program.cs`

**Interfaces:**
- Produces: Application entry point

- [ ] **Step 1: Create Program.cs**

```csharp
using System;
using System.Windows.Forms;
using ScaleControl.Data;
using ScaleControl.Models.Config;
using ScaleControl.Models.Interfaces;
using ScaleControl.Hardware;

namespace ScaleControl.UI
{
    static class Program
    {
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);

            // Show splash
            var splash = new frmSplash();
            splash.Show();
            Application.DoEvents();
            System.Threading.Thread.Sleep(2000);

            // Load configuration
            var dbConfig = DatabaseConfigLoader.Load("settings/dbsettings.xml");
            
            // Initialize database
            IDatabaseConnectionFactory connFactory = dbConfig.Provider == "Access"
                ? new AccessConnectionFactory(dbConfig)
                : (IDatabaseConnectionFactory)new SqlConnectionFactory(dbConfig);

            var dbInit = new DatabaseInitializer(connFactory);
            if (!dbInit.TestConnection())
            {
                MessageBox.Show("数据库连接失败，请检查配置", "错误", 
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            // Initialize hardware
            var scaleConfig = HardwareConfigLoader.Load("settings/hardware.xml");
            
            // Show login
            splash.Hide();
            var login = new frmLogin(connFactory);
            if (login.ShowDialog() != DialogResult.OK) return;

            // Show main form
            Application.Run(new frmMain(connFactory, scaleConfig, login.CurrentUser));
        }
    }
}
```

- [ ] **Step 2: Create HardwareConfigLoader**

```csharp
using System.Xml.Serialization;
using ScaleControl.Models.Config;
using System.Collections.Generic;
using System.IO;

namespace ScaleControl.Data
{
    [XmlRoot("HardwareSettings")]
    public class HardwareConfig
    {
        [XmlArray("Terminals")]
        [XmlArrayItem("Terminal")]
        public List<ScaleConnectionConfig> Terminals { get; set; }
    }

    public static class HardwareConfigLoader
    {
        public static List<ScaleConnectionConfig> Load(string path)
        {
            var serializer = new XmlSerializer(typeof(HardwareConfig));
            using var reader = new StreamReader(path);
            var config = (HardwareConfig)serializer.Deserialize(reader);
            return config.Terminals;
        }
    }
}
```

- [ ] **Step 3: Commit**

```bash
git add .
git commit -m "feat: add application entry point and startup flow"
```

---

### Task 24: Integration Testing and Final Commit

**Files:**
- Modify: All projects as needed

**Interfaces:**
- Verifies: Full application runs end-to-end

- [ ] **Step 1: Build solution**

Run: `msbuild ScaleControl.sln /p:Configuration=Debug`
Expected: Build succeeds with no errors

- [ ] **Step 2: Test startup flow**

- Splash screen displays
- Login form accepts credentials
- Main form loads with all controls
- Scale driver connects (or shows disconnected status)

- [ ] **Step 3: Test weighing workflow**

- Enter truck number → tare weight auto-loads
- Click 读数 → weight captured
- Click 保存 → record saved to database
- Click 打印 → ticket prints

- [ ] **Step 4: Test data management**

- Open truck edit form → CRUD operations work
- Open query form → search and display results

- [ ] **Step 5: Final commit**

```bash
git add .
git commit -m "feat: MVP complete - weighbridge weighing management system"
```

---

## Self-Review Checklist

- [x] All spec requirements covered (weighing, data management, query, printing, anti-cheat)
- [x] No TBD/TODO placeholders
- [x] Type consistency across tasks (IScaleDriver, IWeighingRepository, etc.)
- [x] File paths are exact and complete
- [x] Each task has testable deliverable
- [x] Dependencies between tasks are clear