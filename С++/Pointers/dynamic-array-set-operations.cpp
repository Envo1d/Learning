// Источник: homework 7.txt
#include <iostream>
#include <ctime>
#include<iostream>
#include <cmath>

// Задание 1:
// Даны два массива: А[M] и B[N] (M и N вводятся с клавиатуры). Необходимо создать третий массив минимально возможного размера, 
// в котором нужно собрать элементы массива A, которые не включаются в массив B, без повторений.

namespace task01 {

using namespace std;

void print(int *mas, int);
void init(int *mas, int);
void arr_fill(int* mas1, int* mas2, int* mas3, int, int);
int filter(int* mas, int N, int num)
{
    for (int i = 0; i < N; i++)
    {
        if (mas[i] == num) return 1;
    }
    return 0;
}
 
void run()
{
    srand(unsigned(time(0)));
    setlocale(0, "");
    int M, N;
    cout << "Введите размер первого и второго массива:\n";
    cin >> M >> N;
    cout << endl;
    int* A = (int*)malloc(M * sizeof(int));
    int* B = (int*)malloc(N * sizeof(int));
    int* C = (int*)malloc(sizeof(int));
    init(A, M);
    init(B, N);
    print(A, M);
    cout << endl;
    print(B, N);
    cout << endl;
    arr_fill(A, B, C, M, N);
    free(A);
    free(B);
}
void print(int *mas, int a)
{
    for (int i = 0; i < a; i++)
    {
        cout << mas[i] << "\t";
    }
}
void init(int* mas, int a)
{
    for (int i = 0; i < a; i++)
    {
        mas[i] = rand() % 11;
    }
}
void arr_fill(int* mas1, int* mas2, int* mas3, int M, int N)
{
    int g = 0;
    int K = 0;
    for (int i = 0; i < M; i++)
    {
        if (filter(mas2, N, mas1[i]) == 0)
        {
            if (filter(mas3, K, mas1[i]) == 0)
            {
                mas3 = (int*)realloc(mas3, (K + 1) * sizeof(int));
                K++;
                mas3[g] = mas1[i];
                g++;
            }
        }
    }
    print(mas3, K);
}
} // namespace task01

// Задание 2:
// Даны два массива: А[M] и B[N] (M и N вводятся с клавиатуры). Необходимо создать третий массив минимально возможного размера, 
// в котором нужно собрать элементы массивов A и B, которые не являются общими для них, без повторений.

namespace task02 {

using namespace std;

void print(int *mas, int);
void init(int *mas, int);
void arr_fill(int* mas1, int* mas2, int* mas3, int, int);
int filter(int* mas, int N, int num)
{
    for (int i = 0; i < N; i++)
    {
        if (mas[i] == num) return 1;
    }
    return 0;
}
 
void run()
{
    srand(unsigned(time(0)));
    setlocale(0, "");
    int M, N;
    cout << "Введите размер первого и второго массива:\n";
    cin >> M >> N;
    cout << endl;
    int* A = (int*)malloc(M * sizeof(int));
    int* B = (int*)malloc(N * sizeof(int));
    int* C = (int*)malloc(sizeof(int));
    init(A, M);
    init(B, N);
    print(A, M);
    cout << endl;
    print(B, N);
    cout << endl;
    arr_fill(A, B, C, M, N);
    free(A);
    free(B);
}
void print(int *mas, int a)
{
    for (int i = 0; i < a; i++)
    {
        cout << mas[i] << "\t";
    }
}
void init(int* mas, int a)
{
    for (int i = 0; i < a; i++)
    {
        mas[i] = rand() % 11;
    }
}
void arr_fill(int* mas1, int* mas2, int* mas3, int M, int N)
{
    int g = 0;
    int K = 0;
    for (int i = 0; i < M; i++)
    {
        if (filter(mas2, N, mas1[i]) == 0)
        {
            if (filter(mas3, K, mas1[i]) == 0)
            {
                mas3 = (int*)realloc(mas3, (K + 1) * sizeof(int));
                K++;
                mas3[g] = mas1[i];
                g++;
            }
        }
    }
    for (int i = 0; i < N; i++)
    {
        if (filter(mas1, M, mas2[i]) == 0)
        {
            if (filter(mas3, K, mas2[i]) == 0)
            {
                mas3 = (int*)realloc(mas3, (K + 1) * sizeof(int));
                K++;
                mas3[g] = mas2[i];
                g++;
            }
        }
    }
    print(mas3, K);
}
} // namespace task02

// Задание 3:
// Даны два массива: А[M] и B[N] (M и N вводятся с клавиатуры). Необходимо создать третий массив минимально возможного размера, 
// в котором нужно собрать элементы обоих массивов.

