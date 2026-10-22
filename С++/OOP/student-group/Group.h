#pragma once
#include "Student.h"
class Group
{
	char Name[60];
	Student* mas;
	short size;
public:
	Group();
	void New();
	void Delete();
	void Print();
	void FindPers();
	~Group();
};

