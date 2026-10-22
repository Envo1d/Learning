#include <iostream>
using namespace std;

// Задание 1: Разработать программу, которая выводит на экран го-
// ризонтальную линию из символов. Число символов,
// какой использовать символ, и какая будет линия —
// вертикальная, или горизонтальная — указывает поль-
// зователь.

int symbolLine() {
	int kol, choice, i = 1;
	char simv;
	cout << "Vvedite chislo simvolov\n";
	cin >> kol;
	cout << "Vvedite zhelayemiy simvol\n";
	cin >> simv;
	cout << "Viberite kakoy bydet liniya \n 1. Vertikalnaya\n 2. Gorizontalnaya\n";
	cin >> choice;
		switch (choice)
		{
		case 1:
			while (i <= kol)
			{
				cout << simv << "\n";
				i++;
			}
			break;
		case 2:
			while (i <= kol)
			{
				cout << simv;
				i++;
			}
			break;
		default: cout << "None";
	}
	return 0;
}

// Задание 2: Написать программу, которая находит сумму всех целых
// нечетных чисел в диапазоне, указанном пользователе.

int oddRangeSum() {
	int sum = 0, a, i = 0;
	cout << "Vvedite diapazon chisel:\n";
	cin >> i >> a;
	if (a < i)
	{
		int c;
		c = a;
		a = i;
		i = c;
	}
	while (i<=a)
	{
		if (i % 2 != 0)
		{
			sum += i;
		}
		i++;
	}
	cout << "Summa vseh ne chotnih chisel = " << sum;
	return 0;
}

// Задание 3: Дано натуральное число n. Написать программу, которая
// вычисляет факториал неотрицательных целых чисел
// n (т.е. число целое и больше 0).

int factorial() {
	unsigned int n, sum = 1, i = 1;
	cout << "Vvedite chislo\n";
	cin >> n;
	if (n != 0)
	{
		while (i <= n)
		{
				sum *= i;
				i++;
		}
		cout << "Rezultat - " << sum;
	}
	else
		cout << "Chislo = 0";
	return 0;
}

// Задание 4: У швеи имеется ткань длиной L. Ей необходимо по-
// шить подушки длиной P. Условно договоримся, что
// ширина ткани совпадает с шириной подушки. Опре-
// делить сколько подушек сможет пошить швея, если
// умножать и делить она не умеет.

int pillowCount() {
	float l, p;
	int count = 0;
	cout << "Vvedite dliny tkani\n";
	cin >> l;
	cout << "Vvedite dliny podyshki\n";
	cin >> p;
	while (l>=p)
	{
		l -= p;
		count++;
	}
	cout << "Shveya smozhet poshit " << count << " podyshek";
	return 0;
}

// Задание 5: На складе имеется определенное количество ящиков
// с яблоками (N>=0 — запрашивается у пользователя).
// Необходимо освободить склад. Машины по очереди
// подъезжают и забирают определенное количество ящи-
// ков. Определить сколько машин подъехало к складу.

void truckCount() {
	int n, cap, count = 0;
	cout << "Skolko yaschikov na sklade?\n";
	cin >> n;
	cout << "Skolko mozhet zabrat 1 mashina?\n";
	cin >> cap;
	while (n > 0)
	{
		n -= cap;
		count++;
	}
	cout << "Zagruzhenih mashin yehalo - " << count;
}

void main()
{
	symbolLine();
	oddRangeSum();
	factorial();
	pillowCount();
	truckCount();
}
