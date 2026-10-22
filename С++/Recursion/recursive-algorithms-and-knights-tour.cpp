// Источник: homework 6.txt
#include <iostream>
#include <ctime>

// Задание 1:
// Написать рекурсивную функцию нахождения наибольшего общего делителя двух целых чисел.

namespace task01 {

using namespace std;

int nod(int,int);

void run()
{
	setlocale(0, "");
	int a, b;
	cout << "Введите числа\n";
	cin >> a >> b;
	cout << "НОД = " << nod(a, b);
}

int nod(int a, int b)
{
	if (b != 0)
	{
		if (a > b)
			return nod(b, a % b);
		else
			return nod(a, b % a);
	}
	else return a;
}
} // namespace task01

// Задание 2:
// Дана шахматная доска размером 8х8 и шахматный конь. Программа должна запросить у пользователя координаты клетки поля и поставить туда коня.
// Задача программы найти и вывести путь коня, при котором он обойдет все клетки доски, становясь в каждую клетку только один раз.
// (Так как процесс отыскания пути для разных начальных клеток может затянуться, то рекомендуется сначала опробовать задачу на поле размером 6х6). 
// В программе необходимо использовать рекурсию.

namespace task02 {
#define n 8

using namespace std;

void print(int mas[][n]);
void horse(int mas[][n], int, int, int);
const int stepx[8] = { 1,2,2,1,-1,-2,-2,-1 };
const int stepy[8] = { 2,1,-1,-2,-2,-1,1,2 };

void run()
{
	setlocale(0, "");
	int x, y, d[n][n] = {};
	cout << "Дана шахматная доска 8Х8\n";
	print(d);
    cout << "\nВведите координаты коня (x , y)\n";
	cin >> x >> y;
	x = x - 1;
	cout << endl;
	horse(d, x, y, 1);
}

void print(int mas[][n])
{
	for (int i = 0; i < n; i++)
	{
		for (int j = 0; j < n; j++)
		{
			cout << mas[i][j] << "\t";
		}
		cout << "\n";
	}
}

void horse(int mas[][n], int ix, int iy, int step)
{
	mas[iy][ix] = step++;
	for (int i = 0; i < n; i++)
	{
		int newy = iy + stepy[i];
		int newx = ix + stepx[i];
		if (step > n*n)
		{
			print(mas);
			exit(0);
		}
		if (newy<0 || newy > n - 1 || newx<0 || newx>n - 1 || mas[newy][newx] != 0)
			continue;
		horse(mas, newx, newy, step);
		mas[newy][newx] = 0;
	}
}
} // namespace task02
#undef n

// Задание 3:
// Написать рекурсивную функцию нахождения степени числа.

namespace task03 {

using namespace std;

int stepen(int,int);

void run()
{
	setlocale(0, "");
	int x, y;
	cout <<"Введите число и желаемую степень(x , y)\n";
	cin >> x >> y;
	cout<<stepen(x, y);
}

int stepen(int a, int b)
{
	if(b==0)return 1;
	if (b != 0)
		return a * stepen(a, b - 1);
	else
		return a;
}
} // namespace task03

// Задание 4:
// Написать рекурсивную функцию, которая выводит N звезд в ряд, число N задает пользователь. Проиллюстрируйте работу функции примером.

namespace task04 {

using namespace std;

int star(int);

void run()
{
	int a;
	cout << "Vvedite colichestvo zvezd\n";
	cin >> a;
	star(a);
}

int star(int a)
{
	if (a == 0)
		return 1;
	if (a != 0)
	{
		cout << "*";
		return star(a - 1);
	}
}
} // namespace task04

// Задание 5:
// Написать рекурсивную функцию, которая вычисляет сумму всех чисел в диапазоне от a до b. Пользователь вводит a и b. Проиллюстрируйте работу функции примером.

namespace task05 {

using namespace std;

int sum(int,int);

void run()
{
	int a, b;
	cout << "Vvedite nachalo diapazona i konec\n";
	cin >> a >> b;
	if (b < a)
	{
		int c = a;
		a = b;
		b = c;
	}
	cout<<"Summa = " << sum(a, b);
}

int sum(int a, int b)
{
	if (a == b)
		return a;
	else return a + sum(a + 1, b);
}
} // namespace task05

// Задание 6:
// Напишите рекурсивную функцию, которая принимает одномерный массив из 100 целых чисел, заполненных случайным образом, 
// и находит позицию, с которой начинается последовательность из 10 чисел, сумма которых минимальна.

namespace task06 {
#define a 100

using namespace std;

int minposl(int mas[], int, int, int);

void run()
{
	srand(unsigned(time(0)));
	int arr[a];
    int pos = 0, s = 1000;
	for (int i = 0; i < a; i++)
	{
		arr[i] = rand() % 101;
		cout << arr[i] << "\t";
	}
    cout << "\nMin poziciya - " << minposl(arr, 0, pos, s);
}

int minposl(int mas[], int n, int pos, int s1)
{
	int s = 0;
	for (int i = n; i < n + 3; i++)
	{
		s += mas[i];
	}
	if (s < s1)
	{
		s1 = s;
		pos = n;
	}
	if (n < a - 10)
		return minposl(mas, n + 1, pos, s1);
	return pos + 1;
}
} // namespace task06
#undef a

void main()
{
	task01::run();
	task02::run();
	task03::run();
	task04::run();
	task05::run();
	task06::run();
}
