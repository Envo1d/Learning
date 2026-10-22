#include "House.h"

House::House(int n)
{
	size = n;
	mas = new Apartment[size];
	for (int i = 0; i < size; i++)
	{
		mas[i].SetNum(i + 1);
	}
	cout << "Введите адрес дома: ";
	gets_s(Address);
}

void House::Add()
{
	cout << "Введите номер квартиры для заселения: ";
	int num;
	cin >> num;
	cin.ignore();
	int count;
	cout << "Сколько человек будет в ней жить: ";
	cin >> count; cin.ignore();
	if (num <= size && num >= 1)
	{
		for (short i = 0; i < count; i++)
			mas[num - 1].New();
		cout << "Добавлено\n";
	}
	else
		cout << "Такой квартиры нет\n";
}

void House::Del()
{
	cout << "Введите номер квартиры: ";
	int num;
	cin >> num;
	cin.ignore();
	if (num <= size && num >= 1)
	{
		if (mas[num - 1].GetSize() != 0)
			mas[num - 1].Delete();
		else
			cout << "Квартира пуста\n";
	}
	else
		cout << "Такой квартиры нет\n";
}

void House::Show()
{
	cout << "Адресс: " << Address << "\n";
	int f = 0;
	for (int i = 0; i < size; i++)
	{
		if (mas[i].GetSize() != 0)
		{
			mas[i].Print();
			f = 1;
		}
	}
	if (f == 0)
		cout << "Дом пуст\n";
}

void House::ShowAp()
{
	cout << "Введите номер квартиры: ";
	int num;
	cin >> num;
	cin.ignore();
	if (num <= size && num >= 1)
	{
		if (mas[num - 1].GetSize() != 0)
			mas[num - 1].Print();
		else
			cout << "Она пуста\n";
	}
	else
		cout << "Такой квартиры нет\n";
}

void House::Find()
{
	char str[20];
	cout << "Введите ФИО: ";
	gets_s(str);
	int f = 0;
	for (int i = 0; i < size; i++)
	{
		if (mas[i].FindPers(str) == 1)
			f = 1;
	}
	if (f == 0)
		cout << "Ненайдено\n";
}

House::~House()
{
	delete[] mas;
}

