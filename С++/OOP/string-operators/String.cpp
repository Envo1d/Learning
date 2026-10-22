#include "String.h"

String::String()
{
	stroka = NULL;
	size = 80;
	stroka = (char*)malloc((this->size + 1) * sizeof(char));
}
String::String(int size)
{
	stroka = NULL;
	this->size = size;
	stroka = (char*)malloc((this->size + 1) * sizeof(char));
}
String::String(const char* str)
{
	stroka = NULL;
	size = strlen(str);
	stroka = (char*)malloc((size + 1) * sizeof(char));
	strcpy_s(stroka, (size + 1), str);
}

String::String(const String&copy)
{
	strcpy_s(stroka, size, copy.stroka);
	size = copy.size;
}

String::String(String&&copy)
{
	size = copy.size;
	stroka = copy.stroka;
	copy.stroka = nullptr;
}

String& String::operator=(String&&copy)
{
	if (this != &copy)
	{
		if (stroka != nullptr) free(stroka);
		size = copy.size;
		stroka = copy.stroka;
		copy.stroka = nullptr;
	}
	return *this;
}

String String::operator=(const String& copy)
{
	if (this != &copy)
	{
		if (stroka != NULL)free(stroka);
		strcpy_s(stroka, size, copy.stroka);
		size = copy.size;
	}
	return *this;
}

void String::Enter()
{
	cout << "Введите строку:\n";
	gets_s(stroka, size + 1);
}

void String::Show()
{
	cout << stroka;
}

String & String::operator++()
{
	stroka = (char*)realloc(stroka, (size + 2) * sizeof(char));
	stroka[size] = ' ';
	stroka[size + 1] = '\0';
	size++;
	return *this;
}

String String::operator++(int num)
{
	String tmp;
	stroka = (char*)realloc(stroka, (size + 2) * sizeof(char));
	stroka[size] = ' ';
	stroka[size + 1] = '\0';
	size++;
	return tmp;
}

String & String::operator--()
{
	stroka = (char*)realloc(stroka, (size) * sizeof(char));
	stroka[size - 1] = '\0';
	size--;
	return *this;
}

String String::operator--(int num)
{
	String tmp;
	stroka = (char*)realloc(stroka, (size) * sizeof(char));
	stroka[size - 1] = '\0';
	size--;
	return tmp;
}

int String::operator[](int ind)
{
	if (ind < 0)
		return stroka[0];
	if (ind > size - 1)
		return stroka[size - 1];
	return stroka[ind];
}

int String::operator()(char c)
{
	for (short i = 0; i <= size; i++)
	{
		if (stroka[i] == c)
			return i;
	}
	return -1;
}

int String::operator-()
{
	return size;
}

String::~String()
{
	free(stroka);
}

