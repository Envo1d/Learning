// Источник: Homework 4.txt
#include <iostream>
#include <ctime>

// Задание 1:
// Написать функцию, которая принимает два параметра: 
// основание степени и показатель степени, и вычисляет степень числа на основе полученных данных.

namespace task07 {
using namespace std;

void Pow(int, int);

void run()
{
    setlocale(0, "");
	int x, y;
	cout << "Возведение в степень\n" << endl <<
		"Введите число и степень\n";
	cin >> x >> y;
	Pow(x, y);
}
void Pow(int x, int y)
{
	int z = 1;
	for (int i = 0; i < y; i++)
	{
		z *= x;
	}
	cout << "Ваше число = " << z;
}
} // namespace task07

// Задание 2:
// Написать функцию, которая получает в качестве параметров 
// 2 целых числа и возвращает сумму чисел из диапазона между ними.

namespace task08 {
using namespace std;

void sum(int, int);

void run()
{
    setlocale(0, "");
	int x, y;
	cout << "Суммирование чисел в диапазоне\n" << endl <<
		"Введите начало и конец диапазона\n";
	cin >> x >> y;
	sum(x, y);
}
void sum(int x, int y)
{
	int sum = 0;
	for (int i = x + 1; i < y; i++)
	{
		sum += i;
	}
	cout << "Сумма чисел в диапазоне = " << sum;
}
} // namespace task08

// Задание 3:
// Число называется совершенным, если сумма всех его делителей равна ему самому.
// Напишите функцию поиска таких чисел во введенном интервале.

namespace task09 {
using namespace std;

void digit(int, int);

void run()
{
	setlocale(0, "");
	int x, y;
	cout << "Поиск совершенных чисел\n" << endl <<
		"Введите начало и конец интервала поиска\n";
	cin >> x >> y;
    if (x > y) {
        int c = x;
        x = y;
        y = c;
    }
	digit(x, y);
}
void digit(int x, int y)
{
	cout << "Все совершенные числа : \n";
    for (int i = x; i <= y; ++i)
    {
        int sum = 0;

        for (int j = 1; j < i; ++j) {
            if (i % j == 0)
                sum += j;
        }

        if (sum == i)
            cout << i << endl;
    }
}
} // namespace task09

// Задание 4:
// Написать функцию, выводящую на экран переданную ей игральную карту.

namespace task10 {
using namespace std;

void card(int, int);

void run()
{
	setlocale(0, "");
	int x, y;
    cout << "Введите номер карты: " << endl <<
        "1 - Туз \t 2 - Двойка \t 3 - Тройка" << endl <<
        "4 - Четвёрка \t 5 - Пятёрка \t 6 - Шестёрка" << endl <<
        "7 - Семёрка \t 8 - Восьмёрка \t 9 - Девятка" << endl <<
        "10 - Десятка \t 11 - Валет \t 12 - Дама" << endl <<
        "13 - Король\n";
    cin >> x;
    cout<<"Введите масть карты: " << endl <<
        "Черви - 1" << endl <<
        "Бубны - 2" << endl <<
        "Трефы - 3" << endl <<
        "Пики - 4\n";
    cin >> y;
    system("cls");
	card(x, y);
}
void card(int x, int y)
{
    switch (y)
    {
    case 1:
        system("color 04");
        if (x == 1)
        cout << "Tуз Черви\n";
          else if (x == 11)
        cout << "Bалет Черви\n";
          else if (x == 12)
        cout << "Дама Черви\n";
          else if (x == 13)
        cout << "Король Черви\n";
          else
        cout << x << " Черви\n";
        system("pause >> NUL");
        break;
    case 2:
        system("color 06");
        if (x == 1)
            cout << "Tуз Бубны\n";
        else if (x == 11)
            cout << "Bалет Бубны\n";
        else if (x == 12)
            cout << "Дама Бубны\n";
        else if (x == 13)
            cout << "Король Бубны\n";
        else
            cout << x << " Бубны\n";
        system("pause >> NUL");
        break;
    case 3:
        system("color 78");
        if (x == 1)
            cout << "Tуз Трефы\n";
        else if (x == 11)
            cout << "Bалет Трефы\n";
        else if (x == 12)
            cout << "Дама Трефы\n";
        else if (x == 13)
            cout << "Король Трефы\n";
        else
            cout << x << " Трефы\n";
        system("pause >> NUL");
        break;
    case 4:
        system("color 80");
        if (x == 1)
            cout << "Tуз Пики\n";
        else if (x == 11)
            cout << "Bалет Пики\n";
        else if (x == 12)
            cout << "Дама Пики\n";
        else if (x == 13)
            cout << "Король Пики\n";
        else
            cout << x << " Пики\n";
        system("pause >> NUL");
        break;
    default:
       cout << "Error";
        break;
    }
}
} // namespace task10

