#pragma once
#include "Persone.h"
class Apartment
{
	Persone* mas;
	int size;
	int Num;
public:
	Apartment();
	Apartment(const Apartment&);
	Apartment& operator=(const Apartment&);
	void New();
	void Delete();
	void Print();
	void SetNum(int);
	int FindPers(const char*);
	int GetSize();
	~Apartment();
};

