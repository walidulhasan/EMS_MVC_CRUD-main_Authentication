USE master
GO

DROP DATABASE IF EXISTS EMSeVidenceExam
GO

CREATE DATABASE EMSeVidenceExam
ON
(
	NAME= EMSeVidenceExam,
	FILENAME='C:\Program Files\Microsoft SQL Server\MSSQL15.MAHMUDSABUJ\MSSQL\DATA\EMSeVidenceExam.mdf',
	SIZE=10MB,
	MAXSIZE=1GB,
	FILEGROWTH=10%
)
LOG ON
(
	NAME=EMSeVidenceExam_log,
	FILENAME='C:\Program Files\Microsoft SQL Server\MSSQL15.MAHMUDSABUJ\MSSQL\DATA\EMSeVidenceExam_log.ldf',
	SIZE=10MB,
	MAXSIZE=1GB,
	FILEGROWTH=10%
)
GO
USE EMSeVidenceExam
GO

--CREATE TABLE loginInfo
--(
--	userName VARCHAR(30) NOT NULL,
--	userPassword VARCHAR(10) NOT NULL,
--	userEmail VARCHAR(30) NOT NULL
--)
--Go

--CREATE TABLE tblBranch
--(
--	bId INT IDENTITY(10,1) PRIMARY KEY,
--	bCode VARCHAR(20) NOT NULL UNIQUE,
--	bNameCode VARCHAR(30) NOT NULL,
--	bDistrictName VARCHAR(30) NOT NULL,
--	bSubDistrict VARCHAR(30) NOT NULL,
--	bAddress VARCHAR(30) NOT NULL
--)
--GO

--CREATE TABLE tblOfficial
--(
--	eoId INT PRIMARY KEY NOT NULL,
--	eoPrePosition VARCHAR(50) NOT NULL,
--	eoPresPosition VARCHAR(50) NOT NULL,
--	eoPromPosition VARCHAR(50),
--	bId INT REFERENCES tblBranch(bId),
--	eoBranch VARCHAR(50) NOT NULL
--)
--GO

CREATE TABLE tblEpersonla
(
	eId INT PRIMARY KEY NOT NULL IDENTITY(100,1),
	eTitle NVARCHAR(10) NOT NULL,
	eName VARCHAR(50) NOT NULL,
	eDob DATE NOT NULL,
	eGender VARCHAR(7) NOT NULL,
	eNationalIdNo CHAR(13) UNIQUE NOT NULL,
	ePhoneNo VARCHAR(15) NOT NULL,
	eEmail VARCHAR(50) NOT NULL,
	eMeritals VARCHAR(30) NOT NULL,
	eJoinDate DATE NOT NULL,
	eImage VARCHAR(200) NULL,
)
GO

INSERT INTO tblEpersonla VALUES('Mr','Kamal','10/11/1993','Male','1234267648','01835534503','fiverrwalid@gmail.com','Unmarried','10/11/2021','mo.Jpg')
INSERT INTO tblEpersonla VALUES('Ms','Tammna','10/11/1995','Female','5753367648','01935538903','fiverrwalid@gmail.com','Unmarried','10/11/2021','ui.Jpg')
INSERT INTO tblEpersonla VALUES('Mr','Kamal','10/11/1994','Male','34537687648','01535538903','fiverrwalid@gmail.com','Unmarried','10/11/2019','lo.Jpg')
INSERT INTO tblEpersonla VALUES('Ms','Khushi','10/11/1990','Female','34337648','01735538903','fiverrwalid@gmail.com','Unmarried','10/11/2010','na.Jpg')
INSERT INTO tblEpersonla VALUES('Ms','Tania','10/11/1993','Female','3434367648','01735538903','fiverrwalid@gmail.com','Unmarried','10/11/1999','ra.Jpg')
INSERT INTO tblEpersonla VALUES('Mr','Kamal','10/11/1993','Male','0045367648','01735538903','fiverrwalid@gmail.com','Unmarried','10/11/1992','rt.Jpg')
INSERT INTO tblEpersonla VALUES('Mr','Kamal','10/11/1993','Male','9145367648','01735538903','fiverrwalid@gmail.com','Unmarried','10/11/2021','yy.Jpg')
INSERT INTO tblEpersonla VALUES('Mr','Kamal','10/11/1993','Male','0987367648','01735538903','fiverrwalid@gmail.com','Unmarried','10/11/2021','ka.Jpg')
INSERT INTO tblEpersonla VALUES('Mr','Kamal','10/11/1993','Male','0987367648','01735538903','fiverrwalid@gmail.com','Unmarried','10/11/2021','ka.Jpg')
INSERT INTO tblEpersonla VALUES('Mr','Kamal','10/11/1993','Male','0987367648','01735538903','fiverrwalid@gmail.com','Unmarried','10/11/2021','ka.Jpg')
GO
--select * from tblEpersonla
--CREATE INDEX IX_tblEpersonla_NAME
--    ON tblEpersonla
--    (eName)
--GO

