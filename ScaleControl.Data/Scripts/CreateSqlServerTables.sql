CREATE TABLE [Trade] (
    [Id] INT IDENTITY(1,1) PRIMARY KEY,
    [TicketNo1] NVARCHAR(50),
    [TicketNo2] NVARCHAR(50),
    [Station1] NVARCHAR(50),
    [Station2] NVARCHAR(50),
    [ScaleNo1] NVARCHAR(50),
    [ScaleNo2] NVARCHAR(50),
    [TruckNo] NVARCHAR(50),
    [CardNo] NVARCHAR(50),
    [ContractNo] NVARCHAR(50),
    [Product] NVARCHAR(100),
    [ProductCode] NVARCHAR(50),
    [Specification] NVARCHAR(100),
    [Sender] NVARCHAR(100),
    [Receiver] NVARCHAR(100),
    [Transporter] NVARCHAR(100),
    [FirstDateTime] DATETIME,
    [SecondDateTime] DATETIME,
    [GrossDateTime] DATETIME,
    [TareDateTime] DATETIME,
    [FirstWeight] INT,
    [SecondWeight] INT,
    [Gross] INT,
    [Tare] INT,
    [Net] INT,
    [ProductNet] DECIMAL(18,2),
    [ExceptWater] DECIMAL(18,2),
    [ExceptOther] DECIMAL(18,2),
    [UserId1] NVARCHAR(50),
    [UserName1] NVARCHAR(50),
    [UserId2] NVARCHAR(50),
    [UserName2] NVARCHAR(50),
    [Bc1] NVARCHAR(50),
    [Bc2] NVARCHAR(50),
    [ScaleWeightFlag] NVARCHAR(10),
    [SpareFlag] NVARCHAR(10),
    [UploadFlag] NVARCHAR(10),
    [DataEditFlag] NVARCHAR(10),
    [DataStatus] NVARCHAR(10),
    [ManualInputFlag] NVARCHAR(10),
    [ScaleMode] NVARCHAR(20),
    [FinalFlag] NVARCHAR(10),
    [LeftWeight] INT,
    [TareWeightAlarmFlag] NVARCHAR(10),
    [TareTimeAlarmFlag] NVARCHAR(10),
    [WeightTimeAlarmFlag] NVARCHAR(10),
    [AutoSaveFlag] NVARCHAR(10),
    [AuthFlag] NVARCHAR(10),
    [Driver] NVARCHAR(50),
    [BusinessNo] NVARCHAR(50),
    [IdNumber] NVARCHAR(50),
    [BusinessType] NVARCHAR(50),
    [MaxGross] INT,
    [MaxNet] INT,
    [OwsCheckType] NVARCHAR(20),
    [ReprintCount] INT,
    [IdentifyTruckNo1] NVARCHAR(50),
    [IdentifyTruckNo2] NVARCHAR(50),
    [SpareStr1] NVARCHAR(255),
    [SpareStr2] NVARCHAR(255),
    [SpareStr3] NVARCHAR(255),
    [SpareStr4] NVARCHAR(255),
    [SpareStr5] NVARCHAR(255),
    [SpareStr6] NVARCHAR(255),
    [SpareStr7] NVARCHAR(255),
    [SpareStr8] NVARCHAR(255),
    [SpareStr9] NVARCHAR(255),
    [SpareStr10] NVARCHAR(255),
    [SpareStr11] NVARCHAR(255),
    [SpareStr12] NVARCHAR(255),
    [SpareStr13] NVARCHAR(255),
    [SpareStr14] NVARCHAR(255),
    [SpareStr15] NVARCHAR(255),
    [SpareNum1] DECIMAL(18,2),
    [SpareNum2] DECIMAL(18,2),
    [SpareNum3] DECIMAL(18,2),
    [SpareNum4] DECIMAL(18,2),
    [SpareNum5] DECIMAL(18,2),
    [SpareNum6] DECIMAL(18,2),
    [SpareNum7] DECIMAL(18,2),
    [SpareNum8] DECIMAL(18,2)
);

CREATE TABLE [TruckList] (
    [TruckNo] NVARCHAR(50) PRIMARY KEY,
    [Tare] INT,
    [TareDate] DATETIME,
    [InputCode] NVARCHAR(50),
    [EffectDay] INT,
    [Remark] NVARCHAR(255),
    [MaxGross] INT,
    [MaxNet] INT,
    [OwsCheckType] NVARCHAR(20)
);

