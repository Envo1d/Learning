#include <iostream>
#include <fstream>
#include <vector>
#include <string>
#include <ctime>
#include <Windows.h>

using namespace std;

class exam
{
	string fio;
	string group;
	short que_change;
	vector<string> file;
	vector<string> block1;
	vector<string> block2;
	vector<string> block3;
	vector<string> questions;
	vector<int> sep;
public:
	exam() : que_change(0)
	{
		ifstream in("questions.txt", ios::in);
		if (!in.is_open())
		{
			cout << "Невозможно открыть файл\n";
		}
		else
		{
			while (!in.eof())
			{
				string str;
				getline(in, str);
				file.push_back(str);
			}
		}
		in.close();
		for (int i = 0; i < file.size(); i++)
		{
			string tmp = file.at(i);
			if (tmp == "")
				sep.push_back(i);
		}
		int i = 0;
		for (int j = 0; j < sep.at(i); j++)
		{
			string str = file.at(j);
			block1.push_back(str);
		}
		i++;
		for (int j = sep.at(i - 1); j < sep.at(i); j++)
		{
			string str = file.at(j);
			block2.push_back(str);
		}
		i++;
		for (int j = sep.at(i - 1); j < file.size(); j++)
		{
			string str = file.at(j);
			block3.push_back(str);
		}
		cout << "FIO: "; getline(cin, fio);
		cout << "Group: "; cin >> group;
		ofstream f("result.txt");
		f << "FIO: " << fio << endl << "Group: " << group << endl;
		f.close();
	}
	void get_questions(short col = 0)
	{
		for (; col < 3; col++)
		{
			rand_que(col);
		}
	}
	void show_que()
	{
		cout << "Your questions:\n";
		for (size_t i = 0; i < questions.size(); i++)
		{
			cout << questions.at(i) << endl;
		}
	}
	void change_que(short ind)
	{
		questions.at(ind) = rand_que(ind, "new");
		que_change++;
	}
	void answer()
	{
		cin.ignore();
		ofstream f("result.txt", ios::app);
		if (!f.is_open())
		{
			cout << "Error. File is not open\n";
		}
		else {
			for (size_t i = 0; i < questions.size(); i++)
			{
				system("cls");
				string str;
				cout << questions.at(i) << endl;
				cout << "To replace the question enter \"change\"\n";
				getline(cin, str);
				if (str == "change")
				{
					change_que(i);
					i--;
					if (que_change == 1)
						cout << "Question changed without fines\n";
					else
						cout << "Question changed. -1 mark\n";
					Sleep(1000);
				}
				else
				{
					f << questions.at(i) << endl << str << endl;
				}
			}
			f << "\n...\nQuestions asked: "<< 3 + que_change<<"  Number of replacements: " << que_change;
			if (que_change > 1)
			{
				f << "  Fine -" << que_change - 1 << " mark";
			}
		}
		f.close();
	}
	private: string rand_que(short col, string k = "1")
	{
		int n;
		string str;
		if (col == 0)
		{
			n = rand() % block1.size();
			str = "Block 1: " + block1.at(n);
			questions.push_back(str);
		}
		else if (col == 1)
		{
			n = rand() % block2.size();
			str = "Block 2: " + block2.at(n);
			questions.push_back(str);
		}
		else if (col == 2)
		{
			n = rand() % block2.size();
			str = "Block 3: " + block3.at(n);
			questions.push_back(str);
		}
		if (k != "1")
		{
			k = str;
			questions.erase(questions.begin() + 3);
			return k;
		}
		return k;
	}
};

void main()
{
	srand(time(NULL));
	exam n;
	system("cls");
	n.get_questions();
	n.show_que();
	cout << endl;
	system("pause");
	n.answer();
}
