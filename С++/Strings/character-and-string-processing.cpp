// Источник: homework 7.txt
#include<iostream>
#include<Windows.h>

// Задание 1:
// Написать функцию, которая удаляет из строки символ с заданным номером.

namespace task08 {

using namespace std;

char* del(char* mas, int n, int pos)
{
	memmove(mas + pos, mas + pos + 1, (n - pos - 1) * sizeof(char));
	mas = (char*)realloc(mas, (n - 1) * sizeof(char));
	n--;
	return mas;
}

void run()
{
	setlocale(0, "");
	cout << "Вводите текст:\n";
	char* str = (char*)malloc(100 * sizeof(char));
	cin.getline(str, 100);
	system("cls");
	cout << "Под каким номером удалить символ?\n" << str << endl;
	int n;
	cin >> n;
	cout<<del(str, 100, n - 1);
        free(str);
}
} // namespace task08

// Задание 2:
// Написать функцию, которая удаляет из строки все вхождения в нее заданного символа.

namespace task09 {

using namespace std;

char* del(char* mas, int n,char symb, int count)
{
	int k,i=0;
	while (i < count) {
		k = (strchr(mas, symb) - mas);
		memmove(mas + k, mas + k + 1, (n - k - 1) * sizeof(char));
		mas = (char*)realloc(mas, (n - 1) * sizeof(char));
		n--;
		i++;
	}
	return mas;
}

void run()
{
	setlocale(0, "");
	cout << "Вводите текст:\n";
	char* str = (char*)malloc(100 * sizeof(char));
	gets_s(str, 100);
	system("cls");
	cout << "Какой повторяющийся символ удалить?\n" << str << endl;
	char s;
	cin >> s;
	int count = 0,k;
	k = strlen(str);
	for (int i = 0; i <=k; i++)
	{
		if (s==str[i])
		{
			count++;
		}
	}
	cout << del(str, 100, s, count);
	free(str);
}
} // namespace task09

// Задание 3:
// Написать функцию, которая вставляет в строку в указанную позицию заданный символ.

namespace task10 {

using namespace std;

char* add(char* mas, int n, char symb, int pos)
{
	int j = 0;
	char* str = new char[n + 1];
	for (int i = 0; i < n; i++)
	{
		if (i == pos)
		{
			str[i] = symb;
		}
		else {
			str[i] = mas[j];
			j++;
		}
	}
	cout << str;
	return mas;
}

void run()
{
	setlocale(0, "");
	cout << "Вводите текст:\n";
	char* str = new char[100];
	gets_s(str, 100);
	system("cls");
	cout << "Куда и какой символ добавить?\n" << str << endl;
	char s;
	int pos;
	cin >> pos >> s;
	add(str, 100, s, pos);
	delete[]str;
}
} // namespace task10

// Задание 4:
// Написать программу, которая заменяет все символы точки "." в строке, введенной пользователем, на символы восклицательного знака "!".

namespace task11 {

using namespace std;

char* zamena(char* mas,int count)
{
	for (int i = 0; i < count; i++)
	{
		if (mas[i] == '.')
			mas[i] = '!';
	}
	return mas;
}

void run()
{
	setlocale(0, "");
	cout << "Вводите текст:\n";
	char* str = (char*)malloc(100 * sizeof(char));
	gets_s(str, 100);
	cout << endl;
	int k = strlen(str);
	cout << zamena(str, k);
	free(str);
}
} // namespace task11

// Задание 5:
// Пользователь вводит строку символов и искомый символ, посчитать сколько раз он встречается в строке.

namespace task12 {

using namespace std;

void run()
{
	setlocale(0, "");
	cout << "Вводите текст:\n";
	char* str = (char*)malloc(100 * sizeof(char));
	gets_s(str, 100);
	cout << "\nВведите символ количество которого нужно посчитать\n";
	char s;
	cin >> s;
	int k = strlen(str);
	int count=0;
	for (int i = 0; i < k; i++)
	{
		if (str[i] == s)
			count++;
	}
	cout << count;
	free(str);
}
} // namespace task12

