/*create table History 
(
    Id int Identity primary key,
    ProductId int not null,
    Operation nvarchar(200) not null,
    CreateAt datetime not null default GetDate()
)
GO

create trigger Product_INSERT on Products
after Insert as
insert into History (ProductId, Operation)
select Id, 'Goods added: ' + ProductName + '    Manufacturer ' + Manufacturer
from Inserted
go*/

/*
insert into Products (ProductName, Manufacturer, ProductCount, Price)
values('iPhone 11', 'Apple', 2, 150000)*/

/*
create trigger Products_DELETE on Products
after Delete AS
insert into History(ProductId, Operation)
select Id, 'Goods deleted: '+ ProductName+ '; Manufacturer: '+ Manufacturer
from Deleted
go
*/

/*delete from Products where Id = 30*/

/*
create trigger Products_UPDATE on Products
after Update as
insert into History(ProductId, Operation)
select Id, 'Goods updated: ' + ProductName+ '; Manufacturer: '+ Manufacturer
from Inserted
GO
*/

insert into Products(ProductName, Manufacturer, ProductCount, Price)
values ('C350', 'Motorola', 10, 3000)

update Products set Manufacturer = 'Moto'
where Manufacturer = 'Motorola'

select * from History