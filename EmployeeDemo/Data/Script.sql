CREATE DATABASE Employee_DB

 CREATE TABLE Employee_Mst(
	EmployeeId int NOT NULL IDENTITY(1,1) PRIMARY KEY,
	EmployeeName [nvarchar](50) NOT NULL,
	Gender [nvarchar](50) NOT NULL,
	DOB date NOT NULL,
	Department [nvarchar](50) NOT NULL,
	MobileNo [nvarchar](50) NOT NULL,
	Address [nvarchar](50) NOT NULL,
	UserName [nvarchar](50) NOT NULL,
	Passoword [nvarchar](50) NOT NULL

)	

ALTER TABLE Employee_Mst
 ALTER COLUMN Address nvarchar(max) NOT NULL;

 select *from Employee_Mst

 ALTER TABLE Employee_Mst
 ADD  DepartmentId int FOREIGN KEY REFERENCES Department_Mst(DepartmentId);

 CREATE TABLE Department_Mst(
	DepartmentId int NOT NULL IDENTITY(1,1) PRIMARY KEY,
	DepartmentName [nvarchar](50) NOT NULL,
)	
INSERT INTO Department_Mst
VALUES ('CSE');
INSERT INTO Department_Mst
VALUES ('IT');
INSERT INTO Department_Mst
VALUES ('Mech');
select * from Department_Mst


