create database CoffeeShop
go

use CoffeeShop

create table Info
(
    Id int not null primary key identity(0,1),   
    Сорт nvarchar(50) not null check(len(Сорт)>0),
    [Страна происхождения] nvarchar(50) not null check(len([Страна происхождения])>0),
    [Вид кофе] nvarchar(50) not null check(len([Вид кофе])>0),
    Описание nvarchar(200) not null check(len(Описание)>0),
    [Количество грамм] int not null,
    Себестоимость decimal not null
)