#pragma once
#include <iostream>
using namespace std;
class String
{
	char* stroka;
	int size;
public:
	String() {
		size = 80;
		stroka = (char*)realloc(stroka, (this->size + 1) * sizeof(char));
	}
	String(int size) :String() {
		this->size = size + 1;
	}
	String(const char*);
	void Enter();
	void Show();
	~String();
};

