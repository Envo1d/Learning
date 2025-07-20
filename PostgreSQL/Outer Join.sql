select
    FirstName,
    CreatedAt,
    ProductCount,
    Price,
    ProductId
from
    Orders
    left outer join Customers on Orders.CustomerId = Customers.Id
select
    FirstName,
    CreatedAt,
    ProductCount,
    Price
from
    Customers
    inner join Orders on Customers.Id = Orders.CustomerId
select
    FirstName,
    CreatedAt,
    ProductCount,
    Price
from
    Customers
    left outer join Orders on Customers.Id = Orders.CustomerId
select
    FirstName,
    CreatedAt,
    ProductCount,
    Price,
    ProductId
from
    Orders
    right outer join Customers on Orders.CustomerId = Customers.Id
select
    Customers.FirstName,
    Orders.CreatedAt,
    Products.ProductName,
    Products.Manufacturer
from
    Orders
    left outer join Customers on Orders.CustomerId = Customers.Id
    left outer join Products on Orders.ProductId = Products.Id
select
    Customers.FirstName,
    Orders.CreatedAt,
    Products.ProductName,
    Products.Manufacturer
from
    Orders
    left outer join Customers on Orders.CustomerId = Customers.Id
    left outer join Products on Orders.ProductId = Products.Id
where
    Products.Price < 45000
order by
    Orders.CreatedAt
    /*Cross Join*/
select
    *
from
    Orders
    cross join Customers
    /*Alternative*/
select
    *
from
    Orders,
    Customers