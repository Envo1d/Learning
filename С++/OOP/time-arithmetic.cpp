// Источник: HW OOP 1.txt
// 1. Создайте класс Время, в котором реализованы операции сложения, вычитания, сравнения, ввода и вывод на экран. 
// Возможность конвертации времени из американского формата am (pm): 10:00 pm = 22:00, 12:00 pm = 00:00 .


#include <iostream>
#include <conio.h>

#define clr system("cls")

using namespace std;

class time
{
private:
	short h;
	short m;
	short s;
	char t;
public:
	time(short n = 0) : h(n), m(n), s(n), t('a')
	{}
	friend ostream& operator<<(ostream& stream, const time& res);
	friend istream& operator>>(istream& stream, time& num);
	void sett()
	{
		cout << "a - am\n" <<
			"p - pm\n";
		t = _getch();
	}
	char gett()
	{
		return t;
	}
	void conversion()
	{
		if (t == 'p')
			h = h + 12;
		t = '0';
	}
	friend void operator>(const time& first, const time& second);
	time operator+(const time& second)
	{
		if (t == '0' && second.t != '0')
		{
			time tmp, tmp1;
			tmp1 = second;
			tmp1.conversion();
			tmp.s = s + tmp1.s;
			tmp.m = m + tmp1.m;
			tmp.h = h + tmp1.h;
			if (tmp.s >= 60)
			{
				tmp.m = tmp.m + 1;
				tmp.s = tmp.s - 60;
			}
			if (tmp.m >= 60)
			{
				tmp.h = tmp.h + 1;
				tmp.m = tmp.m - 60;
			}
			if (tmp.h >= 24)
				tmp.h = tmp.h - 24;
			if (tmp.h > 12)
			{
				tmp.h = tmp.h - 12;
				tmp.t = 'p';
			}
			else tmp.t = 'a';
			return tmp;
		}
		else if (t != '0' && second.t == '0')
		{
			time tmp, tmp1;
			tmp1.s = s;
			tmp1.m = m;
			tmp1.h = h;
			tmp1.t = t;
			tmp1.conversion();
			tmp.s = tmp1.s + second.s;
			tmp.m = tmp1.m + second.m;
			tmp.h = tmp1.h + second.h;
			if (tmp.s >= 60)
			{
				tmp.m = tmp.m + 1;
				tmp.s = tmp.s - 60;
			}
			if (tmp.m >= 60)
			{
				tmp.h = tmp.h + 1;
				tmp.m = tmp.m - 60;
			}
			if (tmp.h >= 24)
				tmp.h = tmp.h - 24;
			if (tmp.h > 12)
			{
				tmp.h = tmp.h - 12;
				tmp.t = 'p';
			}
			else tmp.t = 'a';
			return tmp;
		}
		else if (t != '0' && second.t != '0')
		{
			time tmp, tmp1, tmp2;
			tmp1.s = s;
			tmp1.m = m;
			tmp1.h = h;
			tmp1.t = t;
			tmp2 = second;
			tmp1.conversion();
			tmp2.conversion();
			tmp.s = tmp1.s + tmp2.s;
			tmp.m = tmp1.m + tmp2.m;
			tmp.h = tmp1.h + tmp2.h;
			if (tmp.s >= 60)
			{
				tmp.m = tmp.m + 1;
				tmp.s = tmp.s - 60;
			}
			if (tmp.m >= 60)
			{
				tmp.h = tmp.h + 1;
				tmp.m = tmp.m - 60;
			}
			if (tmp.h >= 24)
				tmp.h = tmp.h - 24;
			if (tmp.h > 12)
			{
				tmp.h = tmp.h - 12;
				tmp.t = 'p';
			}
			else tmp.t = 'a';
			return tmp;
		}
		else
		{
			time tmp;
			tmp.t = '0';
			tmp.s = s + second.s;
			tmp.m = m + second.m;
			tmp.h = h + second.h;
			if (tmp.s >= 60)
			{
				tmp.m = tmp.m + 1;
				tmp.s = tmp.s - 60;
			}
			if (tmp.m >= 60)
			{
				tmp.h = tmp.h + 1;
				tmp.m = tmp.m - 60;
			}
			if (tmp.h >= 24)
				tmp.h = tmp.h - 24;
			return tmp;
		}
	}
	time operator-(const time& second)
	{
		if (t == '0' && second.t != '0')
		{
			time tmp, tmp1;
			tmp1 = second;
			tmp1.conversion();
			tmp.s = s - tmp1.s;
			tmp.m = m - tmp1.m;
			tmp.h = h - tmp1.h;
			if (tmp.s < 0)
			{
				tmp.m = tmp.m - 1;
				tmp.s = tmp.s + 60;
			}
			if (tmp.m < 0)
			{
				tmp.h = tmp.h - 1;
				tmp.m = tmp.m + 60;
			}
			if (tmp.h < 0)
				tmp.h = tmp.h + 24;
			if (tmp.h > 12)
			{
				tmp.h = tmp.h - 12;
				tmp.t = 'p';
			}
			else tmp.t = 'a';
			return tmp;
		}
		else if (t != '0' && second.t == '0')
		{
			time tmp, tmp1;
			tmp1.s = s;
			tmp1.m = m;
			tmp1.h = h;
			tmp1.t = t;
			tmp1.conversion();
			tmp.s = tmp1.s - second.s;
			tmp.m = tmp1.m - second.m;
			tmp.h = tmp1.h - second.h;
			if (tmp.s < 0)
			{
				tmp.m = tmp.m - 1;
				tmp.s = tmp.s + 60;
			}
			if (tmp.m < 0)
			{
				tmp.h = tmp.h - 1;
				tmp.m = tmp.m + 60;
			}
			if (tmp.h < 0)
				tmp.h = tmp.h + 24;
			if (tmp.h > 12)
			{
				tmp.h = tmp.h - 12;
				tmp.t = 'p';
			}
			else tmp.t = 'a';
			return tmp;
		}
		else if (t != '0' && second.t != '0')
		{
			time tmp, tmp1, tmp2;
			tmp1.s = s;
			tmp1.m = m;
			tmp1.h = h;
			tmp1.t = t;
			tmp2 = second;
			tmp1.conversion();
			tmp2.conversion();
			tmp.s = tmp1.s - tmp2.s;
			tmp.m = tmp1.m - tmp2.m;
			tmp.h = tmp1.h - tmp2.h;
			if (tmp.s < 0)
			{
				tmp.m = tmp.m - 1;
				tmp.s = tmp.s + 60;
			}
			if (tmp.m < 0)
			{
				tmp.h = tmp.h - 1;
				tmp.m = tmp.m + 60;
			}
			if (tmp.h < 0)
				tmp.h = tmp.h + 24;
			if (tmp.h > 12)
			{
				tmp.h = tmp.h - 12;
				tmp.t = 'p';
			}
			else tmp.t = 'a';
			return tmp;
		}
		else
		{
			time tmp;
			tmp.t = '0';
			tmp.s = s - second.s;
			tmp.m = m - second.m;
			tmp.h = h - second.h;
			if (tmp.s < 0)
			{
				tmp.m = tmp.m - 1;
				tmp.s = tmp.s + 60;
			}
			if (tmp.m < 0)
			{
				tmp.h = tmp.h - 1;
				tmp.m = tmp.m + 60;
			}
			if (tmp.h < 0)
				tmp.h = tmp.h + 24;
			return tmp;
		}
	}
};

