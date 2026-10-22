// Источник: HM OOP 3.txt
// Задание 1.
// Создайте класс Дробь (или используйте уже ранее создан-
// ный вами). Используя перегрузку операторов реализуйте
// для него арифметические операции для работы с дробями
// (операции +, -, *, /).

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
        }
    } while (c != 27);
}

