#include "Info.h"

Info::Info()
{
	name = NULL;
	shirina = 0;
	dlina = 0;
	glybina = 0;
	type = '0';
}

Info::Info(const Info& copy)
{
	name = (char*)malloc(strlen(copy.name) + 1);
	shirina = copy.shirina;
	dlina = copy.dlina;
	glybina = copy.glybina;
	type = copy.type;
}

Info& Info::operator=(const Info& copy)
{
	
	if (this != &copy)
	{
		if (name != NULL) free(name);
		name = (char*)malloc(strlen(copy.name) + 1);
		strcpy_s(name, strlen(copy.name) + 1, copy.name);
		shirina = copy.shirina;
		dlina = copy.dlina;
		glybina = copy.glybina;
		type = copy.type;
	}
	return *this;
}

void Info::Vvod()
{
	if (name != NULL) free(name);
	cout << "Введите название: ";
	name = (char*)realloc(name, 61 * sizeof(name));
	gets_s(name, 61);
	short k = strlen(name);
	name = (char*)realloc(name, (k + 2) * sizeof(char));
	cout << "Введите ширину: ";
	cin >> shirina;
	cout << "Введите длину: ";
	cin >> dlina;
	cout << "Введите глубину: ";
	cin >> glybina;
	cout << "Введите тип (м - море, о - озеро, р - река, б - басейн, п - пруд): ";
	cin >> type;
	cin.ignore();
}

void Info::Show()
{
	cout << "Название - " << name << "\nШирина - " << shirina <<
		"\nДлина - " << dlina << "\nГлубина - " << glybina <<
		"\nТип - " << type;
}

Info::~Info()
{
	free(name);
}

