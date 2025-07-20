select
    Manufacturer,
    count(*) as Models,
    sum(ProductCount) as Units
from
    Products
group by
    Manufacturer with rollup
    /*alternative*/
select
    Manufacturer,
    count(*) as Models,
    sum(ProductCount) as Units
from
    Products
group by
    rollup(Manufacturer)
    /*rollup with several params*/
select
    Manufacturer,
    count(*) as Models,
    sum(ProductCount) as Units
from
    Products
group by
    Manufacturer,
    ProductCount with rollup
    /*cube*/
select
    Manufacturer,
    count(*) as Models,
    sum(ProductCount) as Units
from
    Products
group by
    Manufacturer,
    ProductCount with cube
    /*grouping sets*/
select
    Manufacturer,
    count(*) as Models,
    ProductCount
from
    Products
group by
    grouping sets(Manufacturer, ProductCount)
select
    Manufacturer,
    count(*) as Models,
    ProductCount,
    sum(ProductCount) as Units
from
    Products
group by
    grouping sets(rollup(Manufacturer), ProductCount)
    /*over*/
select
    ProductName,
    Manufacturer,
    ProductCount,
    count(*) over (partition by Manufacturer) as Models,
    sum(ProductCount) over (partition by Manufacturer) as Units
from
    Products