// Задание 6:
// Пользователь вводит строку. Определить количество букв, количество цифр и количество остальных символов, присутствующих в строке.

namespace task13 {

using namespace std;

void run()
{
	setlocale(0, "");
	cout << "Вводите текст:\n";
	char* str = (char*)malloc(100 * sizeof(char));
	gets_s(str, 100);
	int k = strlen(str);
	int digits = 0, letters = 0, symb = 0;
	for (int i = 0; i < k; i++) {
		if (str[i] >= '0' && str[i] <= '9')
			digits++;
		else if (str[i] >= 'a' && str[i] <= 'z' || str[i] >= 'A' && str[i] <= 'Z')
			letters++;
		else 
			symb++;
	}
	cout << "Кол. букв = "<<letters<<endl;
	cout << "Кол. цифр = " << digits << endl;
	cout << "Кол. других символов = " << symb << endl;
	free(str);
}
} // namespace task13

// Задание 7:
// Дана строка символов. Заменить в ней все пробелы на табуляции.

namespace task14 {

using namespace std;

void run()
{
	setlocale(0, "");
	cout << "Вводите текст:\n";
	char* str = (char*)malloc(100 * sizeof(char));
	gets_s(str, 100);
	int k = strlen(str);
	for (int i = 0; i < k; i++) {
		if (str[i] == 32)
			str[i] = '\t';
	}
	cout << str;
	free(str);
}
} // namespace task14

// Задание 8:
// Дана строка символов. Определить количество букв, цифр и остальных символов, присутствующих в строке.

namespace task15 {

using namespace std;

void run()
{
	setlocale(0, "");
	cout << "Вводите текст:\n";
	char* str = (char*)malloc(100 * sizeof(char));
	gets_s(str, 100);
	int k = strlen(str);
	int digits = 0, letters = 0, symb = 0;
	for (int i = 0; i < k; i++) {
		if (str[i] >= '0' && str[i] <= '9')
			digits++;
		else if (str[i] >= 'a' && str[i] <= 'z' || str[i] >= 'A' && str[i] <= 'Z')
			letters++;
		else 
			symb++;
	}
	cout << "Кол. букв = "<<letters<<endl;
	cout << "Кол. цифр = " << digits << endl;
	cout << "Кол. других символов = " << symb << endl;
	free(str);
}
} // namespace task15

// Задание 9:
// Подсчитать количество слов во введенном предложении.

namespace task16 {

using namespace std;

void run()
{
	setlocale(0, "");
	cout << "Вводите текст:\n";
	char* str = (char*)malloc(100 * sizeof(char));
	gets_s(str, 100);
	int k = strlen(str);
	int count = 0;
	for (int i = 0; i < k; i++) {
		if (str[i - 1] != ' ' && (str[i] == ' ' || str[i + 1] == '\0'))
			count++;
	}
	cout << "Слов в предложении :"<<count;
	free(str);
}
} // namespace task16

// Задание 10:
// Дана строка символов. Необходимо проверить является ли эта строка палиндромом.

namespace task17 {

using namespace std;

void run()
{
	SetConsoleCP(1251);
	SetConsoleOutputCP(1251);
	cout << "Вводите текст:\n";
	char* str = (char*)malloc(100 * sizeof(char));
	gets_s(str, 100);
	_strlwr_s(str, 100);
	int k = strlen(str);
	for (int i = 0; i < k; i++)
	{
		for (int j = k - 1; j >= 0; j--)
		{
			if (i != j)
			{
				break;
			}
			else
				cout << "Это палиндром";
		}
	}
	free(str);;
}
} // namespace task17

void main()
{
	task08::run();
	task09::run();
	task10::run();
	task11::run();
	task12::run();
	task13::run();
	task14::run();
	task15::run();
	task16::run();
	task17::run();
}
