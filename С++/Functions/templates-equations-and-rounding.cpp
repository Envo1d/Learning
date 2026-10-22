// Источник: HM 9.txt
#include <iostream>
#include <ctime>
#include <cmath>

// 1.Написать шаблон функции для поиска среднего арифме-
// тического значений массива.

namespace task01 {
#define n 10

using namespace std;

template <typename T> T avg(T arr[])
{
	double sum = 0;
	for (int i = 0; i < n; i++)
	{
		sum += arr[i];
	}
	sum /= n;
	cout << "\nAVG = " << sum;
	return 0;
}

void run()
{
	srand(unsigned(time(0)));
	double mas[n];
	for (int i = 0; i < n; i++)
	{
		mas[i] = (rand() % 50) / 5.0;
		cout << mas[i] << "\t";
	}
	avg(mas);
}
} // namespace task01
#undef n

// 2.Написать перегруженные шаблоны функций для
// нахождения корней линейного (a*x + b = 0) и квадрат-
// ного (a*x2+b*x + c = 0) уравнений. Замечание: в функции
// передаются коэффициенты уравнений.

namespace task02 {

using namespace std;

template <typename T> T line(T a, T b)
{
	T r;
	if (a != 0)
	{
		r = -b / a;
		cout << "Корень = " << r;
	}
	if (a == 0 and b != 0)
		cout << "Корней нет";
	if (a == 0 and b == 0)
		cout << "Бесконечное много корней";
	return 0;
}
template <typename T2> T2 quad(T2 a, T2 b, T2 c)
{
	T2 D = (b * b) - 4 * a * c;
	T2 r1, r2;
	if (b != 0 and c != 0) {
		if (D > 0)
		{
			r1 = (-b + sqrt(D)) / (2 * a);
			r2 = (-b - sqrt(D)) / (2 * a);
			cout << "Корни уравнения:\n" <<
				"X1 = " << r1 << endl <<
				"X2 = " << r2;
		}
		if (D == 0)
		{
			r1 = -(b / (2 * a));
			r2 = r1;
			cout << "Корни уравнения:\n" <<
				"X1 = " << r1 << endl <<
				"X2 = " << r2;
		}
		if (D < 0) cout << "Корней нет";
	}
	else if (b == 0 and c!= 0)
	{
		if (-(c / a) > 0) {
			r1 = -b + sqrt(-(c / a));
			r2 = -b - sqrt(-(c / a));
			cout << "Корни уравнения:\n" <<
				"X1 = " << r1 << endl <<
				"X2 = " << r2;
		}
		else cout << "Корней нет";
	}
	else if (b!=0 and c==0)
	{
		r1 = -(b / a);
		r2 = r1;
		cout << "Корни уравнения:\n" <<
			"X1 = " << r1 << endl <<
			"X2 = " << r2;
	}
	else 
	{
		cout << "X = 0";
	}
	return 0;
}
void run()
{
	setlocale(0, "");
	double a, b, c;
	int choice;
	cout << "\t\tНахождения корней линейного (ax + b = 0) и квадратного (ax^2 + bx + c = 0) уравнений\n\n";
	cout << "Какое уравнение решить?\n" <<
		"1. Линейное\n" <<
		"2. Квадратное\n";
	cin >> choice;
	switch (choice)
	{
	case 1:
		cout << "Введите коэффициенты:\n";
		cin >> a >> b;
		line(a, b);
		break;
	case 2:
		cout << "Введите коэффициенты:\n";
		cin >> a >> b >> c;
		quad(a, b, c);
		break;
	}
}
} // namespace task02

// 3.Написать функцию, которая принимает в качестве
// параметров вещественное число и количество знаков
// после десятичной точки, которые должны остаться. За-
// дачей функции является округление вышеуказанного
// вещественного числа с заданной точностью

namespace task03 {

using namespace std;

double okryglenie(double, int);

void run()
{
	double num;
	int col;
	cout << "Vvedite chislo:\n";
	cin >> num;
	cout << "Skolko ostavit posle tochki?\n";
	cin >> col;
	okryglenie(num, col);
}
double okryglenie(double num, int col)
{
	int celaya = num;
	num -= celaya;
	for (int i = col; i != 0; i--)
		num *= 10;
	double drobnaya = int(num);
	for (int i = col;i != 0; i--)
		drobnaya /= 10;
	cout << double(celaya + drobnaya);
	return 0;
}
} // namespace task03

void main()
{
	task01::run();
	task02::run();
	task03::run();
}