// Задание 5:
// Написать функцию, которая определяет, является ли «счастливым» шестизначное число.

namespace task11 {
using namespace std;

void lucky(int);

void run()
{
	setlocale(0, "");
    int a;
    cout << "Введите шестизначное число: \n";
    cin >> a;
	lucky(a);
}
void lucky(int a)
{
    int sum1 = 0, sum2 = 0;
	for (int i = 0; i < 3; i++)
	{
		sum1 += a % 10;
		a /= 10;
	}
	for (int i = 0; i < 3; i++)
	{
		sum2 += a % 10;
		a /= 10;
	}
	if (sum1 == sum2)
		cout << "Число счастлливое";
	else
		cout << "Число не счастливое";
}
} // namespace task11

// Задание 6:
// Написать функцию, которая принимает две даты (т.е. функция принимает шесть параметров)
// и вычисляет разность в днях между этими датами. 
// Для решения этой задачи необходимо также написать функцию, которая определяет, является ли год високосным.

namespace task12 {
using namespace std;

int vys(int);
int days(int, int, int, int, int, int);

void run()
{
    setlocale(0, "");
    int d1, m1, y1, d2, m2, y2;
    cout << "Введите первую дату ( ДД ММ ГГГГ ): \n"; 
    cin >> d1 >> m1 >> y1;
    cout << "Введите вторую дату( ДД ММ ГГГГ ): \n"; 
    cin >> d2 >> m2 >> y2;
    m1 -= 1; m2 -= 1;
    cout << "Интервал в днях: " << days(d1, m1, y1, d2, m2, y2);
}
int vys(int y)
{
    if (y % 4 == 0) {
        if (y % 100 != 0) return 1;
        else if (y % 400 == 0)  return  1;
    }
    else
        return 0;
}
int days(int d1, int m1, int y1, int d2, int m2, int y2)
{
    int  DIM1 = 0, DIM2 = 0, totaldays = 0, result, mas[12] = { 31,28,31,30,31,30,31,31,30,31,30,31 };
    for (int i = 0; i < m1; i++)
        DIM1 += mas[i];
    for (int i = 0; i < m2; i++)
        DIM2 += mas[i];
    int tmp = y2 - y1;
    for (int i = y1; i < y2; i++) {
        totaldays = +tmp * 365;
    }
    for (int i = y1; i < y2; i++) {
        totaldays += vys(i);
    }
    result = (d2 - d1) + (DIM2 - DIM1) + totaldays;

    if (vys(y1) == 1 && m1 >= 2 || vys(y2) == 1 && m2 >= 2)
        return  result + 1;
    else
        return result;
}
} // namespace task12

// Задание 7:
// Написать функцию, определяющую среднее арифметическое элементов передаваемого ей массива.

namespace task13 {

using namespace std;

void med(int mas[], const int n)
{
	int sum = 0;
	for (int i = 0; i < n; i++)
	{
		sum += mas[i];
	}
	cout << float(sum / n);
}

void run() 
{
	setlocale(0, "");
	srand(unsigned(time(0)));
	const int n = 10;
	int mas[n];
	for (int i = 0; i < n; i++)
	{
		mas[i] = rand() % 100;
		cout << mas[i] << "\t";
	}
	cout << "\nСреднее арифметическое массива = ";
	med(mas, n);
}
} // namespace task13

// Задание 8:
// Написать функцию, определяющую количество положительных, отрицательных и нулевых элементов передаваемого ей массива.

namespace task14 {
using namespace std;

void med(int mas[], const int n)
{
	int kpl = 0, kmn = 0, null = 0;
	for (int i = 0; i < n; i++)
	{
		if (mas[i] > 0)
			kpl++;
		else if (mas[i] == 0)
			null++;
		else
			kmn++;
	}
	cout << "\n\nКоличество положительных элементов - " << kpl << endl <<
		"Количество отрицательных элементов - " << kmn << endl <<
		"Количество нулевых элементов - " << null;
}

void run() 
{
	setlocale(0, "");
	srand(unsigned(time(0)));
	const int n = 10;
	int mas[n];
	for (int i = 0; i < n; i++)
	{
		mas[i] = rand() % 10 - 5;
		cout << mas[i] << "\t";
	}
	med(mas, n);
	system("pause >> 0");
}
} // namespace task14

void main()
{
	task07::run();
	task08::run();
	task09::run();
	task10::run();
	task11::run();
	task12::run();
	task13::run();
	task14::run();
}
