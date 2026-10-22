#pragma once
#include <ostream>
class Family_car
{
	char* name;
	int volume;
public:
	Family_car(const Family_car&) = delete;
	Family_car& operator=(const Family_car&) = delete;
	Family_car(char* name, int volume);
	char* get_name();
	int get_volume();
	virtual ~Family_car();
};

std::ostream& operator<<(std::ostream& out, Family_car& car);