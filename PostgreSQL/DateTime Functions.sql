select GetDate() as DateNow

select GetUtcDate() as UtcDateNow

/*return datetime2 object unlike  GETDATE (datetime object)*/
select SysDateTime() as SysDateTimeNow

select SysUtcDateTime() as SysUtcDateNow

/*возвращает объект datetimeoffset(7), который 
содержит дату и время относительно GMT*/
select SysDateTimeOffset() as [SysDateTimeOffset]

select Day(GetDate()) as [Day]

select Month(GetDate()) as [Month]

select Year(GetDate()) as [Year]

select DateName(year, GetDate()) as YearName
select DateName(quarter, GetDate()) as QuarterName
select DateName(month,GetDate()) as MonthName
select DateName(dayofyear, GetDate()) as DayOfYearName
select DateName(day, GetDate()) as DayOfMonthName
select DateName(week, GetDate()) as WeekName
select DateName(weekday, GetDate()) as DayOfWeekName
select DateName(hour, GetDate()) as HourName
select DateName(minute , GetDate()) as MinuteName
select DateName(second , GetDate()) as SecondName
select DateName(millisecond, GetDate()) as MillisecondName
select DateName(microsecond, GetDate()) as MicrosecondName
select DateName(nanosecond, GetDate()) as NanosecondName
/*tzoffset (tz): смешение в минутах относительно гринвича 
(для объекта datetimeoffset)*/

select DatePart(month , GetDate()) as MonthPart

select DateAdd(month, 2, '2022-3-26') as AddMonthToDate
select DateAdd(day, 5, '2022-3-26') as AddDayToDate
select DateAdd(day, -5, '2022-3-26') as AddDayToDate

select DateDiff(year, '2020-3-26', '2022-5-26') as YearDiff
select DateDiff(month, '2020-3-26', '2022-5-26') as MonthDiff
select DateDiff(day, '2020-3-26', '2022-5-26') as DayDiff

select ToDateTimeOffset('2022-3-26 18:32:30', '+03:00') as [ToDateTimeOffset]

select SwitchOffset(SysDateTimeOffset(), '+02:30') as [SwitchOffset]

select EoMonth('2022-3-26') as EndOfMonthDay
select EoMonth('2022-3-26', -1) as EndOfMonthDay

select DateFromParts(2022, 3, 26) as [DateFromParts]

select IsDate('2022-3-26') [IsDate]
select IsDate('2022-26-3') [IsDate]
select IsDate('26-3-2022') [IsDate]
select IsDate('SQL') [IsDate]

select * from Orders where DateDiff(day , CreatedAt, GetDate()) = 16