--CREATE TABLE tblESalary
--(
--	salaryId INT IDENTITY(1000,1) PRIMARY KEY,
--	basicPay INT CHECK(basicPay>=8000) NOT NULL,
--	houseRent INT NOT NULL,
--	medicalAllowance INT CHECK(medicalAllowance<=1500) NOT NULL DEFAULT 0,
--	travle_allowance INT CHECK(travle_allowance<=2000) NOT NULL DEFAULT 0,
--	childrenEallwanc INT CHECK(childrenEallwanc<=500) NOT NULL DEFAULT 0,
--	grossSalary AS basicPay+houseRent+medicalAllowance+travle_allowance+childrenEallwanc,
--	loan INT DEFAULT 0 NOT NULL,
--	Gpf_Cpf INT DEFAULT 0 NOT NULL,
--	salaryDate DATE NOT NULL DEFAULT GETDATE(),
--	eId INT REFERENCES tblEpersonla(eId),
--	Cut_from_GrossSalary AS loan+Gpf_Cpf,
--	Net_Salary_Paid AS (basicPay+houseRent+medicalAllowance+travle_allowance+childrenEallwanc)-(loan+Gpf_Cpf)
--)
--GO

/*SELECT  EP.eId AS 'Employee Id',EP.eTitle AS Title,EP.eName AS Name,EP.eDob AS 'Date of Birth',EP.eFatherName AS 'Father Name',EP.eGender AS Gender,EP.ePhoneNo AS 'Phone No',EP.eNationalIdNo AS 'National ID',EP.eEmail AS Email,EP.eSocialId AS 'Social Id',EP.eMeritals AS 'Merital Status',
EP.eJoinDate AS 'Join Date',EP.eImage AS 'Image',FO.eoPresPosition AS Position,FO.eoPrePosition AS 'Previous Position',AC.eaMast AS 'Academic Exam',AC.Mast_result AS 'Result',AC.eaSpecial AS 'Special Exam',AC.Special_result AS Result,BR.bNameCode AS 'Branch Code',SA.basicPay AS 'Salary Basic',
SA.houseRent AS 'House Rent',SA.medicalAllowance AS 'Medical Allowance',SA.travle_allowance AS 'Travle Allowance',SA.childrenEallwanc AS 'Children Allowance'
,SA.grossSalary AS 'Gross Salary',SA.loan AS Load,SA.Gpf_Cpf AS 'GP Fund',SA.salaryDate AS 'Salary Date',SA.Cut_from_GrossSalary AS 'Cut From Salary',SA.Net_Salary_Paid AS 'Salary Paid'   FROM tblEpersonla EP 
INNER JOIN tblAcademic AC ON EP.eaId=AC.eaId
INNER JOIN tblOfficial FO ON EP.eoId=FO.eoId
INNER JOIN tblESalary SA ON EP.eId=SA.eId
INNER JOIN tblBranch BR ON FO.bId=BR.bId --where ep.eId=122
GO*/
CREATE TABLE tblPosition
(
	positionId INT PRIMARY KEY IDENTITY(1,1),
	Position VARCHAR(50) NOT NULL
)
GO
INSERT INTO tblPosition VALUES ('General manager')
INSERT INTO tblPosition VALUES ('Admin')
select * from tblPosition

CREATE TABLE tblEmployees
(
	eId INT PRIMARY KEY NOT NULL IDENTITY(100,1),
	Title NVARCHAR(10) NOT NULL,
	eName VARCHAR(50) NOT NULL,
	DateOfBirth DATE NOT NULL,
	eGender VARCHAR(7) NOT NULL,
	PhoneNo VARCHAR(15) NOT NULL,
	positionId INT REFERENCES tblPosition(positionId) on delete cascade ,
	eImage VARCHAR(200) NULL
)
GO
select * from tblEmployees
delete from tblEmployees
drop table tblEmployees
INSERT INTO tblEmployees VALUES ('Mr','Kamal Hossen','10/11/1995','Male','01735538903',27,'kag.jpg')

