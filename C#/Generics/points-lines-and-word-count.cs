using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;

namespace HW
{
    /*
1. Создать необобщенный класс точки в 3-х мерном
пространстве с целочисленными координатами (Point3D),
который наследуется от generic класса Point2D<T>. 
В классе предусмотреть поле для
хранения значения координаты z. Реализовать в классе:

a. Конструктор с параметрами, который принимает начальные
значения для координат точки.
b. Переопределить метод ToString()

2. Создать обобщенный класс прямой на плоскости. В классе
предусмотреть 2 поля типа обобщенной точки, через
которые проходит прямая. Реализовать в классе:

a. Конструктор, который принимает 2 точки.
b. Конструктор, которые принимает 4 координаты (x и у
координаты для 1-ой и 2-ой точки).
c. Переопределить метод ToString().

3. Подсчитать, сколько раз каждое слово встречается в
тексте введенном пользователем. Результат записать в коллекцию
Dictionary<TKey, TValue> и представить статистику.
     */
    class Point2D<T>
    {
        public T X { get; set; }
        public T Y { get; set; }
        
        public Point2D(T x, T y)
        {
            X = x;
            Y = y;
        }
        public override string ToString()
        {
            return $"X = {X}; Y = {Y};";
        }
    }
    class Point3D : Point2D<int>
    {
        public int Z { get; set; }

        public Point3D(int x, int y, int z) : base(x,y)
        {
            Z = z;
        }
        public override string ToString()
        {
            return $"{base.ToString()} Z = {Z}";
        }
    }
    class Straight<T>
    {
        public Point2D<T> FirstPoint { get; set; }
        public Point2D<T> SecondPoint { get; set; }

        public Straight(Point2D<T> firstPoint, Point2D<T> secondPoint)
        {
            FirstPoint = firstPoint;
            SecondPoint = secondPoint;
        }
        public Straight(T xFirst, T yFirst, T xSecond, T ySecond)
        {
            FirstPoint = new Point2D<T>(xFirst, yFirst);
            SecondPoint = new Point2D<T>(xSecond, ySecond);
        }
        public override string ToString()
        {
            return $"Straight with coordinates:\n" +
                $"Point 1: {FirstPoint}\nPoint 2: {SecondPoint}";
        }
    }
    class Counter : IEnumerable
    {
        Dictionary<string, int> result;
        public Dictionary<string,int> Result { get { return result; } }

        public Counter() { result = new Dictionary<string, int>(); }

        public void AnalyzeText(string str)
        {
            char[] toRemove = { ' ', '.', ',', '!', '?', '\\', '"', '/', '#', '$', '@', '&', '*', '(', ')', '-' };
            str = str.ToLower();
            string[] words = str.ToLower().Split(toRemove, StringSplitOptions.RemoveEmptyEntries);
            foreach(var word in words)
            {
                if (result.ContainsKey(word)) result[word] += 1;
                else result.Add(word, 1);
            }
        }

        public IEnumerator GetEnumerator()
        {
            foreach (var item in result)
            {
                yield return $"{item.Key} - {item.Value}";
            }
        }
    }
    class UI
    {
        Point3D point3D;
        Straight<int> straight;
        Counter counter;

        public void CreatePoint3D()
        {
            int x = 0, y = 0, z = 0;
            Console.WriteLine("Enter point coordinates");
            Console.Write("X: ");
            try { x = Convert.ToInt32(Console.ReadLine()); } catch (FormatException msg) { Console.WriteLine(msg.Message); }
            Console.Write("Y: ");
            try { y = Convert.ToInt32(Console.ReadLine()); } catch (FormatException msg) { Console.WriteLine(msg.Message); }
            Console.Write("Z: ");
            try { z = Convert.ToInt32(Console.ReadLine()); } catch (FormatException msg) { Console.WriteLine(msg.Message); }
            point3D = new Point3D(x, y, z);
            Console.Clear();
            Console.WriteLine(point3D);
        }
        public void CreateStraight()
        {
            var key = new ConsoleKeyInfo();
            Console.WriteLine("Create straight from points or coordinates (y/n)");
            Key:
            key = Console.ReadKey(true);
            switch(key.Key)
            {
                case ConsoleKey.Y:
                    Console.Clear();
                    straight = new Straight<int>(new Point2D<int>(2, 4), new Point2D<int>(10, 6));
                    Console.Clear();
                    Console.WriteLine(straight);
                    break;
                case ConsoleKey.N:
                    Console.Clear();
                    int x1 = 0, x2 = 0, y1 = 0, y2 = 0;
                    Console.Write("X1: ");
                    try { x1 = Convert.ToInt32(Console.ReadLine()); } catch (FormatException msg) { Console.WriteLine(msg.Message); }
                    Console.Write("Y1: ");
                    try { y1 = Convert.ToInt32(Console.ReadLine()); } catch (FormatException msg) { Console.WriteLine(msg.Message); }
                    Console.Write("X2: ");
                    try { x2 = Convert.ToInt32(Console.ReadLine()); } catch (FormatException msg) { Console.WriteLine(msg.Message); }
                    Console.Write("Y2: ");
                    try { y2 = Convert.ToInt32(Console.ReadLine()); } catch (FormatException msg) { Console.WriteLine(msg.Message); }
                    straight = new Straight<int>(x1, y1, x2, y2);
                    Console.Clear();
                    Console.WriteLine(straight);
                    break;
                default:
                    goto Key;
            }
        }
        public void AnalyzeText()
        {
            Console.WriteLine("Enter text");
            string text = Console.ReadLine();
            counter = new Counter();
            counter.AnalyzeText(text);
            Console.Clear();
            foreach (var item in counter)
            {
                Console.WriteLine($"Word {item} times");
            }
        }
    }
    class Program
    {
        static void Main(string[] args)
        {
            UI uI = new UI();
            var key = new ConsoleKeyInfo();
            do
            {
                Console.Clear();
                Console.WriteLine("1 - Task 1\n2 - Task 2\n3 - Task 3\nEsc - exit");
                key = Console.ReadKey(true);
                switch (key.Key)
                {
                    case ConsoleKey.D1:
                        Console.Clear();
                        uI.CreatePoint3D();
                        Console.ReadKey(true);
                        break;
                    case ConsoleKey.D2:
                        Console.Clear();
                        uI.CreateStraight();
                        Console.ReadKey(true);
                        break;
                    case ConsoleKey.D3:
                        Console.Clear();
                        uI.AnalyzeText();
                        Console.ReadKey(true);
                        break;
                }
            } while (key.Key != ConsoleKey.Escape);
        }
    }
}