CREATE TABLE [Trade] (
    [Id] AUTOINCREMENT PRIMARY KEY,
    [TicketNo1] TEXT(50),
    [TicketNo2] TEXT(50),
    [Station1] TEXT(50),
    [Station2] TEXT(50),
    [ScaleNo1] TEXT(50),
    [ScaleNo2] TEXT(50),
    [TruckNo] TEXT(50),
    [CardNo] TEXT(50),
    [ContractNo] TEXT(50),
    [Product] TEXT(100),
    [ProductCode] TEXT(50),
    [Specification] TEXT(100),
    [Sender] TEXT(100),
    [Receiver] TEXT(100),
    [Transporter] TEXT(100),
    [FirstDateTime] DATETIME,
    [SecondDateTime] DATETIME,
    [GrossDateTime] DATETIME,
    [TareDateTime] DATETIME,
    [FirstWeight] LONG,
    [SecondWeight] LONG,
    [Gross] LONG,
    [Tare] LONG,
    [Net] LONG,
    [ProductNet] CURRENCY,
    [ExceptWater] CURRENCY,
    [ExceptOther] CURRENCY,
    [UserId1] TEXT(50),
    [UserName1] TEXT(50),
    [UserId2] TEXT(50),
    [UserName2] TEXT(50),
    [Bc1] TEXT(50),
    [Bc2] TEXT(50),
    [ScaleWeightFlag] TEXT(10),
    [SpareFlag] TEXT(10),
    [UploadFlag] TEXT(10),
    [DataEditFlag] TEXT(10),
    [DataStatus] TEXT(10),
    [ManualInputFlag] TEXT(10),
    [ScaleMode] TEXT(20),
    [FinalFlag] TEXT(10),
    [LeftWeight] LONG,
    [TareWeightAlarmFlag] TEXT(10),
    [TareTimeAlarmFlag] TEXT(10),
    [WeightTimeAlarmFlag] TEXT(10),
    [AutoSaveFlag] TEXT(10),
    [AuthFlag] TEXT(10),
    [Driver] TEXT(50),
    [BusinessNo] TEXT(50),
    [IdNumber] TEXT(50),
    [BusinessType] TEXT(50),
    [MaxGross] LONG,
    [MaxNet] LONG,
    [OwsCheckType] TEXT(20),
    [ReprintCount] LONG,
    [IdentifyTruckNo1] TEXT(50),
    [IdentifyTruckNo2] TEXT(50),
    [SpareStr1] TEXT(255),
    [SpareStr2] TEXT(255),
    [SpareStr3] TEXT(255),
    [SpareStr4] TEXT(255),
    [SpareStr5] TEXT(255),
    [SpareStr6] TEXT(255),
    [SpareStr7] TEXT(255),
    [SpareStr8] TEXT(255),
    [SpareStr9] TEXT(255),
    [SpareStr10] TEXT(255),
    [SpareStr11] TEXT(255),
    [SpareStr12] TEXT(255),
    [SpareStr13] TEXT(255),
    [SpareStr14] TEXT(255),
    [SpareStr15] TEXT(255),
    [SpareNum1] CURRENCY,
    [SpareNum2] CURRENCY,
    [SpareNum3] CURRENCY,
    [SpareNum4] CURRENCY,
    [SpareNum5] CURRENCY,
    [SpareNum6] CURRENCY,
    [SpareNum7] CURRENCY,
    [SpareNum8] CURRENCY
);

CREATE TABLE [TruckList] (
    [TruckNo] TEXT(50) PRIMARY KEY,
    [Tare] LONG,
    [TareDate] DATETIME,
    [InputCode] TEXT(50),
    [EffectDay] LONG,
    [Remark] TEXT(255),
    [MaxGross] LONG,
    [MaxNet] LONG,
    [OwsCheckType] TEXT(20)
);

CREATE TABLE [ProductList] (
    [Id] AUTOINCREMENT PRIMARY KEY,
    [ProductName] TEXT(100),
    [Code] TEXT(50),
    [InputCode] TEXT(50),
    [Remark] TEXT(255),
    [EnableMaxNetLimit] BIT,
    [MaxNetLimit] LONG
);

CREATE TABLE [SenderList] (
    [Id] AUTOINCREMENT PRIMARY KEY,
    [Name] TEXT(100),
    [InputCode] TEXT(50),
    [Remark] TEXT(255)
);

CREATE TABLE [ReceiverList] (
    [Id] AUTOINCREMENT PRIMARY KEY,
    [Name] TEXT(100),
    [InputCode] TEXT(50),
    [Remark] TEXT(255)
);

CREATE TABLE [TransporterList] (
    [Id] AUTOINCREMENT PRIMARY KEY,
    [Name] TEXT(100),
    [InputCode] TEXT(50),
    [Remark] TEXT(255)
);

CREATE TABLE [CardInfo] (
    [Id] AUTOINCREMENT PRIMARY KEY,
    [CardNo] TEXT(50),
    [TruckNo] TEXT(50),
    [Remark] TEXT(255)
);

CREATE TABLE [Contractlist] (
    [Id] AUTOINCREMENT PRIMARY KEY,
    [ContractNo] TEXT(50),
    [Sender] TEXT(100),
    [Receiver] TEXT(100),
    [Product] TEXT(100),
    [ContractAmount] CURRENCY,
    [Remark] TEXT(255)
);

CREATE TABLE [UserList] (
    [Id] AUTOINCREMENT PRIMARY KEY,
    [UserId] TEXT(50),
    [LogName] TEXT(50),
    [UserName] TEXT(50),
    [GroupName] TEXT(50),
    [Password] TEXT(100),
    [Remark] TEXT(255)
);

