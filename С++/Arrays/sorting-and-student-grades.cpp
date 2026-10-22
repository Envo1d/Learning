// Источник: homework 5.txt
#include <iostream>
#include <ctime>

// Задание №1:
// Написать программу, выполняющую сортировку одномерного массива целых чисел методом пузырьковой сортировки.

namespace task04 {
#define n 10

using namespace std;

void print(int arr[]);
void sort(int arr[]);

void run()
{
	srand(unsigned(time(0)));
	setlocale(0, "");
	int mas[n];
	for (int i = 0; i < n; i++)
	{
		mas[i] = rand() % 100;
	}
	print(mas);
	cout << "\n\nМассив после сортировки\n\n";
	sort(mas);
	print(mas);
}
void print(int arr[])
{
	for (int i = 0; i < n; i++)
	{
		cout << arr[i] << "\t";
	}
}
void sort(int arr[])
{
	for (int i = 0; i < n; i++)
	{
		for (int j = n - 1; j > i; j--)
		{
			if (arr[j] > arr[j - 1])
			{
				int tmp = arr[j];
				arr[j] = arr[j - 1];
				arr[j - 1] = tmp;
			}
		}
	}
}
} // namespace task04
#undef n

// Задание №2.
// Написать программу, выполняющую сортировку одномерного массива целых чисел методом вставок.

namespace task05 {
#define n 10

using namespace std;

void print(int arr[]);
void sort(int arr[]);

void run()
{
	srand(unsigned(time(0)));
	setlocale(0, "");
	int mas[n];
	for (int i = 0; i < n; i++)
	{
		mas[i] = rand() % 100;
	}
	print(mas);
	cout << "\n\nМассив после сортировки\n\n";
	sort(mas);
	print(mas);
}
void print(int arr[])
{
	for (int i = 0; i < n; i++)
	{
		cout << arr[i] << "\t";
	}
}
void sort(int arr[])
{
	for (int i = 1; i < n; i++)
	{
		int flag = i;
		while (flag > 0 && arr[flag - 1] > arr[flag])
		{
			int tmp = arr[flag - 1];
			arr[flag - 1] = arr[flag];
			arr[flag] = tmp;
			flag -= 1;
		}
	}
}
} // namespace task05
#undef n

// Задание №3.
// Написать программу «успеваемость». Пользователь вводит 10 оценок студента. Реализовать меню для пользователя
// * Вывод оценок (вывод содержимого массива)
// * Пересдача экзамена (пользователь вводит номер элемента массива и новую оценку)
// * Выходит ли стипендия (стипендия выходит, если средний бал не ниже 10.7)

namespace task06 {
#define n 10

using namespace std;

void print(int arr[]);
void retake(int arr[]);
void step(int arr[]);

void run()
{
	setlocale(0, "");
	cout << "\t\t\t\tУспеваемость\n\n";
	int grades[n];
	char choice;
	cout << "Введите оценки за экзамен\n";
	for (int i = 0; i < n; i++)
		cin >> grades[i];
	cout << "Вывести на экран все оценки? [y/n]\n";
	cin >> choice;
	if (choice == 'y')
		print(grades);
	cout << "\n\nБыла пересдача? [y/n]\n";
	cin >> choice;
	if (choice == 'y')
		retake(grades);
	cout << "\nПодсчитать будет ли стипендия? [y/n]\n";
	cin >> choice;
	if (choice == 'y')
		step(grades);
	system("pause >> 0");
}

void print(int arr[])
{
	for (int i = 0; i < n; i++)
		cout << arr[i] << "\t";
}

void retake(int arr[])
{
	char r = 'y', choice;
	while (r == 'y')
	{
		int num;
		cout << "\nВыберите экзамен (1-10) и введите новую оценку\n";
		cin >> num;
		cin >> arr[num - 1];
		cout << "\nБыла ещё пересдача? [y/n]\n";
		cin >> r;
	}
	cout << "\nВывести на экран оценки? [y/n]\n";
	cin >> choice;
	if (choice == 'y')
		print(arr);
}

void step(int arr[])
{
	double avg = 0;
	for (int i = 0; i < n; i++)
		avg += arr[i];
	avg /= 10.0;
	if (avg >= 10.7)
		cout << "\nДа";
	else
		cout << "\nНет. Средний бал ниже 10.7";
}
} // namespace task06
#undef n

// Задание №4.
// Необходимо отсортировать первые две трети массива в порядке возрастания,
// если среднее арифметическое всех элементов больше нуля; иначе - лишь первую треть. 
// Остальную часть массива не сортировать, а расположить в обратном порядке.

namespace task07 {

using namespace std;

void run()
{
	srand(unsigned(time(0)));
	const int n = 12;
	int arr[n];
	double avg = 0;
	for (int i = 0; i < n; i++)
	{
		arr[i] = rand() % 50 - 25;
		cout << arr[i] << "\t";
		avg += arr[i];
	}
	avg /= 12.0;
	cout << "\n\n" << "AVG = " << avg << "\n\n";
	if (avg>0)
	{
		bool f;
		do
		{
			f = false;
			for (int i = 0; i < 7; i++)
			{
				if (arr[i] > arr[i + 1])
				{
					int tmp = arr[i];
					arr[i] = arr[i + 1];
					arr[i + 1] = tmp;
					f = true;
				}
			}
		} while (f == true);
		for (int i = 0; i <= 7; i++)
		{
			cout << arr[i] << "\t";
		}
		for (int i = n - 1; i >= 8; i--)
		{
			cout << arr[i] << "\t";
		}
	}
	else
	{
		bool f;
		do
		{
			f = false;
			for (int i = 0; i < 3; i++)
			{
				if (arr[i] > arr[i + 1])
				{
					int tmp = arr[i];
					arr[i] = arr[i + 1];
					arr[i + 1] = tmp;
					f = true;
				}
			}
		} while (f == true);
		for (int i = 0; i <= 3; i++)
		{
			cout << arr[i] << "\t";
		}
		for (int i = n - 1; i >= 4; i--)
		{
			cout << arr[i] << "\t";
		}
	}
}
} // namespace task07

void main()
{
	task04::run();
	task05::run();
	task06::run();
	task07::run();
}
