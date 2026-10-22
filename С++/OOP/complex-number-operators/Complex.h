#pragma once
#include <iostream>
using namespace std;
class Complex
{
	double r;
	double im;
public:
	Complex();
	Complex(const Complex&);
	Complex operator=(const Complex&);
	Complex operator+(const Complex&);
	Complex operator-(const Complex&);
	Complex operator*(const Complex&);
	Complex operator/(const Complex&);
	void show();
	void ent();
};

