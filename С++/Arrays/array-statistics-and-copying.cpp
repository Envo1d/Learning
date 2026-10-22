// Источник: Homework 3.txt
#include <iostream>
#include <time.h>

// 1: В одномерном массиве, заполненном случайными числами, определить минимальный и максимальный элементы.

namespace task11 {
using namespace std;

void run()
{
	setlocale(0, "");
	srand(time(NULL));
	int arr[10], min, max;
	cout << "Все элементы массива: ";
	for (int i = 0; i < 10; i++)
	{
		arr[i] = rand();
		cout << arr[i]<<endl;
		if (i == 0 || arr[i] < min)
			min = arr[i];
		if (i == 0 || arr[i] > max)
			max = arr[i];
	}
	cout <<"Максимальный элемент массива - "<< max << "\nМинимальный элемент массива - " << min;
}
} // namespace task11

// 2: Пользователь вводит прибыль фирмы за год (12 месяцев). 
// Затем пользователь вводит диапазон (например, 3 и 6 – поиск между 3-м и 6-м месяцем). 
// Необходимо определить месяц, в котором прибыль была максимальна и месяц, в котором прибыль была минимальна с учетом выбранного диапазона.

namespace task12 {
using namespace std;

void run()
{
	setlocale(0, "");
	int d1, d2, max, min;
	const int n = 12;
	int arr[n];
	cout << "Введите доход :\n";
	for (int i = 0; i < n; i++)
	{
		cout << "Месяц " << i + 1 << ": ";
		cin >> arr[i];
	}
	cout << "Введите начальный месяц и конечный:\n";
	cin >> d1 >> d2;
	max = min = d1 - 1;
	for (int i = d1; i < d2; i++)
	{
		if (arr[i] > arr[max]) 
			max = i;
		if (arr[i] < arr[min]) 
			min = i;
	}
	cout << "Максимальный доход " << max + 1 << "\n";
	cout << "Минимальный доход " << min + 1 << "\n";
}
} // namespace task12

// 3: В одномерном массиве, состоящем из N вещественных чисел вычислить:
// • Сумму отрицательных элементов.
// • Произведение элементов, находящихся между min и max элементами.
// • Произведение элементов с четными номерами.
// • Сумму элементов, находящихся между первым и последним отрицательными элементами.

namespace task13 {
using namespace std;

void run()
{
	setlocale(0, "");
	int a = -30, b = 30, sum = 0, p = 1;
	const int n = 10;
	int arr[n];
	int sum2 = 0, last = n - 1, first = -1;
	int j, min = 0, max = 0, pmm = 1;
	for (int i = 0; i < n; i++)
	{
		arr[i] = a + rand() % (b - a + 1);
		cout << arr[i] << "\t";
	}

	for (j = 0; j < n; j++)
	{
		if (arr[j] < arr[min]) 
			min = j;
		if (arr[j] > arr[max]) 
			max = j;
	}

	if (max > min)
	{
		j = max;
		max = min;
		min = j;
	}

	for (j = max + 1; j < min; j++)
		pmm *= arr[j];

	for (int i = 0; i < n; i++)
	{
		if (arr[i] < 0)
			sum += arr[i];
		if ((i + 1) % 2 == 0)
			p *= arr[i];

		for (int i = 0; i < n; ++i)
			if (arr[i] < 0)
			{
				first = i;
				break;
			}
	}
		if (first != -1)
		{
			for (int i = first + 1; i < n; ++i)
				if (arr[i] < 0)
					last = i;
		}
		else
		{
			first = n - 1;
		}

		for (int i = first + 1; i < last; ++i)
		{
			sum2 += arr[i];
		}
		cout << "\n\nСумма отрицательных элементов = " << sum << endl;
		cout << "Произведение элементов с четными номерами = " << p << endl;
		cout << "Произведение чисел между max и min элементами = " << pmm << endl;
		cout << "Сумма элементов, находящихся между первым и последним отрицательными элементами = " << sum2;
}
} // namespace task13

// 4: Написать программу, копирующую последовательно элементы одного массива размером 10 элементов в 2 массива размером 5 элементов каждый.

namespace task14 {
using namespace std;

void run()
{
	setlocale(0, "");
	srand(time(NULL));
	int mas[10], mas1[5], mas2[5];
	cout << "Изначальный массив :\n";
	for (int i = 0; i < 10; i++)
	{
		mas[i] = rand();
		cout << mas[i] << "\t";
	}
	cout << "\nПервый массив :\n";
	for (int i = 0; i < 5; i++)
	{
		mas1[i] = mas[i];
		cout << mas1[i] << "\t";
	}
	cout << "\nВторой массив :\n";
	for (int j = 0, i = 5; i < 10; ++j, ++i)
	{
		mas2[j] = mas[i];
		cout << mas2[j] << "\t";
	}
}
} // namespace task14

// 5: Напишите программу, которая выполняет поэлементную сумму двух массивов и результат заносит в третий массив.

namespace task15 {
using namespace std;

void run()
{
	setlocale(0, "");
	srand(time(NULL));
	int mas[10], mas1[10], mas2[10];
	cout << "Первый массив:\n";
	for (int i = 0; i < 10; i++)
	{
		mas1[i] = rand();
		cout << mas1[i] << "\t";
	}
	cout << "\nВторой массив :\n";
	for (int i = 0; i < 10; i++)
	{
		mas2[i] = rand();
		cout << mas2[i] << "\t";
	}
	cout << "\nТретий массив :\n";
	for (int i= 0; i < 10;i++)
	{
		mas[i] = mas1[i] + mas2[i];
		cout << mas[i] << "\t";
	}
}
} // namespace task15

void main()
{
	task11::run();
	task12::run();
	task13::run();
	task14::run();
	task15::run();
}
