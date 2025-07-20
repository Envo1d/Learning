Declare @lastDate date
select
    @lastDate = Max(CreatedAt)
from
    Orders If DateDiff(day, @lastDate, GetDate()) > 10 Print 'There have been no orders in the last ten days'
    Else Print 'There have been orders in the last ten days'
    /* Если после IF или ELSE идут две и более инструкций, то они заключаются в блок BEGIN...END*/
    Declare @count int,
    @sum money;

select
    @lastDate = Max(CreatedAt),
    @count = Sum(ProductCount),
    @sum = Sum(ProductCount * Price)
from
    Orders if @count > 0 BEGIN Print 'Last order date: ' + Convert(nvarchar, @lastDate) Print 'Sold ' + Convert(nvarchar, @count) + ' unit(s)' Print 'For total cost ' + Convert(nvarchar, @sum)
END;

Else Print 'Order is not exists in DB'