using System;
using System.Linq;
using System.Text;

namespace CourseWorkStart
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.OutputEncoding = System.Text.Encoding.UTF8;
            try
            {
                //Console.WriteLine("Eiler\n");
                //ImprovedEilerMethod calc = new(0.05, Math.PI / 2, (Math.PI / 2) + 1, 0, "x * Sin(x)/x + y/x");
                RungeKuttaMethod calc2 = new(0.05, Math.PI / 2, (Math.PI / 2) + 1, 0, "x * Sin(x)/x + y/x");
                //calc.Calculate();
                calc2.Calculate();
                //Console.WriteLine("i\tx\ty\tf(x;y)\tf(x+h;y+hf(x;y)\tSUMM(functions)\tyi+1\n");
                //for (int i = 0; i < calc.Iterations; i++)
                //{
                //    Console.WriteLine($"{i}   {Math.Round(calc.IterX[i], 6)}   {Math.Round(calc.IterY[i], 6)}   {Math.Round(calc.TablFunc[i], 6)}   " +
                //        $"{Math.Round(calc.HarTabFunc[i], 6)}   {Math.Round(calc.FuncSum[i], 6)}   {Math.Round(calc.LIterY[i], 6)}");
                //}
                Console.WriteLine("\n\nRunge\n");
                Console.WriteLine("i\txi\tyi\tk1\tk2\tk3\tk4\t∆yi\n");
                for (int i = 0; i < calc2.Iterations; i++)
                {
                    Console.WriteLine($"{i}   {Math.Round(calc2.IterX[i], 6)}   {Math.Round(calc2.IterY[i], 6)}   {Math.Round(calc2.K1[i], 6)}   " +
                        $"{Math.Round(calc2.K2[i], 6)}   {Math.Round(calc2.K3[i], 6)}   {Math.Round(calc2.K4[i], 6)}   {Math.Round(calc2.LIterY[i], 6)}");
                }
            }
            catch (Exception) { Console.WriteLine("Ошибка условия"); }
        }
    }
}
