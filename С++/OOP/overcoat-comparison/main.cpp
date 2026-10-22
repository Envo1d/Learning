// Источник: HM OOP 3.txt
// Задание 3.
// Создать класс Overcoat (верхняя одежда)
// Реализовать перегруженные операторы:
// 1. Проверка на равенство типов одежды (операция = =);
// 2. Операцию присваивания одного объекта в другой
// (операция =);
// 3. Сравнение по цене двух пальто одного типа (опера-
// ция>).

#include <Windows.h>
#include <conio.h>
#include "Overcoat.h"

int main()
{
    SetConsoleCP(1251);
    SetConsoleOutputCP(1251);
    cout << "N-1:\n";
    Overcoat a;
    a.ent();
    cout << "N-2:\n";
    Overcoat b;
    b.ent();
    char c = 0, v;
    do {
        system("cls");
        cout << "1 - Проверка на равенство типов\n" <<
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

