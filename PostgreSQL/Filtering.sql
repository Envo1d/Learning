select * from Products where Manufacturer in ('Samsung', 'Xiaomi', 'Huawei')

select * from Products where Manufacturer not in ('Samsung', 'Xiaomi', 'Huawei')

/* IN ��� 'where item or item or item' */

select * from Products where Price between 20000 and 40000

select * from Products where Price not between 20000 and 40000

select * from Products where Price * ProductCount between 100000 and 200000

/*�������� LIKE ��������� ������ ������, �������� ������ ��������������� ���������
��� ����������� ������� ����� ����������� ��� ����������� �������� �����������:

%: ������������� ����� ���������, ������� ����� ����� ����� ���������� ��������, ��� ���� ��������� ����� � �� ��������� �� ������ �������

_: ������������� ������ ���������� �������

[ ]: ������������� ������ �������, ������� ������ � ���������� �������

[ - ]: ������������� ������ ������� �� ������������� ���������

[ ^ ]: ������������� ������ �������, ������� �� ������ ����� ������� ^

��������� ������� ������������� �����������:

WHERE ProductName LIKE 'Galaxy%'

������������� ����� ��������� ��� "Galaxy Ace 2" ��� "Galaxy S7"

WHERE ProductName LIKE 'Galaxy S_'

������������� ����� ��������� ��� "Galaxy S7" ��� "Galaxy S8"

WHERE ProductName LIKE 'iPhone [78]'

������������� ����� ��������� ��� "iPhone 7" ��� "iPhone8"

WHERE ProductName LIKE 'iPhone [6-8]'

������������� ����� ��������� ��� "iPhone 6", "iPhone 7" ��� "iPhone8"

WHERE ProductName LIKE 'iPhone [^7]%'

������������� ����� ��������� ��� "iPhone 6", "iPhone 6S" ��� "iPhone8". �� �� ������������� ��������� "iPhone 7" � "iPhone 7S"

WHERE ProductName LIKE 'iPhone [^1-6]%'

������������� ����� ��������� ��� "iPhone 7", "iPhone 7S" � "iPhone 8". �� �� ������������� ��������� "iPhone 5", "iPhone 6" � "iPhone 6S"
*/
select * from Products where ProductName like 'iPhone [6-8]%'