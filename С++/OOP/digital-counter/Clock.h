#pragma once
#include <iostream>
#include <Windows.h>
#include <conio.h>
#define clr system("cls")
using namespace std;
class Clock
{
	short h;
	short m;
	short s;
	short maxH;
	short maxM;
	short maxS;
public:
	Clock();
	Clock(short);
	Clock(short, short, short);
	Clock(short, short, short, short, short, short);
	void show1();
	void show2();
};

