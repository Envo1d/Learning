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

void main() 
{
	song();
	evety();
}