// Источник: HW OOP 8.txt
/*Задание 1

Реализуйте программу, которая предоставляет функциональность по работе с файлами.
Приложение получает у пользователя путь к файлу, после чего программа отображает интерфейс по анализу содержимого файла.
Возможности интерфейса :
1.	Поиск заданной строки(по итогам показывать статистику поиска строки по всему файлу)
2.	Замена строки на новую строку(по итогам показать статистику по замене строки)
3.	Отображение файла на экран
4.	Переворот содержимого файла
Используйте для работы с файлами потоки.*/

#include <conio.h>
#include <iostream>
#include <string>
#include <fstream>
#define clr system("cls")
#define ps system("pause");
#pragma warning(disable:4996)

using namespace std;

class FileAnalysis
{
	string path;
	char* show = NULL;
	string data;
	char* nw = NULL;
	char* old = NULL;
	bool is_exist = false;
public:
	FileAnalysis() {}
	void set_path()
	{
		cout << "\nEnter path to file. Example: C:/Users/admin/Desktop/new.txt\n";
		getline(cin, path);
		ifstream fin(path);
		if (!fin.is_open())
		{
			cout << "File at this path not exist.\n";
		}
		else
		{
			cout << "File found\n";
			is_exist = true;
		}
		fin.close();
	}
	void set_path(string path)
	{
		this->path = path;
		ifstream fin(this->path);
		if (!fin.is_open())
		{
			cout << "File open/creating error\n";
		}
		else
		{
			cout << "File created\n";
			is_exist = true;
		}
		fin.close();
	}
	void show_file()
	{
		if (show != NULL) delete[] show;
		if (is_exist == true)
		{
			ifstream fin(path);
			fin.seekg(0, std::ios::end);
			std::streamsize length = fin.tellg();
			fin.seekg(0, std::ios::beg);
			show = new char[length + 1];
			fin.read(show, length);
			show[length] = 0;
			cout << show << endl;
			fin.close();
		}
		else cout << "Error. File not founded.\n";
	}
	void replace_string() // Изменить на замену слов
	{
		if (!data.empty()) data.clear();
		if (old != NULL) delete[] old;
		if (nw != NULL) delete[] nw;
		if (show != NULL) delete[] show;
		cout << "Enter string for replace\n";
		string tmp1, tmp2;
		getline(cin, tmp1);
		old = new char[strlen(tmp1.c_str()) + 1];
		strcpy(old, tmp1.c_str());
		cout << "Enter new string\n";
		getline(cin, tmp2);
		nw = new char[strlen(tmp2.c_str()) + 1];
		strcpy(nw, tmp2.c_str());
		ifstream fin(path);
		fin.seekg(0, std::ios::end);
		long length = fin.tellg();
		fin.seekg(0, std::ios::beg);
		show = new char[length + 1];
		fin.read(show, length);
		show[length] = 0;
		fin.close();
		long i = 0;
		bool e = false;
		check:
		for (long j = 0; i < (strlen(show) + 1); i++)
		{
			if (old[j] == show[i])
			{
				j++;
				if (j == strlen(old))
				{
					e = true;
					j = 0;
					goto replace;
				}
				if (old[j] != show[i + 1])
				{
					j = 0;
					if (data.empty())
						data = show[i];
					else
						data += show[i];
				}
			}
			else
			{
				if (data.empty())
					data = show[i];
				else
					data += show[i];
			}
		}
		goto end;
	replace:
		data += nw;
		if (strlen(old) > strlen(nw))
		{
			i += strlen(old) - strlen(nw);
		}
		else if (strlen(old) == strlen(nw))
		{
			i--;
		}
		else if (strlen(old) < strlen(nw))
		{
			i += strlen(nw) - strlen(old);
		}
		goto check;
    end:
		if (e == true)
		{
			cout << "Before:\n" << show << "\n\nAfter:\n" << data << endl;
			ofstream fout(path);
			fout << data;
			fout.close();
		}
		else cout << "\nNo matches\n";
	}
	void find_string()
	{
		cout << "Enter search string\n";
		string tmp1;
		getline(cin, tmp1);
		if (old != NULL) delete[] old;
		if (show == NULL)
		{
			ifstream fin(path);
			fin.seekg(0, std::ios::end);
			long length = fin.tellg();
			fin.seekg(0, std::ios::beg);
			show = new char[length + 1];
			fin.read(show, length);
			show[length] = 0;
			fin.close();
		}
		old = new char[(strlen(tmp1.c_str()) + 1)];
		strcpy(old, tmp1.c_str());
		long i = 0;
		bool e = false;
		int count = 0;
		for (long j = 0; i < (strlen(show) + 1); i++)
		{
			if (old[j] == show[i])
			{
				j++;
				if (j == strlen(old))
				{
					count++;
					e = true;
					j = 0;
				}
			}
		}
		if (e == true) cout << "\nFound:\n" << count << " matches" << endl;
		else cout << "\nNo matches\n";
	}
	void flip()
	{
		ifstream fin(path);
		string tmp;
		getline(fin, tmp, '\0');
		fin.close();
		ofstream fout(path);
		reverse(tmp.begin(), tmp.end());
		fout << tmp;
		fout.close();
	}
	~FileAnalysis()
	{
		if (show != NULL)
			delete[] show;
		if (nw != NULL)
			delete[] nw;
		if (old != NULL)
			delete[]old;
	}
};

void main()
{
	FileAnalysis k;
	char ch = 0;
	cout << "File created? y/n\n";
	ent:
	ch = _getch();
	if (ch == 'y')
	{
		k.set_path();
	}
	else if (ch == 'n')
	{
		string path;
		cout << "Enter path where to create file (Example C:/Users/admin/Desktop/)\n";
		getline(cin, path);
		string filename;
		cout << "Enter file name with type(Example new.txt)\n";
		getline(cin, filename);
		path = path + filename;
		ofstream fout(path, ios::out);
		string data;
		cout << "Enter to file\n";
		getline(cin, data);
		fout << data;
		fout.close();
		k.set_path(path);
	}
	else goto ent;
	ch = 0;
	do
	{
		clr;
		cout << "1 - Search srting\n2 - Replace string with a new\n3 - Show file\n4 - Flip content\n5 - Set path to another created file\nEsc - Exit\n";
		ch = _getch();
		switch (ch)
		{
		case'1':clr;
			k.find_string();
			ps;
			break;
		case'2':clr;
			k.replace_string();
			ps;
			break;
		case'3':clr;
			k.show_file();
			ps;
			break;
		case'4':clr;
			k.flip();
			break;
		case'5':clr;
			k.set_path();
			break;
		}
	} while (ch != 27);
}
