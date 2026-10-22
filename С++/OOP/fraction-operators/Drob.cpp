#include "Drob.h"

Drob::Drob()
{
	ch = 0;
	z = 0;
}

Drob::Drob(int a, int b)
{
	ch = a;
	z = b;
}

Drob::Drob(const Drob& copy)
{
	ch = copy.ch;
	z = copy.z;
}

Drob Drob::operator=(const Drob& copy)
{
	if (this != &copy)
	{
		ch = copy.ch;
		z = copy.z;
	}
	return *this;
}

Drob Drob::operator+(const Drob& obj)
{
	Drob res;
	res.z = z * obj.z;
	res.ch = (ch * obj.z) + (obj.ch * z);
	return res;
}

Drob Drob::operator-(const Drob&obj)
{
	Drob res;
	res.z = z * obj.z;
	res.ch = (ch * obj.z) - (obj.ch * z);
	return res;
}

Drob Drob::operator*(const Drob& obj)
{
	Drob res;
	res.z = z * obj.z;
	res.ch = ch * obj.ch;
	return res;
}

Drob Drob::operator/(const Drob& obj)
{
	Drob res;
	res.ch = ch * obj.z;
	res.z = z * obj.ch;
	return res;
}

void Drob::print()
{
	cout << ch << "\n--\n" << z << "\n";
}

