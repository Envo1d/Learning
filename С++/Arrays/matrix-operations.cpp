// Источник: Homework 4.txt
#include <iostream>
#include <ctime>

// Задание 1:
// Напишите программу, которая создает двухмерный массив и заполняет его по следующему принципу: 
// пользователь вводит число (например, 3) первый элемент массива принимает значение этого числа, 
// последующий элемент массива принимает значение этого числа умноженного на 2 (т.е. 6 для нашего примера), 
// третий элемент массива предыдущий элемент, умноженный на 2 (т.е. 6*2=12 для нашего примера). 
// Созданный массив вывести на экран.

namespace task01 {
using namespace std;

void run()
{
    setlocale(0, "");
    int const n = 3;
    int const m = 5;
    int mas[n][m], a;
    cout << "Введите первый элемент массива: \n";
    cin >> a;
    cout << "\nМассив: \n";
    for(int i = 0 ; i < n; i++)
    {
        for (int j = 0; j < m; j++)
        {
            mas[i][j] = a;
            a *= 2;
        }
    }
    for (int i = 0; i < n; i++)
    {
        for (int j = 0; j < m; j++)
        {
            cout << mas[i][j]<<"\t";
        }
        cout << "\n";
    }
}
} // namespace task01

// Задание 2:
// Напишите программу, которая создает двухмерный массив и заполняет его по следующему принципу: 
// пользователь вводит число (например, 3) первый элемент массива принимает значение этого числа, 
// последующий элемент массива принимает значение этого числа + 1 (т.е. 4 для нашего примера), 
// третий элемент массива предыдущий элемент + 1 (т.е. 5 для нашего примера). 
// Созданный массив вывести на экран.

namespace task02 {
using namespace std;

void run()
{
    setlocale(0, "");
    int const n = 3;
    int const m = 5;
    int mas[n][m], a;
    cout << "Введите первый элемент массива: \n";
    cin >> a;
    cout << "\nМассив: \n";
    for(int i = 0 ; i < n; i++)
    {
        for (int j = 0; j < m; j++)
        {
            mas[i][j] = a;
            a++;
        }
    }
    for (int i = 0; i < n; i++)
    {
        for (int j = 0; j < m; j++)
        {
            cout << mas[i][j]<<"\t";
        }
        cout << "\n";
    }
}
} // namespace task02

// Задание 3:
// Создайте двухмерный массив. Заполните его случайными числами и покажите на экран. 
// Пользователь выбирает количество сдвигов и положение (влево, вправо, вверх, вниз). Выполнить сдвиг массива и показать на экран полученный результат. Сдвиг циклический.
// Например, если мы имеем следующий массив
// 1 2 0 4 5 3
// 4 5 3 9 0 1
// и пользователь выбрал сдвиг на 2 разряда вправо, то мы получим
// 5 3 1 2 0 4
// 0 1 4 5 3 9

