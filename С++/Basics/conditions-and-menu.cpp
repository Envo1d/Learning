#include <iostream>
using namespace std;

// Задание 1: Напишите программу, проверяющую число, введенное с клавиатуры на четность.

void parity() {
	int a;
	cout << "Vvedite chislo\n";
	cin >> a;
	if (a % 2)
		cout << "Chislo ne chetnoe";
	else
		cout << "Chislo chetnoe";
}

// Задание 2: Дано натуральное число а (a<100). Напишите программу,
// выводящую на экран количество цифр в этом числе и сумму этих цифр.

void digitCountAndSum() {
	int a, b, sum;
	cout << "Vvedite chislo\n";
	cin >> a;
	if (a > 9)
	{
		b = 2;
	}
	else
	{
		b = 1;
	}
	sum = a / 10 + a % 10;
	cout << "Summa :" << sum << "\n";
	cout << "Kolichestvo :" << b;
}

// Задание 3: Известно, что 1 дюйм равен 2.54 см. Разработать приложение,
// переводящие дюймы в сантиметры и наоборот.
// Диалог с пользователем реализовать через систему меню.

int lengthConversion() {
	setlocale(LC_ALL, "rus");
	int choice;
	float sm, dm;
	cout << "Выберите задачу:\n" <<
		"1. С дюймов в сантиметры\n" <<
		"2. Из сантиметров в дюймы\n";
	cin >> choice;
	switch (choice)
	{
	case 1:
		cout << "Введите дюймы\n";
		cin >> dm;
		sm = dm * 2.54;
		cout << "Количество сантиметров = " << sm;
		break;
	case 2:
		cout << "Введите сантиметры\n";
		cin >> sm;
		dm = sm / 2.54;
		cout << "Количество дюймов = " << dm;
		break;
	default:
		cout << "Error";
		break;
	}
	return 0;
}

// Задание 4: Написать программу-меню, которая выводила бы на экран название
// мобильного оператора и стоимость телефонного разговора за минуту.
// У пользователя необходимо запросить код мобильного оператора и продолжительность
// разговора. Определить затраченную на звонок сумму денег.
// Ниже предоставлен пример вывода меню.

void mobileCallCost() {
	float kod, time ,price;
	cout << "==================================================================\n";
	cout << "|     Mobile operators    |     Code     | Price per minute, UAH |\n";
	cout << "==================================================================\n";
	cout << "| Kyivstar                |      67      |         3.00          |\n";
	cout << "| Vodafone                |      66      |         2.50          |\n";
	cout << "| Life                    |      63      |         2.00          |\n";
	cout << "==================================================================\n\n";
	cout << "Vvedite kod operatora i prodolzhitelnost razgovora(v minutah)\n";
	cin >> kod;
	if (kod == 67)
	{
		cin >> time;
		price = 3 * time;
		cout << "Cena razgovora : " << price << " UAH"; 
	}
	else if (kod == 66)
	{
		cin >> time;
		price = float(2.50) * time;
		cout << "Cena razgovora : " << price << " UAH";
	}
	else if (kod == 63)
	{
		cin >> time;
		price = 2 * time;
		cout << "Cena razgovora : " << price << " UAH";
	}
	else
		cout << "Takogo koda net";
}

void main()
{
	parity();
	digitCountAndSum();
	lengthConversion();
	mobileCallCost();
}
