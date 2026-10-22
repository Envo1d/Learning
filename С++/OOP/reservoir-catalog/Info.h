#pragma once
#include <iostream>
#include <Windows.h>
using namespace std;
class Info
{
	char* name;
	int shirina;
	int dlina;
	int glybina;
	char type;
public:
	char* GetN() {
		return name;
	}
	int GetS() {
		return shirina;
	}
	int GetD() {
		return dlina;
	}
	int GetG() {
		return glybina;
	}
	char GetT() {
		return type;
	}
	void PrintName() {
		cout << name;
	}
	Info();
	Info(const Info&);
	Info& operator=(const Info&);
	void Vvod();
	void Show();
	~Info();
};

