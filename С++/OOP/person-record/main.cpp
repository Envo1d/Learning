// Источник: Urok 2.txt
// 1.Разработать класс Person, который содержит соот-
// ветствующие члены для хранения:
// * имени,
// * возраста,
// * пола и
// * телефонного номера.
// Напишите функции-члены, которые смогут изме-
// нять эти члены данных индивидуально. Напишите
// функцию-член Person::Print(), которая выводит
// отформатированные данные о человеке.

#include "Persone.h"
int main()
{
	SetConsoleCP(1251);
	SetConsoleOutputCP(1251);
	char name[60];
	cout << "Введите имя человека: ";
	gets_s(name);
	Persone a(name);
	char c;
	do
	{
		clr;
		cout << "1 - Изменить имя\n" <<
			"2 - Изменить возраст\n" <<
			"3 - Изменить пол\n" <<
			"4 - Изменить номер телефона\n" <<
			"5 - Вывод информации\n" <<
			"Esc - выход\n";
		c = _getch();
		switch (c)
		{
		case '1':clr;
			a.setname();
			Sleep(1000);
			break;
		case '2':clr;
			a.setage();
			Sleep(1000);
			break;
		case '3':clr;
			a.setp();
			Sleep(1000);
			break;
		case '4':clr;
			a.setnum();
			Sleep(1000);
			break;
		case '5':clr;
			a.Print();
			system("pause");
			break;
		}
	} while (c != 27);
}

