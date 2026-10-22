#pragma once
#include "Info.h"
class Reservoir
{
	Info* mas;
	int size;
public:
	Reservoir();
	Reservoir(const Reservoir&);
	Reservoir& operator=(const Reservoir&);
	void New();
	void Delete();
	void CalV(int);
	void CalS(int);
	void CheckT(int, int);
	void CheckST(int, int);
	void Copy(int, char*, int&, int&, int&, char&);
	void Print();
	~Reservoir();
};

