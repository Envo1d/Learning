create procedure AddProduct @name nvarchar(20),
@manufacturer nvarchar(20),
@count int = 1,
@price money as
insert into
    Products(ProductName, Manufacturer, ProductCount, Price)
values
    (@name, @manufacturer, @count, @price) Declare @prodName nvarchar(20),
    @companyName nvarchar(20),
    @prodCount int,
    @price money
set
    @prodName = 'Galaxy S7'
set
    @companyName = 'Samsung'
set
    @price = 22000
set
    @prodCount = 5 
    exec AddProduct @prodName,
    @companyName,
    @prodCount,
    @price 
    exec AddProduct 'Galaxy C7',
    'Samsung',
    5,
    21000 
    
DECLARE @prodName NVARCHAR(20),
    @company NVARCHAR(20);

SET
    @prodName = 'Honor 9'
SET
    @company = 'Huawei' EXEC AddProduct @name = @prodName,
    @manufacturer = @company,
    @count = 3,
    @price = 18000
select
    *
from
    Products