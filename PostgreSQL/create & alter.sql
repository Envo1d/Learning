create table customers
(
	Id serial primary key,
	Age integer default 18,
	FirstName varchar(20) not null
);

create table orders
(
	Id serial primary key,
	CustomerId integer references customers(Id) on delete set null,
	Quantity integer
);

alter table customers
add Phone character varying(20) null;

alter table customers
add Address character varying(30) not null default 'Undefined';

alter table customers
drop column Address;

alter table customers
add Address character varying(30) not null default 'Undefined';

alter table customers
alter column FirstName type varchar(50);

alter table customers
alter column FirstName
set not null;

alter table customers
alter column FirstName
drop not null;

alter table customers
add check(Age > 0);

alter table customers
add Email varchar(20);

alter table customers
add unique (Email);

alter table customers
rename column Address to City;