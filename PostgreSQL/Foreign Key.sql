create table Orders
(
Id int primary key identity,
CustomerId int,
CreatedAt Date,
constraint FK_Orders_To_Customers foreign key (CustomerId) references Customers(Id) on delete cascade
)