#pragma once
#include <ostream>
class Sport_car
{
	char* name;
	int max_speed;
public:
	Sport_car(const Sport_car&) = delete;
	Sport_car& operator=(const Sport_car&) = delete;
	Sport_car(const char* name, int max_speed);
	char* get_name();
	int get_max_speed();
	virtual ~Sport_car();
};
std::ostream& operator<<(std::ostream& out, Sport_car& car);