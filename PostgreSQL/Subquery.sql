/*delete Products
 
 create table Customers
 (
 Id int identity primary key,
 FirstName nvarchar(30) not null
 )
 
 create table Orders
 (
 Id int identity primary key,
 ProductId int not null references Products(Id) on delete cascade,
 CustomerId int not null references Customers(Id) on delete cascade,
 CreatedAt date not null,
 ProductCount int default 1,
 Price money not null
 )*/
/*
 insert into
 Products
 values
 ('iPhone 6', 'Apple', 2, 36000),
 ('iPhone 6S', 'Apple', 2, 41000),
 ('iPhone 7', 'Apple', 5, 52000),
 ('Galaxy S8', 'Samsung', 2, 46000),
 ('Galaxy S8 Plus', 'Samsung', 1, 56000),
 ('Mi 5X', 'Xiaomi', 2, 26000),
 ('OnePlus 5', 'OnePlus', 6, 38000)
 insert into
 Customers
 values
 ('Tom'),
 ('Bob'),
 ('Sam')
 insert into
 Orders
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
 '2017-07-11',
 2,
 (
 select
 Price
 from
 Products
 where
 ProductName = 'Galaxy S8'
 )
 ),
 (
 (
 select
 Id
 from
 Products
 where
 ProductName = 'iPhone 6S'
 ),
 (
 select
 Id
 from
 Customers
 where
 FirstName = 'Tom'
 ),
 '2017-07-13',
 1,
 (
 select
 Price
 from
 Products
 where
 ProductName = 'iPhone 6S'
 )
 ),
 (
 (
 select
 Id
 from
 Products
 where
 ProductName = 'iPhone 6S'
 ),
 (
 select
 Id
 from
 Customers
 where
 FirstName = 'Bob'
 ),
 '2017-07-11',
 1,
 (
 select
 Price
 from
 Products
 where
 ProductName = 'iPhone 6S'
 )
 )*/
select
    *
from
    Products
where
    Price = (
        select
            min(Price)
        from
            Products
    )
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
    /* correlated subquery */
select
    CreatedAt,
    Price,
    (
        select
            ProductName
        from
            Products
        where
            Products.Id = Orders.ProductId
    ) as Product
from
    Orders
select
    ProductName,
    Manufacturer,
    Price,
    (
        select
            avg(Price)
        from
            Products as SubProds
        where
            SubProds.Manufacturer = Prods.Manufacturer
    ) as AvgPrice
from
    Products as Prods
where
    Price > (
        select
            avg(Price)
        from
            Products as SubProds
        where
            SubProds.Manufacturer = Prods.Manufacturer
    )