/*
Реализовать программу, которая будет имитировать работу библиотеки. Основные стуктуры программы:

Структура Библиотека:
 - название
 - адрес
 - книги в виде массива структур книга

Структура Книга:
 - автор (типа Автор)
 - название
 - кол-во страниц
 - год
 - количество в наличии
 - количество выданных на руки

Структура Автор:
 - имя
 - фамилия
 

Реализовать следующий функционал:
 - Добавить книгу
 - Поиск книги по названию
 - Удалить книгу, которых нет в наличии
 - Поиск книг по первым введенным символам имени Автора
*/
using System;
using System.Linq;
using System.Threading;

namespace Homework
{
    struct Author
    {
        string name;
        string surname;
        public string Name { get; set; }
        public string Surname { get; set; }
    }
    struct Book
    {
        Author author;
        string name;
        int pages;
        int year;
        byte available;
        byte handed;
        public string AuthorName { get { return author.Name; } set { author.Name = value; } }
        public string AuthorSurname { get { return author.Surname; } set { author.Surname = value; } }
        public string Name { get; set; }
        public int Pages { get; set; }
        public int Year { get; set; }
        public byte Available { get; set; }
        public byte Handed { get; set; }
        public override string ToString()
        {
            return $"Название: {Name}\nАвтор: {AuthorName} {AuthorSurname}\nСтраниц: {Pages}\nГод выпуска: {Year}\nВ наличии: {Available}\nВыдано: {Handed}";
        }
    }
    struct Library
    {
        Book[] books;
        string name;
        string address;
        int count;
        int cur_index;
        public Library(string name, string address, int books)
        {
            this.name = name;
            this.address = address;
            this.books = new Book[books];
            count = 0;
            cur_index = 0;
        }
        public string Name { get { return name; } set { name = value; } }
        public string Address { get { return address; } set { address = value; } }
        public int Books { get { return books.Length; } }
        public override string ToString()
        {
            return $"Библиотека\nНазвание: {name}\nАдрес: {address}";
        }
        public void Add()
        {
            if (cur_index == books.Length)
                throw new Exception("Библиотека заполнена");

            if (books[cur_index].Name != null)
                while (books[cur_index].Name != null)
                    cur_index++;

            Console.WriteLine("Введите фамилию автора");
            books[cur_index].AuthorSurname = Console.ReadLine();
            Console.WriteLine("Введите имя автора");
            books[cur_index].AuthorName = Console.ReadLine();
            Console.WriteLine("Введите название книги");
            books[cur_index].Name = Console.ReadLine();
            int tmp, tmp1; byte tm;
            Console.WriteLine("Введите кол-во страниц");
            if (!int.TryParse(Console.ReadLine(), out tmp1))
                throw new Exception("Не удалось сконвертировать в число");
            else books[cur_index].Pages = tmp1;
            Console.WriteLine("Введите год выпуска книги");
            if (!int.TryParse(Console.ReadLine(), out tmp))
                throw new Exception("Не удалось сконвертировать в число");
            else books[cur_index].Year = tmp;
            Console.WriteLine("Введите количество книг в хранении");
            if (!byte.TryParse(Console.ReadLine(), out tm))
                throw new Exception("Не удалось сконвертировать в число");
            else books[cur_index].Available = tm;
            books[cur_index].Handed = 0;
            if (count != 0)
                cur_index++;
            count++;
        }
        private int GetBookIndex(string name)
        {
            int index = -1;
            for (int i = 0; i < books.Length; i++)
            {
                if (books[i].Name == name)
                    index = i;
            }
            return index;
        }
        public void FindBook(string name)
        {
            int idx = GetBookIndex(name);
            Console.Clear();
            Console.WriteLine(books.ElementAt(idx).ToString());
        }
        public void Give(string name)
        {
            int idx = GetBookIndex(name);
            if (idx != -1)
            {
                if(books.ElementAt(idx).Available > 0)
                {
                    books[idx].Available -= 1;
                    books[idx].Handed += 1;
                }
                else Console.WriteLine("Такой книги нет в наличии");
            }
            else throw new Exception("Книга не найдена");
        }
        public void FindBooksAuthor(string name)
        {
            bool b = false;
            string tmp = name.ToLower();
            for (int i = 0; i < books.Length; i++)
            {
                if (books[i].AuthorName != null && books[i].AuthorName.ToLower().IndexOf(tmp) == 0)
                {
                    Console.WriteLine(books[i]);
                    b = true;
                }
            }
            if (b == false)
                throw new Exception("Совпадений нет");
        }
        public void PrintAll()
        {
            if (count != 0)
                foreach (var book in books)
                {
                    if(book.Name != null)
                        Console.WriteLine($"{book}\n");
                }
            else throw new Exception("Библиотека пуста");
        }
        public void Delete(string name)
        {
            int idx = GetBookIndex(name);
            if (idx != -1)
            {
                books[idx] = default(Book);
                count--;
                if (idx < cur_index)
                    cur_index = idx;
                Console.WriteLine("\nКнига удалена");
            }
            else throw new Exception("Ошибка при поиске");
        }
        public void Delete()
        {
            bool f = false;
            string str = "";
            for (int i = 0; i < count; i++)
            {
                if (books[i].Available == 0)
                {
                    str = books[i].Name;
                    books[i] = default(Book);
                    f = true;
                    count--;
                    if (i < cur_index)
                        cur_index = i;
                    break;
                }
            }
            if (f)
                Console.WriteLine($"\n{str} удалена");
            else throw new Exception("\nНет книг на удаление");
        }
    }
    class Program
    {
        static int Main(string[] arg)
        {
            Console.WriteLine("\t\t\t\tСоздание библиотеки");
            string name= "", address = "";
            int books = 0;
            for (byte i = 0; i < 9; i++, Console.Write("."))
            {
                if (i == 0)
                {
                    Console.WriteLine("Введите название библиотеки");
                    name = Console.ReadLine();
                }
                if(i == 3)
                {
                    Console.WriteLine("\nВведите адрес библиотеки");
                    address = Console.ReadLine();
                }
                if(i==6)
                {
                    Console.WriteLine("\nВведите количество типов книг которое будет хранить библиотека");
                    if (!int.TryParse(Console.ReadLine(), out books))
                    { 
                        Console.WriteLine("Ошибка конвертации");
                        return -1;
                    }
                }
                Thread.Sleep(400);
            }
            Library library = new Library(name, address, books);
            ConsoleKeyInfo key = new ConsoleKeyInfo();
            do
            {
                Console.Clear();
                Console.WriteLine($"\t\t{library}\n\n1 - Добавить новую книгу\n2 - Поиск книги по названию\n3 - Удалить книгу, которой нет в наличии\n" +
                    "4 - Поиск книг по первым введенным символам имени Автора\n5 - Выдать книгу посетителю\n6 - Вывести список книг\n\nEsc - Выход");
                key = Console.ReadKey(true);
                switch(key.Key)
                {
                    case ConsoleKey.D1:
                        Console.Clear();
                        try
                        {
                            library.Add();
                        }
                        catch (Exception ex)
                        {
                            Console.WriteLine($"Ошибка: {ex.Message}");
                        }
                        Console.ReadKey();
                        break;
                    case ConsoleKey.D2:
                        Console.Clear();
                        try
                        {
                            Console.WriteLine("Введите название книги для поиска");
                            string str = Console.ReadLine();
                            library.FindBook(str);
                        }
                        catch (Exception ex)
                        {
                            Console.WriteLine($"Ошибка: {ex.Message}");
                        }
                        Console.ReadKey();
                        break;
                    case ConsoleKey.D3:
                        Console.Clear();
                        try
                        {
                            Console.WriteLine("Вы знаете какой книги нет в наличии (y/n) ?");
                            key = Console.ReadKey();
                            if (key.Key == ConsoleKey.Y)
                            {
                                Console.WriteLine("\nВведите название книги");
                                string str = Console.ReadLine();
                                library.Delete(str);
                            }
                            else library.Delete();
                        }
                        catch (Exception ex)
                        {
                            Console.WriteLine($"Ошибка: {ex.Message}");
                        }
                        Console.ReadKey();
                        break;
                    case ConsoleKey.D4:
                        Console.Clear();
                        try
                        {
                            Console.WriteLine("Поиск книг по первым введенным символам имени Автора");
                            string str = Console.ReadLine();
                            library.FindBooksAuthor(str);
                        }
                        catch (Exception ex)
                        {
                            Console.WriteLine($"Ошибка: {ex.Message}");
                        }
                        Console.ReadKey();
                        break;
                    case ConsoleKey.D5:
                        Console.Clear();
                        try
                        {
                            Console.WriteLine("Введите название книги для выдачи");
                            string str = Console.ReadLine();
                            library.Give(str);
                        }
                        catch (Exception ex)
                        {
                            Console.WriteLine($"Ошибка: {ex.Message}");
                        }
                        Console.ReadKey();
                        break;
                    case ConsoleKey.D6:
                        Console.Clear();
                        try
                        {
                            library.PrintAll();
                        }
                        catch (Exception ex)
                        {
                            Console.WriteLine($"Ошибка: {ex.Message}");
                        }
                        Console.ReadKey();
                        break;
                }
            }
            while (key.Key != ConsoleKey.Escape);
            return 0;
        }
    }
}