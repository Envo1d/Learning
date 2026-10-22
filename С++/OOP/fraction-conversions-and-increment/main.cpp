// Источник: HM OOP 4.txt
// Задание 2.
// В уже существующий класс Дробь добавьте перегрузку
// инкремента и декремента.

#include <Windows.h>
#include <conio.h>
#include "Drob.h"

int main()
{
    setlocale(0, "");
    int n, m;
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
            "5 - Увеличить на 1\n"<<
            "6 - Уменьшить на 1\n"<<
            "Esc - Выход\n";
        cout << "Дробь №1:\n"; a.print();
        cout << "Дробь №2:\n"; b.print();
        c = _getch();
        switch (c) {
        case'1':system("cls");
            r = a.operator+(b);
            r.print();
            Sleep(3000);
            break;
        case'2':system("cls");
            r = a.operator-(b);
            r.print();
            Sleep(3000);
            break;
        case'3':system("cls");
            r = a.operator*(b);
            r.print();
            Sleep(3000);
            break;
        case'4':system("cls");
            r = a.operator/(b);
            r.print();
            Sleep(3000);
            break;
        case '5':system("cls");
            a++;
            b++;
            break;
        case '6':system("cls");
            --a;
            --b;
            break;
        }
    } while (c != 27);
}