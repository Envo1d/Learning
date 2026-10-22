create database Enterprise
go

use Enterprise
go
 
create table Units
(
  UnitId tinyint not null primary key identity(0,1),
  UnitName nvarchar(30) not null check(len(UnitName)>0)
)

create table Address
(
  AddressId int not null primary key identity(0,1),
  Street nvarchar(50) not null check(len(Street)>0),
  City nvarchar(50) not null check(len(City)>0),
  CountryName nvarchar(50) not null check(len(CountryName)>0)
)

create table Supplier
(
  SupplierId int not null primary key identity(0,1),
  Name nvarchar(50) not null check(len(Name)>0),
  AddressId int not null constraint  FK_Supplier_Address foreign key (AddressId) references Address(AddressId) on update cascade,
  Phone nvarchar(30) not null check(len(Phone)>0),
  Bank nvarchar(50) not null check(len(Bank)>0),
  Bill nvarchar(50) not null check(len(Bill)>0)
)

create table Seller
(
  SellerId int not null primary key identity(0,1),
  FullName nvarchar(50) not null check(len(FullName)>0),
  AddressId int not null constraint  FK_Seller_Address foreign key (AddressId) references Address(AddressId) on update cascade,
  Phone nvarchar(30) not null check(len(Phone)>0)
)

create table Producer
(
  ProducerId int not null primary key identity(0,1),
  Name nvarchar(50) not null check(len(Name)>0),
  AddressId int not null constraint  FK_Producer_Address foreign key (AddressId) references Address(AddressId) on update cascade,
  Email nvarchar(30) not null check(len(Email)>0),
  Phone nvarchar(30) not null check(len(Phone)>0)
)

create table Product
(
  ProductId int not null primary key identity(0,1),
  Name nvarchar(50) not null check(len(Name)>0),
  Model nvarchar(50) not null check(len(Model)>0),
  Price money not null check(Price > 0),
  Unit tinyint constraint FK_ProdTemp_Units foreign key (Unit) references Units(UnitId) on update cascade,
  ProducerId int not null constraint FK_Product_Producer foreign key (ProducerId) references Producer(ProducerId) on update cascade
)

create table SuppliedProducts
(
  SupplyId int not null primary key identity(0,1),
  SupDate date not null check(SupDate >= '01.01.2022'),
  Amount int not  null,
  OriginalAmount int not null check(OriginalAmount>0),
  SupplierId int not null constraint FK_SuppliedProducts_Supplier foreign key (SupplierId) references Supplier(SupplierId),
  ProductId int not null constraint FK_SuppliedProducts_Product foreign key (ProductId) references Product(ProductId) on update cascade,
)

create table Customer
(
  CustomerId int not null primary key identity(0,1),
  FullName nvarchar(50) not null check(len(FullName)>0),
  AddressId int not null constraint  FK_Customer_Address foreign key (AddressId) references Address(AddressId) on update cascade,
  Phone nvarchar(30) not null check(len(Phone)>0)
)

create table Sale
(
  SaleId int not null primary key identity(0,1),
  SellerId int not null constraint FK_Sale_Seller foreign key (SellerId) references Seller(SellerId) on update cascade,
  CustomerId int not null constraint FK_Sale_Customer foreign key (CustomerId) references Customer(CustomerId),
  ProductId int not null constraint FK_Sale_Product foreign key (ProductId) references Product(ProductId),
  SaledProductCount int not null,
  SaleDate date not null check(SaleDate >= '01.01.2022'),
  Price money not null,
)

go
