#include "Sport_car.h"
#include <cstring>
#include <ostream>
#pragma warning(disable:4996)

Sport_car::Sport_car(const char* name, int max_speed)
{
	this->name = new char[strlen(name) + 1];
	strcpy(this->name, name);
	this->max_speed = max_speed;
}

char* Sport_car::get_name()
{
	return name;
}

int Sport_car::get_max_speed()
{
	return max_speed;
}

Sport_car::~Sport_car()
{
	delete[] name;
}

std::ostream& operator<<(std::ostream& out, Sport_car& car)
{
	out << car.get_name() << ' ' << car.get_max_speed();
	return out;
}