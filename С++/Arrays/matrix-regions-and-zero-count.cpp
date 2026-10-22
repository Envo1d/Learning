// Источник: HM 7.txt
#include <iostream>
#include <ctime>
#include <iomanip>

// 1. Дан двухмерный массив размерностью 3X4. Необ-
// ходимо найти количество элементов значение которых
// равно нулю.

namespace task01 {

using namespace std;

void run() 
{
	setlocale(0, "");
	srand(unsigned(time(0)));
	const int n = 3;
	const int m = 4;
	int mas[n][m], null = 0;
	for (int i = 0; i < n; i++)
	{
		for (int j = 0; j < m; j++)
		{
			mas[i][j] = rand() % 10;
			if (mas[i][j] == 0)
				null++;
			cout << setw(4) << mas[i][j];
		}
		cout << endl;
	}
	cout << "Количество нулей в массиве = " << null;
}
} // namespace task01

// 2. Дана квадратная матрица порядка n (n строк, n стол-
// бцов). Найти наибольшее из значений элементов, распо-
// ложенных в тёмно-синих частях матриц.

namespace task02 {

using namespace std;

void run() 
{
	setlocale(0, "");
	srand(unsigned(time(0)));
	const int n = 7;
	int mas[n][n], choice;
	for (int i = 0; i < n; i++)
	{
		for (int j = 0; j < n; j++)
		{
			mas[i][j] = rand() % 60;
			cout << mas[i][j] << "\t";
		}
		cout << endl;
	}
	cout << "\n\n";
	int max = mas[0][0];
	cout << "Найти максисальное значение в фигуре: \n" << endl <<
		"1. Верхний правый треугольгник" << endl <<
		"2. Нижний левый треугольник" << endl <<
		"3. Верхний треугольник" << endl <<
		"4. Нижний треугольник" << endl <<
		"5. Песочные часы" << endl <<
		"6. Перевёрнутые песочные часы" << endl <<
		"7. Левый треугольник" << endl <<
		"8. Правый треугольник" << endl <<
		"9. Верхний левый треугольник" << endl <<
		"10. Нижний правый треугольник" << endl;
	cin >> choice;
	cout << endl;
	switch (choice)
	{
	case 1: for (int i = 0; i < n; i++)
	{
		for (int j = 0; j < n; j++)
		{
			if (i <= j)
			{
				cout << mas[i][j] << "\t";
				if (mas[i][j] > max) max = mas[i][j];
			}
			else
				cout << "\t";
		}
		cout << "\n";
	}
		  cout << "\nМаксимальное число в фигуре = " << max << endl;
		  break;
	case 2: for (int i = 0; i < n; i++)
	{
		for (int j = 0; j < n; j++)
		{
			if (i >= j)
			{
				cout << mas[i][j] << "\t";
				if (mas[i][j] > max) max = mas[i][j];
			}
			else
				cout << "\t";
		}
		cout << "\n";
	}
		  cout << "\nМаксимальное число в фигуре = " << max << endl;
		  break;
	case 3: for (int i = 0; i < n; i++)
	{
		for (int j = 0; j < n; j++)
		{
			if (i <= n - j - 1 && j >= i)
			{
				cout << mas[i][j] << "\t";
				if (mas[i][j] > max) max = mas[i][j];
			}
			else
				cout << "\t";
		}
		cout << "\n";
	}
		  cout << "\nМаксимальное число в фигуре = " << max << endl;
		  break;
	case 4: for (int i = 0; i < n; i++)
	{
		for (int j = 0; j < n; j++)
		{
			if (i >= n - j - 1 && j <= i)
			{
				cout << mas[i][j] << "\t";
				if (mas[i][j] > max) max = mas[i][j];
			}
			else
				cout << "\t";
		}
		cout << "\n";
	}
		  cout << "\nМаксимальное число в фигуре = " << max << endl;
		  break;
	case 5: for (int i = 0; i < n; i++)
	{
		for (int j = 0; j < n; j++)
		{
			if (i <= n - j - 1 && j >= i || i >= n - j - 1 && j <= i)
			{
				cout << mas[i][j] << "\t";
				if (mas[i][j] > max) max = mas[i][j];
			}
			else
				cout << "\t";
		}
		cout << "\n";
	}
		  cout << "\nМаксимальное число в фигуре = " << max << endl;
		  break;
	case 6: for (int i = 0; i < n; i++)
	{
		for (int j = 0; j < n; j++)
		{
			if (i <= n - j - 1 && j <= i || i >= n - j - 1 && j >= i)
			{
				cout << mas[i][j] << "\t";
				if (mas[i][j] > max) max = mas[i][j];
			}
			else
				cout << "\t";
		}
		cout << "\n";
	}
		  cout << "\nМаксимальное число в фигуре = " << max << endl;
		  break;
	case 7: for (int i = 0; i < n; i++)
	{
		for (int j = 0; j < n; j++)
		{
			if (i <= n - j - 1 && j <= i)
			{
				cout << mas[i][j] << "\t";
				if (mas[i][j] > max) max = mas[i][j];
			}
			else
				cout << "\t";
		}
		cout << "\n";
	}
		  cout << "\nМаксимальное число в фигуре = " << max << endl;
		  break;
	case 8: for (int i = 0; i < n; i++)
	{
		for (int j = 0; j < n; j++)
		{
			if (i >= n - j - 1 && j >= i)
			{
				cout << mas[i][j] << "\t";
				if (mas[i][j] > max) max = mas[i][j];
			}
			else
				cout << "\t";
		}
		cout << "\n";
	}
		  cout << "\nМаксимальное число в фигуре = " << max << endl;
		  break;
	case 9: for (int i = 0; i < n; i++)
	{
		for (int j = 0; j < n; j++)
		{
			if (j + i <= n - 1)
			{
				cout << mas[i][j] << "\t";
				if (mas[i][j] > max) max = mas[i][j];
			}
			else
				cout << "\t";
		}
		cout << "\n";
	}
		  cout << "\nМаксимальное число в фигуре = " << max << endl;
		  break;
	case 10: for (int i = 0; i < n; i++)
	{
		for (int j = 0; j < n; j++)
		{
			if (j >= n - i - 1)
			{
				cout << mas[i][j] << "\t";
				if (mas[i][j] > max) max = mas[i][j];
			}
			else
				cout << "\t";
		}
		cout << "\n";
	}
		   cout << "\nМаксимальное число в фигуре = " << max << endl;
		   break;
	default: cout << "Error";
		break;
	}
}
} // namespace task02

void main()
{
	task01::run();
	task02::run();
}
