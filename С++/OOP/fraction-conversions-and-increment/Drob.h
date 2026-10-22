#pragma once
#include <iostream>
using std::cout;
using std::cin;

class Drob
{
	int ch;
	int z;
public:
	Drob();
	Drob(int, int);
	Drob(const Drob&);
	Drob operator=(const Drob&);
	Drob operator+(const Drob&);
	Drob operator-(const Drob&);
	Drob operator*(const Drob&);
	Drob operator/(const Drob&);
	Drob & operator++();
	Drob operator++(int);
	Drob & operator--();
	Drob operator--(int);
	void print();
};

