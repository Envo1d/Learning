// Источник: homework 8.txt
#include <iostream>
#include <Windows.h>
#include <conio.h>

// Задание 1:
// Создайте структуру, описывающую комплексное число. Реализуйте арифметические операции с комплексными числами: сумму, разность, умножение, деление.
// Решение в исходном файле отсутствует.

// Задание 2:
// Реализовать структуру «Автомобиль» (длина, клиренс (высота посадки), объем двигателя, мощность двигателя, 
// диаметр колес, цвет, тип коробки передач). Создайте функции для задания значений, отображения значений, поиска значений.

namespace task07 {

using namespace std;

struct Car
{
	char nam[20];
    float len; 
    float klirens;  
    float V;
    float W; 
    float D;
    char color[15]; 
    char type[10]; 
};

Car Vvod()
{
	Car tmp;
	cout << "Введите модель машины: ";
	gets_s(tmp.nam);
	cout << "Введите длину машины: ";
	cin >> tmp.len;
	cin.ignore();
	cout << "Введите клиренс: ";
	cin >> tmp.klirens;
	cin.ignore();
	cout << "Введите объем двигателя: ";
	cin >> tmp.V;
	cin.ignore();
	cout << "Введите мощность двигателя: ";
	cin >> tmp.W;
	cin.ignore();
	cout << "Введите диаметр колес: ";
	cin >> tmp.D;
	cin.ignore();
	cout << "Введите цвет: ";
	gets_s(tmp.color);
	cout << "Введите тип коробки передач: ";
	gets_s(tmp.type);
	return tmp;
}
void Add(Car*& mas, int& n)
{
	mas = (Car*)realloc(mas, (n + 1) * sizeof(Car));
	mas[n] = Vvod();
	n++;
}
void Show(Car tmp)
{
	cout <<"Название - " <<tmp.nam << "\n" <<"Длина - " << tmp.len <<" м"<< "\n" <<"Клиренс - "<< tmp.klirens << "\n" <<
		"Объем двигателя - "<< tmp.V << " л"<< "\n" <<"Мощность двигателя - "<< tmp.W <<" л/с"<< "\n" <<
		"Диаметр колес - "<< tmp.D << "\n" <<"Цвет - "<< tmp.color << "\n" <<"Коробка передач - "<< tmp.type << "\n\n\n";
}
void Print(Car* mas, int n)
{
	for (int i = 0; i < n; i++)
	{
		Show(mas[i]);
	}
}
void Del(Car*& mas, int& n, char* Nazv)
{
	int k = 0;
	for (int i = 0; i < n; i++)
	{
		if (_stricmp(mas[i].nam, Nazv) == 0)
		{
			k = 1;
			for (int j = i; j < n - 1; j++)
			{
				mas[j] = mas[j + 1];
			}
			mas = (Car*)realloc(mas, (n - 1) * sizeof(Car));
			n--;
			i--;
		}
	}
	if (k == 0)
	{
		cout << "Нет совпадений\n";
	}
	else
	{
		cout << "Удаление произошло\n";
	}
}
void Find(Car* mas, int n, char* Name)
{
	bool f = 0;
	for (int i = 0; i < n; i++)
	{
		if (_stricmp(mas[i].nam, Name) == 0)
		{
			f = 1;
			Show(mas[i]);
		}
	}
	if (f == 0)
	{
		cout << "Нет совпадений\n";
	}
}
void run()
{
    SetConsoleCP(1251);
    SetConsoleOutputCP(1251);
	char ch;
	int n = 0;
	Car* Catalog = NULL;
	char str[20];
	do
	{
		system("cls");
		cout << "1-Добавление новой машины в список.\n";
		cout << "2-Удаление из списка.\n";
		cout << "3-Вывод базы.\n";
		cout << "4-Поиск по названию.\n";
		cout << "Esc - Выход.\n";
		ch = _getch();
		switch (ch)
		{
		case '1':system("cls");
			Add(Catalog, n);
			cout << "Добавлено\n";
			Sleep(1300);
			break;
		case '2':system("cls");
			if (n != 0)
			{
				cout << "Введите модель машины: ";
				gets_s(str);
				Del(Catalog, n, str);
			}
			else
			{
				cout << "Каталог пуст\n";
			}
			Sleep(1300);
			break;
		case '3':system("cls");
			if (n != 0)
			{
				Print(Catalog, n);
				system("pause");
			}
			else
			{
				cout << "Каталог пуст\n";
				Sleep(1300);
			}
			break;
		case '4':system("cls");
			if (n != 0)
			{
				cout << "Введите название машины: ";
				gets_s(str);
				Find(Catalog, n, str);
			}
			else
			{
				cout << "Каталог пуст.\n";
			}
			system("pause");
			break;
		}
	} while (ch != 27);
	free(Catalog);
}
} // namespace task07

