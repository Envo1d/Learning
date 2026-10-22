// Источник: HW OOP 3.txt
//Задание 3.
//----------
//Создать шаблонный класс - контейнер Array, который представляет список, позволяющий хранить объекты заданного типа.
//Класс должен быть реализован с помощью двусвязного списка.
//
//Класс должен реализовывать следующие функции :
//
//a.GetSize — получение размера массива(количество элементов, под которые выделена память); +
//b.SetSize(int size, int grow = 1) — установка размера массива
//(если параметр size больше предыдущего размера массива, то выделяется дополнительный блок памяти, 
//если нет, то «лишние» элементы теряются и память освобождается); параметр grow определяет 
//для какого количества элементов необходимо выделить память, если количество элементов превосходит 
//текущий размер массива.Например, SetSize(5, 5); означает, что при добавлении 6 - го элемента размер 
//массива становится равным 10, при добавлении 11 - го — 15 и т.д.; +
//c.GetUpperBound — получение последнего допустимого индекса в массиве.Например, если при размере массива 
//10, вы добавляете в него 4 элемента, то функция вернет 3. +
//d.IsEmpty — массив пуст ? +
//f.RemoveAll — удалить все; +
//g.GetAt — получение определенного элемента(по индексу); +
//h.SetAt — установка нового значения для определенного элемента
//(индекс элемента должен быть меньше текущего размера массива); +
//i. operator [] — для реализации двух предыдущих функций; +
//j.Add — добавление элемента в список; +
//k.Append — «сложение» двух массивов; +
//l. operator =; +
//m.GetData — получения адреса массива с данными; +
//n.InsertAt — вставка элемента(-ов) в заданную позицию; +
//o.RemoveAt — удаление элемента(-ов) с заданной позиции. +
#include <iostream>
using namespace std;

