using System;

namespace Homework
{
    class program
    {
        static void Main(string[] arg)
        {
            int[] arr = new int[100];

            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine("\t\tЗадание №1");
            Console.ResetColor();
            Task_1(arr);
            Console.Write("\nДля продолжение нажмите любую клавишу ");
            Console.ReadKey();
            Console.WriteLine();
            Console.Clear();

            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine("\t\tЗадание №2");
            Console.ResetColor();
            Task_2(arr);
            Console.Write("\nДля продолжение нажмите любую клавишу ");
            Console.ReadKey();
            Console.WriteLine();
            Console.Clear();

            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine("\t\tЗадание №3");
            Console.ResetColor();
            Task_3(arr);
            Console.Write("\nДля продолжение нажмите любую клавишу ");
            Console.ReadKey();
            Console.WriteLine();
            Console.Clear();

            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine("\t\tЗадание №4");
            Console.ResetColor();
            Task_4();
            Console.Write("\nДля продолжение нажмите любую клавишу ");
            Console.ReadKey();
            Console.WriteLine();
        }

        static void Task_1(int[] arr)
        {
            /*
            Создать одномерный массив размером 100 элементов, заполнить случайными
            положительными и отрицательными элементами в диапазоне от - 100 до 100
            */

            Random rnd = new Random();

            for(int i = 0; i < arr.Length; i++)
            {
                arr[i] = rnd.Next(-100, 100);
            }

            Print(arr);
        }

        static void Task_2(int[] arr)
        {
            /*
            Преобразовать массив из первого задания так, что бы сначала шли все
            отрицательные элементы, а потом положительные(0 считать положительным)
            Не сортировка!!!
            */

            int num_count = 0;
            for (int i = 0; i < arr.Length; i++)
                if (arr[i] >= 0)
                    num_count++;
            
            int[] tmp_mas = new int[num_count];
            for (int i = 0, j = 0; i < arr.Length; i++)
                if (arr[i] >= 0)
                {
                    tmp_mas[j] = arr[i];
                    j++;
                }

            for (int i = 0; i < arr.Length; i++)
            {
                if (arr[i] < 0)
                    continue;
                else
                {
                    for (int j = arr.Length - 1; j > i; j--)
                    {
                        if (arr[j] < 0)
                        {
                            int tmp = arr[i];
                            arr[i] = arr[j];
                            arr[j] = tmp;
                        }
                    }
                }
            }

            //Возвращение очерёдности положительных чисел
            for(int i = (arr.Length ) - num_count, j = 0 ; i < arr.Length; i++, j++)
            {
                arr[i] = tmp_mas[j];
            }

            Print(arr);
        }

        static void Task_3(int[] arr)
        {
            /*
            Написать программу, которая предлагает пользователю ввести число и
            считает сколько раз это число встречается в массиве из первого задания
            (Использовать метод IndexOf класса Array)
            */

            Console.WriteLine("Введите число для поиска");
            int num = Convert.ToInt32(Console.ReadLine());
            int count = 0;
            int st_index = Array.IndexOf(arr, num);
            if(st_index == -1)
                Console.WriteLine("Такого числа в массиве нет");
            else
            {
                count++;
                do
                {
                    st_index = Array.IndexOf(arr, num, st_index + 1);
                    if (st_index != -1)
                        count++;
                }
                while (st_index != -1);
                Console.WriteLine("Количество {0} в массиве = {1}", num, count);
            }
        }

        static void Task_4()
        {
            /*
            Задан массив 15х20(многомерный массив) элементов заполненный случайными числами от 1 до 100
            Пользователь вводит две строки, которые нобходимо поменять местами.
            Вывести исходный массив и преобразованный.
            */

            Random rnd = new Random();
            int[,] arr = new int[15, 20];
            for (int i = 0; i < arr.GetLength(0); i++)
            {
                for (int j = 0; j < arr.GetLength(1); j++)
                {
                    arr[i, j] = rnd.Next(1, 100);
                }
            }
            Print(arr);

            int r1, r2;
            Console.WriteLine("Введите строки которые поменять местами");
            Console.Write("Строка 1 - "); r1 = Convert.ToInt32(Console.ReadLine()) - 1;
            Console.Write("Строка 2 - "); r2 = Convert.ToInt32(Console.ReadLine()) - 1;

            for (int i = 0; i < arr.GetLength(1); i++)
            {
                int tmp = arr[r1, i];
                arr[r1, i] = arr[r2, i];
                arr[r2, i] = tmp;
            }
            Print(arr);
        }

        static void Print(int[] arr)
        {
            foreach (int i in arr)
                Console.Write("{0,6:d}", i);
            Console.WriteLine();
        }

        static void Print(int[,] arr)
        {
            for (int i = 0; i < arr.GetLength(0); i++)
            {
                for (int j = 0; j < arr.GetLength(1); j++)
                {
                    Console.Write("{0,6:d}", arr[i, j]);
                }
            }
        }
    }
}