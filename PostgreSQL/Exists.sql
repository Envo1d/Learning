select
    *
from
    Customers
where
    exists (
        select
            *
        from
            Orders
        where
            Orders.CustomerId = Customers.Id
    )
select
    *
from
    Products
where
    not exists (
        select
            *
        from
            Orders
        where
            Orders.ProductId = Products.Id
    )