// Источник: homework 5.txt
#include <iostream>
#include <ctime>

// Задание 1:
// Написать перегруженные функции (int, double, char) для выполнения следующих задач:
// * Инициализация квадратной матрицы;
// * Вывод матрицы на экран;
// * Определение максимального и минимального элемента на главной диагонали матрицы;
// * Сортировка элементов по возрастанию отдельно для каждой строки матрицы.

namespace task01 {
#define size 5

using namespace std;
int init(int);
int init(char);
int init(double);
void maxmin(int arr[][size])
{
	int max = arr[0][0];
	int min = arr[0][0];
	for (int i = 0; i < size; i++)
	{
		for (int j = 0; j < size; j++)
		{
			if (i == j)
			{
				if (arr[i][j] < min) min = arr[i][j];
				if (arr[i][j] > max) max = arr[i][j];
			}
		}
	}
	cout << "\nМаксимальный элемент = " << max << endl <<
		"Минимальный элемент = " << min << endl;
}
void maxmin(char arr[][size])
{
	int max = arr[0][0];
	int min = arr[0][0];
	for (int i = 0; i < size; i++)
	{
		for (int j = 0; j < size; j++)
		{
			if (i == j)
			{
				if (arr[i][j] < min) min = arr[i][j];
				if (arr[i][j] > max) max = arr[i][j];
			}
		}
	}
	char max2 = max, min2 = min;
	cout << "\nМаксимальный элемент = " << max << " - " << max2 << endl <<
		"Минимальный элемент = " << min << " - " << min2 << endl;
}
void maxmin(double arr[][size])
{
	double max = arr[0][0];
	double min = arr[0][0];
	for (int i = 0; i < size; i++)
	{
		for (int j = 0; j < size; j++)
		{
			if (i == j)
			{
				if (arr[i][j] < min) min = arr[i][j];
				if (arr[i][j] > max) max = arr[i][j];
			}
		}
	}
	cout << "\nМаксимальный элемент = " << max << endl <<
		"Минимальный элемент = " << min << endl;
}
void out(int arr[][size])
{
	for (int i = 0; i < size; i++)
	{
		for (int j = 0; j < size; j++)
		{
			cout << arr[i][j] << "\t";
		}
		cout << endl;
	}
}

void out(char arr[][size])
{
	for (int i = 0; i < size; i++)
	{
		for (int j = 0; j < size; j++)
		{
			cout << arr[i][j] << "\t";
		}
		cout << endl;
	}
}
void out(double arr[][size])
{
	for (int i = 0; i < size; i++)
	{
		for (int j = 0; j < size; j++)
		{
			cout << arr[i][j] << "\t";
		}
		cout << endl;
	}
}
void sort(int arr[][size])
{
	bool f;
	do
	{
		f = false;
		for (int i = 0; i < size; i++)
		{
			for (int j = 0; j < size - 1; j++)
			{
				if (arr[i][j] > arr[i][j + 1])
				{
					int tmp = arr[i][j];
					arr[i][j] = arr[i][j + 1];
					arr[i][j + 1] = tmp;
					f = true;
				}
			}
		}
	} while (f == true);
	cout << "\nОтсортированый массив\n";
	for (int i = 0; i < size; i++)
	{
		for (int j = 0; j < size; j++)
		{
			cout << arr[i][j] << "\t";
		}
		cout << endl;
	}
}
void sort(char arr[][size])
{
	bool f;
	do
	{
		f = false;
		for (int i = 0; i < size; i++)
		{
			for (int j = 0; j < size - 1; j++)
			{
				if (arr[i][j] > arr[i][j + 1])
				{
					char tmp = arr[i][j];
					arr[i][j] = arr[i][j + 1];
					arr[i][j + 1] = tmp;
					f = true;
				}
			}
		}
	} while (f == true);
	cout << "\nОтсортированый массив\n";
	for (int i = 0; i < size; i++)
	{
		for (int j = 0; j < size; j++)
		{
			cout << arr[i][j] << "\t";
		}
		cout << endl;
	}
}void sort(double arr[][size])
{
	bool f;
	do
	{
		f = false;
		for (int i = 0; i < size; i++)
		{
			for (int j = 0; j < size - 1; j++)
			{
				if (arr[i][j] > arr[i][j + 1])
				{
					double tmp = arr[i][j];
					arr[i][j] = arr[i][j + 1];
					arr[i][j + 1] = tmp;
					f = true;
				}
			}
		}
	} while (f == true);
	cout << "\nОтсортированый массив\n";
	for (int i = 0; i < size; i++)
	{
		for (int j = 0; j < size; j++)
		{
			cout << arr[i][j] << "\t";
		}
		cout << endl;
	}
}
void run()
{
	setlocale(0, "");
	srand(unsigned(time(0)));
	int choice;
	cout << "Выберите с каким видом матрицы работать:\n" <<
		"1. Целочисленная\n" <<
		"2. Дробная\n" <<
		"3. Символьная\n";
	cin >> choice;
	switch (choice)
	{
	case 1:
		init(1);
		break;
	case 2:
		init(3.5);
		break;
	case 3:
		init('A');
		break;
	}
}

int init(int a)
{
	int arr[size][size];
	for (int i = 0; i < size; i++)
	{
		for (int j = 0; j < size; j++)
		{
			arr[i][j] = rand() % 100 + 1;
		}
	}
	out(arr);
	maxmin(arr);
	sort(arr);
	return 0;
}
int init(char a)
{
	char mas[size][size];
	for (int i = 0; i < size; i++)
	{
		for (int j = 0; j < size; j++)
		{
			mas[i][j] = rand() % 100 + 1;
		}
	}
	out(mas);
	maxmin(mas);
	sort(mas);
	return 0;
}
int init(double a)
{
	double drob[size][size];
	for (int i = 0; i < size; i++)
	{
		for (int j = 0; j < size; j++)
		{
			drob[i][j] = (rand() % 100) / 10.0;
		}
	}
	out(drob);
	maxmin(drob);
	sort(drob);
	return 0;
}
} // namespace task01
#undef size

