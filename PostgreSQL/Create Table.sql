create database usersdb
go

use usersdb

create table Customers
(
Id int primary key identity,
 Age int default 18,
 FirstName nvarchar(20) not null,
 LastName nvarchar(20) not null,
 Email varchar(20) unique,
 Phone varchar(20) unique,
 CHECK((Age >0 AND Age<100) AND (Email !='') AND (Phone !=''))
)