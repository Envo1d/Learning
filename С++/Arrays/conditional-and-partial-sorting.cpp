// Источник: HM 10.txt
#include <iostream>
#include <ctime>

// 1. Дан массив чисел размерностью 10 элементов. Написать
// функцию, которая сортирует массив по возрастанию или по
// убыванию, в зависимости от третьего параметра функции.
// Если он равен 1, сортировка идет по убыванию, если 0, то по
// возрастанию. Первые 2 параметра функции — это массив и
// его размер, третий параметр по умолчанию равен 1.

namespace task01 {

using namespace std;

void sort(int arr[], int n, int p = 1)
{
	if (p == 1)
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
		for (int i = 0; i < n; i++)
			cout << arr[i] << "\t";
	}
	if (p==0)
	{
		for (int i = 0; i < n; i++)
		{
			for (int j = 0; j < n - 1; j++)
			{
				if (arr[j] > arr[j + 1])
				{
					int tmp = arr[j];
					arr[j] = arr[j + 1];
					arr[j + 1] = tmp;
				}
			}
		}
		for (int i = 0; i < n; i++)
			cout << arr[i] << "\t";
	}
}

void run()
{
	srand(unsigned(time(0)));
	setlocale(0, "");
	const int n = 10;
	int arr[n], a;
	for (int i = 0; i < n; i++)
	{
		arr[i] = rand() % 100;
		cout <<arr[i]<< "\t";
	}
	cout << "\nКак сортировать массив?\n" <<
		"0 - по возрастанию\n" <<
		"1 - по убыванию\n";
	cin >> a;
	sort(arr, n, a);
}
} // namespace task01

// 2. Дан массив случайных чисел в диапазоне от –20 до
// +20. Необходимо найти позиции крайних отрицательных
// элементов (самого левого отрицательного элемента и са-
// мого правого отрицательного элемента) и отсортировать
// элементы, находящиеся между ними.

namespace task02 {
#define n 15

using namespace std;

void run()
{
	srand(unsigned(time(0)));
	int mas[n];
	for (int i = 0; i < n; i++)
	{
		mas[i] = rand() % 41 - 20;
		cout << mas[i] << "\t";
	}
	cout << endl;
	int L = 0, R = 0;
	for (int i = 0; i < n; i++)
	{
		if (mas[i] < 0)
		{
			L = i;
			break;
		}
	}
	for (int i = n - 1; i > L; i--)
	{
		if (mas[i] < 0)
		{
			R = i;
			break;
		}
	}
	bool f;
	do
	{
		f = false;
		for (int i = L + 1, j = L + 1; i < R - 1; i++, j++)
		{
				if (mas[j] > mas[j + 1])
				{
					int tmp = mas[j];
					mas[j] = mas[j + 1];
					mas[j + 1] = tmp;
					f = true;
				}
		}
	} while (f == true);
	for (int i = 0; i < n; i++)
		cout << mas[i] << "\t";
}
} // namespace task02
#undef n

// 3. Дан массив из 20 целых чисел со значениями от 1 до 20.
// Необходимо:
// * написать функцию, разбрасывающую элементы мас-
// сива произвольным образом;
// * создать случайное число из того же диапазона и найти
// позицию этого случайного числа в массиве;
// * отсортировать элементы массива, находящиеся слева
// от найденной позиции по убыванию, а элементы массива,
// находящиеся справа от найденной позиции по возрастанию.

namespace task03 {
#define n 20

using namespace std;

void rand(int mas[]);
void print(int mas[]);
void sort(int mas[], int);

void run()
{
	srand(unsigned(time(0)));
	setlocale(0, "");
	int mas[n];
	for (int i = 0, j = 1; i < n; i++, j++)
	{
		mas[i] = j;
	}
	print(mas);
	cout << "\n\n\n";
	rand(mas);
	print(mas);
	cout << "\n\n\n";
	int rnum = rand() % n;
	cout << "Random num = " << rnum << endl;
	sort(mas, rnum);
	print(mas);
}
void print(int mas[])
{
	for (int i = 0; i < n; i++)
		cout << mas[i] << "\t";
}
void rand(int mas[])
{
	for (int i = 0; i < n; i++)
	{
		int r = rand() % n;
		int tmp = mas[i];
		mas[i] = mas[r];
		mas[r] = tmp;
	}
}
void sort(int mas[], int num)
{
	int j;
	for (int i = 0; i < n; i++)
	{
		if (mas[i] == num)
			j = i;
	}
	bool f;
	do
	{
		f = false;
		for (int i = 0; i < j - 1; i++)
		{
			if (mas[i] < mas[i + 1])
			{
				int tmp = mas[i];
				mas[i] = mas[i + 1];
				mas[i + 1] = tmp;
				f = true;
			}
		}
	} while (f == true);
	bool m;
	do
	{
		m = false;
		for (int i = j + 1; i < n - 1; i++)
		{
			if (mas[i] > mas[i + 1])
			{
				int tmp = mas[i];
				mas[i] = mas[i + 1];
				mas[i + 1] = tmp;
				m = true;
			}
		}
	} while (m == true);
}
} // namespace task03
#undef n

void main()
{
	task01::run();
	task02::run();
	task03::run();
}