CREATE TABLE [ProductList] (
    [Id] INT IDENTITY(1,1) PRIMARY KEY,
    [ProductName] NVARCHAR(100),
    [Code] NVARCHAR(50),
    [InputCode] NVARCHAR(50),
    [Remark] NVARCHAR(255),
    [EnableMaxNetLimit] BIT,
    [MaxNetLimit] INT
);

CREATE TABLE [SenderList] (
    [Id] INT IDENTITY(1,1) PRIMARY KEY,
    [Name] NVARCHAR(100),
    [InputCode] NVARCHAR(50),
    [Remark] NVARCHAR(255)
);

CREATE TABLE [ReceiverList] (
    [Id] INT IDENTITY(1,1) PRIMARY KEY,
    [Name] NVARCHAR(100),
    [InputCode] NVARCHAR(50),
    [Remark] NVARCHAR(255)
);

CREATE TABLE [TransporterList] (
    [Id] INT IDENTITY(1,1) PRIMARY KEY,
    [Name] NVARCHAR(100),
    [InputCode] NVARCHAR(50),
    [Remark] NVARCHAR(255)
);

CREATE TABLE [CardInfo] (
    [Id] INT IDENTITY(1,1) PRIMARY KEY,
    [CardNo] NVARCHAR(50),
    [TruckNo] NVARCHAR(50),
    [Remark] NVARCHAR(255)
);

CREATE TABLE [Contractlist] (
    [Id] INT IDENTITY(1,1) PRIMARY KEY,
    [ContractNo] NVARCHAR(50),
    [Sender] NVARCHAR(100),
    [Receiver] NVARCHAR(100),
    [Product] NVARCHAR(100),
    [ContractAmount] DECIMAL(18,2),
    [Remark] NVARCHAR(255)
);

CREATE TABLE [UserList] (
    [Id] INT IDENTITY(1,1) PRIMARY KEY,
    [UserId] NVARCHAR(50),
    [LogName] NVARCHAR(50),
    [UserName] NVARCHAR(50),
    [GroupName] NVARCHAR(50),
    [Password] NVARCHAR(100),
    [Remark] NVARCHAR(255)
);

CREATE TABLE [UserGroup] (
    [GroupId] INT IDENTITY(1,1) PRIMARY KEY,
    [GroupName] NVARCHAR(50),
    [Remark] NVARCHAR(255)
);

CREATE TABLE [UserRoleCtrl] (
    [Id] INT IDENTITY(1,1) PRIMARY KEY,
    [GroupId] INT,
    [ModelId] INT,
    [ModelChnName] NVARCHAR(100),
    [Search] BIT,
    [Edit] BIT,
    [Other1] BIT,
    [Other2] BIT
);

CREATE TABLE [StationList] (
    [Id] INT IDENTITY(1,1) PRIMARY KEY,
    [StationNo] NVARCHAR(50),
    [StationName] NVARCHAR(100),
    [Remark] NVARCHAR(255)
);

CREATE TABLE [LogInfo] (
    [LogId] INT IDENTITY(1,1) PRIMARY KEY,
    [KeyValue] NVARCHAR(255),
    [Operator] NVARCHAR(50),
    [LogTime] DATETIME,
    [OptType] NVARCHAR(50),
    [ModuleId] NVARCHAR(50),
    [ModuleName] NVARCHAR(100),
    [LogBeforeData] NVARCHAR(MAX),
    [LogAfterData] NVARCHAR(MAX),
    [Reason] NVARCHAR(255)
);

CREATE TABLE [SysMenuClassList] (
    [ClassId] INT IDENTITY(1,1) PRIMARY KEY,
    [ChnText] NVARCHAR(100),
    [EngText] NVARCHAR(100),
    [OrderNum] INT
);

CREATE TABLE [SysMenuList] (
    [MenuId] INT IDENTITY(1,1) PRIMARY KEY,
    [ClassId] INT,
    [ChnText] NVARCHAR(100),
    [EngText] NVARCHAR(100),
    [ImageIndex] INT,
    [OrderNum] INT,
    [CanUseFlag] BIT,
    [OperatorText] NVARCHAR(255)
);

