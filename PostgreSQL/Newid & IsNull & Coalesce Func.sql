/*
create table Clients
(
    Id UniqueIdentifier primary key default NewId(),
    FirstName nvarchar(20) not null,
    LastName nvarchar(20) not null,
    Phone nvarchar(20) null,
    Email nvarchar(20) null
)

insert into Clients (FirstName, LastName, Phone, Email)
values ('Tom', 'Smith', '+36436734', null),
('Bob', 'Simpson', null,null)
*/

select FirstName, LastName, IsNull(Phone, 'Undefined') as Phone,
IsNull(Email, 'Unknown') as Email
from Clients

select FirstName, LastName,
Coalesce(Phone, Email, 'Undefined') as Contacts
from Clients