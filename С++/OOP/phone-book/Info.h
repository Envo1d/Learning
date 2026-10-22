#pragma once
#include <iostream>
using namespace std;
class Info
{
	char fio[50];
	char inf[60];
	char hnum[15];
	char wnum[15];
	char mnum[15];
public:
	void Vvod();
	void Show();
	char* GetFio() {
		return fio;
	}
};

