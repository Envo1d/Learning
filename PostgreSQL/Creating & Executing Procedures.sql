create procedure ProductSummary as begin
select
    ProductName as Product,
    Manufacturer,
    Price
from
    Products
end;

execute ProductSummary;

drop procedure ProductSummary;