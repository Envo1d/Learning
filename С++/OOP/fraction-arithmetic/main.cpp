// Источник: HM OOP 1.txt
// Задание 1.
// Реализуйте класс Дробь. Необходимо хранить числитель
// и знаменатель в качестве переменных-членов. Реализуйте
// функции-члены для ввода данных в переменные-члены,
// для выполнения арифметических операций (сложение,
// вычитание, умножение, деление, и т.д.).

#include <Windows.h>
#include <conio.h>
#include "Drob.h"

int main()
{
    setlocale(0, "");
    int n,m;
    cout << "Ввод первой дроби\n";
    cout << "Числитель - "; cin >> n;
    cout << "Знаменатель - "; cin >> m;
    Drob a(n, m);
    cout << "Ввод второй дроби\n";
    cout << "Числитель - "; cin >> n; 
    cout << "Знаменатель - "; cin >> m;
    Drob b(n, m);
    Drob r;
    char c = 0;
    do {
        system("cls");
        cout << "1 - Сложение\n" <<
            "2 - Вычитание\n" <<
            "3 - Умножение\n" <<
            "4 - Деление\n" <<
            "5 - Перевод в десятичный\n" <<
            "Esc - Выход\n";
        cout << "Дробь №1:\n"; a.print();
        cout << "Дробь №2:\n"; b.print();
        c = _getch();
        switch (c) {
        case'1':system("cls");
            r = a.Add(b);
            r.print();
            Sleep(3000);
            break;
        case'2':system("cls");
            r = a.Min(b);
            r.print();
            Sleep(3000);
            break;
        case'3':system("cls");
            r = a.Mul(b);
            r.print();
            Sleep(3000);
            break;
        case'4':system("cls");
            r = a.Div(b);
            r.print();
            Sleep(3000);
            break;
        case '5':system("cls");
            char k;
            cout << "Перевести первую дробь - 1\n" <<
                "Перевести вторую дробь - 2\n" <<
                "Перевести в дробь результат ариф. операции - 3\n";
            double p;
            k = _getch();
            if (k == '1') { p = (double)a.GetCh() / a.GetZ(); cout << p; }
            else if (k == '2') { p = (double)b.GetCh() / b.GetZ(); cout << p; }
            else if (k == '3') { p = (double)r.GetCh() / r.GetZ(); cout << p; }
            Sleep(3000);
            break;
        }
    } while (c != 27);
}