CREATE TABLE [Report] (
    [ReportId] INT IDENTITY(1,1) PRIMARY KEY,
    [ReportName] NVARCHAR(100),
    [ReportCHNName] NVARCHAR(100),
    [ReportSQL] NVARCHAR(MAX),
    [ReportType] NVARCHAR(50),
    [Root] NVARCHAR(255)
);

CREATE TABLE [TFieldNameList] (
    [Id] INT IDENTITY(1,1) PRIMARY KEY,
    [FieldName] NVARCHAR(50),
    [ChnName] NVARCHAR(100),
    [EngName] NVARCHAR(100)
);

CREATE TABLE [MainPosition] (
    [Id] INT IDENTITY(1,1) PRIMARY KEY,
    [ScaleMode] NVARCHAR(20),
    [FieldName] NVARCHAR(50),
    [CtrlName] NVARCHAR(100),
    [Top] INT,
    [Left] INT,
    [Height] INT,
    [Width] INT,
    [FontName] NVARCHAR(50),
    [FontSize] FLOAT,
    [FontItalic] BIT,
    [FontBold] BIT,
    [BackColor] NVARCHAR(50),
    [ForeColor] NVARCHAR(50),
    [LabelCaption] NVARCHAR(100),
    [TabOrder] INT,
    [IsVisible] BIT,
    [IsReadOnly] BIT,
    [IsClear] BIT,
    [IsMustFill] BIT,
    [IsMustExist] BIT,
    [Formula] NVARCHAR(255)
);

CREATE TABLE [SpareStr1] (
    [Id] INT IDENTITY(1,1) PRIMARY KEY,
    [KeyField] NVARCHAR(255),
    [ValueField] NVARCHAR(255)
);

CREATE TABLE [SpareStr2] (
    [Id] INT IDENTITY(1,1) PRIMARY KEY,
    [KeyField] NVARCHAR(255),
    [ValueField] NVARCHAR(255)
);

CREATE TABLE [SpareStr3] (
    [Id] INT IDENTITY(1,1) PRIMARY KEY,
    [KeyField] NVARCHAR(255),
    [ValueField] NVARCHAR(255)
);

CREATE TABLE [SpareStr4] (
    [Id] INT IDENTITY(1,1) PRIMARY KEY,
    [KeyField] NVARCHAR(255),
    [ValueField] NVARCHAR(255)
);

CREATE TABLE [SpareStr5] (
    [Id] INT IDENTITY(1,1) PRIMARY KEY,
    [KeyField] NVARCHAR(255),
    [ValueField] NVARCHAR(255)
);

CREATE TABLE [SpareStr6] (
    [Id] INT IDENTITY(1,1) PRIMARY KEY,
    [KeyField] NVARCHAR(255),
    [ValueField] NVARCHAR(255)
);

CREATE TABLE [SpareStr7] (
    [Id] INT IDENTITY(1,1) PRIMARY KEY,
    [KeyField] NVARCHAR(255),
    [ValueField] NVARCHAR(255)
);

CREATE TABLE [SpareStr8] (
    [Id] INT IDENTITY(1,1) PRIMARY KEY,
    [KeyField] NVARCHAR(255),
    [ValueField] NVARCHAR(255)
);

CREATE TABLE [SpecifList] (
    [Id] INT IDENTITY(1,1) PRIMARY KEY,
    [SpecifName] NVARCHAR(100),
    [Remark] NVARCHAR(255)
);

CREATE TABLE [PictureList] (
    [Id] INT IDENTITY(1,1) PRIMARY KEY,
    [PictureName] NVARCHAR(100),
    [PictureData] VARBINARY(MAX),
    [RecordId] INT,
    [Remark] NVARCHAR(255)
);

CREATE TABLE [TrendLineList] (
    [Id] INT IDENTITY(1,1) PRIMARY KEY,
    [RecordId] INT,
    [WeightData] DATETIME,
    [WeightValue] INT,
    [StableFlag] BIT
);

CREATE TABLE [KeyList] (
    [Id] INT IDENTITY(1,1) PRIMARY KEY,
    [KeyName] NVARCHAR(50),
    [KeyValue] NVARCHAR(255),
    [Remark] NVARCHAR(255)
);
