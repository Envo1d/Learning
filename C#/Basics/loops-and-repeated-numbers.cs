using System;

/*
 Начальный вклад в банке равен 1000 грн. Через каждый месяц размер вклада
увеличивается на Р процентов от имещющейся суммы ( Р-вещественное число, 0 <P<25).
Значение Р программа должна получить у пользователя. По данному Р определить,
через сколько месяцев размер вклада превысит 2000 грн., и вывести найденное
количество месяцев К (целое число) и итоговый размер вклада S (вещественное число)
*/

//namespace Task1
//{
//    class Program
//    {
//        static void Main(string[] args)
//        {
//            Console.ForegroundColor = ConsoleColor.Green;
//            Console.WriteLine("\t\tБанк\n");
//            Console.ForegroundColor = ConsoleColor.White;
//            float sum = 1000;
//            Console.WriteLine("Начальный вклад {0} грн", sum);
//            Console.Write("\nВведите процент ставки: ");
//            float P = Convert.ToSingle(Console.ReadLine());
//            byte month = 0;
//            if (P > 0 && P < 25)
//            {
//                while(true)
//                {
//                    if(sum >= 2000)
//                    {
//                        break;
//                    }
//                    sum += sum * (P / 100);
//                    month++;
//                }
//                Console.ForegroundColor = ConsoleColor.Red;
//                Console.WriteLine("\nИтоговый размер вклада: {0} грн\nПотребовалось месяцев: {1}", sum, month);
//                Console.ForegroundColor = ConsoleColor.White;
//            }
//            else Console.WriteLine("\nПроцентная ставка выше 25%");
//        }
//    }
//}

/*
Даны целы положительные числа A и B (A<B). Вывести все целые числа от A до B
включительно; каждое число должно выводится на новой строке; при этом каждое
число должно выводится количество раз, равное его значению (например, число 3
выводится 3 раза).
Например: если А=3, а B=7, то программа должна сформировать в консоли следующий
вывод:

3 3 3
4 4 4 4
5 5 5 5 5
6 6 6 6 6 6
7 7 7 7 7 7 7 
*/

namespace Task2
{
    class Prog
    {
        static void Main(string[] args)
        {
            short a, b;
            Console.Write("Введите А: "); a = Convert.ToInt16(Console.ReadLine());
            Console.Write("Введите B: "); b = Convert.ToInt16(Console.ReadLine());
            if (a < 0 || b < 0) Console.WriteLine("Введено отрицательное число");
            else
            {
                if (a > b)
                {
                    short c = a;
                    a = b;
                    b = c;
                }
                Console.ForegroundColor = ConsoleColor.Yellow;
                for (short i = a; i <= b; i++)
                {
                    for (short j = 0; j < i; j++)
                    {
                        Console.Write("{0} ", i);
                    }
                    Console.Write("\n");
                }
                Console.ForegroundColor = ConsoleColor.White;
            }
        }
    }
}