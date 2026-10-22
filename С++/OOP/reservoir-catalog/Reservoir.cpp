#include "Reservoir.h"

Reservoir::Reservoir()
{
	mas = NULL;
	size = 0;
}

Reservoir::Reservoir(const Reservoir& copy) 
{
	size = copy.size;
	mas = new Info[size];
	for (int i = 0; i < size; i++)
	{
		mas[i] = copy.mas[i];
	}
}

Reservoir& Reservoir::operator=(const Reservoir& copy)
{
	if (this != &copy)
	{
		if (mas != NULL) delete[] mas;
		size = copy.size;
		mas = new Info[size];
		for (int i = 0; i < size; i++)
		{
			mas[i] = copy.mas[i];
		}
	}
	return *this;
}

void Reservoir::New()
{
	Info tmp; 
	tmp.Vvod();
	Info* New = new Info[size + 1];
	for (int i = 0; i < size; i++)
	{
		New[i] = mas[i];
	}
	New[size] = tmp;
	delete[]mas;
	mas = New;
	size++;
}

void Reservoir::Delete()
{
	char name[61];
	cout << "Введите название водоёма: ";
	gets_s(name);
	bool f = false;
	for ( int i = 0; i < size; i++)
	{
		if (strcmp(name, mas[i].GetN()) == 0)
		{
			f = true;
			break;
		}
	}
	if (f == true)
	{
		Info* New = new Info[size - 1];
		int j = 0;
		for (int i = 0; i < size; i++)
		{
			if (strcmp(name, mas[i].GetN()) != 0)
			{
				New[j] = mas[i];
				j++;
			}
		}
		delete[] mas;
		mas = New;
		size--;
		cout << "Удалено\n";
	}
	else cout << "Ненайдено\n";
}

void Reservoir::CalV(int k)
{
	int s = mas[k - 1].GetS();
	int d = mas[k - 1].GetD();
	int g = mas[k - 1].GetG();
	cout << "Объем = " << s * d * g;
}

void Reservoir::CalS(int k)
{
	int s = mas[k - 1].GetS();
	int d = mas[k - 1].GetD();
	cout << "Площадь = " << s * d;
}

void Reservoir::CheckT(int k, int v)
{
	char t1 = mas[k - 1].GetT();
	char t2 = mas[v - 1].GetT();
	if (t1 == t2)
		cout << "Одинаковые";
	else
		cout << "Разные";
}

void Reservoir::CheckST(int k, int v)
{
	char t1 = mas[k - 1].GetT();
	char t2 = mas[v - 1].GetT();
	if (t1 == t2)
	{
		int s1 = mas[k - 1].GetS();
		int d1 = mas[k - 1].GetD();
		int s2 = mas[v - 1].GetS();
		int d2 = mas[v - 1].GetD();
		if ((s1 * d1) > (s2 * d2)) {
			mas[k - 1].PrintName();
			cout << " - больше";
		}
		else
		{
			mas[v - 1].PrintName();
			cout << " - больше";
		}
	}
	else cout << "Они разные по типу";
}

void Reservoir::Copy(int num, char* name, int& s, int& d, int& g, char& t)
{
	short k = strlen(mas[num - 1].GetN());
	strcpy_s(name, k + 1, mas[num - 1].GetN());
	s = mas[num - 1].GetS();
	d = mas[num - 1].GetD();
	g = mas[num - 1].GetG();
	t = mas[num - 1].GetT();
}

void Reservoir::Print()
{
	for (int i = 0; i < size; i++)
	{
		cout << "№" << i + 1 << endl;
		mas[i].Show();
		cout << endl << endl;
	}
}

Reservoir::~Reservoir()
{
	delete[]mas;
}

