// Источник: Homework 3.txt
#include <iostream>

// Задание 1. Вывести на экран фигуры заполненные звездочками. Диалог с пользователем реализовать при помощи меню.

namespace task01 {
using namespace std;

void run()
{
	setlocale(0, "");
	int n, choice;
	cout << "Введите количество звёздочек (Не четное)\n";
	cin >> n;
	cout << "Выберите фигуру : \n" << endl <<
		"1. Верхний правый треугольгник" << endl <<
		"2. Нижний левый треугольник" << endl <<
		"3. Верхний треугольник" << endl <<
		"4. Нижний треугольник" << endl <<
		"5. Песочные часы" << endl <<
		"6. Перевёрнутые песочные часы" << endl <<
		"7. Левый треугольник" << endl <<
		"8. Правый треугольник" << endl <<
		"9. Верхний левый треугольник"<<endl<<
		"10. Нижний правый треугольник"<<endl;
	cin >> choice;
	switch (choice)
	{
	case 1: for (int j = 1; j <= n; j++)
	{
		for (int i = 1; i <= n; i++)
		{
			if (j<=i)
				cout << "*";
			else
				cout << " ";
		}
		cout << "\n";
	}
		  break;
	case 2: for (int j = 1; j <= n; j++)
	{
		for (int i = 1; i <= n; i++)
		{
			if (j>=i)
				cout << "*";
			else
				cout << " ";
		}
		cout << "\n";
	}
		  break;
	case 3: for (int j = 1; j <= n; j++)
	{
		for (int i = 1; i <= n; i++)
		{
			if (j<=n-i+1 && i >= j)
				cout << "*";
			else
				cout << " ";
		}
		cout << "\n";
	}
		  break;
	case 4: for (int j = 1; j <= n; j++)
	{
		for (int i = 1; i <= n; i++)
		{
			if (j >= n - i + 1 && i <= j)
				cout << "*";
			else
				cout << " ";
		}
		cout << "\n";
	}
		  break;
	case 5: for (int j = 1; j <= n; j++)
	{
		for (int i = 1; i <= n; i++)
		{
			if (j <= n - i + 1 && i >= j || j >= n - i + 1 && i <= j)
				cout << "*";
			else
				cout << " ";
		}
		cout << "\n";
	}
		  break;
	case 6: for (int j = 1; j <= n; j++)
	{
		for (int i = 1; i <= n; i++)
		{
			if (j <= n - i + 1 && i <= j || j >= n - i + 1 && i >= j)
				cout << "*";
			else
				cout << " ";
		}
		cout << "\n";
	}
		  break;
	case 7: for (int j = 1; j <= n; j++)
	{
		for (int i = 1; i <= n; i++)
		{
			if (j <= n - i + 1 && i <= j)
				cout << "*";
			else
				cout << " ";
		}
		cout << "\n";
	}
		  break;
	case 8: for (int j = 1; j <= n; j++)
	{
		for (int i = 1; i <= n; i++)
		{
			if (j >= n - i + 1 && i >= j)
				cout << "*";
			else
				cout << " ";
		}
		cout << "\n";
	}
		  break;
	case 9: for (int j = 1; j <= n; j++)
	{
		for (int i = 1; i <= n; i++) 
		{
			if (i + j <= n + 1)
				cout << "*";
			else
				cout << " ";
		}
		cout << "\n";
	}
		  break;
	case 10: for (int j = 1; j <= n; j++)
	{
		for (int i = 1; i <= n; i++)
		{
			if (i + j >= n + 1)
				cout << "*";
			else
				cout << " ";
		}
		cout << "\n";
	}
		   break;
	default: cout << "Error";
		break;
	}
}
} // namespace task01

// 2: Подсчитать количество целых чисел в диапазоне от 100 до 999 у которых есть две одинаковые цифры

namespace task02 {
using namespace std;

void run()
{
	setlocale(0, "");
	int num, num1, num2, result = 0;
	for (int i = 100; i <= 999; i++)
	{
		num = i / 100;         
		num1 = (i % 100) / 10;  
		num2 = i % 10;          
		if (num == num1 || num1 == num2 || num2 == num)
		result++;
	}
	cout << "Целых чисел в диапазоне от 100 до 999 у которых две одинаковые цифры : " << result;
}
} // namespace task02

// 3: Подсчитать количество целых чисел в диапазоне от 100 до 999 у которых все цифры разные

namespace task03 {
using namespace std;

void run()
{
	setlocale(0, "");
	int num, num1, num2, result = 0;
	for (int i = 100; i <= 999; i++)
	{
		num = i / 100;         
		num1 = (i % 100) / 10;  
		num2 = i % 10;          
		if (num != num1 && num1 != num2 && num2 != num)
		result++;
	}
	cout << "Целых чисел в диапазоне от 100 до 999 у которых все цифры разные : " << result;
}
} // namespace task03

