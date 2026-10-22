// Источник: HW OOP 4.txt
/*Реализовать базу данных дорожной полиции по штрафным квитанциям с помощью бинарного дерева.
Ключом будет служить номер автомобиля, значением узла - список правонарушений.
Если квитанция добавляеться в первый раз, то в дереве появляется новый узел, а в списке данные по правонарушению;
если нет, то данные заносятся в существующий список.

Необходимо также реализовать следующие операции :

Полная распечатка базы данных(по номерам машин и списку правонарушений, числящихся за ними)
Распечатка данных по заданному номеру
Распечатка данных по диапазону номеров*/

#pragma warning(disable: 4996)
#include <iostream>
#include <conio.h>

using namespace std;

class data_base
{
private:
	struct node
	{
		struct list
		{
			char* offense;
			list* next;
			list(char* mas) : next(nullptr)
			{
				offense = new char[strlen(mas) + 1];
				strcpy(offense, mas);
			}
		};
		list* head;
		list* tail;
		short num;
		node* left;
		node* right;
		node() : left(nullptr), right(nullptr), num(NULL), head(nullptr), tail(nullptr) {}
		node(short key) : left(nullptr), right(nullptr), num(key), head(nullptr), tail(nullptr) {}
		node(const node& copy)
		{
			head = nullptr;
			tail = nullptr;
			list* tmp = copy.head;
			while (tmp)
			{
				this->add_l(tmp->offense);
				tmp = tmp->next;
			}
		}
		node& operator=(const node& copy)
		{
			if (this != &copy)
			{
				head = nullptr;
				tail = nullptr;
				list* tmp = copy.head;
				while (tmp)
				{
					this->add_l(tmp->offense);
					tmp = tmp->next;
				}
			}
			return *this;
		}
		void add_l(char* mas)
		{
			list* tmp = new list(mas);
			if (empty())
			{
				tail = head = tmp;
			}
			else
			{
				tail->next = tmp;
				tail = tmp;
			}
		}
		bool empty() { return head == nullptr; }
		friend ostream& operator<<(ostream& stream, const node& ls)
		{
			list* out = ls.head;
			while (out)
			{
				stream << out->offense << '\n';
				out = out->next;
			}
			return stream;
		}
		void show()
		{
			cout << *this;
		}
		void del()
		{
			while (head)
			{
				list* tmp = head->next;
				delete head;
				head = tmp;
			}
		}
		~node()
		{
			del();
		}
	};
	node* root;
public:
	data_base() : root(nullptr) {}
	node* data_copy(node* copy)
	{
		if (copy == nullptr)
			return nullptr;
		node* copyNode = new node;
		copyNode->num = copy->num;
		copyNode->head = copy->head;
		copyNode->left = data_copy(copy->left);
		copyNode->right = data_copy(copy->right);
		return copyNode;
	}
	data_base(const data_base& copy)
	{
		root = nullptr;
		root = data_copy(copy.root);
	}
	data_base& operator=(const data_base& copy)
	{
		if (this != &copy)
		{
			root = nullptr;
			root = data_copy(copy.root);
		}
		return *this;
	}
	char* Gets(char*& str)
	{
		cin.ignore();
		cout << "Enter offense:\n";
		str = nullptr;
		int n = 0;
		char ch;
		while ((ch = getchar()) != '\n')
		{
			str = (char*)realloc(str, n + 1);
			str[n] = ch;
			n++;
		}
		str = (char*)realloc(str, n + 2);
		str[n] = '\n';
		str[n + 1] = 0;
		return str;
	}
	bool empty()
	{
		return root == nullptr;
	}
	void add(short num)
	{
		if (empty())
		{
			root = new node(num);
			char* tmp;
			Gets(tmp);
			root->add_l(tmp);
			free(tmp);
		}
		else
		{
			if (num == root->num)
			{
				char* tmp;
				Gets(tmp);
				root->add_l(tmp);
				free(tmp);
			}
			else
				add(root, new node(num));
		}
		cout << "Done\n";
	}
	void add(node* n, node* new_node)
	{
		if (n->num == new_node->num)
		{
			char* tmp;
			Gets(tmp);
			n->add_l(tmp);
			free(tmp);
		}
		else {
			if (n->num < new_node->num)
			{
				if (n->right == nullptr)
				{
					n->right = new_node;
					char* tmp;
					Gets(tmp);
					n->right->add_l(tmp);
					free(tmp);
				}
				else
				{
					add(n->right, new_node);
				}
			}
			else
			{
				if (n->left == nullptr)
				{
					n->left = new_node;
					char* tmp;
					Gets(tmp);
					n->left->add_l(tmp);
					free(tmp);
				}
				else
				{
					add(n->left, new_node);
				}
			}
		}
	}
	void print(ostream& stream)
	{
		print(stream, root);
	}
	void print(ostream& stream, node* n)
	{
		if (n != nullptr)
		{
			if (n->left != nullptr)
			{
				print(stream, n->left);
			}
			stream <<"Number:" << n->num << "\nList of offenses:\n\n"; n->show();
			if (n->right != nullptr)
			{
				print(stream, n->right);
			}
		}
	}
	friend ostream& operator<<(ostream& stream, data_base& tree)
	{
		tree.print(stream);
		return stream;
	}
	void print_all()
	{
		cout << *this;
	}
	node* find_and_print(short num)
	{
		return find_and_print(root, num);
	}
	node* find_and_print(node* n, short num)
	{
		if (n == nullptr)
		{
			return nullptr;
		}
		if (n->num > num)
		{
			return find_and_print(n->left, num);
		}
		else if (n->num < num)
		{
			return find_and_print(n->right, num);
		}
		cout << "Number:" << n->num << "\nList of offenses:\n\n"; n->show();
		return 0;
	}
	void print_range(short start, short end)
	{
		print_range(start, end, root);
	}
	void print_range(short start, short end, node* n)
	{
		if (n != nullptr)
		{
			if (n->left != nullptr)
			{
				print_range(start, end, n->left);
			}
			if (n->num <= end && n->num >= start)
			{
				cout << "Number:" << n->num << "\nList of offenses:\n\n"; n->show();
			}
			if (n->right != nullptr)
			{
				print_range(start, end, n->right);
			}
		}
	}
	void clear(node* root)
	{
		if (root)
		{
			clear(root->left);
			clear(root->right);
			delete root;
		}
	}
	~data_base()
	{
		clear(root);
	}
};

void main()
{
	data_base b, k;
	char c = 0;
	short x, x1;
	do
	{
		system("cls");
		cout << "1 - Add new record\n"
			<< "2 - Print database\n"
			<< "3 - Printout of data for a given number\n"
			<< "4 - Number range printout\n"
			<< "Esc - Exit\n";
		c = _getch();
		switch (c)
		{
		case '1':system("cls");
			cout << "Enter car number (4 digits)\n";
			cin >> x;
			b.add(x);
			system("pause");
			break;
		case'2':system("cls");
			b.print_all();
			system("pause");
			break;
		case'3':system("cls");
			cout << "Enter car number\n";
			cin >> x;
			system("cls");
			b.find_and_print(x);
			system("pause");
			break;
		case'4':system("cls");
			cout << "Enter range of numbers(min, max)\n";
			cin >> x >> x1;
			system("cls");
			b.print_range(x, x1);
			system("pause");
			break;
		}
	} while (c != 27);
}