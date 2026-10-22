// Источник: Strategy Pattern HM.txt
/*
Используя паттерн Стратегия реализовать приложение
шифрования/дешифрования текста.
В приложении можно выбрать алгоритм шифрования: Цезаря или XOR.
Можно ввести строку текста и выбрать вариант шифрования/дешифрования.
*/

#include <iostream>
#include <string>
#include <conio.h>
#pragma warning(disable:4996)

using namespace std;

class encryptor
{
public:
	virtual void encryption(string&) = 0;
	virtual void decryption(string&) = 0;
};

class Cez : public encryptor
{
public:
	void encryption(string& data) override
	{
		cout << "Enter key for encryption\n";
		int k;
		cin >> k;
		for (size_t i = 0; i < data.length(); i++)
		{
			data[i] += k;
		}
	}
	void decryption(string& data) override
	{
		cout << "Enter key for decryption\n";
		int k;
		cin >> k;
		for (size_t i = 0; i < data.length(); i++)
		{
			data[i] -= k;
		}
	}
};

class XOR : public encryptor
{
public:
	void encryption(string& data) override
	{
		cout << "Enter key for encryption\n";
		int k;
		cin >> k;
		for (size_t i = 0; i < data.length(); i++)
		{
			data[i] ^= 3;
		}
	}
	void decryption(string& data) override
	{
		cout << "Enter key for decryption\n";
		int k;
		cin >> k;
		for (size_t i = 0; i < data.length(); i++)
		{
			data[i] ^= 3;
		}
	}
};

class EncryptorUI
{
	encryptor* Encryptor;
public:
	EncryptorUI() : Encryptor(nullptr) {}
	void set_encryptor(encryptor* enc)
	{
		Encryptor = enc;
	}
	void encryption(string& d)
	{
		Encryptor->encryption(d);
	}
	void decryption(string& d)
	{
    	Encryptor->decryption(d);
	}
};

void main()
{
	string data;
	EncryptorUI ui;
	Cez enc1;
	XOR enc2;
	char c, c2 = 0;
	cout << "Enter data\n";
	getline(cin, data);
	do {
		system("cls");
		cout << "Choose an encryption method\n1 - Caesar's method\n2 - XOR method\nEsc - Exit\n";
		c = _getch();
		switch (c)
		{
		case'1':system("cls");
			ui.set_encryptor(&enc1);
			do {
				system("cls");
				cout << "1 - Encrypt\n2 - Decrypt\nEsc - Exit\n";
				c2 = _getch();
				switch (c2)
				{
				case'1':system("cls");
					ui.encryption(data);
					cout << data << endl;
					system("pause");
					break;
				case'2':system("cls");
					ui.decryption(data);
					cout << data << endl;
					system("pause");
					break;
				}
			} while (c2 != 27);
			break;
		case'2':system("cls");
			ui.set_encryptor(&enc2);
			do {
				system("cls");
				cout << "1 - Encrypt\n2 - Decrypt\nEsc - Exit\n";
				c2 = _getch();
				switch (c2)
				{
				case'1':system("cls");
					ui.encryption(data);
					cout << data << endl;
					system("pause");
					break;
				case'2':system("cls");
					ui.decryption(data);
					cout << data << endl;
					system("pause");
					break;
				}
			} while (c2 != 27);
			break;
		}
	} while (c != 27);
}