namespace task03 {
using namespace std;

void run()
{
    setlocale(0, "");
    srand(unsigned(time(0)));
    int const n = 3;
    int const m = 6;
    int mas[n][m], choice, col, k = 0;
    cout << "Массив: \n\n";
    for (int i = 0; i < n; i++)
    {
        for (int j = 0; j < m; j++)
        {
            mas[i][j] = rand() % 50;
            cout << mas[i][j] << "\t";
        }
        cout << "\n";
    }
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
        for (int i = 0; i < n; i++)
        {
            for (int j = 0; j < m; j++)
            {
                cout << mas[i][j]<<"\t";
            }
            cout << "\n";
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
        for (int i = 0; i < n; i++)
        {
            for (int j = 0; j < m; j++)
            {
                cout << mas[i][j] << "\t";
            }
            cout << "\n";
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
        for (int i = 0; i < n; i++)
        {
            for (int j = 0; j < m; j++)
            {
                cout << mas[i][j] << "\t";
            }
            cout << "\n";
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
        for (int i = 0; i < n; i++)
        {
            for (int j = 0; j < m; j++)
            {
                cout << mas[i][j] << "\t";
            }
            cout << "\n";
        }
        break;
    default:
        cout << "Error";
    }
}
} // namespace task03

// Задание 4:
// В двумерном массиве целых числе посчитать:
// * Сумму всех элементов массива
// * Среднее арифметическое всех элементов массива
// * Минимальный элемент
// * Максимальный элемент

namespace task04 {
using namespace std;

void run()
{
    setlocale(0, "");
    srand(unsigned(time(0)));
    int const n = 3;
    int const m = 5;
    int mas[n][m], sum = 0, asum;
    cout << "Массив: \n\n";
    for(int i = 0 ; i < n; i++)
    {
        for (int j = 0; j < m; j++)
        {
            mas[i][j] = rand() % 100;
            cout << mas[i][j] << "\t";
            sum += mas[i][j];
        }
        cout << "\n";
    }
    int max = mas[0][0], min = mas[0][0];
    for (int i = 0; i < n; i++)
    {
        for (int j = 0; j < m; j++) 
        {
            if (mas[i][j] > max)max = mas[i][j];
            else if (mas[i][j] < min)min = mas[i][j];

        }
    }
    asum = sum / 15;
    cout << "\nСумма всех элементов массива = " << sum;
    cout << "\nСреднее арифметическое всех элементов массива = " << asum;
    cout << "\nМинимальный элемент = " << min;
    cout << "\nМаксимальный элемент = " << max;
    cout << endl;
}
} // namespace task04

// Задание 5:
// В двумерном массиве целых чисел посчитать сумму элементов: в каждой строке; в каждом столбце; 
// одновременно по всем строкам и всем столбцам. Оформить следующим образом:
// 3 5 6 7 | 21
// 12 1 1 1 | 15
// 0 7 12 1 | 20
// ---------------------
// 15 3 19 9 | 56

namespace task05 {
using namespace std;

void run()
{
    setlocale(0, "");
    srand(unsigned(time(0)));
    int const n = 3;
    int const m = 4;
    int mas[n][m], s = 0, s1 = 0, suma = 0;
    cout << "Массив: \n";
    for (int i = 0; i < n; i++)
    {
        for (int j = 0; j < m; j++)
        {
            mas[i][j] = rand() % 50;
        }
    }
    for (int i = 0; i < n; i++)
    {
        int sum = 0;
        for (int j = 0, k = 0; j < m && k < m; j++, k++) 
        {
            sum = sum + mas[i][j];
            cout << mas[i][j] << "\t";
        }
        s += sum;
        cout << "| " << sum << endl;
    }
    cout << "--------------------------------------\n";
    for (int i = 0; i < m; i++)
    {
        int sum = 0;
        for (int j = 0, k = 0; j < n && k < n; j++, k++)
        {
            sum = sum + mas[j][i];
        }
        s1 += sum;
        cout << sum << "\t";
    }
    suma = s + s1;
    cout << "| " << suma;
}
} // namespace task05

// Задание 6:
// Напишите программу, в которой объявляется массив размером 5х10 и массив размером 5х5. 
// Первый массив заполняется случайными числами, в диапазоне от 0 до 50. 
// Второй массив заполняется по следующему принципу: первый элемент второго массива равен сумме первого 
// и второго элемента первого массива, второй элемент второго массива равен 
// сумму третьего и четвертого элемента первого массива.

namespace task06 {
using namespace std;

void run()
{
    setlocale(0, "");
    srand(unsigned(time(0)));
    int const n = 5;
    int const m = 10;
    int const k = 5;
    int const l = 5;
    int mas[n][m], mas2[k][l];
    cout << "Массив: \n";
    for (int i = 0; i < n; i++)
    {
        for (int j = 0; j < m; j++)
        {
            mas[i][j] = rand() % 50;
            cout << mas[i][j] << "\t";
        }
        cout << "\n";
    }
    cout << "Массив 2: \n";
    for (int i = 0; i < k; i++)
    {
        for (int j = 0; j < l; j++) {
            mas2[i][j] = mas[i][2 * j] + mas[i][2 * j + 1];
            cout << mas2[i][j]<<"\t";
        }
        cout << "\n";
    }
}
} // namespace task06

// Функции

void main()
{
	task01::run();
	task02::run();
	task03::run();
	task04::run();
	task05::run();
	task06::run();
}
