// Источник: HM 5.txt
#include <iostream>

// 1. Создать программу, которая выводит на экран про-
// стые числа в диапазоне от 2 до 1000. (Число называется
// простым, если оно делится только на 1 и на само себя
// без остатка; причем числа 1 и 2 простыми не считаются).

namespace task01 {
using namespace std;

void run()
{
	setlocale(0, "");
	cout << "Простые числа от 2 до 1000: \n";
	for (int i = 2; i <= 1000; i++)
	{
		for (int j = 2; j <= 1000; j++)
		{	
			if (i % j == 0)
			{
				if (i != j)
					break;
			 cout << i << endl;
			}
		}
	}
}
} // namespace task01

// 2. Написать программу, которая выводит на экран -
// следующую фигуру:
// *********************
// *                   *
// *                   *
// *                   *
// *                   *
// *                   *
// *                   *
// *********************
// Ширина и высота фигуры задаются пользователем с
// клавиатуры.

namespace task02 {
using namespace std;

void run()
{
	setlocale(0, "");
	int a, b;
	cout << "Введите ширину и высоту фигуры: \n";
	cin >> a >> b;
	for (int i = 1; i <= a; i++)
	{
		for (int j = 1; j <= b; j++) 
		{
			if (i == 1 || i == a || j == 1 || j == b)
				cout << "*";
			else
				cout << " ";
		}
		cout << "\n";
	}
}
} // namespace task02

// 3. При помощи цикла показать на экран календарь
// текущего месяца.

namespace task03 {
using namespace std;

void run()
{
	setlocale(0, "");
	cout << "\nПн\tВт\tСр\tЧт\tПт\tСб\tВс\n\n";
	for (int i = 1; i < 3; i++)
	{
		cout << "\t";
	}
	for (int i = 1; i <= 31; i++)
	{
		cout << i << "\t";
		if ((i + 3 - 1) % 7 == 0) {
			cout << endl;
		}
	}
	cout << "\n\n";
}
} // namespace task03

void main()
{
	task01::run();
	task02::run();
	task03::run();
}
