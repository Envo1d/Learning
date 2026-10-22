// Источник: homework 8.txt
#include <iostream>
#include <ctime>
#include<iostream>
#include<Windows.h>
#include<conio.h>

// Задание 1:
// Написать функцию, добавляющую столбец двухмерному массиву в указанную позицию.

namespace task01 {

using namespace std;

int** create(int n, int m)
{
    int **mas = (int**)malloc(n * sizeof(int*));
    for (int i = 0; i < n; i++)
    {
        mas[i] = (int*)malloc(m * sizeof(int));
    }
    return mas;
}
void print(int** mas, int n, int m)
{
    for (int i = 0; i < n; i++)
    {
        for (int j = 0; j < m; j++)
        {
            cout << mas[i][j] << "\t";
        }
        cout << endl;
    }
    cout << endl;
}
void rand(int** mas, int n, int m)
{
    for (int i = 0; i < n; i++)
    {
        for (int j = 0; j < m; j++)
        {
            mas[i][j] = rand() % 21;
        }
    }
}
void add_stb(int** mas, int n, int &m, int pos)
{
    for (int i = 0; i < n; i++)
    {
        mas[i] = (int*)realloc(mas[i], (m + 1) * sizeof(int));
        memmove(mas[i] + pos + 1, mas[i] + pos, (m - pos) * sizeof(int));
        mas[i][pos] = 12;
    }
    m++;
}
void run()
{
    srand(unsigned(time(0)));
    int n, m, k;
    cout << "Vvedite razmeri massiva:\n";
    cin >> n >> m;
    int** mas = create(n, m);
    rand(mas, n, m);
    print(mas,n, m);
    cout << "V kakuy pos dobavit stolbec?  ";
    cin >> k;
    add_stb(mas, n, m, k);
    print(mas, n, m);
    for (int i = 0; i < n; i++)
    {
        free(mas[i]);
    }
    free(mas);
}
} // namespace task01

// Задание 2:
// Написать функцию, удаляющую столбец двухмерного массива по указанному номеру.

namespace task02 {

using namespace std;

int** create(int n, int m)
{
    int **mas = (int**)malloc(n * sizeof(int*));
    for (int i = 0; i < n; i++)
    {
        mas[i] = (int*)malloc(m * sizeof(int));
    }
    return mas;
}
void print(int** mas, int n, int m)
{
    for (int i = 0; i < n; i++)
    {
        for (int j = 0; j < m; j++)
        {
            cout << mas[i][j] << "\t";
        }
        cout << endl;
    }
    cout << endl;
}
void rand(int** mas, int n, int m)
{
    for (int i = 0; i < n; i++)
    {
        for (int j = 0; j < m; j++)
        {
            mas[i][j] = rand() % 21;
        }
    }
}
void dell_stb(int** mas, int n, int &m, int pos)
{
    for (int i = 0; i < n; i++)
    {
        memmove(mas[i] + pos, mas[i] + pos + 1, (m - pos - 1) * sizeof(int));
        mas[i] = (int*)realloc(mas[i], (m - 1) * sizeof(int));
    }
    m--;
}
void run()
{
    srand(unsigned(time(0)));
    int n, m, k;
    cout << "Vvedite razmeri massiva:\n";
    cin >> n >> m;
    int** mas = create(n, m);
    rand(mas, n, m);
    print(mas,n, m);
    cout << "V kakuy pos ydalit stolbec?  ";
    cin >> k;
    dell_stb(mas, n, m, k);
    print(mas, n, m);
    for (int i = 0; i < n; i++)
    {
        free(mas[i]);
    }
    free(mas);
}
} // namespace task02

// Задание 3:
// Дана матрица порядка MxN (M строк, N столбцов). 
// Необходимо заполнить ее значениями и написать функцию, осуществляющую циклический сдвиг 
// строк и/или столбцов массива указанное количество раз и в указанную сторону.

