#include "String.h"
String::String(const char* str)
{
	size = strlen(str);
	stroka = (char*)realloc(stroka, (size + 1) * sizeof(char));
	strcpy_s(stroka,(size + 1), str);
}

void String::Enter()
{
	cout << "Введите строку:\n";
	gets_s(stroka, size);
}

void String::Show()
{
	cout << stroka;
}

String::~String()
{
	free(stroka);
}


