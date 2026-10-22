// Источник: HW OOP 5.txt
// Создать класс СПРАВОЧНИК со следующими полями:
// 	1. Название фирмы;
// 	2. Владелец;
// 	3. Телефон;
// 	4. Адрес;
// 	5. Род деятельности.
// Реализовать следующие возможности:
// 	1. Поиск по названию;
// 	2. Поиск по владельцу;
// 	3. Поиск по номеру телефона;
// 	4. Поиск по роду деятельности;
// 	5. Показ всех записей и добавление.
// 
// Вся информация, должна сохранятся в файле, должна
// быть реализована возможность добавления новых данных


#include <iostream>
#include <fstream>
#include <Windows.h>
#include <conio.h>
#pragma warning(disable: 4996)

using namespace std;

class catalog
{
	char* name;
	char* owner;
	char* number;
	char* address;
	char* metier;
public:
	catalog() : name(nullptr), owner(nullptr), number(nullptr), address(nullptr), metier(nullptr) {}
	catalog(const catalog& copy)
	{
		name = (char*)malloc(strlen(copy.name) + 1);
		strcpy_s(name, strlen(copy.name) + 1, copy.name);
		owner = (char*)malloc(strlen(copy.owner) + 1);
		strcpy_s(owner, strlen(copy.owner) + 1, copy.owner);
		number = (char*)malloc(strlen(copy.number) + 1);
		strcpy_s(number, strlen(copy.number) + 1, copy.number);
		address = (char*)malloc(strlen(copy.address) + 1);
		strcpy_s(address, strlen(copy.address) + 1, copy.address);
		metier = (char*)malloc(strlen(copy.metier) + 1);
		strcpy_s(metier, strlen(copy.metier) + 1, copy.metier);
	}
	catalog& operator=(const catalog& copy)
	{
		if (this != &copy)
		{
			name = (char*)malloc(strlen(copy.name) + 1);
			strcpy_s(name, strlen(copy.name) + 1, copy.name);
			owner = (char*)malloc(strlen(copy.owner) + 1);
			strcpy_s(owner, strlen(copy.owner) + 1, copy.owner);
			number = (char*)malloc(strlen(copy.number) + 1);
			strcpy_s(number, strlen(copy.number) + 1, copy.number);
			address = (char*)malloc(strlen(copy.address) + 1);
			strcpy_s(address, strlen(copy.address) + 1, copy.address);
			metier = (char*)malloc(strlen(copy.metier) + 1);
			strcpy_s(metier, strlen(copy.metier) + 1, copy.metier);
		}
		return *this;
	}
	char* Gets(char*& str)
	{
		int n = 0;
		if (str != nullptr)
		{
			str = nullptr;
		}
		char ch;
		while ((ch = getchar()) != '\n')
		{
			str = (char*)realloc(str, n + 1);
			str[n] = ch;
			n++;
		}
		str = (char*)realloc(str, n + 2);
		str[n] = '\n';
		str[n + 1] = 0;
		return str;
	}
	void add()
	{
		ifstream check("catalog.txt");
		if (!check)
		{
			check.close();
			cout << "File not created.\n"; Sleep(500);
			cout << "Creating"; Sleep(600);
			cout << '.'; Sleep(600);
			cout << '.'; Sleep(600);
			cout << '.'; system("cls");
			ofstream a("catalog.txt");
			a << '/';
			cout << "Enter company name\n";
			Gets(name);
			a << "\nCompany name: " << name;
			cout << "Enter owner:\n";
			Gets(owner);
			a << "Owner: " << owner;
			cout << "Enter number:\n";
			Gets(number);
			a << "Number: " << number;
			cout << "Enter address:\n";
			Gets(address);
			a << "Address: " << address;
			cout << "Enter company metier:\n";
			Gets(metier);
			a << "Metier: " << metier << "/";
			a.close();
		}
		else
		{
			check.close();
			ofstream a("catalog.txt", std::ofstream::in | std::ofstream::ate | std::ofstream::out);
			cout << "Enter company name\n";
			Gets(name);
			a << "\nCompany name: " << name;
			cout << "Enter owner:\n";
			Gets(owner);
			a << "Owner: " << owner;
			cout << "Enter number:\n";
			Gets(number);
			a << "Number: " << number;
			cout << "Enter address:\n";
			Gets(address);
			a << "Address: " << address;
			cout << "Enter company metier:\n";
			Gets(metier);
			a << "Metier: " << metier << "/";
			a.close();
		}
	}
	void print_all()
	{
		FILE* f = fopen("catalog.txt", "r");
		fseek(f, 0, SEEK_END);
		size_t size = ftell(f);
		fclose(f);
		ifstream out("catalog.txt", ios::in);
		char* s = (char*)malloc(size * sizeof(char));
	    out.getline(s, size, '\0');
		cout << s;
		out.close();
		free(s);
	}
	void find()
	{
		FILE* f = fopen("catalog.txt", "r");
		fseek(f, 0, SEEK_END);
		size_t size = ftell(f);
		fclose(f);
		char* mas = nullptr;
		char ch = 0;
		cout << "1 - Find name.\n"
			<< "2 - Find owner.\n"
			<< "3 - Find number.\n"
			<< "4 - Find metier.\n";
		ch = _getch();
		switch (ch)
		{
		case'1':
			cout << "Enter name\n";
			Gets(mas);
			break;
		case '2':
			cout << "Enter owner\n";
			Gets(mas);
			break;
		case '3':
			cout << "Enter number\n";
			Gets(mas);
			break;
		case'4':
			cout << "Enter metier\n";
			Gets(mas);
			break;
		}
		ifstream out("catalog.txt", ios::in);
		char* s = (char*)malloc(size * sizeof(char));
		out.getline(s, size, '\0');
		size_t i = 0;
		bool e = false;
		size_t h;
		int k = strlen(mas) - 1;
	check:
		for (int j = 0; i < size; i++)
		{
			if (mas[j] == s[i])
			{
				j++;
				if (mas[j] != s[i + 1])
					j--;
				if (j == k)
				{
					e = true;
					goto print;
				}
			}
			else
			{
				continue;
			}
		}
		goto end;
		print:
		h = i;
		while (true)
		{
			if (s[h] == '/') break;
			else h--;
		}
		h++;
		while (true)
		{
			if (s[h] == '/') break;
			else {
				cout << s[h]; 
				h++;
			}
		}
		goto check;
	end:
		if (e == true)
			cout << "\nDone\n";
		else cout << "\nNo matches\n";
	}
	~catalog()
	{
		free(name);
		free(owner);
		free(number);
		free(address);
		free(metier);
	}
};

void main()
{
	catalog b;
	b.add();
	b.print_all();
	system("pause");
	system("cls");
	b.find();
}