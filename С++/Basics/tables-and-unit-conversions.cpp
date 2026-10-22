#include <iostream>
using namespace std;

// Задание 1: Напишите программу, которая выводила бы на экран текстовую таблицу.

void truthTable() {
	cout << "----------------------------------------------------------------\n";
	cout << "|     X     |     Y     |   X and Y   |   X or Y   |    Not X  |\n";
	cout << "================================================================\n";
	cout << "|     0     |     0     |      0      |     0      |     1     |\n";
	cout << "|     0     |     1     |      0      |     1      |     1     |\n";
	cout << "|     1     |     0     |      0      |     1      |     0     |\n";
	cout << "|     1     |     1     |      1      |     1      |     0     |\n";
	cout << "================================================================\n";
}

// Задание 2: Дана диагональ телевизора в дюймах. Написать программу,
// определяющую эту же диагональ в сантиметрах (1 дюйм = 2.54 сантиметров).

void screenDiagonal() {
	short inch;
	float sm;
	cout << "Vvedity liagonal ekrana (inch)\n";
	cin >> inch;
	sm = inch * 2.54;
	cout << "Diagonal = " << sm << " sm";
}

// Задание 3: Емкость аккумулятора смартфона составляет N мАч.
// Написать программу, определяющую минимальную емкость переносного
// зарядного устройства (powerbank), если необходимо 3 полных заряда смартфона.

void powerbankCapacity() {
	short akksmart, powerbank;
	cout << "Vvedite emkost akkamylyatora smartfona\n";
	cin >> akksmart;
	powerbank = akksmart * 3;
	cout << "Minimalnaya emkost poverbanka = " << powerbank << " mAh";
}

// Задание 4: За один день хомячок съедает K грамм корма. Написать программу,
// определяющую закупку корма в килограммах на 30 дней.

void hamsterFood() {
	float den, mes;
	cout << "Vvedite skolko gramm v den est homyak\n";
	cin >> den;
	mes = (den * 0.001) * 30;
	cout << "Na mesyac nyzhno: " << mes << " kg";
}

void main()
{
	truthTable();
	screenDiagonal();
	powerbankCapacity();
	hamsterFood();
}
