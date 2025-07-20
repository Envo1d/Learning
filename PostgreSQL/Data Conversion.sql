select
    Id,
    Cast(CreatedAt as nvarchar) + '; total: ' + Cast(Price * ProductCount as nvarchar)
from
    Orders
    /* Convert(тип_данных, выражение [, стиль])
     Третий необязательный параметр задает стиль форматирования данных. Этот параметр представляет числовое значение, которое для разных типов данных имеет разную интерпретацию. Например, некоторые значения для форматирования дат и времени:
     
     0 или 100 - формат даты "Mon dd yyyy hh:miAM/PM" (значение по умолчанию)
     
     1 или 101 - формат даты "mm/dd/yyyy"
     
     3 или 103 - формат даты "dd/mm/yyyy"
     
     7 или 107 - формат даты "Mon dd, yyyy hh:miAM/PM"
     
     8 или 108 - формат даты "hh:mi:ss"
     
     10 или 110 - формат даты "mm-dd-yyyy"
     
     14 или 114 - формат даты "hh:mi:ss:mmmm" (24-часовой формат времени)
     
     Некоторые значения для форматирования данных типа money в строку:
     
     0 - в дробной части числа остаются только две цифры (по умолчанию)
     
     1 - в дробной части числа остаются только две цифры, а для разделения разрядов применяется запятая
     
     2 - в дробной части числа остаются только четыре цифры
     */
select
    Convert(nvarchar, CreatedAt, 3),
    Convert(nvarchar, Price * ProductCount, 1)
from
    Orders

    select Try_Convert(int, 'sql')
    select Try_Convert(int, '22')

    select Str(123.4567,6,2)
    select Char(219)
    select Ascii('Ы')
    select Nchar(1067)
    select Unicode('Ы')