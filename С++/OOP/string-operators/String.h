#pragma once
#include <iostream>
using namespace std;
class String
{
	char* stroka;
	int size;
public:
	String();
	String(int);
	String(const char*);
	String(const String&);
	String(String&&);
	String& operator=(String&&);
	String operator=(const String&);
	void Enter();
	void Show();
	String & operator++();
	String operator++(int);
	String & operator--();
	String operator--(int);
	int operator[](int);
	int operator()(char);
	int operator-();
	~String();
};

