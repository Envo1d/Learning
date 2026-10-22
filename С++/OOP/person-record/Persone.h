#pragma once
#include <iostream>
#include <Windows.h>
#include <conio.h>
#define clr system("cls");
using namespace std;
class Persone
{
	char* name;
	short age;
	char pol;
	char number[13];
public:
	Persone();
	Persone(const char*);
	void setname();
	void setage();
	void setp();
	void setnum();
	void Print();
	~Persone();
};

