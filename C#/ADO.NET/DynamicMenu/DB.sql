create database MenuBase
go

use MenuBase

create table Menu
(
   Id int not null identity(0,1) primary key,
   [Group] nvarchar(50) not null check(len([Group])>0),
   Name nvarchar(100) not null check(len(Name)>0),
   Action nvarchar(100) not null check(len(Action)>0),
   Checkable bit not null
)
go

create proc spAddMenu
   @group nvarchar(50),
   @name nvarchar(100),
   @action nvarchar(100),
   @checkable bit
as

begin 
   insert into Menu([Group], Name, Action, Checkable)
   values (@group, @name, @action, @checkable)

   select scope_identity()
end
go

create proc spGetTab
as

begin
    select * from Menu
end
go

create proc spGetById
    @id int
as

begin
    select [Group], Name, Action, Checkable from Menu where Id = @id
end
go