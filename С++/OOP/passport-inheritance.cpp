// Источник: HW OOP 6.txt
/*Задание №2.Создайте класс Passport(паспорт), который будет содержать паспортную информацию о гражданине Украины.
С помощью механизма наследования, реализуйте класс ForeignPassport(загран.паспорт) производный от Passport.
Напомним, что заграничный паспорт содержит помимо паспортных данных, также данные о визах, номер заграничного паспорта.*/

#include <iostream>
#include <Windows.h>
#include <string>
#include <conio.h>
#pragma warning(disable:4996)

using namespace std;

class passport
{
	int document_n;
	string surname;
	string name;
	string patronymic;
	char sex;
	string date_of_birth;
	string date_of_expiry;
	string nationality;
public:
	passport()
	{
		cout << "Введите номер паспорта\n";
		cin >> document_n;
		cout << "Введите фамилию\n";
		cin >> surname;
		cout << "Введите имя\n";
		cin >> name;
		cout << "Введите отчество\n";
		cin >> patronymic;
		cout << "Введите пол(м/ж)\n";
		cin >> sex;
		cout << "Введите дату рождения\n";
		cin >> date_of_birth;
		cout << "Введите дату окончания действия пасспорта\n";
		cin >> date_of_expiry;
		cout << "Введите национальность\n";
		cin >> nationality;
	}
	void show()
	{
		cout << "Номер паспорта: " << document_n << endl
			<< "Национнальность: " << nationality << endl
			<< "Фамилия: " << surname << endl
			<< "Имя: " << name << endl
			<< "Отчество: " << patronymic << endl
			<< "Пол: " << sex << endl
			<< "Дата рождения: " << date_of_birth << endl
			<< "Действителен до: " << date_of_expiry << endl;
	}
};

class foreignpassport : public passport
{
	struct node
	{
		char* visa_info;
		char* date;
		char* visa_name;
		node* next;
		node() : next(nullptr), visa_info(nullptr), date(nullptr), visa_name(nullptr) {}
		node(const string inf, const string name, const string date) : next(nullptr)
		{
			this->date = new char[strlen(date.c_str()) + 1];
			strcpy(this->date, date.c_str());
			visa_name = new char[strlen(name.c_str()) + 1];
			strcpy(visa_name, name.c_str());
			visa_info = new char[strlen(inf.c_str()) + 1];
			strcpy(visa_info, inf.c_str());
		}
	};
	int num;
	node* head, * tail;
public:
	foreignpassport() : passport()
	{
		head = nullptr;
		tail = nullptr;
		cout << "Введите номер загран паспорта\n";
		cin >> num;
	}
	foreignpassport(const foreignpassport& copy)
	{
		head = nullptr;
		tail = nullptr;
		node* tmp = copy.head;
		while (tmp)
		{
			this->add(tmp->visa_info, tmp->visa_name, tmp->date);
			tmp = tmp->next;
		}
		num = copy.num;
	}
	foreignpassport& operator=(const foreignpassport& copy)
	{
		if (this != &copy)
		{
			head = nullptr;
			tail = nullptr;
			node* tmp = copy.head;
			while (tmp)
			{
				this->add(tmp->visa_info, tmp->visa_name, tmp->date);
				tmp = tmp->next;
			}
			num = copy.num;
		}
		return *this;
	}
	void add(const string inf, const string name, const string date)
	{
		node* tmp = new node(inf, name, date);
		if (empty())
		{
			tail = head = tmp;
		}
		else
		{
			tail->next = tmp;
			tail = tmp;
		}
	}
	bool empty() { return head == nullptr; }
	void clear()
	{
		while (head)
		{
			node* tmp = head->next;
			delete head;
			head = tmp;
		}
	}
	friend ostream& operator<<(ostream& stream, const foreignpassport& o)
	{
		node* out = o.head;
		while (out)
		{
			stream << out->visa_name << '\n' << "Инфо: " << out->visa_info << '\n' << "Дата выдачи: " <<out->date << "\n\n";
			out = out->next;
		}
		return stream;
	}
	void show()
	{
		cout << "Информация о паспорте:\n";
		passport::show();
		cout << endl;
		cout << "Номер загран паспорта: " << num << endl;
		cout << "Визы:\n" << *this;
	}
	~foreignpassport()
	{
		clear();
	}
};

void main()
{
	SetConsoleCP(1251);
	SetConsoleOutputCP(1251);
	cout << "1 - Создать паспорт\n2 - Создать загран паспорт\n";
	char c, c2 = 0;
	c = _getch();
	if (c == '1')
	{
		passport n1;
		system("cls");
		n1.show();
		cout << endl;
		system("pause");
	}
	else if (c == '2')
	{
		foreignpassport f1;
		cin.ignore();
		do {
			system("cls");
			cout << "Добавить визу - 1.\nДля выхода нажмите Esc\n";
			c2 = _getch();
			if (c2 == '1')
			{
				cout << "Введите название визы:\n";
				string name;
				getline(cin, name);
				cout << "Введите информацию о визе:\n";
				string info;
				getline(cin, info);
				cout << "Введите дату выдачи визы:\n";
				string date;
				getline(cin, date);
				f1.add(info, name, date);
			}
			else continue;
		} while (c2 != 27);
		system("cls");
		f1.show();
		cout << endl;
		system("pause");
	}
}
