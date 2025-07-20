select * from Products where Manufacturer = 'Samsung'

select * from Products where Price > 45000

select * from Products where Price * ProductCount > 200000

select * from Products where Manufacturer = 'Samsung' and Price > 45000

select * from Products where Manufacturer = 'Samsung' or Price > 30000

select * from Products where not Manufacturer = 'Samsung' /* or */ select * from Products where Manufacturer <> 'Samsung'

select * from Products where Manufacturer = 'Samsung' or Price > 30000 and ProductCount > 2

select * from Products where ( Manufacturer = 'Samsung' or Price > 30000 ) and ProductCount > 2

select * from Products where ProductCount is null

select * from Products where ProductCount is not null