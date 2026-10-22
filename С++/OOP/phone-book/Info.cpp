#include "Info.h"

void Info::Vvod()
{
	cout << "Введите ФИО\n";
	gets_s(fio,50);
	cout << "Введите доп. информацию об абоненте\n";
	gets_s(inf,60);
	cout << "Введите рабочий телефон\n";
	gets_s(wnum, 15);
	cout << "Введите домашний телефон\n";
	gets_s(hnum, 15);
	cout << "Введите мобильный телефон\n";
	gets_s(mnum,15);
        cin.ignore(0);
}

void Info::Show()
{
	cout << fio;
	cout << "\nРабочий - " << wnum << "\nДомашний - " << hnum <<
		"\nМобильный - " << mnum << endl;
	cout <<"Доп. информация - "<< inf;
}

