// Источник: HW OOP 3.txt
//Задание 1.
//----------
//В существующий класс односвязного списка добавить :

//реализовать конструктор копирования,
//перегрузить оператор = (метод должен возвращать копию списка),
//перегрузить оператор + (оператор должен возвращать адрес головы нового списка, содержащего элементы обоих списков для которых вызывался оператор),
//перегрузить оператор * (оператор должен возвращать адрес головы нового списка, содержащего только общие элементы обоих списков для которых вызывался оператор),
//перегрузить оператор >> (для ввода списка)
//#include <iostream>
//using namespace std;
//
//class list
//{
//	struct node
//	{
//		int value;
//		node* next;
//		node(int value) : value(value), next(nullptr){}
//	};
//	node* head;
//	node* tail;
//	int size;
//public:
//	list(): head(nullptr), tail(nullptr), size(0) {}
//	list(const list& copy)
//	{
//		head = nullptr;
//		tail = nullptr;
//		node* tmp = copy.head;
//		while (tmp)
//		{
//			this->add(tmp->value);
//			tmp = tmp->next;
//		}
//		size = copy.size;
//	}
//	list& operator=(const list& s)
//	{
//		if (this != &s)
//		{
//			head = nullptr;
//			tail = nullptr;
//			node* tmp = s.head;
//			while (tmp)
//			{
//				this->add(tmp->value);
//				tmp = tmp->next;
//			}
//		}
//		return *this;
//	}
//	list& operator+(const list& s)
//	{
//		list* tmp = new list;
//		node* t = head;
//		while (t)
//		{
//			tmp->add(t->value);
//			t = t->next;
//		}
//		t = s.head;
//		while (t)
//		{
//			tmp->add(t->value);
//			t = t->next;
//		}
//		return *tmp;
//	}
//	list& operator*(const list& s)
//	{
//		list* tmp = new list;
//		node* t = head, * t2 = s.head;
//		if (size > s.size) {
//			for (short i = 0; i < size; i++)
//			{
//				for (short j = 0; j < s.size; j++)
//				{
//					if (t->value == t2->value)
//					{
//						tmp->add(t->value);
//						t2 = t2->next;
//					}
//					else
//					{
//						t2 = t2->next;
//					}
//				}
//				t = t->next;
//				t2 = s.head;
//			}
//		}
//		else {
//			for (short i = 0; i < s.size; i++)
//			{
//				for (short j = 0; j < size; j++)
//				{
//					if (t2->value == t->value)
//					{
//						tmp->add(t->value);
//						t = t->next;
//					}
//					else
//					{
//						t = t->next;
//					}
//				}
//				t2 = t2->next;
//				t = head;
//			}
//		}
//
//		return *tmp;
//	}
//	void add(int value)
//	{
//		node* tmp = new node(value);
//		if (empty())
//		{
//			tail = head = tmp;
//			size++;
//		}
//		else
//		{
//			tail->next = tmp;
//			tail = tmp;
//			size++;
//		}
//	}
//	bool empty() { return head == nullptr; }
//	friend ostream& operator<<(ostream& stream, const list& ls)
//	{
//		node* out = ls.head;
//		while (out)
//		{
//			stream << out->value << ' ';
//		    out = out->next;
//		}
//		return stream;
//	}
//	friend istream& operator>>(istream& stream, list& ls)
//	{
//		int c;
//		stream >> c;
//		ls.add(c);
//		return stream;
//	}
//	void clear()
//	{
//		while (head)
//		{
//			node* tmp = head->next;
//			delete head;
//			head = tmp;
//		}
//	}
//	~list()
//	{
//		clear();
//	}
//};
//void main()
//{
//	list a;
//	a.add(5);
//	a.add(6);
//	a.add(7);
//	cout << a << endl;
//	list b;
//	b = a;
//	cout << b << endl;
//	list c;
//	c = a + b;
//	cout << c << endl;
//	list e;
//	for (int i = 0; i < 4; i++)
//	{
//		cin >> e;
//	}
//	cout << e << endl;
//	list d;
//	d = a * e;
//	cout << d;
//}
//--

