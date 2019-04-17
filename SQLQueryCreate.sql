create database QLHV

use QLHV

create table Student
(
	StudentID int identity(1,1) primary key,
	StudentName nvarchar(50) not null,
	PhoneNum nvarchar(50) ,
	StuAddress nvarchar(50),
	RegistryDate datetime,
	StudentClassID int foreign key(StudentClassID) references Class(ClassID),
)

create table Class
(
	ClassID int constraint PK_Class primary key,
	ClassName nvarchar(50) not null,
	ClassDetail nvarchar(max),

)

create table Fees
(
	Amount bigint ,
	Is_pay bit ,
	StudentID int foreign key references Student(StudentID)

)

create table Account
(
	AccID int identity(1,10) primary key,
	username nvarchar(50),
	Pass nvarchar(max),
	is_admin bit not null,
)