CREATE TABLE [UserGroup] (
    [GroupId] AUTOINCREMENT PRIMARY KEY,
    [GroupName] TEXT(50),
    [Remark] TEXT(255)
);

CREATE TABLE [UserRoleCtrl] (
    [Id] AUTOINCREMENT PRIMARY KEY,
    [GroupId] LONG,
    [ModelId] LONG,
    [ModelChnName] TEXT(100),
    [Search] BIT,
    [Edit] BIT,
    [Other1] BIT,
    [Other2] BIT
);

CREATE TABLE [StationList] (
    [Id] AUTOINCREMENT PRIMARY KEY,
    [StationNo] TEXT(50),
    [StationName] TEXT(100),
    [Remark] TEXT(255)
);

CREATE TABLE [LogInfo] (
    [LogId] AUTOINCREMENT PRIMARY KEY,
    [KeyValue] TEXT(255),
    [Operator] TEXT(50),
    [LogTime] DATETIME,
    [OptType] TEXT(50),
    [ModuleId] TEXT(50),
    [ModuleName] TEXT(100),
    [LogBeforeData] MEMO,
    [LogAfterData] MEMO,
    [Reason] TEXT(255)
);

CREATE TABLE [SysMenuClassList] (
    [ClassId] AUTOINCREMENT PRIMARY KEY,
    [ChnText] TEXT(100),
    [EngText] TEXT(100),
    [OrderNum] LONG
);

CREATE TABLE [SysMenuList] (
    [MenuId] AUTOINCREMENT PRIMARY KEY,
    [ClassId] LONG,
    [ChnText] TEXT(100),
    [EngText] TEXT(100),
    [ImageIndex] LONG,
    [OrderNum] LONG,
    [CanUseFlag] BIT,
    [OperatorText] TEXT(255)
);

CREATE TABLE [Report] (
    [ReportId] AUTOINCREMENT PRIMARY KEY,
    [ReportName] TEXT(100),
    [ReportCHNName] TEXT(100),
    [ReportSQL] MEMO,
    [ReportType] TEXT(50),
    [Root] TEXT(255)
);

CREATE TABLE [TFieldNameList] (
    [Id] AUTOINCREMENT PRIMARY KEY,
    [FieldName] TEXT(50),
    [ChnName] TEXT(100),
    [EngName] TEXT(100)
);

CREATE TABLE [MainPosition] (
    [Id] AUTOINCREMENT PRIMARY KEY,
    [ScaleMode] TEXT(20),
    [FieldName] TEXT(50),
    [CtrlName] TEXT(100),
    [Top] LONG,
    [Left] LONG,
    [Height] LONG,
    [Width] LONG,
    [FontName] TEXT(50),
    [FontSize] REAL,
    [FontItalic] BIT,
    [FontBold] BIT,
    [BackColor] TEXT(50),
    [ForeColor] TEXT(50),
    [LabelCaption] TEXT(100),
    [TabOrder] LONG,
    [IsVisible] BIT,
    [IsReadOnly] BIT,
    [IsClear] BIT,
    [IsMustFill] BIT,
    [IsMustExist] BIT,
    [Formula] TEXT(255)
);

CREATE TABLE [SpareStr1] (
    [Id] AUTOINCREMENT PRIMARY KEY,
    [KeyField] TEXT(255),
    [ValueField] TEXT(255)
);

CREATE TABLE [SpareStr2] (
    [Id] AUTOINCREMENT PRIMARY KEY,
    [KeyField] TEXT(255),
    [ValueField] TEXT(255)
);

CREATE TABLE [SpareStr3] (
    [Id] AUTOINCREMENT PRIMARY KEY,
    [KeyField] TEXT(255),
    [ValueField] TEXT(255)
);

CREATE TABLE [SpareStr4] (
    [Id] AUTOINCREMENT PRIMARY KEY,
    [KeyField] TEXT(255),
    [ValueField] TEXT(255)
);

CREATE TABLE [SpareStr5] (
    [Id] AUTOINCREMENT PRIMARY KEY,
    [KeyField] TEXT(255),
    [ValueField] TEXT(255)
);

CREATE TABLE [SpareStr6] (
    [Id] AUTOINCREMENT PRIMARY KEY,
    [KeyField] TEXT(255),
    [ValueField] TEXT(255)
);

CREATE TABLE [SpareStr7] (
    [Id] AUTOINCREMENT PRIMARY KEY,
    [KeyField] TEXT(255),
    [ValueField] TEXT(255)
);

CREATE TABLE [SpareStr8] (
    [Id] AUTOINCREMENT PRIMARY KEY,
    [KeyField] TEXT(255),
    [ValueField] TEXT(255)
);

CREATE TABLE [SpecifList] (
    [Id] AUTOINCREMENT PRIMARY KEY,
    [SpecifName] TEXT(100),
    [Remark] TEXT(255)
);

CREATE TABLE [PictureList] (
    [Id] AUTOINCREMENT PRIMARY KEY,
    [PictureName] TEXT(100),
    [PictureData] LONGBINARY,
    [RecordId] LONG,
    [Remark] TEXT(255)
);

CREATE TABLE [TrendLineList] (
    [Id] AUTOINCREMENT PRIMARY KEY,
    [RecordId] LONG,
    [WeightData] DATETIME,
    [WeightValue] LONG,
    [StableFlag] BIT
);

CREATE TABLE [KeyList] (
    [Id] AUTOINCREMENT PRIMARY KEY,
    [KeyName] TEXT(50),
    [KeyValue] TEXT(255),
    [Remark] TEXT(255)
);
