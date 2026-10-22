// Источник: HM OOP 3.txt
// Задание 4.
// Создать класс Flat (квартира).
// Реализовать перегруженные операторы:
// 1. Проверка на равенство площадей квартир (операция
// ==);
// 2. Операцию присваивания одного объекта в другой
// (операция =);
// 3. Сравнение двух квартир по цене (операция>).

#include <Windows.h>
#include <conio.h>
#include "Flat.h"

int main()
{
    SetConsoleCP(1251);
    SetConsoleOutputCP(1251);
    Flat a;
    a.ent();
    Flat b;
    b.ent();
    char c = 0, v;
    do {
        system("cls");
        cout << "1 - Проверка на равенство площадей\n" <<
            "2 - Присвоить инф. объекта в другой объект\n" <<
            "3 - Сравнение цен\n" <<
            "Esc - Выход\n";
        cout << "\n\n№1:\n"; a.show();
        cout << "\n\n№2:\n"; b.show();
        cout << "\n";
        c = _getch();
        switch (c) {
        case'1':system("cls");
            ((a == b) == true) ? cout << "Равны" : cout << "Разные";
            Sleep(3000);
            break;
        case'2':system("cls");
            cout << "Какой объект скопировать во второй?";
            cin >> v;
            if (v == '1')
                b = a;
            if (v == '2')
                a = b;
            Sleep(3000);
            break;
        case'3':system("cls");
            if ((a > b) == true)
            {
                a.show();
                cout << "\nДороже";
            }
            else
            {
                b.show();
                cout << "\nДороже";
            }
            Sleep(3000);
            break;
        }
    } while (c != 27);
}