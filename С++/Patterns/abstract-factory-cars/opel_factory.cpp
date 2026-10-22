#include "opel_factory.h"
#include "opel_sport_car.h"
#include "opel_family_car.h"

Sport_car* opel_factory::new_sport_car()
{
	return new opel_sport_car((char*)"Opel GT", 400);
}

Family_car* opel_factory::new_family_car()
{
	return new opel_family_car((char*)"Opel Omega B", 300);
}
