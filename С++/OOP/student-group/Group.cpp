#include "Group.h"

Group::Group()
{
	size = 0;
	mas = NULL;
	cout << "Введите название группы: ";
	gets_s(Name);
}

void Group::New()
{
	Student tmp;
	tmp.Vvod();
	Student* New = new Student[size + 1];
	for (int i = 0; i < size; i++)
	{
		New[i] = mas[i];
	}
	New[size] = tmp;
	delete[] mas;
	mas = New;
	size++;
	cout << "Добавлен";
}

void Group::Delete()
{
	char str[40];
	cout << "Введите ФИО: ";
	gets_s(str);
	bool f = false;
	for (int i = 0; i < size; i++)
	{
		if (strcmp(str, mas[i].GetFio()) == 0)
		{
			f = true;
			break;
		}
	}
	if (f == true)
	{
		Student* New = new Student[size - 1];
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

void Group::Print()
{
	cout << Name << endl << endl;
	for (int i = 0; i < size; i++)
	{
		cout << "№" << i + 1 << endl;
		mas[i].Show();
	}
}

void Group::FindPers()
{
	char str[40];
	cout << "Введите ФИО: ";
	gets_s(str);
	bool f = false;
	for (int i = 0; i < size; i++)
	{
		if (strcmp(str, mas[i].GetFio()) == 0)
		{
			f = true;
			mas[i].Show();
			break;
		}
	}
	if (f == false);
		cout << "Ненайден\n";
}

Group::~Group()
{
	delete[]mas;
}

