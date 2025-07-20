select * from Products

delete Products from
(select top 2 * from Products
where Manufacturer='Apple Inc.') as Selected
where Products.Id = Selected.Id

select * from Products