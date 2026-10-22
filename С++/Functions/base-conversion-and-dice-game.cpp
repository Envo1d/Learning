// Источник: HM 8.txt
#include <iostream>
#include <Windows.h>
#include <ctime>

// 1. Написать функцию, которая получает в качестве ар-
// гументов целое положительное число и систему счисле-
// ния, в которую это число должно переводится (системы
// счисления от 2 до 36). Например, при переводе числа 27 в
// систему счисления 16 должно получиться 1B; 13 в 5-ю —
// 23; 35 в 18-ю — 1H.

namespace task01 {

using namespace std;

void transform(int, int);

void run()
{
	setlocale(0, "");
	int num, choice;
	cout << "Введите число\n";
	cin >> num;
	cout << "Выберите систему счисления ( от 2 до 36 ):\n";
	cin >> choice;
	transform(num, choice);
}

void transform(int number, int choice)
{
	int mas[50], col = 0;
	for (; number > 0; col++)
	{
		mas[col] = number % choice;
		number /= choice;
	}
	cout << "Ваше число = ";
	for (int i = col - 1; i >= 0; i--)
	{
		cout << mas[i];
	}
}
} // namespace task01

// 2. Игра «кубики». Условие: имеется два игральных
// кубика со значениями от 1 до 6. Игра происходит с ком-
// пьютером, кубики бросаются поочередно. Побеждает тот,
// у кого сумма выпавших очков по итогам пяти бросков
// больше. Предусмотрите возможность получения первого
// хода человеком или компьютером. Кубики отображаются
// с помощью символов. В конце игры необходимо выводить
// среднюю сумму по броскам для обоих участников.

