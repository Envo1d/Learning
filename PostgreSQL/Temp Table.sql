/*create table #ProductSummary (ProdId int identity, ProdName nvarchar(20), Price money)

insert into #ProductSummary values ('Nokia 8', 18000), ('iPhone 8', 56000)

select * from #ProductSummary */
/*
select ProductId, Sum(ProductCount) as TotalCount,
Sum(Price * ProductCount) as TotalPrice
into #OrdersSummary from Orders group by ProductId

select Products.ProductName, #OrdersSummary.TotalCount, #OrdersSummary.TotalPrice from Products
inner join #OrdersSummary on Products.Id = #OrdersSummary.ProductId*/

/*
create table ##OrderDetails(ProductId int, TotalCount int, TotalSum money)

insert into ##OrderDetails select ProductId, Sum(ProductCount), Sum(ProductCount * Price) from Orders group by ProductId

select * from ##OrderDetails*/

with OrdersInfo as
(
    select ProductId, Sum(ProductCount) as TotalCount, Sum(ProductCount * Price) as TotalSum
    from Orders group by ProductId
)

select * from OrdersInfo