namespace task03 {

using namespace std;

void print(int *mas, int);
void init(int *mas, int);
void arr_fill(int* mas1, int* mas2, int* mas3, int, int);
 
void run()
{
    srand(unsigned(time(0)));
    setlocale(0, "");
    int M, N;
    cout << "Введите размер первого и второго массива:\n";
    cin >> M >> N;
    cout << endl;
    int* A = (int*)malloc(M * sizeof(int));
    int* B = (int*)malloc(N * sizeof(int));
    int* C = (int*)malloc((M + N) * sizeof(int));
    init(A, M);
    init(B, N);
    print(A, M);
    cout << endl;
    print(B, N);
    cout << endl;
    arr_fill(A, B, C, M, N);
    free(A);
    free(B);
}
void print(int *mas, int a)
{
    for (int i = 0; i < a; i++)
    {
        cout << mas[i] << "\t";
    }
}
void init(int* mas, int a)
{
    for (int i = 0; i < a; i++)
    {
        mas[i] = rand() % 11;
    }
}
void arr_fill(int* mas1, int* mas2, int* mas3, int M, int N)
{
    int g = 0;
    int K = M+N;
    for (int i = 0; i < M; i++)
    {
            mas3[g] = mas1[i];
            g++;
    }
    for (int i = 0; i < N; i++)
    {
            mas3[g] = mas2[i];
            g++;
    }
    print(mas3, K);
}
} // namespace task03

// Задание 4:
// Даны два массива: А[M] и B[N] (M и N вводятся с клавиатуры). Необходимо создать третий массив минимально возможного размера, 
// в котором нужно собрать общие элементы двух массивов без повторений.

namespace task04 {

using namespace std;

void print(int* mas, int);
void init(int* mas, int);
void arr_fill(int* mas1, int* mas2, int* mas3, int, int);
int filter(int* mas, int N, int num)
{
    for (int i = 0; i < N; i++)
    {
        if (mas[i] == num) return 1;
    }
    return 0;
}

void run()
{
    srand(unsigned(time(0)));
    setlocale(0, "");
    int M, N;
    cout << "Введите размер первого и второго массива:\n";
    cin >> M >> N;
    cout << endl;
    int* A = (int*)malloc(M * sizeof(int));
    int* B = (int*)malloc(N * sizeof(int));
    int* C = (int*)malloc(sizeof(int));
    init(A, M);
    init(B, N);
    print(A, M);
    cout << endl;
    print(B, N);
    cout << endl;
    arr_fill(A, B, C, M, N);
    free(A);
    free(B);
}
void print(int* mas, int a)
{
    for (int i = 0; i < a; i++)
    {
        cout << mas[i] << "\t";
    }
}
void init(int* mas, int a)
{
    for (int i = 0; i < a; i++)
    {
        mas[i] = rand() % 11;
    }
}
void arr_fill(int* mas1, int* mas2, int* mas3, int M, int N)
{
    int g = 0;
    int K = 0;
    for (int i = 0; i < M; i++)
    {
        if (filter(mas2, N, mas1[i]) == 1)
        {
            if (filter(mas3, K, mas1[i]) == 0)
            {
                mas3 = (int*)realloc(mas3, (K + 1) * sizeof(int));
                K++;
                mas3[g] = mas1[i];
                g++;
            }
        }
    }
    print(mas3, K);
}
} // namespace task04

// Задание 5:
// Дан массив: А[M] (M вводится с клавиатуры). Необходимо удалить из массива четные или нечетные значения. 
// Пользователь вводит данные в массив, а также с помощью меню решает, что нужно удалить.

namespace task05 {

using namespace std;

void print(int* mas, int);
int filter(int);
int* move(int* mas, int pos, int& k)
{
	memmove(mas + pos, mas + pos + 1, (k - pos - 1) * sizeof(int));
	mas = (int*)realloc(mas, (k - 1) * sizeof(int));
	k--;
	return mas;
}

void run()
{
	setlocale(0, "");
	int M, c;
	cout << "Введите размер массива\n";
	cin >> M;
	int* A = (int*)malloc(M * sizeof(int));
	cout << "\nВведите элементы массива\n";
	for (int i = 0; i < M; i++)
	{
		cin >> A[i];
	}
	cout << "\nМассив:\n";
	print(A, M);
	cout << "Какие удалить числа?\n" <<
		"1 - Четные\n" <<
		"2 - Нечетные\n";
	cin >> c;
	if (c == 1)
	{
		for (int i = 0; i < M; i++)
		{
			if (filter(A[i]) == 1)
			{
				A = move(A, i, M);
				i--;
			}
		}
		cout << "После удаления:\n";
		print(A, M);
	}
	else if (c == 2)
	{
		for (int i = 0; i < M; i++)
		{
			if (filter(A[i]) == 0)
			{
				A = move(A, i, M);
				i--;
			}
		}
		cout << "После удаления:\n";
		print(A, M);
	}
	else
		cout << "Error";
        free(A);
}

void print(int* mas, int k)
{
	for (int i = 0; i < k; i++)
	{
		cout << mas[i] << "\t";
	}
	cout << "\n";
}

int filter(int num)
{
	if (num % 2 == 0)
		return 1;
	else
		return 0;
}
} // namespace task05

