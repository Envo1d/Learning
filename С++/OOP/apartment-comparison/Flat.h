#pragma once
#include <iostream>
using std::cin;
using std::cout;
class Flat
{
	short s;
	int cost;
	short num_in_house;
public:
	Flat();
	void show();
	void ent();
	Flat(const Flat&);
	Flat operator=(const Flat&);
	friend bool operator==(const Flat&, const Flat&);
	friend bool operator>(const Flat&, const Flat&);
};

