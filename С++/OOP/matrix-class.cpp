// Источник: HW OOP 1.txt
// 2. Создать класс для работы с матрицами. Предусмотреть, как минимум,  функции для сложения матриц, умножения матриц,  
// транспонирования матриц, присваивания матриц друг другу, установка и получение произвольного элемента матрицы . 
// Необходимо перегрузить соответствующие операторы.


#include <iostream>
#include <conio.h>
#include <Windows.h>

#define clr system("cls")

using namespace std;

class matrix
{
private:
	double** mas;
	short n;
	short m;
public:
	matrix()
	{
		mas = NULL;
		n = 0;
		m = 0;
	}
	matrix(short k, short j)
	{
		n = k;
		m = j;
		mas = (double**)malloc(n * sizeof(double*));
		for (short i = 0; i < n; i++)
		{
			mas[i] = (double*)malloc(m * sizeof(double));
		}
	}
	matrix(const matrix& copy)
	{
		n = copy.n;
		m = copy.m;
		mas = (double**)malloc(n * sizeof(double*));
		for (short i = 0; i < n; i++)
		{
			mas[i] = (double*)malloc(m * sizeof(double));
		}
		for (short i = 0; i < n; i++)
		{
			for (short j = 0; j < m; j++)
			{
				mas[i][j] = copy.mas[i][j];
			}
		}
	}
	matrix operator=(const matrix& copy)
	{
		if (this != &copy)
		{
			if (mas != NULL) {
				for (int i = 0; i < n; i++)
				{
					free(mas[i]);
				}
				free(mas);
			}
			n = copy.n;
			m = copy.m;
			mas = (double**)malloc(n * sizeof(double*));
			for (short i = 0; i < n; i++)
			{
				mas[i] = (double*)malloc(m * sizeof(double));
			}
			for (short i = 0; i < n; i++)
			{
				for (short j = 0; j < m; j++)
				{
					mas[i][j] = copy.mas[i][j];
				}
			}
		}
		return *this;
	}
	friend ostream& operator<<(ostream& stream, const matrix& data);
	friend istream& operator>>(istream& stream, matrix& data);
	matrix operator+(const matrix& sec)
	{
		matrix tmp(n, m);
		for (short i = 0; i < n; i++)
			for (short j = 0; j < m; j++)
				tmp.mas[i][j] = mas[i][j] + sec.mas[i][j];
		return tmp;
	}
	matrix operator*(const matrix& sec)
	{
		matrix tmp(n, sec.m);
		for (int i = 0; i < n; i++)
		{
			for (int j = 0; j < sec.m; j++)
			{
				tmp.mas[i][j] = 0;
				for (int k = 0; k < m; k++)
					tmp.mas[i][j] += mas[i][k] * sec.mas[k][j];
			}
		}
		return tmp;
	}
	matrix operator==(const matrix& a)
	{
		n = a.n;
		m = a.m;
		for (short i = 0; i < n; i++)
			for (short j = 0; j < m; j++)
				mas[i][j] = a.mas[i][j];
		return *this;
	}
	matrix operator==(const double& num)
	{
		cout << "Enter column and row of number\n";
		short x, y;
		cin >> x >> y;
		mas[y - 1][x - 1] = num;
		cout << "Done";
		return *this;
	}
	double operator()(short x, short y)
	{
		return mas[y - 1][x - 1];
	}
	matrix operator!=(const matrix& sec)
	{
		short tmp1 = n, tmp2 = m;
		double** newmas;
		newmas = (double**)malloc(n * sizeof(double*));
		for (short i = 0; i < n; i++)
		{
			newmas[i] = (double*)malloc(m * sizeof(double));
		}
		for (short i = 0; i < n; i++)
			for (short j = 0; j < m; j++)
				newmas[i][j] = sec.mas[i][j];
		for (int i = 0; i < n; i++)
		{
			free(mas[i]);
		}
		free(mas);
		n = tmp2;
		m = tmp1;
		mas = (double**)malloc(n * sizeof(double*));
		for (short i = 0; i < n; i++)
		{
			mas[i] = (double*)malloc(m * sizeof(double));
		}
		for (short i = 0; i < n; i++)
			for (short j = 0; j < m; j++)
				mas[i][j] = newmas[j][i];
		for (short i = 0; i < n; i++)
			free(newmas[i]);
		free(newmas);
		return *this;
	}
	~matrix()
	{
		for (int i = 0; i < n; i++)
		{
			free(mas[i]);
		}
		free(mas);
	}
};

