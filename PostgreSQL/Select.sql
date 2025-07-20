use productsDb;

select * from Products
go

select ProductName, Price from Products
go

select (ProductName + ' (' + Manufacturer + ')') as 'Model Name', Price, (Price * ProductCount) as 'Total Price' from Products
go

select distinct Manufacturer from Products
go

select ProductName + ' (' + Manufacturer + ')' as ModelName, Price into ProductSummary from Products
go

select * from ProductSummary