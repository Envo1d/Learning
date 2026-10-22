#include <iostream>

using namespace std;

void Rand_Int(int* mas, int n)
{
	for (int i = 0; i < n; i++)
		mas[i] = rand() % 25;
}
void Print_Int(int* mas, int n)
{
	for (int i = 0; i < n; i++)
		cout << mas[i] << "\t";
	cout << "\n";
}
void Min_Int(int* mas, int n)
{
	int k = mas[0];
	for (int i = 0; i < n; i++)
		if (k > mas[i]) k = mas[i];
	cout << "Min = " << k;
}
void Max_Int(int* mas, int n)
{
	int k = mas[0];
	for (int i = 0; i < n; i++)
		if (k < mas[i]) k = mas[i];
	cout << "Max = " << k;
}
void Sort_Int(int* mas, int n, int ch)
{
	int tmp;
	int i, j;
	for (i = 0; i < n; i++) {
		tmp = mas[i];
		if (ch == 1) {
			for (j = i - 1; j >= 0 && mas[j] > tmp; j--)
				mas[j + 1] = mas[j];
		}
		else if (ch == 2) {
			for (j = i - 1; j >= 0 && mas[j] < tmp; j--)
				mas[j + 1] = mas[j];
		}
		mas[j + 1] = tmp;
	}
}
void Edit_Int(int* mas, int ch)
{
	int k = ch - 1;
	cin >> mas[k];
}

void Rand_Double(double* mas, int n)
{
	for (int i = 0; i < n; i++)
	{
		mas[i] = rand() / 32767.0 * 25;
	}
}
void Print_Double(double* mas, int n)
{
	for (int i = 0; i < n; i++)
	{
		cout << mas[i] << "\t";
	}
	cout << "\n";
}
void Min_Double(double* mas, int n)
{
	double k = mas[0];
	for (int i = 0; i < n; i++)
		if (k > mas[i]) k = mas[i];
	cout << "Min = " << k;
}
void Max_Double(double* mas, int n)
{
	double k = mas[0];
	for (int i = 0; i < n; i++)
		if (k < mas[i]) k = mas[i];
	cout << "Max = " << k;
}
void Sort_Double(double* mas, int n, int ch)
{
	double tmp;
	int i, j;
	for (i = 0; i < n; i++) {
		tmp = mas[i];
		if (ch == 1) {
			for (j = i - 1; j >= 0 && mas[j] > tmp; j--)
				mas[j + 1] = mas[j];
		}
		else if (ch == 2) {
			for (j = i - 1; j >= 0 && mas[j] < tmp; j--)
				mas[j + 1] = mas[j];
		}
		mas[j + 1] = tmp;
	}
}
void Edit_Double(double* mas, int ch)
{
	int k = ch - 1;
	cin >> mas[k];
}

void Rand_Char(char* mas, int n)
{
	for (int i = 0; i < n; i++)
	{
		mas[i] = rand() % 25;
	}
}
void Print_Char(char* mas, int n)
{
	for (int i = 0; i < n; i++)
	{
		cout << mas[i] << "\t";
	}
	cout << "\n";
}
void Min_Char(char* mas, int n)
{
	char k = mas[0];
	for (int i = 0; i < n; i++)
		if (k > mas[i]) k = mas[i];
	cout << "Min = " << k;
}
void Max_Char(char* mas, int n)
{
	char k = mas[0];
	for (int i = 0; i < n; i++)
		if (k < mas[i]) k = mas[i];
	cout << "Max = " << k;
}
void Sort_Char(char* mas, int n, int ch)
{
	char tmp;
	int i, j;
	for (i = 0; i < n; i++) {
		tmp = mas[i];
		if (ch == 1) {
			for (j = i - 1; j >= 0 && mas[j] > tmp; j--)
				mas[j + 1] = mas[j];
		}
		else if (ch == 2) {
			for (j = i - 1; j >= 0 && mas[j] < tmp; j--)
				mas[j + 1] = mas[j];
		}
		mas[j + 1] = tmp;
	}
}
void Edit_Char(char* mas, int ch)
{
	int k = ch - 1;
	cin >> mas[k];
}
