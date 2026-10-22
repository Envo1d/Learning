// Источник: HW OOP 9.txt
/*
Создайте приложение для работы автосалона. Необходимо хранить информацию о продаваемых автомобилях 
(название, год выпуска, объем двигателя, цену, др.).
Реализуйте интерфейс для добавления данных, удаления данных, отображения данных.
Автомобиль представляет собой класс с соответствующими полями, автосалон – класс в котором 
автомобили хранятся в векторе с соответствующими методами.
Данные должны сохраняться при закрытии программы и считываться при запуске
*/

#include <iostream>
#include <fstream>
#include <string>
#include <vector>
#include <conio.h>
#define clr system("cls")

using namespace std;

class car
{
	string model;
	string brand;
	string color;
	int year;
	float volume;
	int cost;
public:
	car() : year(0), volume(0), cost(0)  {}
	friend istream& operator>>(istream& in, car& c)
	{
		string line;
		getline(in, line);
		int start = line.find(":");
		start += 2;
		int end = line.find(';');
		c.brand = line.substr(start, end - start);
		start = line.find(':', start);
		start += 2;
		end = line.find(';', ++end);
		c.model = line.substr(start, end - start);
		start = line.find(':', start);
		start += 2;
		end = line.find(';', ++end);
		c.color = line.substr(start, end - start);
		start = line.find(':', start);
		start += 2;
		end = line.find(';', ++end);
		c.year = stoi(line.substr(start, end - start));
		start = line.find(':', start);
		start += 2;
		end = line.find(';', ++end);
		c.volume = stof(line.substr(start, end - start));
		start = line.rfind(':');
		start++;
		c.cost = stoi(line.substr(start, end - line.length()));
		return in;
	}
	void add_info()
	{
		cout << "Enter car brand\n";
		getline(cin, brand);
		cout << "Enter car model\n";
		getline(cin, model);
		cout << "Enter car color\n";
		getline(cin, color);
		cout << "Enter year of manufacture\n";
		cin >> year;
		cout << "Enter engine volume\n";
		cin >> volume;
		cout << "Enter cost\n";
		cin >> cost;
		cin.ignore();
	}
	string get_brand() { return brand; }
	string get_model() { return model; }
	string get_color() { return color; }
	int get_year() { return year; }
	float get_volume() { return volume; }
	int get_cost() { return cost; }
	friend ostream& operator<<(ostream& out, car& c)
	{
		out << "Brand: " << c.brand << "\nModel: " << c.model << "\nColor: " << c.color << "\nYear: " << c.year << "\nEngine volume: " << c.volume << "\nCost: " << c.cost << endl << endl;
		return out;
	}
	~car() {}
};

class car_showroom
{
	vector <car> cars;
	size_t size;
public:
	car_showroom() {
		ifstream fin("data.txt");
		if (fin.is_open()) {
			if (fin.peek() == EOF) size = 0;
			else {
				fin >> size;
				fin.seekg(5);
				cars.resize(size);
				size_t sz_tmp = 0;
				while (!fin.eof())
				{
					fin >> cars[sz_tmp++];
				}
			}
		}
		else cout << "Error";
		fin.close();
	}
	void show()
	{
		if (size == 0)
			cout << "List empty\n";
		else
			for (size_t i = 0; i < size; i++)
				cout << cars[i];
	}
	void add()
	{
		car tmp;
		tmp.add_info();
		cars.push_back(tmp);
		size++;
	}
	void remove()
	{
		cout << "Enter the car number from the list\n";
		int tmp;
		cin >> tmp;
		cars.erase(cars.begin() + (--tmp));
		size--;
	}
	~car_showroom() 
	{
		ofstream fout("data.txt");
		if (fout.is_open())
		{
			fout << size << endl << endl;
			for (size_t i = 0; i < size - 1; i++)
			{
				fout << "Brand: " << cars[i].get_brand() << "; Model: " << cars[i].get_model() << "; Color: " << cars[i].get_color() << "; Year: " << cars[i].get_year() << "; Engine volume: " << cars[i].get_volume() << "; Cost: " << cars[i].get_cost() << endl;
			}
			fout << "Brand: " << cars[size - 1].get_brand() << "; Model: " << cars[size - 1].get_model() << "; Color: " << cars[size - 1].get_color() << "; Year: " << cars[size - 1].get_year() << "; Engine volume: " << cars[size - 1].get_volume() << "; Cost: " << cars[size - 1].get_cost();
		}
		else cout << "Error\n";
		fout.close();
	}
};

void main()
{
	car_showroom a;
	char c = 0;
	do
	{
		clr;
		cout << "1 - Show list\n" <<
			"2 - Add new car to list\n" <<
			"3 - Delete car from list\n" <<
			"Esc - exit\n";
		c = _getch();
		switch (c)
		{
		case '1':clr;
			a.show();
			system("pause");
			break;
		case '2':clr;
			a.add();
			system("pause");
			break;
		case '3':clr;
			a.remove();
			system("pause");
			break;
		}
	} while (c != 27);
}