/*create procedure GetPriceStats @minPrice money output,
@maxPrice money output as
Select
    @minPrice = Min(Price),
    @maxPrice = Max(Price)
from
    Products

    */

    DECLARE @minPrice money, @maxPrice money
    exec GetPriceStats @minPrice output, @maxPrice output

    Print 'Min price: ' + convert(varchar, @minPrice);
    Print 'Max price: ' + convert(varchar, @maxPrice);
/*go
    create procedure CreateProduct
    @name NVARCHAR(20),
    @manufacturer NVARCHAR(20),
    @count int,
    @price money,
    @id int output
    as insert into Products (ProductName, Manufacturer, ProductCount, Price)
    values (@name, @manufacturer, @count, @price)
    set @id = @@IDENTITY
    */

    declare @id int
    exec CreateProduct 'LG V30', 'LG', 3, 20000, @id output

    print @id
/*
    create procedure GetAvgPrice AS
    declare @avgPrice money
    select @avgPrice = Avg(Price) from Products
    return @avgPrice;*/

    declare @res money
    exec @res = GetAvgPrice
    print @res;