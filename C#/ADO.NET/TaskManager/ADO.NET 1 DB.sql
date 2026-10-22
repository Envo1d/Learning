create database TaskManager
go

use TaskManager

create table Information
(
    Id int not null identity(1,1) primary key,
    Name nvarchar(max) not null check(len(Name)>0),
    Importance int not null check(Importance >= 1 and Importance <= 5),
    [Appointment date] date not null check(len([Appointment date])>0),
    [Period of execution] date not null check(len([Period of execution])>0)
)
