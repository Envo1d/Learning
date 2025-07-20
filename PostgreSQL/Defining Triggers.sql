/*create trigger Products_INSERT_UPDATE
on Products
After INSERT, UPDATE
as
Update Products
Set Price = Price + Price * 0.38
Where Id = (select Id from inserted)*/

disable trigger Products_INSERT_UPDATE on Products
go
enable trigger Products_INSERT_UPDATE on Products
go

drop trigger Products_INSERT_UPDATE