Declare @number int,
@factorial int
Set
    @factorial = 1;

Set
    @number = 5;

while @number > 0 begin
set
    @factorial = @factorial * @number;

set
    @number = @number - 1;

end;

Print @factorial
/*create table #Accounts (CreatedAt Date, Balance Money)*/
Declare @rate float,
@period int,
@sum money,
@date date
Set
    @date = GetDate();

Set
    @rate = 0.065;

Set
    @period = 5;

Set
    @sum = 10000;

While @period > 0 begin
insert into
    #Accounts values (@date, @sum)
set
    @period = @period - 1;

set
    @date = DateAdd(year, 1, @date);

set
    @sum = @sum + @sum * @rate;

end;

select
    *
from
    #Accounts
Set
    @number = 1;

While @number < 10 begin Print Convert(nvarchar, @number);

set
    @number = @number + 1;

If @number = 7 break;

If @number = 4 continue;

Print 'Iteration end'
end;