-- ScaleControl Database Creation Script
-- MS Access / Jet SQL Syntax
-- Matches TOLEDO AVS table structure

CREATE TABLE Trade (
    Id AUTOINCREMENT PRIMARY KEY,
    TicketNo1 VARCHAR(50),
    TicketNo2 VARCHAR(50),
    Station1 VARCHAR(50),
    Station2 VARCHAR(50),
    ScaleNo1 VARCHAR(50),
    ScaleNo2 VARCHAR(50),
    TruckNo VARCHAR(50),
    CardNo VARCHAR(50),
    ContractNo VARCHAR(50),
    Product VARCHAR(100),
    ProductCode VARCHAR(50),
    Specification VARCHAR(100),
    Sender VARCHAR(100),
    Receiver VARCHAR(100),
    Transporter VARCHAR(100),
    FirstDateTime DATETIME,
    SecondDateTime DATETIME,
    GrossDateTime DATETIME,
    TareDateTime DATETIME,
    FirstWeight LONG,
    SecondWeight LONG,
    Gross LONG,
    Tare LONG,
    Net LONG,
    ProductNet CURRENCY,
    ExceptWater CURRENCY,
    ExceptOther CURRENCY,
    UserId1 VARCHAR(50),
    UserName1 VARCHAR(50),
    UserId2 VARCHAR(50),
    UserName2 VARCHAR(50),
    Bc1 VARCHAR(50),
    Bc2 VARCHAR(50),
    ScaleWeightFlag VARCHAR(10),
    SpareFlag VARCHAR(10),
    UploadFlag VARCHAR(10) DEFAULT '0',
    DataEditFlag VARCHAR(10) DEFAULT '0',
    DataStatus VARCHAR(10) DEFAULT '1',
    ManualInputFlag VARCHAR(10) DEFAULT '0',
    ScaleMode VARCHAR(20),
    FinalFlag VARCHAR(10) DEFAULT '0',
    LeftWeight LONG,
    TareWeightAlarmFlag VARCHAR(10) DEFAULT '0',
    TareTimeAlarmFlag VARCHAR(10) DEFAULT '0',
    WeightTimeAlarmFlag VARCHAR(10) DEFAULT '0',
    AutoSaveFlag VARCHAR(10) DEFAULT '0',
    AuthFlag VARCHAR(10) DEFAULT '0',
    Driver VARCHAR(50),
    BusinessNo VARCHAR(50),
    IdNumber VARCHAR(50),
    BusinessType VARCHAR(50),
    MaxGross LONG,
    MaxNet LONG,
    OwsCheckType VARCHAR(20),
    ReprintCount LONG DEFAULT 0,
    IdentifyTruckNo1 VARCHAR(50),
    IdentifyTruckNo2 VARCHAR(50),
    SpareStr1 VARCHAR(255),
    SpareStr2 VARCHAR(255),
    SpareStr3 VARCHAR(255),
    SpareStr4 VARCHAR(255),
    SpareStr5 VARCHAR(255),
    SpareStr6 VARCHAR(255),
    SpareStr7 VARCHAR(255),
    SpareStr8 VARCHAR(255),
    SpareStr9 VARCHAR(255),
    SpareStr10 VARCHAR(255),
    SpareStr11 VARCHAR(255),
    SpareStr12 VARCHAR(255),
    SpareStr13 VARCHAR(255),
    SpareStr14 VARCHAR(255),
    SpareStr15 VARCHAR(255),
    SpareNum1 CURRENCY,
    SpareNum2 CURRENCY,
    SpareNum3 CURRENCY,
    SpareNum4 CURRENCY,
    SpareNum5 CURRENCY,
    SpareNum6 CURRENCY,
    SpareNum7 CURRENCY,
    SpareNum8 CURRENCY
);
GO

CREATE TABLE TruckList (
    TruckNo VARCHAR(50) PRIMARY KEY,
    Tare LONG DEFAULT 0,
    TareDate DATETIME,
    InputCode VARCHAR(50),
    EffectDay LONG DEFAULT 0,
    Remark VARCHAR(255),
    MaxGross LONG,
    MaxNet LONG,
    OwsCheckType VARCHAR(20)
);
GO

