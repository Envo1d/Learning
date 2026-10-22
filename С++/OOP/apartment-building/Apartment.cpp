#include "Apartment.h"

Apartment::Apartment()
{
	mas = NULL;
	size = 0;
	Num = 0;
}

Apartment::Apartment(const Apartment& copy)
{
	size = copy.size;
	Num = copy.Num;
	mas = new Persone[size];
	for (int i = 0; i < size; i++)
	{
		mas[i] = copy.mas[i];
	}
}

Apartment& Apartment::operator=(const Apartment& copy)
{
	if (this != &copy)
	{
		if (mas != NULL) delete[] mas;
		size = copy.size;
		Num = copy.Num;
		mas = new Persone[size];
		for (int i = 0; i < size; i++)
		{
			mas[i] = copy.mas[i];
		}
	}
	return *this;
}

void Apartment::New()
{
	Persone tmp;
	tmp.Vvod();
	Persone* New = new Persone[size + 1];
	for (int i = 0; i < size; i++)
	{
		New[i] = mas[i];
	}
	New[size] = tmp;
	delete[] mas;
	mas = New;
	size++;
}

void Apartment::Delete()
{
	char str[20];
	cout << "Введите ФИО: ";
	gets_s(str);
	int f = 0;
	for (int i = 0; i < size; i++)
	{
		if (strcmp(str, mas[i].GetFio()) == 0)
		{
			f = 1;
			break;
		}
	}
	if (f == 1)
	{
		Persone* New = new Persone[size - 1];
		int j = 0;
		for (int i = 0; i < size; i++)
		{
			if (strcmp(str, mas[i].GetFio()) != 0)
			{
				New[j] = mas[i];
				j++;
			}
		}
		delete[] mas;
		mas = New;
		size--;
		cout << "Удален\n";
	}
	else
		cout << "Ненайден\n";
}


void Apartment::Print()
{
	cout << "Номер квартиры: " << Num << "\n";
	for (int i = 0; i < size; i++)
	{
		mas[i].Show();
	}
}

void Apartment::SetNum(int n)
{
	Num = n;
}

int Apartment::FindPers(const char* str)
{
	int f = 0;
	for (int i = 0; i < size; i++)
	{
		if (strcmp(mas[i].GetFio(), str) == 0)
		{
			cout << "Живёт в квартире №" << Num << "\n";
			mas[i].Show();
			f = 1;
		}
	}
	return f;
}

int Apartment::GetSize()
{
	return size;
}

Apartment::~Apartment()
{
	delete[] mas;
}