// Задание 3:
// Разработайте программу «Библиотека». Создайте структуру «Книга» (название, автор, издательство, жанр). Создайте массив из 10 книг. 
// Реализуйте для него следующие возможности:
// Редактировать книгу
// Печать всех книг
// Поиск книг по автору
// Поиск книги по названию
// Сортировка массива по названию книг
// Сортировка массива по автору
// Сортировка массива по издательству

namespace task08 {

using namespace std;

struct Book
{
	char Name[20];
	char Author[15];
	char Publ[30];
	char Ganr[15];
};
Book Vvod()
{
	Book tmp;
	cout << "Введите название книги: ";
	gets_s(tmp.Name);
	cout << "Введите автора: ";
	gets_s(tmp.Author);
	cout << "Введите жанр книги: ";
	gets_s(tmp.Ganr);
	cout << "Введите Издательство: ";
	gets_s(tmp.Publ);
	return tmp;
}
void Add(Book*& mas, int& n)
{
	mas = (Book*)realloc(mas, (n + 1) * sizeof(Book));
	mas[n] = Vvod();
	n++;
}
void Show(Book tmp)
{
	cout << "Название - " << tmp.Name << "\n" << "Автор - " << tmp.Author << "\n" << "Жанр - " << tmp.Ganr << "\n" <<
		"Издательство - " << tmp.Publ << "\n\n";
}
void Print(Book* mas, int n)
{
	for (int i = 0; i < n; i++)
	{
		Show(mas[i]);
	}
}
void Red(Book*& mas, int& n, char* Nazv)
{
	int k = 0;
	for (int i = 0; i < n; i++)
	{
		if (_stricmp(mas[i].Name, Nazv) == 0)
		{
			k = 1;
			mas[i] = Vvod();
		}
	}
	if (k == 0)
	{
		cout << "Нет совпадений.\n";
	}
	else
	{
		cout << "Изменено.\n";
	}
}
void Find_Author(Book* mas, int n, char* Fio)
{
	bool f = 0;
	for (int i = 0; i < n; i++)
	{
		if (_stricmp(mas[i].Author, Fio) == 0)
		{
			f = 1;
			Show(mas[i]);
		}
	}
	if (f == 0)
	{
		cout << "Нет совпадений.\n";
	}
}
void Find_Name(Book* mas, int n, char* nam)
{
	bool f = 0;
	for (int i = 0; i < n; i++)
	{
		if (_stricmp(mas[i].Name, nam) == 0)
		{
			f = 1;
			Show(mas[i]);
		}
	}
	if (f == 0)
	{
		cout << "Нет совпадений.\n";
	}
}
void Sort_Name(Book* mas, int n)
{
	for (int i = 0; i < n; i++)
	{
		for (int j = 0; j < n - 1; j++)
		{
			if (_stricmp(mas[j].Name, mas[j + 1].Name) > 0)
			{
				Book tmp = mas[j];
				mas[j] = mas[j + 1];
				mas[j + 1] = tmp;
			}
		}
	}
}
void Sort_Author(Book* mas, int n)
{
	for (int i = 0; i < n; i++)
	{
		for (int j = 0; j < n - 1; j++)
		{
			if (_stricmp(mas[j].Author, mas[j + 1].Author) > 0)
			{
				Book tmp = mas[j];
				mas[j] = mas[j + 1];
				mas[j + 1] = tmp;
			}
		}
	}
}
void Sort_Publ(Book* mas, int n)
{
	for (int i = 0; i < n; i++)
	{
		for (int j = 0; j < n - 1; j++)
		{
			if (_stricmp(mas[j].Publ, mas[j + 1].Publ) > 0)
			{
				Book tmp = mas[j];
				mas[j] = mas[j + 1];
				mas[j + 1] = tmp;
			}
		}
	}
}
void run()
{
	SetConsoleCP(1251);
	SetConsoleOutputCP(1251);
	char ch;
	int n = 0;
	Book* Catalog = NULL;
	char str[20];
	do
	{
		system("cls");
		cout << "1-Добавление книги.\n";
		cout << "2-Редактировать книгу.\n";
		cout << "3-Вывод списка.\n";
		cout << "4-Поиск по автору.\n";
		cout << "5-Поиск книги по названию.\n";
		cout << "6-Сортировка массива по названию книг.\n";
		cout << "7-Сортировка массива по автору.\n";
		cout << "8-Сортировка массива по издательству.\n";
		cout << "Esc-Выход.\n";
		ch = _getch();
		switch (ch)
		{
		case '1':system("cls");
			Add(Catalog, n);
			cout << "Добавлено.\n";
			Sleep(1300);
			break;
		case '2':system("cls");
			if (n != 0)
			{
				cout << "Введите название редактируемой книги: ";
				gets_s(str);
				Red(Catalog, n, str);
			}
			else
			{
				cout << "Каталог пуст.\n";
			}
			Sleep(1300);
			break;
		case '3':system("cls");
			if (n != 0)
			{
				Print(Catalog, n);
				system("pause");
			}
			else
			{
				cout << "Каталог пуст.\n";
				Sleep(1300);
			}
			break;
		case '4':system("cls");
			if (n != 0)
			{
				cout << "Введите фамилию автора: ";
				gets_s(str);
				Find_Author(Catalog, n, str);
			}
			else
			{
				cout << "Каталог пуст.\n";
			}
			system("pause");
			break;
		case '5':system("cls");
			if (n != 0)
			{
				cout << "Введите название книги: ";
				gets_s(str);
				Find_Name(Catalog, n, str);
			}
			else
			{
				cout << "Каталог пуст.\n";
			}
			system("pause");
			break;
		case '6':system("cls");
			if (n != 0)
			{
				Sort_Name(Catalog, n);
				cout << "Сортировка произведена.\n";
			}
			else
			{
				cout << "Каталог пуст.\n";
			}
			Sleep(1300);
			break;
		case '7':system("cls");
			if (n != 0)
			{
				Sort_Author(Catalog, n);
				cout << "Сортировка произведена.\n";
			}
			else
			{
				cout << "Каталог пуст.\n";
			}
			Sleep(1300);
			break;
		case '8':system("cls");
			if (n != 0)
			{
				Sort_Publ(Catalog, n);
				cout << "Сортировка произведена.\n";
			}
			else
			{
				cout << "Каталог пуст.\n";
			}
			Sleep(1300);
			break;
		}
	} while (ch != 27);
	free(Catalog);
}
} // namespace task08

