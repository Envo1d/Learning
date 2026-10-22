// Источник: HW OOP 7.txt
/*Создать приложение для автоматизации учета животных в зоопарке.
В зоопарке живут : питоны, удавы, гадюки, львы, пантеры, волки, собаки динго.
По каждому животному необходимо вести статистику расходов на еду в день
(в гривневом эквиваленте).
У животного есть кличка, возраст, вес, номер вольера, время пребывания в зоопарке.

Задача системы учета животных :
1. Добавление нового животного в зоопарк
2. Отображение всех животных
3. Удаление животного по кличке
4. Добавление расходов на еду за текущий день для отдельного животного
5. Подсчет расходов на питание для всех животных за текущий день...
6. ... и за весь период учета

При выполнении этого домашнего задания внимательно продумайте иерархию классов животных.*/
#include <iostream>
#include <string>
#include <Windows.h>
#include <conio.h>
#define clr system("cls")

using namespace std;

//main class
class animal
{
	string sp;
	string name;
	double age;
	short weight;
	short aviary_number;
	short days_in_zoo;
public:
	animal()
	{
		sp = "0";
		name = "0";
		age = 0;
		weight = 0;
		aviary_number = 0;
		days_in_zoo = 0;
	}
	animal(const animal& s)
	{
		name = s.name;
		age = s.age;
		weight = s.weight;
		aviary_number = s.aviary_number;
		days_in_zoo = s.days_in_zoo;
	}
	animal& operator=(const animal& s)
	{
		if (this != &s)
		{
			name = s.name;
			age = s.age;
			weight = s.weight;
			aviary_number = s.aviary_number;
			days_in_zoo = s.days_in_zoo;
		}return *this;
	}
	animal(string targ)
	{
		sp = targ;
		cout << "Введите кличку животного\n";
		cin >> name;
		cout << "Введите возраст\n";
		cin >> age;
		cout << "Введите вес\n";
		cin >> weight;
		cout << "Номер клетки: ";
		cin >> aviary_number;
		cout << "Количество дней пребывания в зоопарке: ";
		cin >> days_in_zoo;
	}
	virtual short get_period() { return days_in_zoo; }
	virtual string get_name() { return name; }
	virtual int cal_expenses_per_allday() = 0;
	void show()
	{
		cout << "Вид: " << sp << endl
			<< "Кличка: " << name << endl
			<< "Возраст: " << age << endl
			<< "Вес: " << weight << endl
			<< "Номер клетки: " << aviary_number << endl
			<< "Дней в зоопарке: " << days_in_zoo << endl << endl;
	}
	virtual ~animal() {}
};
//partial classes
class cats : public animal
{
	short cost_day;
	int cost_period;
public:
	cats(const cats& s)
	{
		cost_day = s.cost_day;
		cost_period = s.cost_period;
	}
	cats& operator=(const cats& s)
	{
		if (this != &s)
		{
			cost_day = s.cost_day;
			cost_period = s.cost_period;
		}return *this;
	}
	cats(string sp) : animal(sp) 
	{
		cost_day = 0;
		cost_period = 0;
	}
	virtual int cal_expenses_per_allday()
	{
		short days = animal::get_period();
		int res = days * cost_day;
		return res;
	}
	void set_costday()
	{
		cout << "Введите расходы за день:\n";
		cin >> cost_day;
	}
	short get_daycost() { return cost_day; }
	virtual void show() = 0;
	virtual ~cats() {}
};
class dogs : public animal
{
	short cost_day;
	int cost_period;
public:
	dogs(const dogs& s)
	{
		cost_day = s.cost_day;
		cost_period = s.cost_period;
	}
	dogs& operator=(const dogs& s)
	{
		if (this != &s)
		{
			cost_day = s.cost_day;
			cost_period = s.cost_period;
		}return *this;
	}
	dogs(string sp) : animal(sp)
	{
		cost_day = 0;
		cost_period = 0;
	}
	virtual int cal_expenses_per_allday()
	{
		short days = animal::get_period();
		int res = days * cost_day;
		return res;
	}
	void set_costday()
	{
		cout << "Введите расходы за день:\n";
		cin >> cost_day;
	}
	short get_daycost() { return cost_day; }
	virtual void show() = 0;
	virtual ~dogs() {}
};
class reptiles : public animal
{
	short cost_day;
	int cost_period;
public:
	reptiles(const reptiles& s)
	{
		cost_day = s.cost_day;
		cost_period = s.cost_period;
	}
	reptiles& operator=(const reptiles& s)
	{
		if (this != &s)
		{
			cost_day = s.cost_day;
			cost_period = s.cost_period;
		}return *this;
	}
	reptiles(string sp) : animal(sp)
	{
		cost_day = 0;
		cost_period = 0;
	}
	virtual int cal_expenses_per_allday()
	{
		short days = animal::get_period();
		int res = days * cost_day;
		return res;
	}
	void set_costday()
	{
		cout << "Введите расходы за день:\n";
		cin >> cost_day;
	}
	short get_daycost() { return cost_day; }
	virtual void show() = 0;
	virtual ~reptiles() {}
};
//
class lions : public cats
{
public:
	lions(string n = "Лев") : cats(n) {}
    void cal_cost_period()
	{
		cats::cal_expenses_per_allday();
	}
	virtual void show() { animal::show(); }
	void show_costday() { cout << "Расходы за день: " << cats::get_daycost() << endl; }
	~lions() {}
};
class panthers : public cats
{
public:
	panthers(string n = "Пантера") : cats(n) {}
	void cal_cost_period()
	{
		cats::cal_expenses_per_allday();
	}
	virtual void show() { animal::show(); }
	void show_costday() { cout << "Расходы за день: " << cats::get_daycost() << endl; }
	~panthers() {}
};
class wolves : public dogs
{
public:
	wolves(string n = "Волк") : dogs(n) {}
	void cal_cost_period()
	{
		dogs::cal_expenses_per_allday();
	}
	virtual void show() { animal::show(); }
	void show_costday() { cout << "Расходы за день: " << dogs::get_daycost() << endl; }
	~wolves() {}
};
class dingo : public dogs
{
public:
	dingo(string n = "Собака Динго") : dogs(n) {}
	void cal_cost_period()
	{
		dogs::cal_expenses_per_allday();
	}
	virtual void show() { animal::show(); }
	void show_costday() { cout << "Расходы за день: " << dogs::get_daycost() <<endl; }
	~dingo() {}
};
class pythons : public reptiles
{
public:
	pythons(string n = "Питон") : reptiles(n) {}
	void cal_cost_period()
	{
		reptiles::cal_expenses_per_allday();
	}
	virtual void show() { animal::show(); }
	void show_costday() { cout << "Расходы за день: " << reptiles::get_daycost() << endl; }
	~pythons() {}
};
class boa : public reptiles
{
public:
	boa(string n = "Удав") : reptiles(n) {}
	void cal_cost_period()
	{
		reptiles::cal_expenses_per_allday();
	}
	virtual void show() { animal::show(); }
	void show_costday() { cout << "Расходы за день: " << reptiles::get_daycost() << endl; }
	~boa() {}
};
class vipers : public reptiles
{
public:
	vipers(string n = "Гадюка") : reptiles(n) {}
	void cal_cost_period()
	{
		reptiles::cal_expenses_per_allday();
	}
	virtual void show() { animal::show(); }
	void show_costday() { cout << "Расходы за день: " << reptiles::get_daycost() <<endl; }
	~vipers() {}
};
//
class zoo
{
	friend class cats;
	friend class dogs;
	friend class reptiles;
	static const short c = 8;
	static const short d = 6;
	static const short r = 10;
	cats** cat;
	dogs** dog;
	reptiles** reptile;
	int numc, numd, numr;
public:
	zoo()
	{
		numc = numd = numr = 0;
		cat = new cats * [c];
		dog = new dogs * [d];
		reptile = new reptiles * [r];
	}
	zoo(const zoo& s)
	{
		cat = s.cat;
		dog = s.dog;
		reptile = s.reptile;
		numc = s.numc;
		numd = s.numd;
		numr = s.numr;
	}
	zoo& operator=(const zoo& s)
	{
		if (this != &s)
		{
			cat = s.cat;
			dog = s.dog;
			reptile = s.reptile;
			numc = s.numc;
			numd = s.numd;
			numr = s.numr;
		}return *this;
	}
	void add()
	{
		char k;
		clr;
		cout << "Кого довабить: \n"
			<< "1 - Льва\n"
			<< "2 - Пантеру\n"
			<< "3 - Динго\n"
			<< "4 - Волка\n"
			<< "5 - Питона\n"
			<< "6 - Удава\n"
			<< "7 - Гадюку\n";
		k = getchar();
		switch (k)
		{
		case '1':clr;
			if (numc <= c)
			{
				cat[numc] = new lions();
				numc++;
			}
			else cout << "Нет свободных клеток";
			break;
		case '2':clr;
			if (numc <= c)
			{
				cat[numc] = new panthers();
				numc++;
			}
			else cout << "Нет свободных клеток";
			break;
		case'3':clr;
			if (numd <= d)
			{
				dog[numd] = new dingo();
				numd++;
			}
			else cout << "Нет свободных клеток";
			break;
		case'4':clr;
			if (numd <= d)
			{
				dog[numd] = new wolves();
				numd++;
			}
			else cout << "Нет свободных клеток";
			break;
		case'5':clr;
			if (numr <= r)
			{
				reptile[numr] = new pythons();
				numr++;
			}
			else cout << "Нет свободных клеток";
			break;
		case'6':clr;
			if (numr <= r)
			{
				reptile[numr] = new boa();
				numr++;
			}
			else cout << "Нет свободных клеток";
			break;
		case'7':clr;
			if (numr <= r)
			{
				reptile[numr] = new vipers();
				numr++;
			}
			else cout << "Нет свободных клеток";
			break;
		}
	}
	void show_all()
	{
		clr;
		for (short i = 0; i < numc; i++)
		{
			cat[i]->show();
		}
		for (short i = 0; i < numd; i++)
		{
			dog[i]->show();
		}
		for (short i = 0; i < numr; i++)
		{
			reptile[i]->show();
		}
	}
	void del_name()
	{
		clr;
		cout << "Введите кличку животного\n";
		string tmp;
		cin >> tmp;
		for (short i = 0; i < numc; i++)
		{
			if (cat[i]->get_name() == tmp)
			{
				delete[] cat[i];
				numc--;
				goto end;
			}
		}
		for (short i = 0; i < numd; i++)
		{
			if (dog[i]->get_name() == tmp)
			{
				delete[] dog[i];
				numd--;
				goto end;
			}
		}
		for (short i = 0; i < numr; i++)
		{
			if (reptile[i]->get_name() == tmp)
			{
				delete[] reptile[i];
				numr--;
				goto end;
			}
		}
	end:
		cout << "Удалено\n";
	}
	void add_cost()
	{
		clr;
		cout << "Введите кличку животного для назначения расходов\n";
		string name;
		cin >> name;
		for (short i = 0; i < numc; i++)
		{
			if (cat[i]->get_name() == name)
			{
				cat[i]->set_costday();
				goto end;
			}
		}
		for (short i = 0; i < numd; i++)
		{
			if (dog[i]->get_name() == name)
			{
				dog[i]->set_costday();
				goto end;
			}
		}
		for (short i = 0; i < numr; i++)
		{
			if (reptile[i]->get_name() == name)
			{
				reptile[i]->set_costday();
				goto end;
			}
		}
	end:;
	}
	void show_all_daycost()
	{
		clr;
		int res = 0;
		for (short i = 0; i < numc; i++)
		{
			res += cat[i]->get_daycost();
		}
		for (short i = 0; i < numd; i++)
		{
			res += dog[i]->get_daycost();
		}
		for (short i = 0; i < numr; i++)
		{
			res += reptile[i]->get_daycost();
		}
		cout << "Расходы на всех животных за день: " << res << endl;
	}
	void show_all_cost()
	{
		clr;
		int res = 0;
		for (short i = 0; i < numc; i++)
		{
			res += cat[i]->cal_expenses_per_allday();
		}
		for (short i = 0; i < numd; i++)
		{
			res += dog[i]->cal_expenses_per_allday();
		}
		for (short i = 0; i < numr; i++)
		{
			res += reptile[i]->cal_expenses_per_allday();
		}
		cout << "Расходы на всех животных за весь период: " << res << endl;
	}
	~zoo()
	{
		for (int i = 0; i < numc; i++)
		{
			delete cat[i];
		}
		delete[] cat;
		for (int i = 0; i < numd; i++)
		{
			delete dog[i];
		}
		delete[] dog;
		for (int i = 0; i < numr; i++)
		{
			delete[] reptile;
		}
		delete[] reptile;
	}
};
void main()
{
	SetConsoleCP(1251);
	SetConsoleOutputCP(1251);
	zoo n1;
	char c = 0;
	do
	{
		clr;
		cout << "1. Добавление нового животного в зоопарк\n"
			<< "2. Отображение всех животных\n"
			<< "3. Удаление животного по кличке\n"
			<< "4. Добавление расходов на еду за текущий день для отдельного животного\n"
			<< "5. Подсчет расходов на питание для всех животных за текущий день\n"
			<< "6. Подсчет расходов на питание для всех животных за весь период учета\n"
			<< "Esc - Выход\n\n";
		c = _getch();
		switch (c)
		{
		case '1':clr;
			n1.add();
			Sleep(1000);
			break;
		case '2':clr;
			n1.show_all();
			system("pause");
			cin.ignore();
			break;
		case'3':clr;
			n1.del_name();
			Sleep(1000);
			break;
		case'4':clr;
			n1.add_cost();
			system("pause");
			cin.ignore();
			break;
		case'5':clr;
			n1.show_all_daycost();
			system("pause");
			cin.ignore();
			break;
		case'6':clr;
			n1.show_all_cost();
			system("pause");
			cin.ignore();
			break;
		}
	} while (c != 27);
}