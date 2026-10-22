// Источник: HM OOP 3.txt
// Задание 2.
// Создайте класс Complex (комплексное число) или исполь-
// зуйте уже созданный вами класс. Создайте перегруженные
// операторы для реализации арифметических операций для
// по работе с комплексными числами (операции +, -, *, /).

#include <Windows.h>
#include <conio.h>
#include "Complex.h"

int main()
{
    setlocale(0, "");
    cout << "Ввод первого числа\n";
    Complex a;
    a.ent();
    cout << "Ввод второго числа\n";
    Complex b;
    b.ent();
    Complex r;
    char c = 0;
    do {
        system("cls");
        cout << "1 - Сложение\n" <<
            "2 - Вычитание\n" <<
            "3 - Умножение\n" <<
            "4 - Деление\n" <<
            "Esc - Выход\n";
        cout << "\n\n№1:\n"; a.show();
        cout << "\n№2:\n"; b.show();
        cout << endl;
        c = _getch();
        switch (c) {
        case'1':system("cls");
            r = a.operator+(b);
            r.show();
            Sleep(3000);
            break;
        case'2':system("cls");
            r = a.operator-(b);
            r.show();
            Sleep(3000);
            break;
        case'3':system("cls");
            r = a.operator*(b);
            r.show();
            Sleep(3000);
            break;
        case'4':system("cls");
            r = a.operator/(b);
            r.show();
            Sleep(3000);
            break;
        }
    } while (c != 27);
}