CREATE TABLE ProductList (
    Id AUTOINCREMENT PRIMARY KEY,
    ProductName VARCHAR(100),
    Code VARCHAR(50),
    InputCode VARCHAR(50),
    Remark VARCHAR(255),
    EnableMaxNetLimit YESNO DEFAULT FALSE,
    MaxNetLimit LONG DEFAULT 0
);
GO

CREATE TABLE SenderList (
    Id AUTOINCREMENT PRIMARY KEY,
    Name VARCHAR(100),
    InputCode VARCHAR(50),
    Remark VARCHAR(255)
);
GO

CREATE TABLE ReceiverList (
    Id AUTOINCREMENT PRIMARY KEY,
    Name VARCHAR(100),
    InputCode VARCHAR(50),
    Remark VARCHAR(255)
);
GO

CREATE TABLE TransporterList (
    Id AUTOINCREMENT PRIMARY KEY,
    Name VARCHAR(100),
    InputCode VARCHAR(50),
    Remark VARCHAR(255)
);
GO

CREATE TABLE CardInfo (
    Id AUTOINCREMENT PRIMARY KEY,
    CardNo VARCHAR(50),
    TruckNo VARCHAR(50),
    Remark VARCHAR(255)
);
GO

CREATE TABLE Contractlist (
    Id AUTOINCREMENT PRIMARY KEY,
    ContractNo VARCHAR(50),
    Sender VARCHAR(100),
    Receiver VARCHAR(100),
    Product VARCHAR(100),
    ContractAmount CURRENCY,
    Remark VARCHAR(255)
);
GO

CREATE TABLE UserList (
    Id AUTOINCREMENT PRIMARY KEY,
    UserId VARCHAR(50),
    LogName VARCHAR(50),
    UserName VARCHAR(50),
    GroupName VARCHAR(50),
    Password VARCHAR(100),
    Remark VARCHAR(255)
);
GO

CREATE TABLE UserGroup (
    GroupId AUTOINCREMENT PRIMARY KEY,
    GroupName VARCHAR(50),
    Remark VARCHAR(255)
);
GO

CREATE TABLE UserRoleCtrl (
    Id AUTOINCREMENT PRIMARY KEY,
    GroupId LONG,
    ModelId LONG,
    ModelChnName VARCHAR(100),
    Search YESNO DEFAULT FALSE,
    Edit YESNO DEFAULT FALSE,
    Other1 YESNO DEFAULT FALSE,
    Other2 YESNO DEFAULT FALSE
);
GO

CREATE TABLE StationList (
    Id AUTOINCREMENT PRIMARY KEY,
    StationNo VARCHAR(50),
    StationName VARCHAR(100),
    Remark VARCHAR(255)
);
GO

CREATE TABLE LogInfo (
    LogId AUTOINCREMENT PRIMARY KEY,
    KeyValue VARCHAR(255),
    Operator VARCHAR(50),
    LogTime DATETIME,
    OptType VARCHAR(50),
    ModuleId VARCHAR(50),
    ModuleName VARCHAR(100),
    LogBeforeData MEMO,
    LogAfterData MEMO,
    Reason VARCHAR(255)
);
GO

CREATE TABLE SysMenuClassList (
    ClassId AUTOINCREMENT PRIMARY KEY,
    ChnText VARCHAR(100),
    EngText VARCHAR(100),
    OrderNum LONG DEFAULT 0
);
GO

CREATE TABLE SysMenuList (
    MenuId AUTOINCREMENT PRIMARY KEY,
    ClassId LONG,
    ChnText VARCHAR(100),
    EngText VARCHAR(100),
    ImageIndex LONG DEFAULT 0,
    OrderNum LONG DEFAULT 0,
    CanUseFlag YESNO DEFAULT TRUE,
    OperatorText VARCHAR(255)
);
GO

