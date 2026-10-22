#pragma once
#include <iostream>
using std::cin;
using std::cout;
class Overcoat
{
	char name[41];
	char type;
	int cost;
public:
	Overcoat();
	void ent();
	void show();
	Overcoat(const Overcoat&);
	Overcoat operator=(const Overcoat&);
	friend bool operator==(const Overcoat&, const Overcoat&);
	friend bool operator>(const Overcoat&, const Overcoat&);
};