// Задание 2:
// Написать перегруженные функции и протестировать их в основной программе:
// * Нахождения максимального значения в одномерном массиве;
// * Нахождения максимального значения в двумерном массиве;
// * Нахождения максимального значения в трёхмерном массиве;
// * Нахождения максимального значения двух целых;
// * Нахождения максимального значения трёх целых;

namespace task02 {
#define a 10
#define b 5
#define c 3
using namespace std;

void max(int arr[])
{
	int max = arr[0];
	for (int i = 0; i < a; i++)
	{
		if (arr[i] > max)max = arr[i];
	}
	cout << max;
}
void max(int arr[][b])
{
	int max = arr[0][0];
	for (int i = 0; i < a; i++)
	{
		for (int j = 0; j < b; j++)
		{
			if (arr[i][j] > max)max = arr[i][j];
		}
	}
	cout << max;
}
void max(int arr[][b][c])
{
	int max = arr[0][0][0];
	for (int i = 0; i < a; i++)
	{
		for (int j = 0; j < b; j++)
		{
			for (int k = 0; k < c; k++)
			{
				if (arr[i][j][k] > max)max = arr[i][j][k];
			}
		}
	}
	cout << max;
}
void max(int f, int s)
{
	if (s > f)cout << s;
	else cout << f;
}
void max(int f, int s, int t)
{
	int max = f;
	if (s > max)max = s;
	if (t > max)max = t;
	cout << max;
}

void run()
{
	srand(unsigned(time(0)));
	setlocale(0, "");
	const int n = 10;
	const int m = 5;
	const int p = 3;
	int mas1[n], mas2[n][m], mas3[n][m][p], f, s, t, choice;
	for (int i = 0; i < n; i++)
	{
		mas1[i] = rand() % 50;
	}
	for (int i = 0; i < n; i++)
	{
		for (int j = 0; j < m; j++) 
		{
			mas2[i][j] = rand() % 100;
		}
	}
	for (int i = 0; i < n; i++)
	{
		for (int j = 0; j < m; j++)
		{
			for (int k = 0; k < p; k++) 
			{
				mas3[i][j][k] = rand() % 150;
			}
		}
	}
	cout << "Есть три массива: \n";
	cout << "Первый\n";
	for (int i = 0; i < n; i++)
	{
		cout << mas1[i] << "\t";
	}
	cout << "\n\n";
	cout << "Второй\n";
	for (int i = 0; i < n; i++)
	{
		for (int j = 0; j < m; j++)
		{
			cout << mas2[i][j] << "\t";
		}
		cout << endl;
	}
	cout << "\n\n";
	cout << "Третий\n";
	for (int i = 0; i < n; i++)
	{
		for (int j = 0; j < m; j++)
		{
			for (int k = 0; k < p; k++)
			{
				cout << mas3[i][j][k] << "\t";
			}
			cout << endl;
		}
	}
	cout << "\n\n";
	cout << "Что делать?\n" <<
		"1. Нахождение максимального значения в одномерном массиве;\n" <<
		"2. Нахождение максимального значения в двумерном массиве;\n" <<
		"3. Нахождение максимального значения в трёхмерном массиве;\n" <<
		"4. Нахождение максимального значения двух целых;\n" <<
		"5. Нахождение максимального значения трёх целых;\n";
	cin >> choice;
	switch (choice)
	{
	case 1:
		max(mas1);
		break;
	case 2:
		max(mas2);
		break;
	case 3: 
		max(mas3);
		break;
	case 4:
		cout << "Введите числа\n";
		cin >> f >> s;
		max(f, s);
		break;
	case 5:
		cout << "Введите числа\n";
		cin >> f >> s >> t;
		max(f, s, t);
		break;
	}
}
} // namespace task02
#undef a
#undef b
#undef c