// 4: Пользователь вводит любое целое число. Необходимо из этого целого числа удалить все цифры 3 и 6 и вывести обратно на экран.

namespace task04 {
using namespace std;

void run()
{
	setlocale(0, "");
	int num, tmp = 1, result = 0;
	cout << "Введите число :\n";
	cin >> num;
	for (; num!= 0;)
	{
		if (num % 10 != 3 && num % 10 != 6)
		{
			result = result + tmp * (num % 10);
			tmp *= 10;
		}
		num /= 10;
	}
	cout << "Новое число = " << result;
}
} // namespace task04

// 5: Пользователь вводит любое целое число А. Необходимо вывести все целые числа В, для которых А делиться без остатка на В*В и не делиться без остатка на В*В*В

namespace task05 {
using namespace std;

void run()
{
	setlocale(0, "");
	int a;
	cout << "Введите число А :\n";
	cin >> a;
	cout << "\nВсе целые числа В, для которых А делиться без остатка на В*В и не делиться без остатка на В*В*В :\n";
	for (int b = 1; b*b <=a; b++)
	{
		if (a%(b*b)==0 && a%(b*b*b)!=0)
		{
			cout << b << endl;
		}
	}
}
} // namespace task05

// 6: Пользователь вводит целое число А. Программа должна определить, что куб суммы цифр этого числа равен А*А

namespace task06 {
using namespace std;

void run()
{
	setlocale(0, "");
	int a, sum = 0;
	cout << "Введите число А :\n";
	cin >> a;
	for (int i = a ;i != 0; i/=10)
	{
		sum += i % 10;
	}
	if (a * a == sum * sum * sum)
		cout << "Куб суммы цифр этого числа равен А*А";
	else
		cout << "Куб суммы не равен А*А";
}
} // namespace task06

// 7: Пользователь вводит целое число. Необходимо вывести все целые числа, на которое заданное число делиться без остатка.

namespace task07 {
using namespace std;

void run()
{
	setlocale(0, "");
	int a;
	cout << "Введите число А :\n";
	cin >> a;
	cout << "Все числа на которые А делиться без остатка :\n";
	for ( int i = 1; i <= a; i++)
	{
		if (a % i == 0)
			cout << i << "\t";
	}
}
} // namespace task07

// 8: Пользователь вводит два целых числа. Необходимо вывести все целые числа, на которые оба введенных числа делятся без остатка.

namespace task08 {
using namespace std;

void run()
{
	setlocale(0, "");
	int a, b;
	cout << "Введите число А и B :\n";
	cin >> a >> b;
	cout << "Все числа на которые А и B делиться без остатка :\n";
	for ( int i = 1; i <= a; i++)
	{
		if (a % i == 0)
			cout << i << "\t";
	}
	cout << endl;
	for (int j = 1; j <= b; j++)
	{
		if (b % j == 0)
			cout << j << "\t";
	}
}
} // namespace task08

// 9: Пользователь вводит число. Определить количество цифр в этом числе, посчитать их сумму и
// среднее арифметическое. Определить количество нулей в этом числе. Общение с пользователем
// организовать через меню.

namespace task09 {
using namespace std;

void run()
{
	setlocale(0, "");
	int a, sum = 0, count = 0, zero = 0;
	float med;
	cout << "Введите желаемое число :\n";
	cin >> a;
	for (; a > 0;)
	{
		sum += a % 10;
		count++;
		if (a % 10 == 0)
		{
			zero++;
		}
		a /= 10;
	}
	med = (float) sum / count;
	cout << "Количество цифр - " << count << endl <<
		"Сумма чисел - " << sum << endl <<
		"Среднее арифметическое - " << med << endl <<
		"Количество нулей - " << zero;
}
} // namespace task09

// 10:
// Написать программу, которая выводит на экран шахматную доску с заданным размером клеточки.

namespace task10 {
using namespace std;

void run()
{
	setlocale(0, "");
	int h, a, w;
	cout << "Введите высоту шахматной доски.\nh = ";
	cin >> h;
	cout << "Введите ширину шахматной доски.\nw = ";
	cin >> w;
	cout << "Введите величину ячейки шахматной доски.\na = ";
	cin >> a;
	for (int i = 0; i < h; i++)
	{
		for (int ii = 0; ii < a; ii++)
		{
			for (int j = 0; j < w; j++)
			{
				for (int jj = 0; jj < a; jj++)
				{
					if (i % 2 == 0 && j % 2 == 0 || i %2 != 0 && j % 2 != 0)
						cout << "*";
					else
						cout << "-";
				}
			}
			cout << "\n";
		}
	}
	cout << "\n";
}
} // namespace task10

// Массивы одномерные

void main()
{
	task01::run();
	task02::run();
	task03::run();
	task04::run();
	task05::run();
	task06::run();
	task07::run();
	task08::run();
	task09::run();
	task10::run();
}
