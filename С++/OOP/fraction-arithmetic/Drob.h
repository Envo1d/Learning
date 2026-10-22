#pragma once
#include <iostream>
using std::cout;
using std::cin;

class Drob
{
	int ch;
	int z;
public:
	int GetCh();
	int GetZ();
	Drob();
	Drob(int, int);
	Drob Add(Drob);
	Drob Min(Drob);
	Drob Mul(Drob);
	Drob Div(Drob);
	void print();
};

