/*
create table Customers
(
    Id int primary key identity,
    FirstName nvarchar(20) not null,
    LastName nvarchar(20) not null,
    AccountSum money
)

create table Employees
(
    Id int identity primary key,
    FirstName nvarchar(20) not null,
    LastName nvarchar(20) not null
)
GO

insert into Customers values
('Tom', 'Smith', 2000),
('Sam', 'Brown', 3000),
('Mark', 'Adams', 2500),
('Paul', 'Ins', 4200),
('John', 'Smith', 2800),
('Tim', 'Cook', 2800)

insert into Employees values
('Homer', 'Simpson'),
('Tom', 'Smith'),
('Mark', 'Adams'),
('Nick', 'Svensson')
*/

select FirstName, LastName from Customers
union select FirstName, LastName from Employees

select FirstName + ' ' + LastName as FullName from Customers
union select FirstName + ' ' + LastName as EmployeeName from Employees
order by FullName desc

/*Error expected (first query has one more param)*/
/*
select FirstName, LastName, AccountSum from Customers
union select FirstName, LastName from Employees*/

/*Error expected (second query has another param type)*/

/*
select FirstName, LastName from Customers
union select Id, LastName from Employees*/

select FirstName, LastName from Customers union all select FirstName, LastName from Employees

select FirstName, LastName, AccountSum + AccountSum*0.1 as TotalSum from Customers where AccountSum < 3000 
union select FirstName, LastName, AccountSum + AccountSum*0.3 as TotalSum from Customers where AccountSum >= 3000