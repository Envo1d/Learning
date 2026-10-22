// Источник: HW OOP 2.txt
// 2.	Создать имитационную модель "остановка маршрутных
// такси". Необходимо вводить следующую информацию:
// среднее время между появлениями пассажиров на
// остановке в разное время суток, среднее время между
// появлениями маршруток на остановке в разное время
// суток, тип остановки (конечная или нет). Необходимо
// определить: среднее время пребывание человека на
// остановке, достаточный интервал времени между при-
// ходами маршруток, чтобы на остановке находилось не
// более N людей одновременно. Количество свободных
// мест в маршрутке является случайной величиной.


#include <iostream>
#include <ctime>
#include <conio.h>
#include <Windows.h>

using namespace std;

class busstop
{
	short stop[25];
	short size = -1;
public:
	friend class bus;
	bool empty()
	{
		return size == -1;
	}
	bool full()
	{
		return size >= 24;
	}
	void push(short c) {
		if (!full()) {
			stop[++size] = c;
		}
		else {
			cout << "Error";
		}
	}
	int pop() {
		if (!empty()) {
			for (int i = 0; i < size; i++)
			{
				stop[i] = stop[i + 1];
			}
			size--;
			return 1;
		}
		else {
			cout << "Error" << endl;
			return 0;
		}
	}
	
	void clear() {
		size = -1;
	}
	~busstop()
	{
		clear();
	}
};
class simulation
{
public:
	friend class busstop;
	void sim(busstop& s)
	{
		cout << "Ведите время (у - утро, о - обед, в - вечер, н - ночь): ";
		char time_of_day = _getch();
		cout << "Тип остановки конечная или нет (к/н)\n";
		char type = _getch();
		cout << "Введите среднее время между появлениями пассажиров на остановке (мин)\n";
		short time_p;
		cin >> time_p;
		cout << "Введите среднее время между появлениями маршруток (мин)\n";
		short time_c;
		cin >> time_c;
		cout << "Запустить симуляцию - Enter\n";
		char f;
		flag:
		f = _getch();
		short p = 0, c = 0, count = 0;
		double j = (double)time_c / time_p;
		cout << "Примерное время ожидания - " << j << " м\n";
		Sleep(1500);

		if (f == 13) {
			while (true)
			{
				Sleep(1000);
				p++;
				if (p == time_p)
				{
					short x = 0;
					rand1(x, type, time_of_day);
					for (short i = 0; i < x; i++)
					{
						s.push(1);
						count++;
					}
					system("cls");
					cout << "На остановке " << count << " ч\n";
					if (s.full() == true)
					{
						cout << "Остановка переполнена\nНужно чаще пустить маршрутки\n";
						break;
					}
					p = 0;
				}
				c++;
				if (c == time_c)
				{
					short k = 1 + rand() % (18 - 1);
					cout << "\nПрибыла маршрутка\nСвободных мест - " << k << endl;
					Sleep(2000);
					if (count > k)
					{
						for (short i = 0; i < k; i++)
						{
							s.pop();
							if (s.empty())
								break;
						}
						count -= k;
					}
					if (count < k || count == k)
					{
						for (short i = 0; i < k; i++)
						{
							s.pop();
							if (s.empty())
								break;
						}
						count -= count;
						cout << "На остановке " << count << " ч\n";
					}
					c = 0;
				}
			}
		}
	}
	void rand1(short& t,char type,char time)
	{
		if (type == 'к')
		{
			if (time == 'у')
			{
				t = 3 + rand() % (7 - 3);
			}
			else if (time == 'о')
			{
				t = 2 + rand() % (5 - 2);
			}
			else if (time == 'в')
			{
				t = 3 + rand() % (7 - 3);
			}
			else
			{
				t = 1 + rand() % (3 - 1);
			}
		}
		else
		{
			if (time == 'у')
			{
				t = 2 + rand() % (5 - 2);
			}
			else if (time == 'о')
			{
				t = 1 + rand() % (4 - 1);
			}
			else if (time == 'в')
			{
				t = 2 + rand() % (5 - 2);
			}
			else
			{
				t = 1 + rand() % (3 - 1);
			}
		}
	}
};


void main()
{
	SetConsoleCP(1251);
	SetConsoleOutputCP(1251);
	srand(unsigned(time(NULL)));
	busstop n1;
	simulation f;
	f.sim(n1);
}

