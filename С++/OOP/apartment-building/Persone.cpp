#include "Persone.h"

Persone::Persone()
{
	fio = NULL;
	age = 0;
}

Persone::Persone(const Persone& copy)
{
	age = copy.age;
	fio = (char*)malloc(strlen(copy.fio) + 1);
	strcpy_s(fio, strlen(copy.fio) + 1, copy.fio);
}

Persone& Persone::operator=(const Persone& copy)
{
	if (this != &copy)
	{
		if (fio != NULL) free(fio);
		age = copy.age;
		fio = (char*)malloc(strlen(copy.fio) + 1);
		strcpy_s(fio, strlen(copy.fio) + 1, copy.fio);
	}
	return *this;
}
void Persone::Vvod()
{
	if (fio != NULL) free(fio);
	cout << "Введите ФИО: ";
	fio = (char*)realloc(fio, 61 * sizeof(char));
	gets_s(fio, 61);
	int k = strlen(fio);
	fio = (char*)realloc(fio, (k + 1) * sizeof(char));
	cout << "Введите возраст: ";
	cin >> age;
	cin.ignore();
}

void Persone::Show()
{
	cout << "ФИО - " << fio << "\nВозраст - " << age << "\n";
}

Persone::~Persone()
{
	free(fio);
}

