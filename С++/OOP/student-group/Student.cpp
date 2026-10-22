#include "Student.h"

Student::Student()
{
	fio = NULL;
	age = 0;
}

Student::Student(const Student& copy)
{
	age = copy.age;
	fio = (char*)malloc(strlen(copy.fio) + 1);
	strcpy_s(fio, strlen(copy.fio) + 1, copy.fio);
}

Student& Student::operator=(const Student& copy)
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

void Student::Vvod()
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

void Student::Show()
{
	cout << "ФИО - " << fio << "\nВозраст - " << age << "\n";
}

Student::~Student()
{
	free(fio);
}

