create database prods
go

use prods;

create table Products
(
    Id int identity primary key,
    ProductName nvarchar(30) not null,
    Manufacturer nvarchar(30) not null,
    Price money not null,
    IsDeleted bit null
)
GO

create trigger Products_Delete on Products
instead of Delete
as Update Products set IsDeleted = 1
where Id = (select Id from Deleted)
go

insert into Products(ProductName, Manufacturer, Price)
values ('iPhone X', 'Apple', 79000),
('Pixel 2', 'Google', 60000);
go

select * from Products
go

delete from Products where ProductName = 'Pixel 2';
go

select * from Products
go