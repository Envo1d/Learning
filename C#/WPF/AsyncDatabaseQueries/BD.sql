create database AsyncHM
go

use AsyncHM

create table Authors
(
    Id int primary key not null identity(0,1),
    FirstName nvarchar(50) not null check(len(FirstName)>0),
    LastName nvarchar(50) not null check(len(LastName)>0)
)

create table Books
(
    Id int primary key not null identity(0,1),
    Title nvarchar(50) not null check(len(Title)>0),
)
go

insert into Authors(FirstName, LastName)
values('Lewis','Carroll')

insert into Books(Title)
values('Alice’s Adventures in Wonderland')

insert into Authors(FirstName, LastName)
values('John','Tolkien')

insert into Books(Title)
values('The Hobbit')

insert into Authors(FirstName, LastName)
values('Richard','Adams')

insert into Books(Title)
values('Watership Down')

insert into Authors(FirstName, LastName)
values('Susan','Cooper')

insert into Books(Title)
values('The Dark is Rising')

insert into Books(Title)
values('The Neverending Story')