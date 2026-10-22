/*
Написать программу, имитирующую многоквартирный дом. Необходимо иметь классы “Человек”, “Квартира”, “Дом”. 
Класс “Квартира” содержит массив объектов класса “Человек”. Реализовать метод добавления человека 
в квартиру и получения по имени.
Класс “Дом” содержит массив класса “Квартира”. Реализовать метод для добавления кваритры и получения
по номеру (строка).

Каждый из классов содержит переменные-члены и функции-члены, которые необходимы для предметной области класса. 

Продемонстрировать работу полученного набора классов.
*/
using System;
using System.Text;

namespace Homework
{
    class Persone
    {
        string fio;
        byte age;
        
        public Persone()
        {
            fio = null;
            age = 0;
        }
        public string Fio { get { return fio; } }
        public void EntInfo()
        {
            Console.WriteLine("\nВведите ФИО");
            fio = Console.ReadLine();
            Console.WriteLine("\nВведите возраст");
            age = byte.Parse(Console.ReadLine());
        }
        public override string ToString()
        {
            return $"ФИО: {fio}\nВозраст: {age}\n";
        }
    }
    class Apartment
    {
        Persone[] persones;
        short number;
        byte numOfPeople;

        public Apartment()
        {
            persones = null;
            number = 0;
            numOfPeople = 0;
        }
        public void Add()
        {
            Array.Resize<Persone>(ref persones, numOfPeople + 1);
            persones[numOfPeople] = new Persone();
            persones[numOfPeople].EntInfo();
            numOfPeople++;
        }
        public override string ToString()
        {
            StringBuilder tmp = new StringBuilder();
            foreach(var per in persones)
            {
                tmp.Append(per.ToString());
            }
            return $"Номер квартиры: {number}\n{tmp}";
        }
        public byte NumOfPeople { get { return numOfPeople; } }
        public short Number { set { number = value; } get { return number; } } 
        public bool FindPers(string inf)
        {
            bool f = false;
            for (int i = 0; i < numOfPeople; i++)
            {
                if (persones[i].Fio.IndexOf(inf) != -1)
                {
                    Console.WriteLine($"Живёт в квартире №{number}\n{persones[i]}");
                    f = true;
                }
            }
            return f;
        }
    }
    class House
    {
        static Apartment[] apartments;
        byte countOfApart;
        string address;

        public House(byte size)
        {
            countOfApart = size;
            apartments = new Apartment[countOfApart];
            for (short i = 0; i < countOfApart; i++)
            {
                apartments[i] = new Apartment();
                apartments[i].Number = Convert.ToInt16(i + 1);
            }
            Console.WriteLine("Введите адрес дома");
            address = Console.ReadLine();
        }
        public void Add()
        {
            Console.Write($"Свободные квартиры: ");
            foreach(var app in apartments)
            {
                if(app.NumOfPeople==0)
                    Console.Write($"{app.Number} ");
            }
            Console.WriteLine("\n\nВведите номер квартиры для заселениня");
            short num = short.Parse(Console.ReadLine());
            Console.WriteLine("Сколько человек будет в ней жить");
            byte count = byte.Parse(Console.ReadLine());
            if(num <= countOfApart && num >= 1)
            {
                for (byte i = 0; i < count; i++)
                {
                    apartments[num - 1].Add();
                }
                Console.WriteLine("\nДобавлено");
            }
            else Console.WriteLine("Такой кввартиры нет");
        }
        public override string ToString()
        {
            StringBuilder str = new StringBuilder();
            string strout;
            bool f = false;
            for (int i = 0; i < countOfApart; i++)
            {
                if (apartments[i].NumOfPeople != 0)
                {
                    str.Append(apartments[i]);
                    f = true;
                }
            }
            if (f == false)
                str.Append("Дом пуст");
            strout = Convert.ToString(str);
            return strout; 
        }
        public void ShowApart()
        {
            Console.WriteLine("Введите номер квартиры");
            short num = short.Parse(Console.ReadLine());
            if(num <= countOfApart && num >= 1)
            {
                if (apartments[num - 1].NumOfPeople != 0)
                    Console.WriteLine(apartments[num - 1]);
                else Console.WriteLine("Квартира пустая");
            }
            else Console.WriteLine("Такой квартиры нет");
        }
        public void FindPerson()
        {
            bool f = false;
            Console.WriteLine("Введите имя для поиска");
            string str = Console.ReadLine();
            foreach(var apart in apartments)
            {
                if (apart.FindPers(str) == true)
                    f = true;
            }
            if(f==false)
                Console.WriteLine("Нет совпадений");
        }
    }
    class Program
    {
        static void Main(string[] arg)
        {
            Console.WriteLine("Введите кол-во квартир в доме");
            byte a;
            House house = new House(a = byte.Parse(Console.ReadLine()));
            ConsoleKeyInfo key = new ConsoleKeyInfo();
            do
            {
                Console.Clear();
                Console.WriteLine("1 - Заселение в квартиру\n2 - Поиск жильца\n3 - Вывести список жильцов в квартире\n4 - Вывести информацию о доме\nEsc - выход");
                key = Console.ReadKey(true);
                switch (key.Key)
                {
                    case ConsoleKey.D1:
                        Console.Clear();
                        house.Add();
                        Console.ReadKey();
                        break;
                    case ConsoleKey.D2:
                        Console.Clear();
                        house.FindPerson();
                        Console.ReadKey();
                        break;
                    case ConsoleKey.D3:
                        Console.Clear();
                        house.ShowApart();
                        Console.ReadKey();
                        break;
                    case ConsoleKey.D4:
                        Console.Clear();
                        Console.WriteLine(house);
                        Console.ReadKey();
                        break;
                }
            } while (key.Key != ConsoleKey.Escape);
        }
    }
}