namespace task02 {

using namespace std;

int pattern(int);
int game(int);

void run()
{
	setlocale(0, "");
	srand(unsigned(time(0)));
	int a;
	cout << "Игра 'Кубики'\n\n";
	cout << "Кто ходит первый? \n" <<
		"1. Вы\n" <<
		"2. Компьютер\n";
	cin >> a;
	game(a);
}

int pattern(int a)
{
	if (a == 5) {
		for (int i = 1; i <= 6; i++)
		{
			system("cls");
			if (i == 1)
			{
				cout << "\t-----------\n" <<
					"\t|         |\n" <<
					"\t|    *    |\n" <<
					"\t|         |\n" <<
					"\t-----------\n";
			}
			if (i == 2){
				cout << "\t-----------\n" <<
				"\t| *       |\n" <<
				"\t|         |\n" <<
				"\t|       * |\n" <<
				"\t-----------\n";
		}
			if (i == 3){
				cout << "\t-----------\n" <<
				"\t| *       |\n" <<
				"\t|    *    |\n" <<
				"\t|       * |\n" <<
				"\t-----------\n";
		}
			if (i == 4) {
				cout << "\t-----------\n" <<
					"\t| *     * |\n" <<
					"\t|         |\n" <<
					"\t| *     * |\n" <<
					"\t-----------\n";
			}
			if (i == 5) {
				cout << "\t-----------\n" <<
					"\t| *     * |\n" <<
					"\t|    *    |\n" <<
					"\t| *     * |\n" <<
					"\t-----------\n";
			}
			if (i == 6)
			{
				cout << "\t-----------\n" <<
					"\t| *     * |\n" <<
					"\t| *     * |\n" <<
					"\t| *     * |\n" <<
					"\t-----------\n";
			}
			Sleep(450);
		}
		system("cls");
	}
	return 1;
}

int game(int a)
{
	int hum = 0, comp = 0, comm = a, l = 1, r = 6, start, end = 0, tmp1 = 0, tmp2 = 0;
	float avsum1, avsum2;
	Flag:
		while (end <= 10){
		if (comm == 1)
		{
			pattern(5);
			if (start = pattern(1))
			{
				flag1:
				tmp1 += rand()% 7;
				if (tmp1 == 0)
					goto flag1;
				if (tmp1 == 1 || tmp1 == 7)
				{
					cout << "\t-----------\n" <<
						"\t|         |\n" <<
						"\t|    *    |\n" <<
						"\t|         |\n" <<
						"\t-----------\n";
					if (tmp1 == 7)
						tmp1 = 1;
				}
				if (tmp1 == 2 || tmp1 == 8)
				{
					cout << "\t-----------\n" <<
						"\t| *       |\n" <<
						"\t|         |\n" <<
						"\t|       * |\n" <<
						"\t-----------\n";
					if (tmp1 == 8)
						tmp1 = 2;
				}
				if (tmp1 == 3 || tmp1 == 9)
				{
					cout << "\t-----------\n" <<
						"\t| *       |\n" <<
						"\t|    *    |\n" <<
						"\t|       * |\n" <<
						"\t-----------\n";
					if (tmp1 == 9)
						tmp1 = 3;
				}
				if (tmp1 == 4 || tmp1 == 10)
				{
					cout << "\t-----------\n" <<
						"\t| *     * |\n" <<
						"\t|         |\n" <<
						"\t| *     * |\n" <<
						"\t-----------\n";
					if (tmp1 == 10)
						tmp1 = 4;
				}
				if (tmp1 == 5 || tmp1 == 11)
				{
					cout << "\t-----------\n" <<
						"\t| *     * |\n" <<
						"\t|    *    |\n" <<
						"\t| *     * |\n" <<
						"\t-----------\n";
					if (tmp1 == 11)
						tmp1 = 5;
				}
				if (tmp1 == 6 || tmp1 == 12)
					cout << "\t-----------\n" <<
					"\t| *     * |\n" <<
					"\t| *     * |\n" <<
					"\t| *     * |\n" <<
					"\t-----------\n";
				hum += tmp1;
				comm++;
				end++;
				cout << "\nВам выпала " << tmp1;
				Sleep(1800);
				goto Flag;
			}
		}
		if (comm == 2)
		{
			pattern(5);
			if (start = pattern(1))
			{
				flag2:
				tmp2 += rand() % 7;
				if (tmp2 == 0)
					goto flag2;
				if (tmp2 == 1 || tmp2 == 7)
				{
					cout << "\t-----------\n" <<
						"\t|         |\n" <<
						"\t|    *    |\n" <<
						"\t|         |\n" <<
						"\t-----------\n";
					if (tmp2 == 7)
						tmp2 = 1;
				}
				if (tmp2 == 2 || tmp2 == 8)
				{
					cout << "\t-----------\n" <<
						"\t| *       |\n" <<
						"\t|         |\n" <<
						"\t|       * |\n" <<
						"\t-----------\n";
					if (tmp2 == 8)
						tmp2 = 2;
				}
				if (tmp2 == 3 || tmp2 == 9)
				{
					cout << "\t-----------\n" <<
						"\t| *       |\n" <<
						"\t|    *    |\n" <<
						"\t|       * |\n" <<
						"\t-----------\n";
					if (tmp2 == 9)
						tmp2 = 3;
				}
				if (tmp2 == 4 || tmp2 == 10)
				{
					cout << "\t-----------\n" <<
						"\t| *     * |\n" <<
						"\t|         |\n" <<
						"\t| *     * |\n" <<
						"\t-----------\n";
					if (tmp2 == 10)
						tmp2 = 4;
				}
				if (tmp2 == 5 || tmp2 == 11)
				{
					cout << "\t-----------\n" <<
						"\t| *     * |\n" <<
						"\t|    *    |\n" <<
						"\t| *     * |\n" <<
						"\t-----------\n";
					if (tmp2 == 11)
						tmp2 = 5;
				}
				if (tmp2 == 6 || tmp2 == 12)
					cout << "\t-----------\n" <<
					"\t| *     * |\n" <<
					"\t| *     * |\n" <<
					"\t| *     * |\n" <<
					"\t-----------\n";
				comp += tmp2;
				comm--;
				end++;
				cout << "\nКомпьютеру выпала " << tmp2;
				Sleep(1800);
				goto Flag;
			}
		}
	}
	system("cls");
	avsum1 = float(hum / 5);
	avsum2 = float(comp / 5);
	cout << "Средняя сумма по броскам у вас = " << avsum1<<endl;
	cout << "Средняя сумма по броскам у компьютера = " << avsum2 << endl;
	cout << "Ваши очки - " << hum << endl <<
		"Очки компьютера - " << comp << endl;
	if (hum > comp)
		cout << "Вы победили!";
	else if (hum == comp)
		cout << "Ничья";
	else 
		cout << "Скайнет победил!";
	system("pause >> 0");
	return 0;
}
} // namespace task02

void main()
{
	task01::run();
	task02::run();
}
