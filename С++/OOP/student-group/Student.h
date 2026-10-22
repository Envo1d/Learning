#pragma once
#include <iostream>
using namespace std;
class Student
{
	char* fio;
	short age;
public:
	char* GetFio() {
		return fio;
 }
	short GetA() {
		return age;
	}
	Student();
	Student(const Student&);
	Student& operator=(const Student&);
	void Vvod();
	void Show();
	~Student();
};

