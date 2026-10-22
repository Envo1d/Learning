#include "Flat.h"

Flat::Flat()
{
	s = 0;
	cost = 0;
	num_in_house = 0;
}

void Flat::show()
{
	cout << "Номер - " << num_in_house << "\nПлощадь = " << s << "\nЦена - " << cost;
}

void Flat::ent()
{
	cout << "Введите номер квартиры: "; cin >> num_in_house;
	cout << "\nВведите площадь квартиры: "; cin >> s;
	cout << "\nВведите цену: "; cin >> cost;
}

Flat::Flat(const Flat& copy)
{
	s = copy.s;
	cost = copy.cost;
	num_in_house = copy.num_in_house;
}

Flat Flat::operator=(const Flat&copy)
{
	if (this != &copy)
	{
		s = copy.s;
		cost = copy.cost;
		num_in_house = copy.num_in_house;
	}
	return *this;
}

bool operator==(const Flat& a, const Flat& b)
{
	if (a.s == b.s)
		return true;
}

bool operator>(const Flat& a, const Flat& b)
{
	if (a.cost > b.cost)
		return true;
	else return false;
}

