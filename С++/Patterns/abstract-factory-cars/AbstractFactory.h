#pragma once
#include "Sport_car.h"
#include "Family_car.h"
class AbstractFactory
{
public:
	virtual Sport_car* new_sport_car() = 0;
	virtual Family_car* new_family_car() = 0;
};