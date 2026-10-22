#include <iostream>
using namespace std;

// Задание 1: Вывести на экран один куплет любимого стихотворения или песни, с указанием автора или исполнителя. 
// Используйте escape-последовательности для форматирования.

void song() {
  cout << "You made me a, you made me a believer, believer\n";
	cout << "\*Pain, pain\*\n";
	cout << "You break me down, you build me up, believer, believer\n";
	cout << "\*Pain\*\n";
	cout << "Oh let the bullets fly, oh let them rain\n";
	cout << "My life, my love, my drive, it came from\n";
	cout << "\*Pain\*\n";
	cout << "You made me a, you made me a believer, believer\n\n\t";
	cout << "Imagine Dragons";
}

// Задание 2: Вывести на экран стих «Every hunter wants…» таким образом, чтобы каждый «цвет» начинался с новой строки и соответствующим количеством табуляций.

void every() {
	cout << "\tEvery\n\t";
	cout << "Hunters\n\t";
	cout << "Wants\n\t";
	cout << "To know\n\t";
	cout << "Where\n\t";
	cout << "A pheasant\n\t";
	cout << "Sit";
}

// Задание 3: Напишите объявление о продаже чего-нибудь и выведите его на экран, в том виде как оно должно было бы быть напечатано.
// Например:
// Продам щенков.
// Порода: ротвейлер.
// ……
// Тел.: 222-22-22
// 222 | 222 |
// 22 | 22 |
// 22 | 22 |
// и т.д.

void advertisement() {
	cout << "\t\*Prodam schenkov\*\n\t";
	cout << " Poroda - Layka\n\t";
	cout << " Cena - 100$\n\n";
	cout << "Nomer telephona: 099-659-99-89\n";
	cout << "Nick\n";
	cout << "\t099 | 099 | 099\n\t";
	cout << "659 | 659 | 659\n\t";
	cout << "99  | 99  | 99\n\t";
	cout << "89  | 89  | 89";
}

// Задание 4: Заданы три сопротивлении R1, R2, R3 . Вычислить значение сопротивления R0 по формуле: 1/R0 = 1/R1+1/R2+1/R3.

void resistance() {
	float R0, R1, R2, R3, R;
	cout << "Vvedite soprotivlenie trex elementov\n";
	cin >> R1 >> R2 >> R3;
	R0 = (1 / R1) + (1 / R2) + (1 / R3);
	R0 = 1 / R0;
	cout << "Obshee soprotivlenie cepi = " << R0 ;
}

// Задание 5: По заданной длине окружности найти площадь круга по формуле S = pi*R2, радиус вычислить из формулы длины окружности: L=2*pi *R
// Примечание pi = 3.14

void circleArea() {
	const float pi = 3.14;
	float L, R, S;
	cout << "Vvedite dliny okryghnosti\n";
	cin >> L;
	R = L / (2 * pi);
	cout << "Radius = " << R <<"\n";
	S = pi * (R * R);
	cout << "Ploshad kryga = " << S;
}

// Задание 6: Вычислить пройденное расстояние при прямолинейном равноускоренном движении по формуле S = v*t + (a*t2) / 2, где v – скорость, t – время, а – ускорение.

void distance() {
	float S, v, t, a;
	cout << "Vvedite nachalnuy skorost, vremya i yskorenie\n";
	cin >> v >> t >> a;
	S = v * t + ((a * (t * t)) / 2);
	cout << "Rastoyanie = " << S;
}

// Задание 7:
// Пользователь вводит с клавиатуры расстояние до аэропорта и время, за которое нужно доехать.
// Вычислить скорость, с которой ему нужно ехать.

void airportSpeed() {
	float v, t, s;
	cout << "Vvedite rastoyanie (km) i vremya (v chasax)\n";
	cin >> s >> t;
	v = s/t;
	cout << "Vam nyzhno exat so skorosty " << v << "km/chas";
}

// Задание 8:
// Пользователь вводит с клавиатуры время начала и время завершения телефонного разговора
// (часы, минуты и секунды). Посчитать стоимость разговора, если стоимость минуты – 30 копеек.

void phoneCallCost() {
	int shour, smin, ssec, ehour, emin, esec;
	float stime, etime, time;
	cout << "Vvedite vremya nachala razgovora (h,min,sec)\n";
	cin >> shour >> smin >> ssec;
	cout << "Vvedite vremya konca razgovora\n";
	cin >> ehour >> emin >> esec;
	stime = shour * 60 + smin + ssec / 60 + 0.5;
	etime = ehour * 60 + emin + esec / 60 + 0.5;
	time = etime - stime;
	cout << "Cena razgovora = " << time * 0.3;
}

// Задание 9:
// Пользователь вводит с клавиатуры расстояние, расход бензина на 100 км и стоимость трех
// видов бензина. Вывести на экран сравнительную таблицу со стоимостью поездки на разных
// видах бензина.

void fuelCost() {
	float s, rashod, b1, b2, b3, cost1, cost2, cost3 , val;
	cout << "Vvedite rastoyanie i rashod benzina\n";
	cin >> s >> rashod;
	cout << "Vvedite ceny na 1, 2, 3 vid benzina\n";
	cin >> b1 >> b2 >> b3;
	val = (s / 100) * rashod;
	cost1 = val * b1;
	cost2 = val * b2;
	cost3 = val * b3;
	cout << "Stoimost poezdki na etih vidah benzina:\n";
	cout << "1 vid\t 2 vid\t 3 vid\n";
	cout << cost1 << "\t" << cost2 << "\t" << cost3;
}

void main() 
{
	song();
	every();
	advertisement();
	resistance();
	circleArea();
	distance();
	airportSpeed();
	phoneCallCost();
	fuelCost();
}
