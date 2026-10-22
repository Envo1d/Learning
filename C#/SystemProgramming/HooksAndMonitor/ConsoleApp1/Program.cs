using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Threading;

namespace ConsoleApp1
{
    class Program
    {
        public static long FileLenght { get; set; }
        public static int CurrentPos { get; set; }
        public static StreamReader reader;
        public static StreamWriter writer;
        public static byte counter = 0;
        static void Main(string[] args)
        {
            CurrentPos = 0;
            FileInfo file = new FileInfo("alisa.txt");
            FileLenght = file.Length;
            Console.WriteLine(FileLenght);
            Console.WriteLine(FileLenght / 10);
            Encoding.RegisterProvider(CodePagesEncodingProvider.Instance);
            reader = new StreamReader("alisa.txt", Encoding.GetEncoding("windows-1251"));
            using(FileStream fs = File.Open("copy.txt", FileMode.Create))
            { }
            writer = new StreamWriter("copy.txt", true, Encoding.GetEncoding("windows-1251"));
            for (int i = 1; i <= 10; i++)
            {
                new Thread(() =>
                {
                    Monitor.Enter(reader);
                    Monitor.Enter(writer);
                    try
                    {
                        for (; CurrentPos <= (FileLenght / 10) * i; CurrentPos++)
                        {
                            var res = reader.Read();
                            if (res == -1) break;
                            writer.Write(Convert.ToChar(res));
                        }
                    }
                    finally
                    {
                        Monitor.Exit(reader);
                        Monitor.Exit(writer);
                        Console.WriteLine(Thread.CurrentThread.ManagedThreadId + "end");
                        counter++;
                    }    
                }).Start();

            }
            Console.WriteLine("Waiting");
            while (counter != 10) { }
            reader.Close();
            writer.Close();
        }
    }
}