// Задание 4:
// Реализовать структуру «Машина» (цвет, модель, номер). Номер машины может представлять из себя или пятизначный номер или слово до 8 символов.
// Рекомендации: номер реализовать как объединение.
// Создать экземпляр структуры «Машина» и реализовать для него следующие функции:
// Заполнение машины
// Печать машины
// Создать массив из 10 экземпляров структуры «Машина» и реализовать для него следующие функции:
// Редактировать машину
// Печать всех машин
// Поиск машины по номеру

namespace task09 {

using namespace std;

struct Data
{
	char Color[20];
	char Model[30];
	char Nomer[10];
};
Data Vvod()
{
	Data tmp;
	cout << "Введите цвет машины:\n";
	gets_s(tmp.Color);
	cout << "Введите модель машины:\n";
	gets_s(tmp.Model);
	cout << "Введите номер машины:\n";
	gets_s(tmp.Nomer);
	return tmp;
}
void show(Data tmp)
{
	cout << "Модель: " << tmp.Model << endl << "Цвет: " << tmp.Color << endl << "Номер: " << tmp.Nomer << "\n\n";
}
void car(Data *&mas, int &n)
{
	mas = (Data*)realloc(mas, (n + 1) * sizeof(Data));
	mas[n]= Vvod();
	n++;
	system("cls");
	show(mas[n - 1]);
}
void print(Data* mas, int n)
{
	for (int i = 0; i < n; i++)
	{
		show(mas[i]);
	}
}
void red(Data*& mas, int& n, char *k)
{
	for (int i = 0; i < n; i++)
	{
		int f = 0;
		{
			if (_stricmp(mas[i].Model, k) == 0)
			{
				f = 1;
				mas[i] = Vvod();
			}
		}
		if (f == 0)
			cout << "Ненайдено\n";
		else
			cout << "Изменено\n";
	}
}
void find(Data* mas, int n, char* k)
{
	int f = 0;
	for (int i = 0; i < n; i++)
	{
		if (_stricmp(mas[i].Nomer, k) == 0)
		{
			f = 1;
			show(mas[i]);
		}
	}
	if (f == 0)
		cout << "Ненайдено\n";
}
void run()
{
	SetConsoleCP(1251);
	SetConsoleOutputCP(1251);
	char ch;
	int n = 0;
	char k[20];
	Data* mas = NULL;
	do
	{
		system("cls");
		cout << "1 - Добавить модель машины\n" <<
			"2 - Редактировать машину\n" <<
			"3 - Печать всех машин\n" <<
			"4 - Поиск машины по номеру\n";
		cout << "Esc - Выход.\n";
		ch = _getch();
		switch (ch)
		{
		case '1':system("cls");
			car(mas, n);
			Sleep(2000);
			break;
		case '2':system("cls");
			cout << "Введите марку машины для редактирования:\n";
			gets_s(k);
			red(mas, n, k);
			Sleep(2000);
			break;
		case '3':system("cls");
			print(mas, n);
			Sleep(4000);
			break;
		case '4':system("cls");
			cout << "Введите номер машины:\n";
			gets_s(k);
			find(mas, n, k);
			Sleep(2000);
			break;
		}
	} while (ch != 27);
	free(mas);
}
} // namespace task09

void main()
{
	task07::run();
	task08::run();
	task09::run();
}
