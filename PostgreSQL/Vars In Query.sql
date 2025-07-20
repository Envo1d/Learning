Declare @maxPrice money, @minPrice money, @dif money, @count int

Set @count = (select Sum(ProductCount) from Orders);

select @minPrice = Min(Price), @maxPrice = Max(Price) from Products

Set @dif = @maxPrice - @minPrice;

Print 'Total Sold: ' + Str(@count, 5) + ' goods';
Print 'Difference between max and min prices: ' + Str(@dif);

Declare @sum money, @id int, @prodid int, @name nvarchar(20);
Set @id = 19;

select @sum = Sum(Orders.Price * Orders.ProductCount), @name = Products.ProductName,
@prodid = Products.Id
from Orders 
inner join Products on Orders.ProductId = Products.Id
group by Products.ProductName, Products.Id
having Products.Id = @id

Print 'Goods ' + @name + ' sold for the amount ' + Str(@sum)