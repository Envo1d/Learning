// Источник: HW OOP 2.txt
// 3.	Разработать приложение, имитирующее очередь пе-
// чати принтера. Должны быть клиенты, посылающие
// запросы на принтер, у каждого из которых есть свой
// приоритет. Каждый новый клиент попадает в очередь
// в зависимости от своего приоритета. Необходимо
// сохранять статистику печати (пользователь, время) в
// отдельной очереди. Предусмотреть вывод статистики
// на экран.


#define _CRT_SECURE_NO_WARNINGS
#include <iostream>
#include <ctime>
#include <stdio.h>
#include <conio.h>

using namespace std;

class info
{
	char* inf;
	char timep;
	short prior;
	char* doc_name;
	time_t timer;
public:
	info() 
	{
		inf = (char*)malloc(NULL * sizeof(char));
		prior = 0;
		doc_name = (char*)malloc(NULL * sizeof(char));
	}
	info(const info& copy)
	{
		timer = copy.timer;
		prior = copy.prior;
		inf = (char*)malloc(strlen(copy.inf) + 1);
		strcpy_s(inf, strlen(copy.inf) + 1, copy.inf);
		doc_name = (char*)malloc(strlen(copy.doc_name) + 1);
		strcpy_s(doc_name, strlen(copy.doc_name) + 1, copy.doc_name);
	}
	info& operator=(const info& copy)
	{
		if (this != &copy)
		{
			if (inf != NULL && doc_name != NULL) {
				free(inf);
				free(doc_name);
			}
			timer = copy.timer;
			prior = copy.prior;
			inf = (char*)malloc(strlen(copy.inf) + 1);
			strcpy_s(inf, strlen(copy.inf) + 1, copy.inf);
			doc_name = (char*)malloc(strlen(copy.doc_name) + 1);
			strcpy_s(doc_name, strlen(copy.doc_name) + 1, copy.doc_name);
		}
		return *this;
	}
	void show()
	{
		cout << "\nПриоритет - " << prior << endl;
		cout << inf << endl;
		cout << "Название документа - " << doc_name << endl;
		cout << "Время - " << ctime(&timer);
	}
	short get_p()
	{
		return prior;
	}
	void add()
	{
		cout << "Введите имя пользователя\n";
		Gets(inf);
		cout << "Название документа\n";
		Gets(doc_name);
		cout << "Приоритет = ";
		cin >> prior;
		cin.ignore();
		timer = time(NULL);
	}
	char* Gets(char*& str)
	{
		str = nullptr;
		int n = 0;
		char ch;
		while ((ch = getchar()) != '\n')
		{
			str = (char*)realloc(str, n + 1);
			str[n] = ch;
			n++;
		}
		str = (char*)realloc(str, n + 1);
		str[n] = 0;
		return str;
	}
	~info()
	{
		free(inf);
		free(doc_name);
	}
};

class printer
{
	info mas[15];
	info stat[50];
	int stat_size = -1;
	short count = -1;
public:
	friend class info;
	void push()
	{
		if (!full())
		{
			++count;
			mas[count].add();
			if (count != 0) {
				for (short i = 0; i <= count; i++)
				{
					if (mas[count].get_p() > mas[count - 1].get_p())
					{
						info tmp = mas[count];
						mas[count] = mas[count - 1];
						mas[count - 1] = tmp;
					}
				}
			}
		}
		else cout << "Queue full";
	}
	bool empty()
	{
		return count == -1;
	}
	bool full()
	{
		return count >= 14;
	}
	int pop() {
		if (!empty()) {
			++stat_size;
			stat[stat_size] = mas[0];
			for (int i = 0; i < count; i++)
			{
				mas[i] = mas[i + 1];
			}
			count--;
			return 1;
		}
		else {
			cout << "Error" << endl;
			return 0;
		}
	}
	void clear() {
		count = -1;
	}
	void show_stat()
	{
		for (int i = 0; i <= stat_size; i++)
		{
			cout << "\nN" << i + 1;
			stat[i].show();
		}

	}
	~printer()
	{
		clear();
	}
};

void main()
{
	setlocale(0, "");
	char c = 0;
	printer n1;
	do {
		system("cls");
		cout << "1 - Добавление в очередь на печать\n" <<
			"2 - Удаление с очереди(печать)\n" <<
			"3 - Показать статистику печати\n";
		c = _getch();
		switch (c)
		{
		case '1':system("cls");
			n1.push();
			cout << endl;
			system("pause");
			break;
		case '2':system("cls");
			n1.pop();
			break;
		case '3':system("cls");
			n1.show_stat();
			cout << endl;
			system("pause");
			break;
		}
	} while (c != 27);
}