// Источник: HM 6.txt
#include <iostream>
#include <time.h>

// 1. Написать программу, которая выводит содержимое
// массива наоборот.

namespace task01 {

using namespace std;

void run()
{
	int mas[3];
	srand(time(NULL));
	setlocale(0, "");
	cout << "Изначальный массив :\n";
	for (int i = 0; i < 3; i++)
	{
		mas[i] = rand();
		cout << mas[i] << "\n";
	}
	cout << "Наоборот :\n";
	for (int i = 2; i >= 0 ; i--)
	{
		cout << mas[i] << "\n";
	}
}
} // namespace task01

// 2. Написать программу, которая находит сумму четных
// и сумму нечетных элементов массива.

namespace task02 {

using namespace std;

void run()
{
	srand(time(NULL));
	int mas[10], sum1 = 0, sum2 = 0;
	setlocale(0, "");
	for (int i = 0; i < 10; i++)
	{
		mas[i] = rand();
		cout << mas[i]<<"\n";
		if (mas[i] % 2 == 0)
			sum1 += mas[i];
		else
			sum2 += mas[i];
	}
	cout << "\n\nСумма четных элементов - " << sum1 << endl <<
		"Сумма нечетных элементов - " << sum2;
}
} // namespace task02

// 3. Написать программу, которая находит в массиве
// значения, повторяющиеся два и более раз, и показывает
// их на экран.

namespace task03 {
using namespace std;

void run()
{
    setlocale(0, "");
    int const n = 10;
    int mas[n], rep=0;
    cout << "Введите элементы массива: \n";
    for (int i = 0; i < n; i++)
    {
        cin >> mas[i];
    }
    cout << "Повторяющиеся элементы: \n";
    for (int i = 0; i < n; i++) {
        for (int j = i + 1; j < n; j++) 
        {
            if (mas[i] == mas[j]) 
            {
                for (int y = j - 1; y >= 0; y--) 
                {
                    if (mas[j] == mas[y])
                        rep++;
                }
                if (rep == 1) 
                {
                    cout << mas[i] << " ";
                }
                rep = 0;
            }
        }
    }
}
} // namespace task03

// 4. Написать программу, которая находит в массиве са-
// мое маленькое нечетное число и показывает его на экран.

namespace task04 {
using namespace std;

void run()
{
    setlocale(0, "");
    int const n = 10;
    int mas[n];
    cout << "Введите элементы массива: \n";
    for (int i = 0; i < n; i++)
    {
        cin >> mas[i];
    }
    int min = mas[0];
    for (int i = 0; i < n; i++)
    {
        if (min > mas[i] && mas[i] % 2 != 0)
            min = mas[i];
    }
    cout << "\nСамое маленькое нечетное число : " << min;
}
} // namespace task04

void main()
{
	task01::run();
	task02::run();
	task03::run();
	task04::run();
}
