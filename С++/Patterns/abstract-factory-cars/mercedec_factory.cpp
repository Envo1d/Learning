#include "mercedec_factory.h"
#include "mercedec_sport_car.h"
#include "mercedec_family_car.h"

Sport_car* mercedec_factory::new_sport_car()
{
    return new mercedec_sport_car((char*)"Mercedec Sport", 300);
}

Family_car* mercedec_factory::new_family_car()
{
    return new mercedec_family_car((char*)"Mercedec Benz", 500);
}
