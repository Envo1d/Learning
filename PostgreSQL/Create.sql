create database internetstore;
go 

use internetstore;

create table Customers
(
Id int primary key identity,
Age int default 18,
FirstName nvarchar(20) not null,
LastName nvarchar(20) not null,
Email varchar(30) unique,
Phone varchar(20) unique
);

create table Orders
(
Id int primary key identity,
CustomerId int,
CreatedAt date,
constraint FK_Orders_To_Customers foreign key (CustomerId) references Customers (Id) on delete cascade
)