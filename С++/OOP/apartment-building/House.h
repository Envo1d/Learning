#pragma once
#include "Apartment.h"
class House
{
	Apartment* mas;
	int size;
	char Address[25];
public:
	House(int);
	void Add();
	void Del();
	void Show();
	void ShowAp();
	void Find();
	~House();
};