CREATE TABLE Report (
    ReportId AUTOINCREMENT PRIMARY KEY,
    ReportName VARCHAR(100),
    ReportCHNName VARCHAR(100),
    ReportSQL MEMO,
    ReportType VARCHAR(50),
    Root VARCHAR(255)
);
GO

CREATE TABLE TFieldNameList (
    Id AUTOINCREMENT PRIMARY KEY,
    FieldName VARCHAR(50),
    ChnName VARCHAR(100),
    EngName VARCHAR(100)
);
GO

CREATE TABLE MainPosition (
    Id AUTOINCREMENT PRIMARY KEY,
    ScaleMode VARCHAR(20),
    FieldName VARCHAR(50),
    CtrlName VARCHAR(100),
    Top LONG DEFAULT 0,
    Left LONG DEFAULT 0,
    Height LONG DEFAULT 0,
    Width LONG DEFAULT 0,
    FontName VARCHAR(50),
    FontSize SINGLE DEFAULT 0,
    FontItalic YESNO DEFAULT FALSE,
    FontBold YESNO DEFAULT FALSE,
    BackColor VARCHAR(50),
    ForeColor VARCHAR(50),
    LabelCaption VARCHAR(100),
    TabOrder LONG DEFAULT 0,
    IsVisible YESNO DEFAULT TRUE,
    IsReadOnly YESNO DEFAULT FALSE,
    IsClear YESNO DEFAULT FALSE,
    IsMustFill YESNO DEFAULT FALSE,
    IsMustExist YESNO DEFAULT FALSE,
    Formula VARCHAR(255)
);
GO

CREATE TABLE SpareStr1 (
    Id AUTOINCREMENT PRIMARY KEY,
    KeyField VARCHAR(255),
    ValueField VARCHAR(255)
);
GO

CREATE TABLE SpareStr2 (
    Id AUTOINCREMENT PRIMARY KEY,
    KeyField VARCHAR(255),
    ValueField VARCHAR(255)
);
GO

CREATE TABLE SpareStr3 (
    Id AUTOINCREMENT PRIMARY KEY,
    KeyField VARCHAR(255),
    ValueField VARCHAR(255)
);
GO

CREATE TABLE SpareStr4 (
    Id AUTOINCREMENT PRIMARY KEY,
    KeyField VARCHAR(255),
    ValueField VARCHAR(255)
);
GO

CREATE TABLE SpareStr5 (
    Id AUTOINCREMENT PRIMARY KEY,
    KeyField VARCHAR(255),
    ValueField VARCHAR(255)
);
GO

CREATE TABLE SpareStr6 (
    Id AUTOINCREMENT PRIMARY KEY,
    KeyField VARCHAR(255),
    ValueField VARCHAR(255)
);
GO

CREATE TABLE SpareStr7 (
    Id AUTOINCREMENT PRIMARY KEY,
    KeyField VARCHAR(255),
    ValueField VARCHAR(255)
);
GO

CREATE TABLE SpareStr8 (
    Id AUTOINCREMENT PRIMARY KEY,
    KeyField VARCHAR(255),
    ValueField VARCHAR(255)
);
GO

CREATE TABLE SpecifList (
    Id AUTOINCREMENT PRIMARY KEY,
    SpecifName VARCHAR(100),
    Remark VARCHAR(255)
);
GO

CREATE TABLE PictureList (
    Id AUTOINCREMENT PRIMARY KEY,
    PictureName VARCHAR(100),
    PictureData OLEOBJECT,
    RecordId LONG,
    Remark VARCHAR(255)
);
GO

CREATE TABLE TrendLineList (
    Id AUTOINCREMENT PRIMARY KEY,
    RecordId LONG,
    WeightData DATETIME,
    WeightValue LONG,
    StableFlag YESNO DEFAULT FALSE
);
GO

CREATE TABLE KeyList (
    Id AUTOINCREMENT PRIMARY KEY,
    KeyName VARCHAR(50),
    KeyValue VARCHAR(255),
    Remark VARCHAR(255)
);
GO
