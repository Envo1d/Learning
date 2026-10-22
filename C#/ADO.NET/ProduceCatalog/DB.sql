create database VegetablesAndFruits
go

use VegetablesAndFruits

create table Info
(
    Id int not null primary key identity(0,1),
    Name nvarchar(100) not null check(len(Name)>0),
    Type nvarchar(25) not null check(len(Type)>0),
    Color nvarchar(50) not null check(len(Color)>0),
    Calorie int not null check(Calorie > 0)
)