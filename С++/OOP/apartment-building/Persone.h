#pragma once
#include <iostream>
#include <Windows.h>
using namespace std;
class Persone
{
	char* fio;
	int age;
public:
	Persone();
	Persone(const Persone&);
	Persone& operator=(const Persone&);
	void Vvod();
	void Show();
	char* GetFio() {
		return fio;
	}
	~Persone();
};

