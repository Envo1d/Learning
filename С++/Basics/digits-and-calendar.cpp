#include <iostream>
using namespace std;

// Задание 1: Пользователь вводит с клавиатуры число больше нуля,
// необходимо вывести все его цифры, начиная с конца.

void reverseDigits() {
	int n, rev;
	cout << "Vvedite chislo: \n";
	cin >> n;
	cout << "Chislo naoborot = ";
	while (n > 0) {
		rev = n % 10;
		n /= 10;
		cout << rev;
	}
}

// Задание 2: Пользователь вводит с клавиатуры число, необходимо
// показать на экран сумму его цифр.

void digitSum() {
	int n, tmp, sum = 0;
	cout << "Vvedite chislo: \n";
	cin >> n;
	while (n > 0) {
		tmp = n % 10;
		n /= 10;
		sum += tmp;
	}
	cout << "Summa chisel = " << sum;
}

// Задание 3: В первый день улитка проползла 15 см. Каждый следу-
// ющий день она проползала на 2 см дальше. Определить
// какое общее расстояние проползет улитка через N дней.

void snailDistance() {
	int n, tmp = 0, sum = 0, ras = 15;
	cout << "Vvedite kolichestvo dney: \n";
	cin >> n;
	while (tmp < n) 
	{
		sum += ras;
		ras += 2;
		tmp++;
	}
	cout << "Summarniy put = " << sum;
}

// Задание 4: Для принятия решения студент Д. подбрасывал монетку
// 9 раз. Если в результате количество выпавших монеток
// стороной «орел» было четным числом, принимал ре-
// шение в положительную сторону, иначе в отрицатель-
// ную. Напишите программу, которая 9 раз запрашивает
// число 1 или 0 (орел/решка) и выдает соответствующий
// результат решения проблемы студента Д.

void coinDecision() {
	int sum = 0, n, i = 0;
	cout << "Orel = 1\nReshka = 0\n";
	while (i < 9)
	{
		cout << "\nOrel ili reshka?\n";
		cin >> n;
		sum += n;
		i++;
	}
	if (sum % 2 == 0)
		cout << "\nDa";
	else
		cout << "\nNet";
}

// Задание 5: Вывести на дисплей календарь на выбранный месяц
// с учетом указанного номера дня недели для начала
// месяца.

void monthCalendar() {
	setlocale(LC_ALL, "rus");
	int month, day, dinm = 0, weekends = 0;
	cout << "Введите номер месяца (1 - 12)\n";
	cin >> month;
	cout << "Введите день с которого начинаеться месяц (1 - 7)\n";
	cin >> day;
	switch (month)
	{
	case 1:cout << "\t\t\tЯнварь\n"; dinm = 31;
		break;
	case 2:cout << "\t\t\tФевраль\n"; dinm = 28; 
		break;
	case 3:cout << "\t\t\tМарт\n"; dinm = 31; 
		break;
	case 4:cout << "\t\t\tАпрель\n"; dinm = 30; 
		break;
	case 5:cout << "\t\t\tМай\n"; dinm = 31; 
		break;
	case 6:cout << "\t\t\tИюнь\n"; dinm = 30; 
		break;
	case 7:cout << "\t\t\tИюль\n"; dinm = 31; 
		break;
	case 8:cout << "\t\t\tАвгуст\n"; dinm = 31; 
		break;
	case 9:cout << "\t\t\tСеньтябрь\n"; dinm = 30; 
		break;
	case 10:cout << "\t\t\tОктябрь\n"; dinm = 31; 
		break;
	case 11:cout << "\t\t\tNНоябрь\n"; dinm = 30; 
		break;
	case 12:cout << "\t\t\tДекабрь\n"; dinm = 31; 
		break;
	}
	cout << "\nПн\tВт\tСр\tЧт\tПт\tСб\tВс\n";
	for (int i = 1; i < day; i++)
	{
		cout << "\t";
	}
	for (int i = 1; i <= dinm; i++)
	{
		cout << i << "\t";
		if ((i + day - 1) % 7 == 0) {
			cout << endl;
			weekends++;
		}
		if ((i + day - 3) % 6 == 0)
		{
			weekends++;
		}
	}
	cout << "\n\nВ этом месяце " << weekends << " выходных\n";
}

void main()
{
	reverseDigits();
	digitSum();
	snailDistance();
	coinDecision();
	monthCalendar();
}
