#include <iostream>
using namespace std;

// Задание 1: Напишите программу, которая вычисляет сумму целых чисел от а до 500 (значение a
// вводится с клавиатуры).

void sumTo500() {
	int a, s = 0;
	cout << "Vvedite a\n";
	cin >> a;
	while (a<=500)
	{
		s += a;
		a++;
	}
	cout << "Summa ot a do 500 = " << s;
}

// Задание 2: Напишите программу, которая запрашивает два целых числа x и y, после чего
// вычисляет и выводит значение x в степени y.

void integerPower() {
	int x, y, i = 0, result = 1;
	cout << "Vvedite x i y\n";
	cin >> x >> y;
	while (i < y)
	{
		result *= x;
		i++;
	}
	cout << x << " v " << y << " stepeni = " << result;
}

// Задание 3: Найти среднее арифметическое всех целых чисел от 1 до 1000.

void arithmeticMean() {
	float sum = 0;	
	for (int i = 0; i <= 1000; i++)
	{
		sum += i;
	}
	cout << "Srednee ariphmeticheskoe ot 1 do 1000 = " << sum / 1000;
}

// Задание 4: Найти произведение всех целых чисел от a до 20 (значение a вводится с клавиатуры:
// 1 <=a <= 20).

void productTo20() {
	double a, s = 1;
	cout << "Vvedite a ";
	cin >> a;
	if (a > 1)
	{
		for (int i = a; i <= 20; i++)
			s *= i;
		cout << "Proizvedenie = " << s;
	}
	else
		cout << "Chislo menshe 1";
}

// Задание 5: Написать программу, которая выводит на экран таблицу умножения на k, где k –
// номер варианта.

void multiplicationTable() {
	int k, i = 1;
	cout << "Vvedite variant: ";
	cin >> k;
	while (i <= 10)
	{
		cout << k << " \* " << i << " = " << k * i << "\n";
		i++;
	}
}

// Задание 6: Вывести на экран все числа от нуля до введенного пользователем числа.

void numbersFromZero() {
	int a , i = 0;
	cout << "Vvedite chislo: ";
	cin >> a;
	while (i <= a)
	{
		cout << i << "\n";
		i++;
	}
}

// Задание 7: Пользователь вводит две границы диапазона, вывести на экран все числа из этого
// диапазона. Предусмотреть, чтобы пользователь мог вводить границы диапазона в произвольном
// порядке.
// 1) вывести все четные числа из диапазона.
// 2) вывести все нечетные числа из диапазона.
// 3) вывести все числа, кратные семи.

void rangeNumbers() {
	int a , b;
	cout << "Vvedite diapazon chisel ";
	cin >> a >> b;
	if (a > b)
	{
		int c;
		c = a;
		a = b;
		b = c;
	}
	cout << "Chetnie chisla: \n";
	for (int i = a; i <= b; i++)
	{
		if (i % 2 == 0)
		{
			cout << i << "\n";
		}
	}
	cout << "Ne chentine chisla: \n";
	for (int i = a; i <= b; i++)
	{
		if (i % 2 != 0)
		{
			cout << i << "\n";
		}
	}
	cout << "Kratnie 7: \n";
	for (int i = a; i <= b; i++)
	{
		if (i % 7 == 0)
		{
			cout << i << "\n";
		}
	}
}

// Задание 8: Пользователь вводит две границы диапазона. Посчитать сумму всех чисел
// диапазона.

void rangeSum() {
	int a , b, sum = 0;
	cout << "Vvedite diapazon chisel\n";
	cin >> a >> b;
	if (a > b)
	{
		int c;
		c = a;
		a = b;
		b = c;
	}
	while (a <= b)
	{
		sum += a;
		a++;
	}
	cout << "Summa chisel = " << sum;
}

// Задание 9: Пользователь с клавиатуры вводит числа. Посчитать их сумму и вывести на экран,
// как только пользователь введет ноль.

void sumUntilZero() {
	double sum = 0, dig;
	cout << "Vvodite chisla dlya summirovaniya (viyti - 0)\n\n";

	do
	{
		cin >> dig;
		if (dig)
			sum += dig;
	} while (dig);
	cout << "Summa chisel = " << sum << endl;
}

void main()
{
	sumTo500();
	integerPower();
	arithmeticMean();
	productTo20();
	multiplicationTable();
	numbersFromZero();
	rangeNumbers();
	rangeSum();
	sumUntilZero();
}
