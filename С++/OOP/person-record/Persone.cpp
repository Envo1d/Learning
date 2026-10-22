#include "Persone.h"

Persone::Persone()
{
	name = NULL;
	age = 0;
	pol = '0';
	for (int i = 0; i < 13; i++)
	{
		number[i] = '0';
	}
}

Persone::Persone(const char* name)
{
	short k = strlen(name);
	this->name = (char*)realloc(this->name, (k + 1) * sizeof(char));
	strcpy_s(this->name, (k + 1), name);
	cout << "Введите возраст: "; cin >> age;
	cout << "Введите пол: "; cin >> pol;
	cout << "Введите номер телефона: "; cin >> number;
	cin.ignore();
}

void Persone::setname()
{
	char tmp[60];
	cout << "Введите новое имя:\n";
	gets_s(tmp);
	name = (char*)realloc(name, (strlen(tmp) + 1) * sizeof(char));
	strcpy_s(name, strlen(tmp) + 1, tmp);
	cout << "Изменено";
}

void Persone::setage()
{
	cin >> age;
	cout << "Изменено";
	cin.ignore();
}

void Persone::setp()
{
	cin >> pol;
	cout << "Изменено";
	cin.ignore();
}

void Persone::setnum()
{
	cin >> number;
	cout << "Изменено";
	cin.ignore();
}

void Persone::Print()
{
	cout << "Имя: " << name << "\nВозраст: " << age <<
		"\nПол: " << pol << "\nНомер телефона: " << number << endl;
}

Persone::~Persone()
{
	free(name);
}

