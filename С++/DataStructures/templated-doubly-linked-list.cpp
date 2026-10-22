// Источник: HW OOP 3.txt
//Задание 2.
//----------
//В существующий класс двусвязного списка добавить :
//
//добавление элементов в середину списка(insert),
//удаление элемента по индексу(remove),
//перегрузить оператор = (метод должен возвращать копию списка),
//перегрузить оператор >> (для ввода списка),
//список должен быть шаблонным
//#include <iostream>
//using namespace std;
//
//template <class T>
//class list
//{
//	struct node
//	{
//		T value;
//		node* next;
//		node* prev;
//		node(T value) : value(value), next(nullptr), prev(nullptr) {}
//	};
//	node* head;
//	node* tail;
//	int size;
//public:
//	list() : head(nullptr), tail(nullptr), size(0) {}
//	list(const list& copy)
//	{
//		head = nullptr;
//		tail = nullptr;
//		node* tmp = copy.head;
//		while (tmp)
//		{
//			this->add_back(tmp->value);
//			tmp->prev = tmp;
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
//				this->add_back(tmp->value);
//				tmp->prev = tmp;
//				tmp = tmp->next;
//			}
//		}
//		return *this;
//	}
//	void add_front(T value)
//	{
//		node* tmp = new node(value);
//		if (empty())
//		{
//			tail = head = tmp;
//			size++;
//		}
//		else
//		{
//			head->next = tmp;
//			tmp->prev = head;
//			head = tmp;
//			size++;
//		}
//	}
//	void add_back(T value)
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
//			tmp->prev = tail;
//			tail = tmp;
//			size++;
//		}
//	}
//	bool empty() { return head == nullptr; }
//
//	void insert(T value, int idx)
//	{
//		if (empty() || idx == 0)
//		{
//			add_front(value);
//		}
//		else
//		{
//			node* cur = head;
//			int cur_idx = 0;
//			while (idx - 1 > cur_idx && cur != nullptr)
//			{
//				cur->prev = cur;
//				cur = cur->next;
//				cur_idx++;
//			}
//			if (cur == nullptr)
//			{
//				add_back(value);
//			}
//			else
//			{
//				node* new_node = new node(value);
//				new_node->next = cur->next;
//				new_node->prev = cur;
//				cur->next = new_node;
//			}
//		}
//	}
//
//	void remove(int idx)
//	{
//		if (idx == 0) 
//		{
//			node* tmp = head;
//			head = head->next;
//			delete tmp;
//		}
//		else
//		{
//			node* cur = head;
//			int cur_idx = 0;
//			while (idx - 1 > cur_idx && cur != nullptr)
//			{
//				cur->prev = cur;
//				cur = cur->next;
//				cur_idx++;
//			}
//			if (cur != nullptr)
//			{
//				node* tmp = cur->next;
//				if (tmp != nullptr)
//				{
//					cur->next = tmp->next;
//				}
//				else {
//					cur->next = nullptr; 
//				}
//				delete tmp;
//			}
//		}
//	}
//
//	friend ostream& operator<<(ostream& stream, const list& ls)
//	{
//		node* out = ls.head;
//		while (out)
//		{
//			stream << out->value << ' ';
//			out = out->next;
//		}
//		return stream;
//	}
//	friend istream& operator>>(istream& stream, list& ls)
//	{
//		int c;
//		stream >> c;
//		ls.add_back(c);
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
//	list<int> a;
//	a.add_back(5);
//	a.add_back(6);
//	a.add_back(7);
//	cout << a << endl;
//	list<int> b;
//	b = a;
//	cout << b << endl;
//	b.insert(4, 2);
//	cout << b << endl;
//	b.remove(2);
//	cout << b << endl;
//	list <int> c;
//	int k = 0;
//	while (k < 5)
//	{
//		cin >> c;
//		k++;
//	}
//	cout << c;
//}
//--

