#pragma once
#include "Info.h"
class TelBook
{
	char Name[20];
	Info mas[20];
	short t;
public:
	TelBook(const char*);
	void Add();
	void Del();
	void Find();
	void print();
};

