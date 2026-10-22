// Источник: homework 6.txt
#include <iostream>
#include <ctime>
#include <iomanip>

// Задание 1:
// Используя два указателя на массив целых чисел, скопировать один массив в другой. Использовать в программе арифметику указателей для продвижения по массиву, 
// а также оператор разыменования.

namespace task07 {
#define n 10

using namespace std;

void print(int mas[])
{
	for (int i = 0; i < n; i++)
		cout << "\t" << mas[i];
}

void copy(int *parr1, int *parr2)
{
	for (int i = 0; i < n; i++)
	{
		*(parr2 + i) = *(parr1 + i);
	}
}

void run()
{
	srand(unsigned(time(0)));
	int arr1[n], arr2[n] = {};
	cout << "First array: \n";
	for (int i = 0; i < n; i++)
	{
		arr1[i] = rand() % 51;
	}
	print(arr1);
	cout << "\nSecond array: \n";
	print(arr2);
	copy(arr1, arr2);
	cout << "\nSecond array: \n";
	print(arr2);
}
} // namespace task07
#undef n

// Задание 2:
// Используя указатель на массив целых чисел, изменить порядок следования элементов массива на противоположный. 
// Использовать в программе арифметику указателей для продвижения по массиву, а также оператор разыменования.

namespace task08 {
#define n 10

using namespace std;

void print(int mas[])
{
	for (int i = 0; i < n; i++)
		cout << "\t" << mas[i];
}

void run()
{
	srand(unsigned(time(0)));
	int arr[n], *pl = arr;
	for (int i = 0; i < n; i++)
	{
		arr[i] = rand() % 51;
	}
	print(arr);
	cout << endl;
	for (int i = 0, j = n - 1; i <= j; i++, j--)
	{
		int tmp = *(arr + i);
		*(arr + i) = *(pl + j);
		*(pl + j) = tmp;
	}
	print(arr);
}
} // namespace task08
#undef n

// Задание 3:
// Используя два указателя на массивы целых чисел, скопировать один массив в другой так, 
// чтобы во втором массиве элементы находились в обратном порядке. 
// Использовать в программе арифметику указателей для продвижения по массиву, а также оператор разыменования.

namespace task09 {
#define n 10

using namespace std;

void print(int mas[])
{
	for (int i = 0; i < n; i++)
		cout << "\t" << mas[i];
}

void copy(int *parr1, int *parr2)
{
	for (int i = 0, j = n - 1; i < n; i++, j--)
	{
		*(parr2 + i) = *(parr1 + j);
	}
}

void run()
{
	srand(unsigned(time(0)));
	int arr1[n], arr2[n] = {};
	cout << "First array: \n";
	for (int i = 0; i < n; i++)
	{
		arr1[i] = rand() % 51;
	}
	print(arr1);
	copy(arr1, arr2);
	cout << "\nSecond array: \n";
	print(arr2);
}
} // namespace task09
#undef n

// Задание 4:
// Используя указатели и оператор разыменования, определить наибольшее из двух чисел.

namespace task10 {

using namespace std;

void run()
{
	int a, b;
	cout << "Enter numbers: \n";
	cin >> a >> b;
	int *pa = &a, *pb = &b;
	cout << "The largest number : \n";
	if (*pa > * pb)
		cout << *pa;
	else
		cout << *pb;
}
} // namespace task10

// Задание 5:
// Используя указатели и оператор разыменования, определить знак числа, введённого с клавиатуры.

namespace task11 {

using namespace std;

void run()
{
	int a;
	cout << "Enter numbes: \n";
	cin >> a;
	int *pa = &a;
	if (*pa > 0)
		cout << "Pos";
	else if (*pa == 0)
		cout << "Is zero";
	else
		cout << "Neg";
}
} // namespace task11

// Задание 6:
// Используя указатели и оператор разыменования, обменять местами значения двух переменных.

namespace task12 {

using namespace std;

void run()
{
	int a, b;
	cout << "Enter numbers: \n";
	cin >> a >> b;
	int *pa = &a, *pb = &b;
	system("cls");
	cout << "Before: \n";
	cout << *pa << setw(3) << *pb;
	cout << "\nReverse : \n";
	int tmp = *pa;
	*pa = *pb;
	*pb = tmp;
	cout << *pa << setw(3) << *pb;
}
} // namespace task12

// Задание 7:
// Написать примитивный калькулятор, пользуясь только указателями.

namespace task13 {

using namespace std;

void run()
{
	double a, b;
	char z;
	cout << "Enter operation: \n";
	cin >> a >> z >> b;
	double *pa = &a, *pb = &b;
	if (z == '+')
		cout <<"Res = "<< *pa + *pb;
	else if(z == '-')
		cout << "Res = " << *pa - *pb;
	else if(z=='/')
		cout << "Res = " << *pa / *pb;
	else if(z=='*')
		cout << "Res = " << *pa * *pb;
}
} // namespace task13

// Задание 8:
// Используя указатель на массив целых чисел, посчитать сумму элементов массива. Использовать в программе арифметику 
// указателей для продвижения по массиву, а также оператор разыменования.

namespace task14 {
#define n 10

using namespace std;

void run()
{
	srand(unsigned(time(0)));
	int arr[n], * parr = arr, sum = 0;
	for (int i = 0; i < n; i++)
	{
		arr[i] = rand() % 51;
		cout << "\t" << arr[i];
	}
	for (int i = 0; i < n; i++)
	{
		sum += *(parr + i);
	}
	cout << "\n\nSum = " << sum;
}
} // namespace task14
#undef n

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