ostream& operator<<(ostream& stream, const matrix& data)
{
	for (short i = 0; i < data.n; i++)
	{
		for (short j = 0; j < data.m; j++)
			stream << data.mas[i][j] << "\t";
		stream << "\n";
	}
	return stream;
}
istream& operator>>(istream& stream, matrix& data)
{
	for (short i = 0; i < data.n; i++)
		for (short j = 0; j < data.m; j++)
			stream >> data.mas[i][j];
	return stream;
}

void main()
{
	short x1, x2, y1, y2, x, y;
	cout << "Matrix #1\n\n" <<
		"Enter size of matrix (x,y)\n";
	cin >> x1 >> y1;
	cout << "Enter elements of matrix\n";
	matrix n1(y1, x1);
	cin >> n1;
	cout << "Created";
	Sleep(800);
	clr;
	cout << "Matrix #2\n\n" <<
		"Enter size of matrix (x,y)\n";
	cin >> x2 >> y2;
	cout << "Enter elements of matrix\n";
	matrix n2(y2, x2);
	cin >> n2;
	cout << "Created";
	Sleep(800);
	matrix res;
	char c = 0, k = 0;
	double num;
	do {
		clr;
		cout << "Matrix #1\n" << n1 << "\n\n";
		cout << "Matrix #2\n" << n2 << "\n\n";
		char p;
		cout << "1 - addition\n" <<
			"2 - multiplication\n" <<
			"3 - matrix transpose\n" <<
			"4 - assigning matrices to each other\n" <<
			"5 - setting an arbitrary matrix element\n" <<
			"6 - getting an arbitrary matrix element\n" <<
			"Esc - exit\n";
		c = _getch();
		switch (c)
		{
		case '1':clr;
			if ((x1 != x2 && y1 != y2) || (x1 == x2 && y1 != y2) || (x1 != x2 && y1 == y2))
				cout << "They have different sizes";
			else if(x1 == x2 && y1 == y2){
				res = n1 + n2;
				cout << "Result\n" << res << "\n\n";
			}
			system("pause >0");
			break;
		case '2':clr;
			if (x1 != y2)
				cout << "Еhe number of columns Matrix #1 is not equal to the number of rows Matrix #2";
			else {
				res = n1 * n2;
				cout << "Result\n" << res << "\n\n";
			}
			system("pause >0");
			break;
		case '3':clr;
			cout << "Choose matrix\n" <<
				"1 - Matrix #1\n" <<
				"2 - Matrix #2\n";
			k = _getch();
			if (k == '1')
			{
				res = n1;
				res != res;
			}
			if (k == '2')
			{
				res = n2;
				res != res;
			}
			cout << "Result\n" << res << "\n\n";
			system("pause >0");
			break;
		case '4':clr;
			cout << "1 - Matrix #1 to Matrix #2\n" <<
				"2 - Matrix #2 to Matrix #1\n";
			k = _getch();
			if (k == '1')
				n2 == n1;
			if (k == '2')
				n1 == n2;
			break;
		case '5':clr;
			cout << "Enter new number\n";
			cin >> num;
			cout << "Choose matrix\n" <<
				"1 - Matrix #1\n" <<
				"2 - Matrix #2\n";
			k = _getch();
			if (k == '1')
				n1 == num;
			if (k == '2')
				n2 == num;
			break;
		case '6':clr;
			cout << "Choose matrix\n" <<
				"1 - Matrix #1\n" <<
				"2 - Matrix #2\n";
			k = _getch();
			if (k == '1')
			{
				cout << "Enter x and y of number\n";
				cin >> x >> y;
				cout << "\nResult = " << n1(x, y);
			}
			if (k == '2')
			{
				cout << "Enter x and y of number\n";
				cin >> x >> y;
				cout << "\nResult = " << n2(x, y);
			}
			system("pause >0");
			break;
		}
	} while (c != 27);
}

