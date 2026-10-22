// Источник: HW OOP 1.txt
// 3. Написать программу, которая на основе классов реализует карточную игру Блэк-Джек.


#include <iostream>
#include <Windows.h>
#include <ctime>
#include <conio.h>
 
using namespace std;

class Blackjack
{
private:
	short bet;
	short total_points;
	char cards[14] = { '2','3','4','5','6','7','8','9','D','J','Q','K','T','\0' };
	char hand[8] = { 0,0,0,0,0,0,0,'\0' };
	short count;
	short sum;
public:
	friend class AI;
	Blackjack()
	{
		bet = 0;
		total_points = 0;
		count = 0;
		sum = 0;
	}
	short operator()(short col)
	{
		this->total_points = col;
		return total_points;
	}
	short get_p()
	{
		return total_points;
	}
	friend istream& operator>>(istream& stream, Blackjack& num);
	friend ostream& operator<<(ostream& stream, Blackjack& num);
	void card()
	{
		short tmp1 = rand() % 13;
		hand[count] = cards[tmp1];
		short tmp2 = tmp1 + 2;
		if (tmp2 >= 10) {
			tmp2 = 10;
			sum += tmp2;
		}
		else sum += tmp2;
		count++;
	}
	bool scan1(short sum)
	{
		if (sum <= 21) return true;
		else return false;
	}
	void ar_points(bool res)
	{
		if (res == false)
		{
			total_points -= bet;
		}
		else
		{
			total_points += bet * 2;
		}
	}
};

istream& operator>>(istream& stream, Blackjack& num)
{
	stream >> num.bet;
	return stream;
}
ostream& operator<<(ostream& stream, Blackjack& num)
{
	short i = 0;
	while (num.hand[i] != 0)
	{
		if(num.hand[i]=='D')
			stream << "|10|" << "  ";
		else stream << "|" << num.hand[i] << "|" << "  ";
		i++;
	}
	return stream;
}

class AI
{
public:
	void reset(Blackjack& player, Blackjack& croupier)
	{
		player.sum = 0;
		player.count = 0;
		croupier.sum = 0;
		croupier.count = 0;
		for (short i = 0; i < 7; i++)
		{
			player.hand[i] = 0;
			croupier.hand[i] = 0;
		}
	}
	void start(Blackjack& player)
	{
		short start_points;
		cout << "Введите количество фишек\n";
		cin >> start_points;
		player(start_points);
	}
	void game(Blackjack& player, Blackjack& croupier)
	{
		cout << "Введите вашу ставку\n";
		cin >> player;
		croupier.card();
		char k = 0;
		do {
			system("cls");
			cout << "\t\tСтавка [" << player.bet << "]\n\n\n";
			cout << "Карты крупье: " << croupier << "|*|\n\n\n";
			cout << "Ваши карты: " << player << "\n";
			cout << "Сумма = " << player.sum << "\t Количество фишек: " << player.total_points;
			cout << "\n\n1 - Взять карту\n" <<
				"2 - Удвоить ставку\n" <<
				"Пробел - Пас\n";
			k = _getch();
			switch (k)
			{
			case '1':
				player.card();
				if (player.scan1(player.sum) == false)
				{
					system("cls");
					cout << "Ваши карты: " << player << "\n";
					cout << "Сумма = " << player.sum;
					cout << "\nПеребор\n";
					player.ar_points(false);
					cout << "Вы проиграли\n\n";
					system("pause");
					k = 32;
				}
				else
					Sleep(500);
				break;
			case '2':
				player.bet *= 2;
				if (player.bet > player.total_points)
				{
					system("cls");
					cout << "Нельзя удвоить\n";
					player.bet /= 2;
					Sleep(1000);
				}
				else
					Sleep(300);
				break;
			}
		} while (k != 32);
		system("cls");
		croupier.card();
		cout << "Карты крупье: " << croupier << "\n";
		cout << "Сумма карт = " << croupier.sum;
		cout << "\n\n\nВаши карты: " << player << "\n";
		cout << "Сумма карт = " << player.sum;
		if (croupier.sum > player.sum && croupier.scan1(croupier.sum)==true)
		{
			cout << "\n\nВы проиграли\n";
			player.ar_points(false);
			cout << endl;
			system("pause");
		}
		else if (croupier.sum == player.sum)
		{
			cout << "\n\nНичья\n";
			cout << endl;
			system("pause");
		}
		else if (croupier.scan1(croupier.sum) == false && player.scan1(player.sum) == false)
		{
			cout << "\n\nПроиграли все\n";
			cout << endl;
			system("pause");
		}
		else
		{
			Sleep(3000);
			croupier.card();
			system("cls");
			cout << "Крупье взял карту";
			Sleep(2000);
			system("cls");
			cout << "Карты крупье: " << croupier << "\n";
			cout << "Сумма карт = " << croupier.sum;
			cout << "\n\n\nВаши карты: " << player << "\n";
			cout << "Сумма карт = " << player.sum;
			if (croupier.sum > player.sum && croupier.scan1(croupier.sum) == true)
			{
				cout << "\n\nВы проиграли\n";
				player.ar_points(false);
				cout << endl;
				system("pause");
			}
			else {
				cout << "\n\nПобеда!\n";
				player.ar_points(true);
				cout << endl;
				system("pause");
			}
		}
	}
};

void main()
{
	srand(unsigned(time(NULL)));
	setlocale(0, "");
	char c = 0;
	AI pc;
	Blackjack player, croupier;
	pc.start(player);
	do {
		system("cls");
		cout << "Начать/продолжить игру - 1\n" <<
			"Выход - Esc\n";
		c = _getch();
		system("cls");
		if (c == '1') {
			if (player.get_p() == 0)
			{
				system("cls");
				cout << "У вас больше нет фишек\n";
				Sleep(1000);
				c = 27;
			}
			else {
				pc.reset(player, croupier);
				pc.game(player, croupier);
			}
		}
	} while (c != 27);
}