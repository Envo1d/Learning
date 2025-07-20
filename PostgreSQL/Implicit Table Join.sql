select
    *
from
    Orders,
    Customers
select
    *
from
    Orders,
    Customers
where
    Orders.CustomerID = customers.Id
select
    Customers.FirstName,
    Products.ProductName,
    Orders.CreatedAt
from
    Orders,
    Customers,
    Products
where
    Orders.CustomerID = customers.Id
    and Orders.ProductId = Products.Id