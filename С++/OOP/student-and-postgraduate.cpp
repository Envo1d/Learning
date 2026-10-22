// Источник: HW OOP 6.txt
/*Задание №1.Создайте класс Student, который будет содержать информацию о студенте.
С помощью механизма наследования, реализуйте класс Aspirant(аспирант - студент,
который готовится к защите кандидатской работы) производный от Student.*/
#include <iostream>
#include <string>
#pragma warning(disable: 4996)

using namespace std;

class student
{
	char* fio;
	short age;
	char* student_card;
public:
	student(const string fio, short age, const string student_card) : age(age)
	{
		this->fio = new char[strlen(fio.c_str()) + 1];
		strcpy(this->fio, fio.c_str());
		this->student_card = new char[strlen(student_card.c_str()) + 1];
		strcpy(this->student_card, student_card.c_str());
	}
	void show()
	{
		cout << "\t" << fio << endl;
		cout << "Age: " << age << endl;
		cout << "Student card: " << student_card << endl;
	}
	~student()
	{
		delete[] fio;
	}
};

class aspirant : public student
{
	char* work_name;
	short days_for_work;
public:
	aspirant(const string fio, short age, const string s_card, const string work, short time) : student(fio, age, s_card)
	{
		this->work_name = new char[strlen(work.c_str()) + 1];
		strcpy(this->work_name, work.c_str());
		days_for_work = time;
	}
	void show()
	{
		student::show();
		cout << "Topic: " << work_name << endl;
		cout << "Time for work: " << days_for_work << " days" << endl;
	}
	~aspirant()
	{
		delete[] work_name;
	}
};

void main()
{
	cout << "1 - Create info about student\n2 - Create info about aspirant\n";
	char c = getchar();
	if (c == '1')
	{
		cout << "Enter full name:\n"; string inf;
		cin.ignore();
		getline(cin, inf);
		cout << "Enter age: "; short a;
		cin >> a;
		cin.ignore();
		cout << "Enter student card: "; string c;
		getline(cin, c);
		student n(inf, a, c);
		system("cls");
		n.show();
	}
	else if (c == '2')
	{
		cout << "Enter full name:\n"; string inf;
		cin.ignore();
		getline(cin, inf);
		cout << "Enter age: "; short a;
		cin >> a;
		cin.ignore();
		cout << "Enter student card: "; string c;
		getline(cin, c);
		cout << "Enter work name:\n"; string w;
		getline(cin, w);
		cout << "Enter amount of days for work:\n"; short days;
		cin >> days;
		aspirant d(inf, a, c, w, days);
		system("cls");
		d.show();
	}
	else cout << "Error";
}