template <class T>
class Array
{
public:
	struct node
	{
		T value;
		node* next;
		node* prev;
		short avail;
		node(T value) : value(value), next(nullptr), prev(nullptr), avail(0) {}
	};
private:
	node* head;
	node* tail;
	int size, grow, num;
public:
	Array() : head(nullptr), tail(nullptr), size(0), grow(0), num(0) {}
	Array(const Array& copy)
	{
		head = nullptr;
		tail = nullptr;
		node* tmp = copy.head;
		while (tmp)
		{
			this->add_back(tmp->value);
			tmp->prev = tmp;
			tmp = tmp->next;
		}
		size = copy.size;
		grow = copy.grow;
		num = copy.num;
	}
	Array& operator=(const Array& s)
	{
		if (this != &s)
		{
			head = nullptr;
			tail = nullptr;
			node* tmp = s.head;
			while (tmp)
			{
				this->add_back(tmp->value);
				tmp->prev = tmp;
				tmp = tmp->next;
			}
			size = s.size;
			grow = s.grow;
			num = s.num;
		}
		return *this;
	}
	void add_front(T value)
	{
		node* tmp = new node(value);
		if (empty())
		{
			tail = head = tmp;
			size++;
		}
		else
		{
			head->next = tmp;
			tmp->prev = head;
			head = tmp;
			size++;
		}
	}
	void add_back(T value)
	{
		node* tmp = new node(value);
		if (empty())
		{
			tail = head = tmp;
			size++;
		}
		else
		{
			tail->next = tmp;
			tmp->prev = tail;
			tail = tmp;
			size++;
		}
	}
	bool empty() { return head == nullptr; }
	short IsEmpty()
	{
		return head->avail;
	}
	node* GetData()
	{
		return head;
	}
	T& operator[](int idx)
	{
		node* cur = head;
		int cur_idx = 0;
		while (idx > cur_idx)
		{
			cur->prev = cur;
			cur = cur->next;
			cur_idx++;
		}
		return cur->value;
	}
	T GetAt(int idx)
	{
		return (*this)[idx];
	}
	void SetAt(int value, int idx)
	{
		(*this)[idx] = value;
	}
	int GetUpperBound() { return num - 1; }
	int GetSize() 
	{ 
		return size;
	}
	void SetSize(int size2, int grow2)
	{
		grow = grow2;
		if (size2 > size)
		{
			while (size < size2)
			{
				node* tmp = new node(0);
				if (empty())
				{
					tail = head  = tmp;
					size++;
				}
				else
				{
					tail->next = tmp;
					tmp->prev = tail;
					tail = tmp;
					size++;
				}
			}
			return;
		}
		else if (size2 < size)
		{
			while (size>size2)
			{
				node* tmp = head->next;
				delete head;
				head = tmp;
				size--;
			}
			return;
		}
		else if (head)
		{
			int t = 0;
			while (t<grow)
			{
				size++;
				node* tmp = new node(0);
				tail->next = tmp;
				tmp->prev = tail;
				tail = tmp;
				t++;
			}
			return;
		}
	}
	void Add(T value)
	{
		if (check())
		{
			SetSize(size, grow);
		}
		node* cur = head;
		while (cur->avail!=0)
		{
			cur->prev = cur;
			cur = cur->next;
		}
		cur->value = value;
		cur->avail = 1;
		num++;
	}
	bool check() { return size == num; }
	void InsertAt(T value, int idx)
	{
		if (idx == 0)
		{
			if (check())
			{
				SetSize(size, grow);
			}
			int k = 0;
			Array <T>tmp = *this;
			node* tmp2 = tmp.head;
			node* cur = head;
			while (k < num)
			{
				cur->next->value = tmp2->value;
				cur->next->avail = tmp2->avail;
				cur = cur->next;
				tmp2 = tmp2->next;
				k++;
			}
			head->value = value;
			num++;
		}
		else if (idx == size)
		{
			if (check())
			{
				SetSize(size, grow);
			}
			node* cur = head;
			int cur_idx = 0;
			while (idx > cur_idx)
			{
				cur->prev = cur;
				cur = cur->next;
				cur_idx++;
			}
			cur->value = value;
			cur->avail = 1;
			num++;
		}
		else
		{
			if (check())
			{
				SetSize(size, grow);
			}
			Array <T>tmp = *this;
			node* tmp2 = tmp.head;
			int k = 0;
			while (k < tmp.num)
			{
				tmp2->avail = 1;
				tmp2->prev = tmp2;
				tmp2 = tmp2->next;
				k++;
			}
			tmp2 = tmp.head;
			node* cur = head;
			int cur_idx = 0;
			while (idx > cur_idx)
			{
				cur->prev = cur;
				cur = cur->next;
				tmp2->prev = tmp2;
				tmp2 = tmp2->next;
				cur_idx++;
			}
			cur->value = value;
			while (cur_idx < num)
			{
				cur->next->value = tmp2->value;
				cur->next->avail = tmp2->avail;
				cur = cur->next;
				tmp2 = tmp2->next;
				cur_idx++;
			}
			num++;
		}
	}
	void RemoveAt(int idx)
	{
		if (idx == 0)
		{
			int k = 0;
			node* cur = head;
			while (k < num - 1)
			{
				cur->value = cur->next->value;
				cur = cur->next;
				k++;
			}
			cur->value = 0;
			cur->avail = 0;
			num--;
		}
		else if (idx == size)
		{
			node* cur = head;
			int cur_idx = 0;
			while (idx - 1 > cur_idx)
			{
				cur->prev = cur;
				cur = cur->next;
				cur_idx++;
			}
			cur->value = 0;
			cur->avail = 0;
			num--;
		}
		else
		{
			node* cur = head;
			int cur_idx = 0;
			while (idx - 1 > cur_idx)
			{
				cur->prev = cur;
				cur = cur->next;
				cur_idx++;
			}
			while (cur_idx < num - 1)
			{
				cur->value = cur->next->value;
				cur = cur->next;
				cur_idx++;
			}
			cur->value = 0;
			cur->avail = 0;
			num--;
		}
	}
	Array Append(const Array& obj)
	{
		Array tmp = *this;
		tmp.SetSize(num+obj.num, grow);
		node* f = head;
		int k = 0;
		while (f->avail!=0)
		{
			node* cur = tmp.head;
			while (cur->avail != 0)
			{
				cur->prev = cur;
				cur = cur->next;
			}
			cur->value = f->value;
			cur->avail = 1;
			num++;
			f = f->next;
		}
		node* s = obj.head;
		while (s->avail != 0)
		{
			node* cur = tmp.head;
			while (cur->avail != 0)
			{
				cur->prev = cur;
				cur = cur->next;
			}
			cur->value = s->value;
			cur->avail = 1;
			num++;
			s = s->next;
		}
		
		return tmp;
	}
	friend ostream& operator<<(ostream& stream, const Array& ls)
	{
		node* out = ls.head;
		while (out!=nullptr)
		{
			stream << out->value << ' ';
			out = out->next;
		}
		return stream;
	}
	void RemoveAll()
	{
		while (head)
		{
			node* tmp = head->next;
			delete head;
			head = tmp;
		}
		size = 0;
		grow = 0;
		num = 0;
	}
	~Array()
	{
		RemoveAll();
	}
};
void main()
{
	//Изначально 0 в массиве - дополнительные блоки памяти
	Array<int> a, b, c;
	a.SetSize(3, 3);
	cout << a << endl;
	cout << a.IsEmpty() << endl;
	a.Add(5);
	a.Add(6);
	a.Add(7);
	a.Add(4);
	a.Add(2);
	a.Add(10);
	a.Add(12);
	a.Add(13);
	a.Add(15);
	cout << a << endl << a.IsEmpty() << endl;
	cout << a.GetData() << endl;
	cout << a.GetUpperBound() <<endl;
	cout << a.GetSize() << endl;
	a.InsertAt(14, 4);
	cout << a << endl;
	a.Add(1);
	a.Add(4);
	cout << a << endl;
	cout << a.GetSize() << endl;
	a.RemoveAt(2);
	cout << a << endl;
	b.SetSize(3, 3);
	b.Add(23);
	b.Add(54);
	cout << b << endl;
	c = a.Append(b);
	cout << c << endl;
	cout << c.GetAt(2) << endl;
	c.SetAt(3, 2);
	cout << c << endl;
}