select * from Products

update Products set Price = Price + 5000

select * from Products

update Products set Manufacturer = 'Samsung Inc.' where Manufacturer = 'Samsung'

select * from Products

update Products set Manufacturer = 'Apple Inc.' from (select top 2 * from Products where Manufacturer='Apple') as Selected where Products.Id = Selected.Id

select * from Products