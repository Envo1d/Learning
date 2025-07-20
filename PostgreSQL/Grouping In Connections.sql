select FirstName, count(Orders.Id) as OrderCount from Customers join Orders 
on Orders.CustomerId = Customers.Id group by Customers.Id, Customers.FirstName

select FirstName, count(Orders.Id) as OrderCount from Customers left join Orders 
on Orders.CustomerId = Customers.Id group by Customers.Id, Customers.FirstName

select Products.ProductName, Products.Manufacturer, Sum(Orders.ProductCount * Orders.Price) as Units
from Products left join Orders on Orders.ProductId = Products.Id group by Products.Id, Products.ProductName, Products.Manufacturer
