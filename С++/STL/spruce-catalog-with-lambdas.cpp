#include <iostream>
#include <vector>
#include <algorithm>
#include <random>
#include <ctime>
#include <conio.h>

using namespace std;

class spruce
{
	short price;
	double height;
public:
	/*class cmpprice
	{
	public:
		bool operator()(spruce& first, spruce& second)
		{
			return first.price < second.price;
		}
	};*/

	spruce(short p, double h) : price(p), height(h) {}

	/*bool operator<(spruce& second)
	{
		return height < second.height;
	}*/

	void de_increase_price(short p, bool c)
	{
		if (c == true)
			price += p;
		else
			price -= p;
	}

	void div_mult_price(short p, bool c)
	{
		if (c == true)
			price *= p;
		else
			price /= p;
	}

	short get_price()
	{
		return price;
	}

	double get_height()
	{
		return height;
	}

	friend ostream& operator<<(ostream& out, spruce& s)
	{
		out << "Height: " << s.height << "  Price: " << s.price << endl;
		return out;
	}
};

class prog
{
	vector<spruce> container;
public:
	prog()
	{
		default_random_engine eng(time(NULL));
		double beg1 = 1; double end1 = 3;
		uniform_real_distribution<> rand_double(beg1, end1);
		short beg2 = 50; short end2 = 500;
		uniform_real_distribution<> rand_short(beg2, end2);
		while (container.size() < 20)
		{
			short price = rand_short(eng);
			double height = rand_double(eng);
			spruce tmp(price, height);
			container.push_back(tmp);
		}
	}

	void find_min()
	{
	ent:
		cout << "1 - Search by price\n2 - Search by height\n";
		char c;
		c = getchar();
		if (c == '1')
		{
			auto res = min_element(container.begin(), container.end(), [](spruce& first, spruce& second) {return first.get_price() < second.get_price(); });
			cout << "\tMIN\n" << "Height: " << res->get_height() << "  Price: " << res->get_price() << endl;
		}
		else if (c == '2')
		{
			auto res = min_element(container.begin(), container.end(), [](spruce& first, spruce& second) {return first.get_height() < second.get_height(); });
			cout << "\tMIN\n" << "Height: " << res->get_height() << "  Price: " << res->get_price() << endl;
		}
		else {
			system("cls"); goto ent;
		}
	}

	void find_max()
	{
	ent:
		cout << "1 - Search by price\n2 - Search by height\n";
		char c;
		c = getchar();
		if (c == '1')
		{
			auto res = max_element(container.begin(), container.end(), [](spruce& first, spruce& second) {return first.get_price() < second.get_price(); });
			cout << "\tMAX\n" << "Height: " << res->get_height() << "  Price: " << res->get_price() << endl;
		}
		else if (c == '2')
		{
			auto res = max_element(container.begin(), container.end(), [](spruce& first, spruce& second) {return first.get_height() < second.get_height(); });
			cout << "\tMAX\n" << "Height: " << res->get_height() << "  Price: " << res->get_price() << endl;
		}
		else {
			system("cls"); goto ent;
		}
	}

	void print()
	{
		short  k = 1;
		for (auto s : container)
		{
			cout << k << " - " << s;
			k++;
		}
	}

	void sort_data()
	{
	ent:
		cout << "1 - Sort Ascending\n2 - Descending Sort\n";
		char c, c2;
		c = getchar();
		if (c == '1' || c == '2')
		{
		ch:
			cout << "1 - Sort by price\n2 - Sort by height\n";
			c2 = getchar();
			if (c2 == '1')
			{
				sort(container.begin(), container.end(), [](spruce& first, spruce& second) {return first.get_price() < second.get_price(); });
			}
			else if (c2 == '2')
			{
				sort(container.begin(), container.end(), [](spruce& first, spruce& second) {return first.get_height() < second.get_height(); });
			}
			else
			{
				system("cls");
				goto ch;
			}
		}
		else
		{
			system("cls");
			goto ent;
		}
		if (c == '2') reverse(container.begin(), container.end());
	}

	void price_increase()
	{
		cout << "Enter how much to increase\n";
		short n;
		cin >> n;
	ent:
		cout << "1 - Multiply the current price by " << n << "\n2 - Add " << n << " to the current price\n";
		char c;
		c = getchar();
		if (c == '1')
		{
			for (short i = 0; i < 20; i++)
			{
				container[i].div_mult_price(n, true);
			}
		}
		else if (c == '2')
		{
			for (short i = 0; i < 20; i++)
			{
				container[i].de_increase_price(n, true);
			}
		}
		else
		{
			system("cls");
			goto ent;
		}
	}

	void price_reduction()
	{
		cout << "Enter how much to decrease\n";
		short n;
		cin >> n;
	ent:
		cout << "1 - Divide the current price by " << n << "\n2 - Subtract " << n << " from the current price\n";
		char c;
		c = getchar();
		if (c == '1')
		{
			for (short i = 0; i < 20; i++)
			{
				container[i].div_mult_price(n, false);
			}
		}
		else if (c == '2')
		{
			for (short i = 0; i < 20; i++)
			{
				container[i].de_increase_price(n, false);
			}
		}
		else
		{
			system("cls");
			goto ent;
		}
	}

	void remove_from_list()
	{
		cout << "Enter tree number at list\n";
		short n;
		cin >> n; n--;
		container.erase(container.begin() + n);
	}
};

void main()
{
	prog n1;
	char c = 0;
	do {
		system("cls");
		cout << "1 - Show list\n2 - Find minimal\n3 - Find maximal\n4 - Sorting\n5 - Increase price\n6 - Decrease price\n7 - Remove tree from list\nEsc - exit\n";
		c = _getch();
		switch (c)
		{
		case '1':system("cls");
			n1.print();
			system("pause");
			break;
		case'2':system("cls");
			n1.find_min();
			system("pause");
			break;
		case'3':system("cls");
			n1.find_max();
			system("pause");
			break;
		case'4':system("cls");
			n1.sort_data();
			break;
		case'5':system("cls");
			n1.price_increase();
			break;
		case'6':system("cls");
			n1.price_reduction();
			break;
		case'7':system("cls");
			n1.remove_from_list();
			break;
		}
	} while (c != 27);
}