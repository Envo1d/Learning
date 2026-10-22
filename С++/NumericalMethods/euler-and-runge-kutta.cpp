#include <iostream>
#include <math.h>

using namespace std;

double func(double x, double y)
{
	return (1 + x * y) / (x * x);
}

double roundD(double num)
{
	return floor(num * 1000000 + 0.5) / 1000000;
}

void improved(double startX ,double startY, double end, double step)
{
	double x, y, firstF, secF, sum, l, iter = 0;
	x = startX;
	y = startY;
	firstF = func(x, y);
	firstF = roundD(firstF);
	secF = func((x + step), (y + (step * firstF)));
	secF = roundD(secF);
	sum = firstF + secF;
	sum = roundD(sum);
	l = y + ((step / 2) * sum);
	l = roundD(l);
	cout << iter << "\t" << x << "\t" << y << "\t" << firstF << "\t" << secF << "\t" << l << "\t" << endl;
	iter++;
	x += step;
	y += l;
	while (roundD(x) <= end)
	{
		firstF = func(x, y);
		firstF = roundD(firstF);
		secF = func((x + step), (y + (step * firstF)));
		secF = roundD(secF);
		sum = firstF + secF;
		sum = roundD(sum);
		l = y + ((step / 2) * sum);
		l = roundD(l);
		cout << iter << "\t" << x << "\t" << y << "\t" << firstF << "\t" << secF << "\t" << l << "\t" << endl;
		iter++;
		x += step;
		y += l;
	}
}

void runge(double startX, double startY, double end, double step)
{
	double x, y, k1, k2, k3, k4, l, iter = 0;
	x = startX;
	y = startY;
	k1 = func(x, y);
	k1 = roundD(k1);
	k2 = func((x + (step/2)), (y + (step * k1 / 2)));
	k2 = roundD(k2);
	k3 = func((x + (step / 2)), (y + (step * k2 / 2)));
	k3 = roundD(k3);
	k4 = func((x + step), (y + (step * k3)));
	k4 = roundD(k4);
	l = (step / 6) * (k1 + (2 * k2) + (2 * k3) + k4);
	l = roundD(l);
	cout << iter << "\t" << x << "\t" << y << "\t" << k1 << "\t" << k2 << "\t" << k3 << "\t" << k4 << "\t" << l << "\t" << endl;
	iter++;
	x += step;
	y += l;
	while (roundD(x) <= end)
	{
		k1 = func(x, y);
		k1 = roundD(k1);
		k2 = func((x + (step / 2)), (y + (step * k1 / 2)));
		k2 = roundD(k2);
		k3 = func((x + (step / 2)), (y + (step * k2 / 2)));
		k3 = roundD(k3);
		k4 = func((x + step), (y + (step * k3)));
		k4 = roundD(k4);
		l = (step / 6) * (k1 + (2 * k2) + (2 * k3) + k4);
		l = roundD(l);
		cout << iter << "\t" << x << "\t" << y << "\t" << k1 << "\t" << k2 << "\t" << k3 << "\t" << k4 << "\t" << l << "\t" << endl;
		iter++;
		x += step;
		y += l;
	}
}

void main()
{
	//y(1) = 0
	//[1;2]
	//0,05

	improved(1, 0, 2, 0.05);
	cout << "\n\n\n";
	runge(1, 0, 2, 0.05);
}