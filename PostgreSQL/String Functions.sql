select Len('Apple') as StringLength

select LTrim('   Apple') as StartTabulationTrim

select RTrim('Apple   ') as EndTabulationTrim

select CharIndex('pl', 'Apple') as IndexOf

select PatIndex('%p_e%', 'Apple') as IndexOfPattern

select Left('Apple', 3) as CharFromStart

select Right('Apple', 3) as CharFromEnd

select Substring('Galaxy S8 Plus', 8, 2) as [Substring]

select Replace('Galaxy S8 Plus', 'S8 Plus', 'Note 8') as [Replace]

select Reverse('123456789') as [Reverse]

select Concat('Tom', ' ', 'Smith') as Concatination

select Lower('Apple') as ToLowerCase

select Upper('Apple') as ToUpperCase

/*Also SPACE that return string with specific number of spaces/tabs */

select Upper(Left(Manufacturer,2)) as Abbreviation,
Concat(ProductName, ' - ', Manufacturer) as FullProdName
from Products Order By Abbreviation