ostream& operator<<(ostream& stream, const time& res)
{
	if (res.s < 10 && res.m >= 10 && res.h >= 10)
		stream << res.h << ':' << res.m << ':' << '0' << res.s;
	else if (res.s < 10 && res.m >= 10 && res.h < 10)
		stream << '0' << res.h << ':' << res.m << ':' << '0' << res.s;
	else if (res.s >= 10 && res.m >= 10 && res.h >= 10)
		stream << res.h << ':' << res.m << ':' << res.s;
	else if (res.s >= 10 && res.m >= 10 && res.h < 10)
		stream << '0' << res.h << ':' << res.m << ':' << res.s;
	else if (res.s >= 10 && res.m < 10 && res.h < 10)
		stream << '0' << res.h << ':' << '0' << res.m << ':' << res.s;
	else if (res.s >= 10 && res.m < 10 && res.h >= 10)
		stream << res.h << ':' << '0' << res.m << ':' << res.s;
	else if (res.s < 10 && res.m < 10 && res.h >= 10)
		stream << res.h << ':' << '0' << res.m << ':' << '0' << res.s;
	else if (res.s < 10 && res.m < 10 && res.h < 10)
		stream << '0' << res.h << ':' << '0' << res.m << ':' << '0' << res.s;
	return stream;
}
istream& operator>>(istream& stream, time& res)
{
	stream >> res.h >> res.m >> res.s;
	return stream;
}
void operator>(const time& first, const time& second)
{
	if (first.t == 'p')
		cout << "Clock 1 > Clock 2\n";
	else if (second.t == 'p')
		cout << "Clock 2 > Clock 1\n";
	if (first.t == '0' && second.t == '0')
	{
		if (second.h < first.h) cout << "Clock 1 > Clock 2\n";
		else if (first.h < second.h)cout << "Clock 2 > Clock 1\n";
	}
	else if (first.t == '0')
	{
		time tmp = second;
		tmp.conversion();
		if (first.h > tmp.h) cout << "Clock 1 > Clock 2\n";
		else if (tmp.h > first.h)cout << "Clock 2 > Clock 1\n";
	}
	else if (second.t == '0')
	{
		time tmp = first;
		tmp.conversion();
		if (second.h < tmp.h) cout << "Clock 1 > Clock 2\n";
		else if (tmp.h < second.h)cout << "Clock 2 > Clock 1\n";
	}
}

