#include "Complex.h"

Complex::Complex()
{
	r = 0;
	im = 0;
}

Complex::Complex(const Complex& copy)
{
	r = copy.r;
	im = copy.im;
}

Complex Complex::operator=(const Complex&copy)
{
	if (this != &copy)
	{	
		r = copy.r;
		im = copy.im;
	}
	return *this;
}

Complex Complex::operator+(const Complex& obj)
{
	Complex tmp;
	tmp.r = r + obj.r;
	tmp.im = im + obj.im;
	return tmp;
}

Complex Complex::operator-(const Complex& obj)
{
	Complex tmp;
	tmp.r = r - obj.r;
	tmp.im = im - obj.im;
	return tmp;
}

Complex Complex::operator*(const Complex& obj)
{
	Complex tmp;
	tmp.r = (r * obj.r) - (im * obj.im);
	tmp.im = (im * obj.r) + (r * obj.im);
	return tmp;
}

Complex Complex::operator/(const Complex&obj)
{
	Complex tmp;
	tmp.r = ((r * obj.r) + (im * obj.im))/((im*im)+(obj.im*obj.im));
	tmp.im = ((im * obj.r) - (r * obj.im))/ ((im * im) + (obj.im * obj.im));
	return tmp;
}

void Complex::show()
{
	cout << r << " + " << im << "i";
}

void Complex::ent()
{
	cout << "Введите вещественную часть: "; cin >> r;
	cout << "\nВведите мнимую часть: "; cin >> im;
}

