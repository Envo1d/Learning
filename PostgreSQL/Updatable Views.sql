/*create view ProductView as
select
    ProductName as Product,
    Manufacturer,
    Price
from
    Products
    */
/*
    insert into ProductView(Product, Manufacturer, Price)
    values('Nokia 8', 'HDC Global', 18000)*/

    select * from ProductView

    update ProductView set Price = 15000 where Product = 'Nokia 8'

    select * from ProductView

    delete from ProductView where Product = 'Nokia 8'

    select * from ProductView