void main()
{
	time n1, n2, n3;
	cout << "Set the time for clock 1:\n";
	cin >> n1;
	n1.sett();
	clr;
	cout << "Set the time for clock 2:\n";
	cin >> n2;
	n2.sett();
	clr;
	char c = 0;
	do {
		clr;
		char p;
		cout << "Clock 1\n\n";
		if (n1.gett() != '0')cout << n1 << ' ' << n1.gett() << 'm' << endl;
		else cout << n1;
		cout << "\n\nClock 2\n\n";
		if (n2.gett() != '0')cout << n2 << ' ' << n2.gett() << 'm' << endl;
		else cout << n2;
		cout << "\n\n1 - addition\n" <<
			"2 - subtraction\n" <<
			"3 - comparison\n" <<
			"4 - conversion from american format\n" <<
			"Esc - exit\n";
		c = _getch();
		switch (c)
		{
		case '1':clr;
			n3 = n1 + n2;
			if (n3.gett() != '0')cout << n3 << ' ' << n3.gett() << 'm' << endl;
			else cout << n3 << endl;
			system("pause");
			break;
		case '2':clr;
			n3 = n1 - n2;
			if (n3.gett() != '0')cout << n3 << ' ' << n3.gett() << 'm' << endl;
			else cout << n3 << endl;
			system("pause");
			break;
		case '3':clr;
			n1 > n2;
			system("pause");
			break;
		case '4':clr;
			cout << "Convert Clock1 - 1\n" <<
				"Convert Clock2 - 2\n";
			p = _getch();
			if (p == '1')
				n1.conversion();
			if (p == '2')
				n2.conversion();
			cout << "\nDone\n\n";
			system("pause");
			break;
		}
	} while (c != 27);
}

