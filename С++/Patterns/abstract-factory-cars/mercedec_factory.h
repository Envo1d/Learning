#pragma once
#include "AbstractFactory.h"
class mercedec_factory : public AbstractFactory
{
public:
	virtual Sport_car* new_sport_car() override;
	virtual Family_car* new_family_car() override;
};

