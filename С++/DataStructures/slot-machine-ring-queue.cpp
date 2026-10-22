// Источник: HW OOP 2.txt
// 1.	Создать имитацию игры "однорукий бандит". Например,
// при нажатии кнопки «Enter» происходит «вращение»
// трех барабанов (естественно, количество вращений
// каждого из них выбирается случайно), на которых изо-
// бражены разные значки; и если выпадает определенная
// комбинация, то игрок получает какой-то выигрыш.


#include <iostream>
#include <conio.h>
#include <Windows.h>
#include <ctime>

using namespace std;

class queuering
{
	enum {size = 4};
	char queue[size + 1];
	short count;
public:
	friend class game;
	queuering() : count(0) {}
	bool empty()
	{
		return count == 0;
	}
	bool full()
	{
		return count == size;
	}
	void add(char c) {
		if (!full()) {
			queue[count++] = c;
		}
		else {
			cout << "Error" << endl;
		}
	}
	bool push() {
		if (!empty()) {
			char temp = queue[0];
			for (int i = 1; i < count; ++i) {
				queue[i - 1] = queue[i];
			}
			queue[count - 1] = temp;
			return 1;
		}
		else {
			cout << "Error" << endl;
			return 0;
		}
	}
	void clear() {
		count = 0;
	}
	void show() {
		for (int i = 0; i < count; ++i) {
			cout << queue[i] << " ";
		}
	}
	void show2() {
		show();
		cout << endl;
	}
	~queuering()
	{
		clear();
	}
};

class game
{
	short p;
public:
	game(short n) : p(n) {}
	
	void sbarrel(queuering* a, const int n) {
		for (int k = 0; k < n; ++k) {
			(a + k)->show2();
		}
	}

	void barrel(queuering* a, const int n) {
		for (int k = 0; k < n; ++k) {
			char n1, n2 = 0;
			while (!((a + k)->full())) {
			n1 = 33 + rand() % (38 - 33);
				if (n1 == n2) {
					continue;
				}
				else {
					(a + k)->add(n1);
					n2 = n1;
				}
			}
		}
	}

	void rotate(queuering* a, const int n) {
		for (int k = 0; k < n; ++k) {
			int n = rand() % 20 + 10;
			for (int i = 0; i < n; ++i) {
				(a + k)->push();
				Sleep(100);
				(a + k)->show();
				for (int i = 0; i < (a + k)->size; ++i) {
					cout << "\r\r";
				}
			}
			(a + k)->show();
			cout << "   " << n << " оборотов" << endl;
		}
	}
	
	void end(queuering* a, const int n) {
		short tmp = p;
		for (int k, i = 0; i < (a + k)->size; ++i) {
			bool f = false;
			for (k = 1; k < n; ++k) {
				if ((a + k - 1)->queue[i] == (a + k)->queue[i]) {
					f = true;
				}
				else {
					f = false;
					break;
				}
			}
			if (f == true)
			{
				p += p;
				break;
			}
		}
		if (p == tmp) {
			cout << endl << "Вы проиграли" << endl << endl;
			system("pause >0");
		}
		else {
			cout << endl << "Вы победили - " << p << "$" << endl << endl;
			system("pause >0");
		}
	}
};

void main() {
	setlocale(0, "");
	srand(unsigned(time(NULL)));
	const short n = 3;
	queuering a[n];
	cout << "Введите вашу ставку: ";
	short p;
	cin >> p;
	game n1(p);
	char c = 0, k = 0;
	do {
		system("cls");
		cout << "Играть - 1\n" <<
			"Выход - Esc\n";
		c = _getch();
		system("cls");
		if (c == '1') {
			n1.barrel(a, n);
			n1.sbarrel(a, n);
			f:
			cout << "Крутить - Enter";
			k = _getch();
			if (k == 13) {
				system("cls");
				n1.rotate(a, n);
				n1.end(a, n);
			}
			else
				goto f;
		}
	} while (c != 27);
}

