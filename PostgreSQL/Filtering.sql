select * from Products where Manufacturer in ('Samsung', 'Xiaomi', 'Huawei')

select * from Products where Manufacturer not in ('Samsung', 'Xiaomi', 'Huawei')

/* IN как 'where item or item or item' */

select * from Products where Price between 20000 and 40000

select * from Products where Price not between 20000 and 40000

select * from Products where Price * ProductCount between 100000 and 200000

/*ќператор LIKE принимает шаблон строки, которому должно соответствовать выражение
ƒл€ определени€ шаблона могут примен€тьс€ р€д специальных символов подстановки:

%: соответствует любой подстроке, котора€ может иметь любое количество символов, при этом подстрока может и не содержать ни одного символа

_: соответствует любому одиночному символу

[ ]: соответствует одному символу, который указан в квадратных скобках

[ - ]: соответствует одному символу из определенного диапазона

[ ^ ]: соответствует одному символу, который не указан после символа ^

Ќекоторые примеры использовани€ подстановок:

WHERE ProductName LIKE 'Galaxy%'

—оответствует таким значени€м как "Galaxy Ace 2" или "Galaxy S7"

WHERE ProductName LIKE 'Galaxy S_'

—оответствует таким значени€м как "Galaxy S7" или "Galaxy S8"

WHERE ProductName LIKE 'iPhone [78]'

—оответствует таким значени€м как "iPhone 7" или "iPhone8"

WHERE ProductName LIKE 'iPhone [6-8]'

—оответствует таким значени€м как "iPhone 6", "iPhone 7" или "iPhone8"

WHERE ProductName LIKE 'iPhone [^7]%'

—оответствует таким значени€м как "iPhone 6", "iPhone 6S" или "iPhone8". Ќо не соответствует значени€м "iPhone 7" и "iPhone 7S"

WHERE ProductName LIKE 'iPhone [^1-6]%'

—оответствует таким значени€м как "iPhone 7", "iPhone 7S" и "iPhone 8". Ќо не соответствует значени€м "iPhone 5", "iPhone 6" и "iPhone 6S"
*/
select * from Products where ProductName like 'iPhone [6-8]%'