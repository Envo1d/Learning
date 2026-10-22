/*
Продолжить реализацию паттерна Абстрактная фабрика начатого на занятии:
Добавить класс mercedes_family_car, который представляет собой семейный автомобиль
Класс наследует family_car.
Экземпляр данного класса должен возвращать метод new_famaly_car() класса mercedes_factory.

Аналогично mercedes_factory, mercedes_family_car, mercedes_sport_car создать классы,
opel_factory, opel_family_car и opel_sport_car.

Дополнительный материал: http://cpp-reference.ru/patterns/creational-patterns/abstract-factory/
*/

#include <iostream>
#include "mercedec_factory.h"
#include "opel_factory.h"

using namespace std;

void main()
{
	AbstractFactory* factory1 = new mercedec_factory();
	Sport_car* sport1 = factory1->new_sport_car();
	cout << *sport1 << endl;
	Family_car* family1 = factory1->new_family_car();
	cout << *family1 << endl;
	AbstractFactory* factory2 = new opel_factory();
	Sport_car* sport2 = factory2->new_sport_car();
	cout << *sport2 << endl;
	Family_car* family2 = factory2->new_family_car();
	cout << *family2 << endl;
}