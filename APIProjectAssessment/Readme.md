CREATE TABLE Tbl_DataDetail (
    Id INT PRIMARY KEY IDENTITY(1,1),
    DeviceId NVARCHAR(MAX),
    DeviceType NVARCHAR(MAX),
    DeviceName NVARCHAR(MAX),
    GroupId NVARCHAR(MAX),
    DataType NVARCHAR(MAX),
    Temperature INT,
    Humidity INT,
    Occupancy BIT,
    Timestamp INT
);

--drop table Tbl_DataDetail


CREATE TABLE Tbl_Address (
    AddressID INT PRIMARY KEY IDENTITY(1,1),
    Name NVARCHAR(100),
    ParentID INT,
    FOREIGN KEY (ParentID) REFERENCES Tbl_Address(AddressID)
);
