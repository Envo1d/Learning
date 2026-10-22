// Источник: HW OOP 6.txt
/*Задание №3.Создать базовый класс «Транспортное средство» и производные классы «Автомобиль», «Велосипед», «Повозка».
Подсчитать время и стоимость перевозки пассажиров и грузов каждым транспортным средством.*/

#include <iostream>
#include <string>
#include <Windows.h>
#include <ctime>
#include <conio.h>
#pragma warning(disable:4996)

using namespace std;

class vehicle
{
	double weight;
	short year;
	char* color;
	string model;

	void add()
	{
		cout << "Введите модель транспортного средства: \n";
		getline(cin, model);
		cout << "Введите вес траспортного средства (кг): ";
		cin >> weight;
		cout << "Введите год выпуска транспортного средства: ";
		cin >> year;
		cout << "Введите цвет: ";
		char* tmp = new char[64];
		cin >> tmp;
		color = new char[strlen(tmp) + 1];
		strcpy(color, tmp);
		delete[] tmp;
		cin.ignore();
	}

public:
	vehicle()
	{
		add();
	}
	double cal_time(double distance, double speed)
	{
		double res_speed;
		res_speed = (double)speed * 1000 / 3600;
		double res_time = (double)distance / res_speed;
		res_time /= 3600;
		return res_time;
	}

	double cal_cost(double need_time, int service_cost) 
	{
		time_t now = time(0);
		tm* localtm = localtime(&now);
		short year = localtm->tm_year + 1900;
		short days;
		service_cost *= 12;
		if ((year % 4 == 0 && year % 100 != 0) || year % 400 == 0) days = 366;
		else days = 365;
		double tmp = ((double)service_cost / days) / 24;
		double res = (tmp * need_time) * 10;
		return res;
	}
	void show()
	{
		cout << "Модель: " << model << endl
			<< "Вес: " << weight << " кг\n"
			<< "Год выпуска: " << year << " г\n"
			<< "Цвет: " << color << endl;
	}
	~vehicle() { delete[] color; }
};

class car : public vehicle
{
	double fuel_consumption;
	short seats;
public:
	car() : vehicle()
	{
		cout << "Введите количество мест: ";
		cin >> seats;
		cout << "Введите расход топлива на 100 км: ";
		cin >> fuel_consumption;
		cin.ignore();
	}
	void cal_time()
	{
		cout << "Введите дистанцию (в км) и скорость: ";
		double dist, v, res;
		cin >> dist;
		cin >> v;
		dist *= 1000;
		res = vehicle::cal_time(dist, v);
		cout << "Нужно " << res << " ч";
	}
	void cal_cost()
	{
		cout << "Введите дистанцию (в км) и скорость: \n";
		double dist, v;
		cin >> dist >> v;
		double fuel_cost = (fuel_consumption / dist) * 22.57;
		cout << "Введите цену обслуживания машины и зарплату водителя за месяц: \n";
		int sum, service, salary;
		cin >> service >> salary;
		sum = service + salary;
		double res;
		dist *= 1000;
		res = (vehicle::cal_cost(vehicle::cal_time(dist, v), sum)) + fuel_cost;
		cout << "Один человек заплатит - " << res << " грн" << endl
			<< "Вместе все пасажиры заплатят - " << res * seats << " грн" << endl
			<< "За доставку груза - " << res * 2 << " грн" << endl;
	}
	void show()
	{
		vehicle::show();
		cout << "Расход топлива: " << fuel_consumption << " л" << endl
			<< "Количесвто мест: " << seats << endl;
	}
	~car() {}
};
class bicycle : public vehicle
{
public:
	bicycle() : vehicle()
	{}
	void cal_time()
	{
		cout << "Введите дистанцию (в км) и скорость: ";
		double dist, v, res;
		cin >> dist;
		cin >> v;
		dist *= 1000;
		res = vehicle::cal_time(dist, v);
		cout << "Нужно " << res << " ч";
	}
	void cal_cost()
	{
		cout << "Введите дистанцию (в км) и скорость: \n";
		double dist, v;
		cin >> dist >> v;
		cout << "Введите цену обслуживания велосипеда и зарплату водителя за месяц: \n";
		int sum, service, salary;
		cin >> service >> salary;
		sum = service + salary;
		double res;
		dist *= 1000;
		res = (vehicle::cal_cost(vehicle::cal_time(dist, v), sum));
		cout << "Пасажир заплатит - " << res << " грн" << endl
			<< "За доставку груза - " << res * 2 << " грн" << endl;
	}
	void show()
	{
		vehicle::show();
	}
	~bicycle() {}
};
class carriage : public vehicle
{
	string name;
	short age;
	short seats;
public:
	carriage() : vehicle()
	{
		cout << "Введите кличку лошади: \n";
		cin >> name;
		cout << "Сколько лет лошади: ";
		cin >> age;
		cout << "Сколько мест в повозке: ";
		cin >> seats;
		cin.ignore();
	}
	void cal_time()
	{
		cout << "Введите дистанцию (в км) и скорость: ";
		double dist, v, res;
		cin >> dist;
		cin >> v;
		dist *= 1000;
		res = vehicle::cal_time(dist, v);
		cout << "Нужно " << res << " ч";
	}
	void cal_cost()
	{
		cout << "Введите дистанцию (в км) и скорость: \n";
		double dist, v;
		cin >> dist >> v;
		cout << "Введите цену содержания лошади вместе с обслуживанием повозки и зарплату возчика за месяц: \n";
		int sum, service, salary;
		cin >> service >> salary;
		sum = service + salary;
		double res;
		dist *= 1000;
		res = (vehicle::cal_cost(vehicle::cal_time(dist, v), sum));
		cout << "Один человек заплатит - " << res << " грн" << endl
			<< "Вместе все пасажиры заплатят - " << res * seats << " грн" << endl
			<< "За доставку груза - " << res * 2 << " грн" << endl;
	}
	void show()
	{
		cout << "Кличка лошади: " << name << endl
			<< "Возраст лошади: " << age << endl
			<< "Количество мест в повозке: " << seats << endl;
		vehicle::show();
	}
	~carriage() {}
};

void main()
{
	SetConsoleCP(1251);
	SetConsoleOutputCP(1251);
	cout << "Ввод инфоррмации о машине\n";
	car a;
	system("cls");
	cout << "Ввод инфоррмации о велосипеде\n";
	bicycle b;
	system("cls");
	cout << "Ввод инфоррмации о повозке\n";
	carriage c;
	char ch = 0;
	cin.ignore();
	do
	{
		system("cls");
		cout << "1 - Вывод информации о машине\n2 - Вывод информации о велосипеде\n3 - Вывод информации о повозке\nEsc - выход\n";
		ch = _getch();
		switch (ch)
		{
		case '1':system("cls");
			a.show();
			cout << endl <<"Время на доставку\n";
			a.cal_time();
			cout << endl <<"Цена за доставку\n";
			a.cal_cost();
			system("pause");
			break;
		case '2':system("cls");
			b.show();
			cout << endl << "Время на доставку\n";
			b.cal_time();
			cout << endl << "Цена за доставку\n";
			b.cal_cost();
			system("pause");
			break;
		case '3':system("cls");
			c.show();
			cout << endl << "Время на доставку\n";
			c.cal_time();
			cout << endl << "Цена за доставку\n";
			c.cal_cost();
			system("pause");
			break;
		}
	} while (ch != 27);
}