namespace task03 {

using namespace std;

int** create(int n, int m)
{
    int** mas = (int**)malloc(n * sizeof(int*));
    for (int i = 0; i < n; i++)
    {
        mas[i] = (int*)malloc(m * sizeof(int));
    }
    return mas;
}
void print(int** mas, int n, int m)
{
    for (int i = 0; i < n; i++)
    {
        for (int j = 0; j < m; j++)
        {
            cout << mas[i][j] << "\t";
        }
        cout << endl;
    }
    cout << endl;
}
void rand(int** mas, int n, int m)
{
    for (int i = 0; i < n; i++)
    {
        for (int j = 0; j < m; j++)
        {
            mas[i][j] = rand() % 21;
        }
    }
}
void move(int** mas, int n, int m)
{
    int col, choice, k = 0;
    cout << "\nВведите количество сдвигов: \n";
    cin >> col;
    cout << "\nВыберите куда сдвинуть массив:" << endl <<
        "1. Влево" << endl <<
        "2. Вправо" << endl <<
        "3. Вверх" << endl <<
        "4. Вниз" << endl;
    cin >> choice;
    switch (choice)
    {
    case 1:
        while (k < col) {
            for (int i = 0; i < n; i++)
            {
                int tmp;
                for (int j = 0; j < m - 1; j++)
                {
                    tmp = mas[i][j];
                    mas[i][j] = mas[i][j + 1];
                    mas[i][j + 1] = tmp;
                }
            }
            k++;
        }
        break;
    case 2:
        while (k < col) {
            for (int i = 0; i < n; i++)
            {
                int tmp;
                for (int j = m - 1; j > 0; j--)
                {
                    tmp = mas[i][j];
                    mas[i][j] = mas[i][j - 1];
                    mas[i][j - 1] = tmp;
                }
            }
            k++;
        }
        break;
    case 3:
        while (k < col) {
            for (int i = 0; i < m; i++)
            {
                int tmp;
                for (int j = 0; j < n - 1; j++)
                {
                    tmp = mas[j][i];
                    mas[j][i] = mas[j + 1][i];
                    mas[j + 1][i] = tmp;
                }
            }
            k++;
        }
        break;
    case 4:
        while (k < col) {
            for (int i = 0; i < m; i++)
            {
                int tmp;
                for (int j = n - 1; j > 0; j--)
                {
                    tmp = mas[j][i];
                    mas[j][i] = mas[j - 1][i];
                    mas[j - 1][i] = tmp;
                }
            }
            k++;
        }
        break;
    default:
        cout << "Error";
    }
}
void run()
{
    srand(unsigned(time(0)));
    setlocale(0, "");
    int n, m, k;
    cout << "Введите размеры массива:\n";
    cin >> n >> m;
    int** mas = create(n, m);
    rand(mas, n, m);
    print(mas, n, m);
    move(mas, n, m);
    print(mas, n, m);
    for (int i = 0; i < n; i++)
    {
        free(mas[i]);
    }
    free(mas);
}
} // namespace task03

// Задание 4:
// Транспонирование матрицы – это операция, после которой столбцы прежней матрицы становятся строками, 
// а строки столбцами. Напишите функцию транспонирования матрицы.

namespace task04 {

using namespace std;

int** create(int n, int m)
{
    int** mas = (int**)malloc(n * sizeof(int*));
    for (int i = 0; i < n; i++)
    {
        mas[i] = (int*)malloc(m * sizeof(int));
    }
    return mas;
}
void print(int** mas, int n, int m)
{
    for (int i = 0; i < n; i++)
    {
        for (int j = 0; j < m; j++)
        {
            cout << mas[i][j] << "\t";
        }
        cout << endl;
    }
    cout << endl;
}
void rand(int** mas, int n, int m)
{
    for (int i = 0; i < n; i++)
    {
        for (int j = 0; j < m; j++)
        {
            mas[i][j] = rand() % 21;
        }
    }
}
void rever(int** mas, int n, int m)
{
    int** newMas = create(m, n);
    for (int i = 0; i < m; i++)
        for (int j = 0; j < n; j++)
            newMas[i][j] = mas[j][i];
    int temp = n;
    n = m;
    m = temp;
    print(newMas, n, m);
    for (int i = 0; i < n; i++)
    {
        free(newMas[i]);
    }
    free(newMas);
}

void run()
{
    srand(unsigned(time(0)));
    setlocale(0, "");
    int n, m, k;
    cout << "Введите размеры массива:\n";
    cin >> n >> m;
    int** mas = create(n, m);
    rand(mas, n, m);
    print(mas, n, m);
    rever(mas, n, m);
    for (int i = 0; i < n; i++)
    {
        free(mas[i]);
    }
    free(mas);
}
} // namespace task04

