/*create view OrdersProductsCustomers as
 select
 Orders.CreatedAt as OrderDate,
 Customers.FirstName as Customer,
 Products.ProductName as Product
 from
 Orders
 inner join Products on Orders.ProductId = Products.Id
 inner join Customers on Customers.Id = Orders.CustomerId
 */
/*
select
    *
from
    OrdersProductsCustomers
    */
    /* Alternative creation
     create view OrdersProductsCustomers(OrderDate, Customer, Product) as
     select
     Orders.CreatedAt,
     Customers.FirstName,
     Products.ProductName
     from
     Orders
     inner join Products on Orders.ProductId = Products.Id
     inner join Customers on Customers.Id = Orders.CustomerId
     */
/*
     alter view OrdersProductsCustomers as select 
     Orders.CreatedAt as OrderDate,
     Customers.FirstName as Customer,
     Products.ProductName as Product,
     Products.Manufacturer as Manufacturer
     from
     Orders
     inner join Products on Orders.ProductId = Products.Id
     inner join Customers on Customers.Id = Orders.CustomerId
     */
    
    drop view OrdersProductsCustomers