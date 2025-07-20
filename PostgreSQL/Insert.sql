create database productsDb;
go

use productsDb;

create table Products
(
Id int identity primary key,
ProductName nvarchar(30) not null,
Manufacturer nvarchar(30) not null,
ProductCount int default 0,
Price money not null
)
go

insert into Products 
values
('iPhone 6', 'Apple', 3, 36000),
('Galaxy S8', 'Samsung', 2, 46000),
('Galaxy S8 Plus', 'Samsung', 1, 56000),
('Mi6', 'Xiaomi', default, 28000)
go