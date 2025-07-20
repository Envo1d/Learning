/*
 В выражении SELECT мы можем вводить подзапросы четырьмя способами:
 
 Использовать в условии в выражении WHERE
 
 Использовать в условии в выражении HAVING
 
 Использовать в качестве таблицы для выборки в выражении FROM
 
 Использовать в качестве спецификации столбца в выражении SELECT
 */
select
    *
from
    Products
select
    *
from
    Products
where
    Price > (
        select
            avg(Price)
        from
            Products
    )
select
    *
from
    Customers
where
    Id not in (
        select
            CustomerId
        from
            Orders
    )
select
    *
from
    Products
where
    Price < all(
        select
            Price
        from
            Products
        where
            Manufacturer = 'Apple'
    )
select
    *
from
    Products
where
    Price < any(
        select
            Price
        from
            Products
        where
            Manufacturer = 'Apple'
    )
select
    *,
    (
        select
            ProductName
        from
            Products
        where
            Id = Orders.ProductId
    ) as Product
from
    Orders
insert into
    Orders(
        ProductId,
        CustomerId,
        CreatedAt,
        ProductCount,
        Price
    )
values
(
        (
            select
                Id
            from
                Products
            where
                ProductName = 'Galaxy S8'
        ),
        (
            select
                Id
            from
                Customers
            where
                FirstName = 'Tom'
        ),
        '2022-03-17',
        2,
        (
            select
                Price
            from
                Products
            where
                ProductName = 'Galaxy S8'
        )
    )
update
    Orders
set
    ProductCount = ProductCount + 2
where
    CustomerId = (
        select
            Id
        from
            Customers
        where
            FirstName = 'Tom'
    )
update
    Orders
set
    Price = (
        select
            Price
        from
            Products
        where
            Id = Orders.ProductId
    ) + 2000
where
    Id = 1
delete from
    Orders
where
    ProductId = (
        select
            Id
        from
            Products
        where
            ProductName = 'Galaxy S8'
    )
    and CustomerId =(
        select
            Id
        from
            Customers
        where
            FirstName = 'Bob'
    )