select
    ProductName,
    Manufacturer,
    case
        ProductCount
        when 1 then 'Product Ends'
        when 2 then 'Few goods'
        when 3 then 'Available'
        else 'Lots of goods'
    end as EvaluateCount
from
    Products
select
    ProductName,
    Manufacturer,
    case
        when Price > 50000 then 'Category A'
        when Price between 40000
        and 50000 then 'Category B'
        when Price between 30000
        and 40000 then 'Category C'
        else 'Category D'
    end as Category
from
    Products
select
    ProductName,
    Manufacturer,
    iif(ProductCount > 3, 'Lots of goods', 'Few goods')
from
    Products