// Задание 5:
// Создайте динамический массив, хранящий в первой строке имя, а во второй - телефон. 
// Организуйте поиск по имени и по номеру телефона и возможность ввода и изменения данных.

namespace task05 {

using namespace std;

void init(int** mas, int n, int m) {

	for (int i = 0; i < n; i++)
	{
		mas[i] = (int*)malloc(m * sizeof(int));
	}
}
void enter(int** mas, int n, int m) 
{
	for (int i = 0; i < n; i++) {

		for (int j = 0; j < m; j++) 
		{
			if (j % 2 != 0) {
				cout << "Введите номер: "; 
				cin >> mas[i][j];
			}
			else {
				cout << "Введите уникальный номер пользователя: "; 
				cin >> mas[i][j];
			}
		}
	}
}

void edit(int** mas, int n, int p) 
{
	cout << "Введиет новый уникальный номер: ";
	cin >> mas[p - 1][0];
	cout << "Введите новый телефон: ";
	cin >> mas[p - 1][1];
}

void print(int** mas, int n, int m) 
{
	for (int i = 0; i < n; i++) 
	{
		for (int j = 0; j < m; j++) 
		{
			cout << mas[i][j] << "\t";
		}
		cout << "\n";
	}
	cout << "\n";
}
void search(int** mas, int n, int m, int t) 
{
	int value; 
	cout << "Введите значение для поиска: "; 
	cin >> value; 
	short f = 0;
	if (t == 1) {
		for (int i = 0; i < n; i++) 
		{
			for (int j = 0; j < m; j++) 
			{
				if (mas[i][j] == value)
				{
					cout << "Имя: " << mas[i][j] << endl <<
						" Телефон: " << mas[i][j + 1] << endl;
					f = 1;
				}
			}
		}
		if (f == 0) {
			cout << "Ничего нет";
		}
		f = 0;
	}
	else if (t == 2)
	{
		for (int i = 0; i < n; i++) 
		{
			for (int j = 0; j < m; j++) 
			{
				if (mas[i][j] == value) 
				{
					cout << "Имя: " << mas[i][j - 1] << endl <<
						" Телефон: " << mas[i][j] << endl;
					f = 1;
				}
			}
		}
		if (f == 0) 
		{
			cout << "Ничего нет\n";
		}
		f = 0;
	}
	else
		cout << "Error";
}

int run()
{
	setlocale(0, "");
	short n, m = 2; 
	cout << "Введите количество добавляемых людей: "; 
	cin >> n;
	int** mas = (int**)malloc(n * sizeof(int*));
	init(mas, n, m);
	enter(mas, n, m);
	char ch;
	int k, t, p;
	do
	{
		system("cls");
		cout << "1-Поиск\n";
		cout << "2-Изменить пользователя\n";
		cout << "3-Показать список.\n";
		cout << "Esc - Выход.\n";
		ch = _getch();
		switch (ch)
		{
		case '1':system("cls");

			cout << "Искать по имени(1)/ по телефону(2)\n";
			cin >> t;
			search(mas, n, m, t);
			Sleep(1300);
			break;
		case '2':system("cls");
			cout << "Введите номер пользователя в списке: ";
			cin >> p;
		    edit(mas, n, p);
			Sleep(1300);
			break;
		case '3':system("cls");
			print(mas, n, m);
			system("pause");
			break;
		}
	} while (ch != 27);
	for (short i = 0; i < n; i++) {
		free(mas[i]);
	}
	free(mas);
	return 0;
}
} // namespace task05

void main()
{
	task01::run();
	task02::run();
	task03::run();
	task04::run();
	task05::run();
}
