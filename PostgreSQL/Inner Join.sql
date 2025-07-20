select
    Orders.CreatedAt,
    Orders.ProductCount,
    Products.ProductName
from
    Orders
    join Products on Orders.ProductId = Products.Id
select
    Orders.CreatedAt,
    Customers.FirstName,
    Products.ProductName
from
    Orders
    join Products on Orders.ProductId = Products.Id
    join Customers on Customers.Id = Orders.CustomerId
select
    Orders.CreatedAt,
    Customers.FirstName,
    Products.ProductName
from
    Orders
    join Products on Orders.ProductId = Products.Id
    join Customers on Customers.Id = Orders.CustomerId
where
    Products.Price < 45000
order by
    Customers.FirstName
select
    Orders.CreatedAt,
    Customers.FirstName,
    Products.ProductName
from
    Orders
    join Products on Orders.ProductId = Products.Id
    and Products.Manufacturer = 'Apple'
    join Customers on Customers.Id = Orders.CustomerId
order by
    Customers.FirstName