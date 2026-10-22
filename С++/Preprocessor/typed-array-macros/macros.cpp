// Источник: homework 9.txt
// Задание 2:
// С помощью директивы #define написать следующие макросы:
// * Нахождение меньшего из двух чисел;
// * Нахождение большего из двух чисел;
// * Возведение числа в квадрат;
// * Возведение числа в степень;
// * Проверка числа на четность;
// * Проверка числа на нечетность;

#include <iostream>
#include <conio.h>

#define Min ((a<b)?cout<<a:cout<<b)
#define Max ((a>b)?cout<<a:cout<<b)
#define Squre (cout<<a*a)
#define Step for(int i = 0;i < b;i++){r *= a;}
#define Chet ((a%2==0)?cout<<"Четное":cout<<"Нечетное")

using namespace std;

int main()
{
	setlocale(0, "");
	int a, b, r = 1;
	char ch;
	cout << "1 - Нахождение меньшего из двух чисел\n" <<
		"2 - Нахождение большего из двух чисел\n" <<
		"3 - Возведение числа в квадрат\n" <<
		"4 - Возведение числа в степень\n" <<
		"5 - Проверка числа на четность\n";
	ch = _getch();
	switch (ch)
	{
	case '1':
		cout << "Введите числа: ";
		cin >> a >> b;
		Min<<" меньше";
		break;
	case '2':
		cout << "Введите числа: ";
		cin >> a >> b;
		Max<<" больше";
		break;
	case '3':
		cout << "Введите число: ";
		cin >> a;
		Squre;
		break;
	case '4':
		cout << "Введите число и степень: ";
		cin >> a >> b;
		Step;
		cout << r;
		break;
	case '5':
		cout << "Введите число: ";
		cin >> a;
		Chet;
		break;
	}
}