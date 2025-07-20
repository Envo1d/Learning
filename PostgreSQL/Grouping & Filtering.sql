select Manufacturer, count(*) as ModelsCount from Products group by Manufacturer

select Manufacturer, ProductCount, count(*) as ModelsCount from Products group by Manufacturer, ProductCount

select Manufacturer, count(*) as ModelsCount from Products where Price > 30000 group by Manufacturer order by ModelsCount desc

select Manufacturer, count(*) as ModelsCount from Products group by Manufacturer having count(*)>1

select Manufacturer, count(*) as ModelsCount from Products where Price * ProductCount > 80000 group by Manufacturer having count(*)>1

select Manufacturer, count(*) as ModelsCount, sum(ProductCount) as Units from Products where Price * ProductCount > 80000 group by Manufacturer having count(*)>1 order by Units desc