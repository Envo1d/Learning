#include "Drob.h"
int Drob::GetCh()
{
	return ch;
}

int Drob::GetZ()
{
	return z;
}

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

Drob Drob::Add(Drob v)
{
	Drob res;
	res.z = z * v.z;
	res.ch = (ch * v.z) + (v.ch * z);
	return res;
}

Drob Drob::Min(Drob v)
{
	Drob res;
	res.z = z * v.z;
	res.ch = (ch * v.z) - (v.ch * z);
	return res;
}

Drob Drob::Mul(Drob v)
{
	Drob res;
	res.z = z * v.z;
	res.ch = ch * v.ch;
	return res;
}

Drob Drob::Div(Drob v)
{
	Drob res;
	res.ch = ch * v.z;
	res.z = z * v.ch;
	return res;
}

void Drob::print()
{
	cout << GetCh() << "\n--\n" << GetZ()<<"\n";
}

