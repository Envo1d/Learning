select
  *
from
  Products
select
  avg(Price) as Average_Price
from
  Products
select
  avg(Price) as Average_Price
from
  Products
where
  Manufacturer = 'Apple'
select
  avg(Price * ProductCount) as AverageTotalPrice
from
  Products
select
  count(*) as RowsCount
from
  Products
select
  count(Manufacturer) as AppleProd
from
  Products
where
  Manufacturer = 'Apple'
select
  min(Price) as MinPrice
from
  Products
select
  max(Price) as MaxPrice
from
  Products
select
  sum(ProductCount) as TotalCount
from
  Products
select
  sum(ProductCount * Price) as SumTotal
from
  Products
select
  avg(distinct ProductCount)
from
  Products
select
  count(*) as ProdCount,
  sum(ProductCount) as TotalCount,
  min(Price) as MinPrice,
  max(Price) as MaxPrice,
  avg(Price) as AvgPrice
from
  Products