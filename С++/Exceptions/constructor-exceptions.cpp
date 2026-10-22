// Источник: HW OOP 8.txt
/*Задание 2

Напишите класс Garage который содержит объект Car.В Car есть проблемы с Motor.
Используйте блок try в конструкторе класса Garage для
перехвата исключения(брошенного из класса Motor), когда объект Car инициализируется.
Бросьте другое исключение из конструктора Garage для того, что бы поймать его в main().*/

//#include <iostream>
//#pragma warning(disable:4996)
//
//using namespace std;
//
//class Engine : exception
//{
//	bool OK;
//	int power;
//	float volume;
//public:
//	Engine(const char* msg, bool ok) : exception(msg)
//	{
//		OK = ok;
//		power = 300;
//		volume = 3.4f;
//	}
//	Engine(bool ok)
//	{
//		OK = ok;
//		power = 300;
//		volume = 3.4f;
//	}
//	~Engine() {}
//};
//
//class Car
//{
//	bool engine_broken = true;
//public:
//	Car()
//	{
//		if (engine_broken == true)
//		{
//			throw Engine("Engine is broken", engine_broken);
//		}
//		else throw Engine(engine_broken);
//	}
//	~Car() {}
//};
//
//class Garage : exception
//{
//	char* problem = NULL;
//public:
//	Garage()
//	{
//		try
//		{
//			Car a;
//		}
//		catch (Engine& ex)
//		{
//			throw Garage("Engine is broken");
//		}
//	}
//	Garage(const char* msg) : exception(msg)
//	{
//		problem = new char[strlen(msg) + 1];
//		strcpy(problem, msg);
//	}
//	const char* prob () const
//	{
//		return problem;
//	}
//	~Garage() {}
//};
//
//void main()
//{
//	try
//	{
//		Garage b;
//	}
//	catch (Garage& ex)
//	{
//		cerr << ex.prob() << endl;
//	}
//}