// Задание 3:
// Измените программы из первого и второго задания с помощью шаблонов

namespace task03 {
#define size 5

using namespace std;
int init(int);
int init(char);
int init(double);
template <typename T> T maxmin(T arr[][size])
{
	T max = arr[0][0];
	T min = arr[0][0];
	for (int i = 0; i < size; i++)
	{
		for (int j = 0; j < size; j++)
		{
			if (i == j)
			{
				if (arr[i][j] < min) min = arr[i][j];
				if (arr[i][j] > max) max = arr[i][j];
			}
		}
	}
	cout << "\nМаксимальный элемент = " << max << endl <<
		"Минимальный элемент = " << min << endl;
	return 0;
}
template <typename Y> Y out(Y arr[][size])
{
	for (int i = 0; i < size; i++)
	{
		for (int j = 0; j < size; j++)
		{
			cout << arr[i][j] << "\t";
		}
		cout << endl;
	}
	return 0;
}

template <typename U> U sort(U arr[][size])
{
	bool f;
	do
	{
		f = false;
		for (int i = 0; i < size; i++)
		{
			for (int j = 0; j < size - 1; j++)
			{
				if (arr[i][j] > arr[i][j + 1])
				{
					U tmp = arr[i][j];
					arr[i][j] = arr[i][j + 1];
					arr[i][j + 1] = tmp;
					f = true;
				}
			}
		}
	} while (f == true);
	cout << "\nОтсортированый массив\n";
	for (int i = 0; i < size; i++)
	{
		for (int j = 0; j < size; j++)
		{
			cout << arr[i][j] << "\t";
		}
		cout << endl;
	}
	return 0;
}
void run()
{
	setlocale(0, "");
	srand(unsigned(time(0)));
	int choice;
	cout << "Выберите с каким видом матрицы работать:\n" <<
		"1. Целочисленная\n" <<
		"2. Дробная\n" <<
		"3. Символьная\n";
	cin >> choice;
	switch (choice)
	{
	case 1:
		init(1);
		break;
	case 2:
		init(3.5);
		break;
	case 3:
		init('A');
		break;
	}
}

int init(int a)
{
	int arr[size][size];
	for (int i = 0; i < size; i++)
	{
		for (int j = 0; j < size; j++)
		{
			arr[i][j] = rand() % 100 + 1;
		}
	}
	out(arr);
	maxmin(arr);
	sort(arr);
	return 0;
}
int init(char a)
{
	char mas[size][size];
	for (int i = 0; i < size; i++)
	{
		for (int j = 0; j < size; j++)
		{
			mas[i][j] = rand() % 100 + 1;
		}
	}
	out(mas);
	maxmin(mas);
	sort(mas);
	return 0;
}
int init(double a)
{
	double drob[size][size];
	for (int i = 0; i < size; i++)
	{
		for (int j = 0; j < size; j++)
		{
			drob[i][j] = (rand() % 100) / 10.0;
		}
	}
	out(drob);
	maxmin(drob);
	sort(drob);
	return 0;
}
} // namespace task03
#undef size

void main()
{
	task01::run();
	task02::run();
	task03::run();
}