// Задание 6:
// Написать функцию, которая получает указатель на динамический массив и его размер. Функция
// должна удалить из массива все простые числа и вернуть указатель на новый динамический
// массив.

namespace task06 {

using namespace std;

int simple(int num);
int* del(int* mas, int, int& size2);
void print(int* mas, int);

void run()
{
	srand(unsigned(time(0)));
	setlocale(0, "");
	int size, size2 = 0;
	cout << "Введите размер массива: \n"; 
	cin >> size;
	int* A = new int[size];
	for (int i = 0; i < size; i++)
	{
		A[i] = rand() % 51;
	}
	cout << "Массив:\n";
	print(A, size);
	cout << "\n\n";
	int* B = del(A, size, size2);
	cout<< "Массив без простых чисел:\n";
	print(B, size2);
	delete[] A;
	delete[] B;
}

int simple(int num)
{
	if ((num == 2) || (num == 3))
		return 1;
	else {
		for (int i = 2; i <= sqrt(num); ++i)
			if (num % i == 0)
			{
				return 0;
				break;
			}
	}
}

int* del(int* arr, int size, int& size2)
{
	for (int i = 0; i < size; ++i)
	{
		if (simple(arr[i])==0) 
			++size2;
	}
	int* B2 = new int[size2];
	for (int i = 0, k = 0; i < size; ++i)
	{
		if (simple(arr[i]) == 0)
		{
			B2[k] = arr[i];
			k++;
		}
	}
	return B2;
}
void print(int* mas, int k)
{
	for (int i = 0; i < k; i++)
	{
		cout << mas[i] << "\t";
	}
	cout << endl;
}
} // namespace task06

// Задание 7:
// Написать функцию, которая получает указатель на статический массив и его размер. 
// Функция распределяет положительные, отрицательные и нулевые элементы в отдельные динамические массивы.

namespace task07 {

using namespace std;

void print(int* mas, int);
void sort(int mas[], int);


void run()
{
	srand(unsigned(time(0)));
	setlocale(0, "");
	const int n = 30;
	int mas[n];
	for (int i = 0; i < n; i++)
		mas[i] = rand() % 20 - 10;
	cout << "Статический массив:\n";
	print(mas, n);
	sort(mas, n);
}

void sort(int mas[], int k)
{
	int* arr1 = (int*)malloc(sizeof(int));
	int* arr2 = (int*)malloc(sizeof(int));
	int* arr3 = (int*)malloc(sizeof(int));
	int c1 = 0, c2 = 0, c3 = 0, g1 = 0, g2 = 0, g3 = 0;
	for (int i = 0; i < k; i++)
	{
		if (mas[i] > 0)
		{
			arr1 = (int*)realloc(arr1, (c1 + 1) * sizeof(int));
			c1++;
			arr1[g1] = mas[i];
			g1++;
		}
		else if (mas[i] == 0)
		{
			arr3 = (int*)realloc(arr3, (c3 + 1) * sizeof(int));
			c3++;
			arr3[g3] = mas[i];
			g3++;
		}
		else
		{
			arr2 = (int*)realloc(arr2, (c2 + 1) * sizeof(int));
			c2++;
			arr2[g2] = mas[i];
			g2++;
		}
	}
	cout << "Массив с положительными элементами:\n";
	print(arr1, c1);
	cout << "Массив с отрицательными элементами:\n";
	print(arr2, c2);
	cout << "Массив с нулевыми элементами:\n";
	print(arr3, c3);
	free(arr1);
	free(arr2);
	free(arr3);
}

void print(int* mas, int k)
{
	for (int i = 0; i < k; i++)
	{
		cout << mas[i] << "\t";
	}
	cout << endl;
}
} // namespace task07

void main()
{
	task01::run();
	task02::run();
	task03::run();
	task04::run();
	task05::run();
	task06::run();
	task07::run();
}
