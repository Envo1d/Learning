#include "Family_car.h"
#include <cstring>
#include <ostream>
#pragma warning(disable:4996)

Family_car::Family_car(char* name, int volume)
{
	this->name = new char[strlen(name) + 1];
	strcpy(this->name, name);
	this->volume = volume;
}

char* Family_car::get_name()
{
	return name;
}

int Family_car::get_volume()
{
	return volume;
}

Family_car::~Family_car()
{
	delete[] name;
}

std::ostream& operator<<(std::ostream& out, Family_car& car)
{
	out << car.get_name() << ' ' << car.get_volume();
	return out;
}