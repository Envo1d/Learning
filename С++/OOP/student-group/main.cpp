// Источник: Urok 1.txt
// 2.Написать класс, описывающий группу студентов. Студент
// также реализуется с помощью соответствующего
// класса.

#include <Windows.h>
#include <conio.h>
#include "Group.h"
#define clr system("cls")

int main()
{
	SetConsoleCP(1251);
	SetConsoleOutputCP(1251);
	char ch;
	Group a;
	do
	{
		clr;
		cout << "1 - Добавить студента в группу\n" <<
			"2 - Удалить студента\n" <<
			"3 - Найти студента\n" <<
			"4 - Вывести список группы\n" <<
			"Esc - Выход";
		ch = _getch();
		switch (ch)
		{
		case '1':clr;
			a.New();
			Sleep(1000);
			break;
		case '2':clr;
			a.Delete();
			Sleep(1000);
			break;
		case '3':clr;
			a.FindPers();
			Sleep(2000);
			break;
		case '4':clr;
			a.Print();
			cout << endl;
			system("pause");
			break;
		}
	} while (ch != 27);
}