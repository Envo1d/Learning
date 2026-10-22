#include "TelBook.h"

TelBook::TelBook(const char* str)
{
	strcpy_s(Name, str);
	t = 0;
}

void TelBook::Add()
{
	if (t < 20)
	{
		mas[t].Vvod();
		t++;
	}
	else cout << "Full";
}

void TelBook::Del()
{
	cout << "Введите порядочный номер абонента в списке\n";
	short k;
	cin >> k;
	k--;
	for (int i = 0; i < 20; i++)
	{
		if (k == i)
		{
		    mas[i] = mas[i + 1];
			t--;
			break;
		}
	}
}

void TelBook::Find()
{
	char f[50];
	cout << "Введите ФИО для поиска - ";
	gets_s(f, 50);
	bool p = false;
	for (int i = 0; i < t; i++)
	{
		if (_strcmpi(mas[i].GetFio(), f) == 0)
		{
			mas[i].Show();
			p = true;
		}
	}
	if (p == false)
		cout << "Совпадений нет";
}

void TelBook::print()
{
	cout << Name << "\n\n";
	for (int i = 0; i < t; i++)
	{
		cout << i + 1 << " - ";
		mas[i].Show();
		cout << "\n\n";
	}
}

