#include "Clock.h"

Clock::Clock()
{
	h = 0; m = 0; s = 0;
	maxH = 0; maxM = 0; maxS = 0;
}

Clock::Clock(short h)
{
	this->h = h;
	cout << "М - "; cin >> m;
	cout << "С - "; cin >> s;
	maxS = 0;
	maxM = 0;
	maxH = 0;
}

Clock::Clock(short maxH, short maxM, short maxS)
{
	h = 0;
	m = 0;
	s = 0;
	this->maxH = maxH;
	this->maxM = maxM;
	this->maxS = maxS;
}

Clock::Clock(short h, short m, short s, short maxH, short maxM, short maxS)
{
	this->h = h;
	this->m = m;
	this->s = s;
	this->maxH = maxH;
	this->maxM = maxM;
	this->maxS = maxS;
}

void Clock::show1()
{
	while(true)
	{
		clr;
		if (s < 10 && m >= 10 && h >= 10)
			cout << h << ":" << m << ":" << "0" << s << endl;
		else if (s < 10 && m >= 10)
			cout << "0" << h << ":" << m << ":" << "0" << s << endl;
		else if (s < 10)
			cout << "0" << h << ":" << "0" << m << ":" << "0" << s <<endl;
		else if (s >= 10 && m >= 10 && h >= 10)
			cout << h << ":" << m << ":" << s << endl;
		else if (s >= 10 && m >= 10)
			cout << "0" << h << ":" << m << ":" << s << endl;
		else if (s >= 10)
			cout << "0" << h << ":" << "0" << m << ":" << s << endl;
		Sleep(999);
		s++;
		if (s == 60)
		{
			m++;
			s = 0;
		}
		if (m == 60)
		{
			h++;
			m = 0;
		}
		if (h == 24)
			h = 0;
		if (_kbhit())
		{
			cout << "Пауза\n";
			cout << "Для выхода нажмите дважды Esc\n";
			cout << "Для продолжения нажмите дважды любую кнопку\n";
			system("pause >nul");
			char k;
			k = _getch();
			if (k != 27)
				continue;
			else break;
		}
	}
}

void Clock::show2()
{
	while (s <= maxS && m <= maxM && h <= maxH)
	{
		clr;
		if (s < 10 && m >= 10 && h >= 10)
			cout << h << ":" << m << ":" << "0" << s << endl;
		else if (s < 10 && m >= 10)
			cout << "0" << h << ":" << m << ":" << "0" << s << endl;
		else if (s < 10)
			cout << "0" << h << ":" << "0" << m << ":" << "0" << s << endl;
		else if (s >= 10 && m >= 10 && h >= 10)
			cout << h << ":" << m << ":" << s << endl;
		else if (s >= 10 && m >= 10)
			cout << "0" << h << ":" << m << ":" << s << endl;
		else if (s >= 10)
			cout << "0" << h << ":" << "0" << m << ":" << s << endl;
		Sleep(999);
		s++;
		if (s == 60)
		{
			m++;
			s = 0;
		}
		if (m == 60)
		{
			h++;
			m = 0;
		}
		if (h == 24)
			h = 0;
		if (_kbhit())
		{
			cout << "Пауза\n";
			cout << "Для выхода дважды нажмите Esc\n";
			cout << "Для продолжения дважды нажмите любую кнопку\n";
			system("pause >nul");
			char k;
			k = _getch();
			if (k != 27)
				continue;
			else break;
		}
	}
	while (true) {
		MessageBeep(MB_ICONEXCLAMATION);
		if (_kbhit())
			break;
		Sleep(900);
	}
}

