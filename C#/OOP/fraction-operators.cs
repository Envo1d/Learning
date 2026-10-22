using System;
using System.Linq;
using System.Text;

namespace Homework
{
    /*
    Разработать класс Fraction, представляющий простую
дробь. в классе предусмотреть два поля: числитель
и знаменатель дроби. 
Выполнить перегрузку следующих операторов: +,-,*,/,==,!=,<,>, true и false.
Арифметические действия и сравнение выполняется
в соответствии с правилами работы с дробями. 
Оператор true возвращает true если дробь правильная
(числитель меньше знаменателя), оператор false
возвращает true если дробь неправильная (числитель
больше знаменателя).

Выполнить перегрузку операторов, необходимых для
успешной компиляции следующего фрагмента кода:

Fraction f = new Fraction(3, 4);
int a = 10;
Fraction f1 = f * a;
Fraction f2 = a * f;
double d = 1.5;
Fraction f3 = f + d 
    */
    class Fraction
    {
        public int Numerator { get; set; }
        public int Denominator { get; set; }
        public int Integ { get; set; }
        public Fraction(int num = 1, int denom = 1)
        {
            Numerator = num;
            if (denom <= 0)
{
                Console.WriteLine("Denominator less than or equal to zero\nEnter new denominator\n");
                int tmp = Convert.ToInt32(Console.ReadLine());
                Denominator = tmp;
            }
            else Denominator = denom;
            Integ = 0;
        }
        public override string ToString()
        {
            int tmp = Numerator;
            StringBuilder str = new StringBuilder();
            if (Integ != 0)
                str.Append($"[{Integ}]\n\t");
            str.Append($"{Numerator}\n");
            if (Integ != 0)
                str.Append("\t");
            str.Append("-");
            while (tmp>10)
            {
                str.Append("-");
                tmp /= 10;
            }
            str.Append("\n");
            if (Integ != 0)
                str.Append("\t");
            str.Append($"{Denominator}");
            return Convert.ToString(str);
        }
        public Fraction ConvertToFract(float num)
        {
            string str = Convert.ToString(num);
            int s = str.IndexOf(",");
            StringBuilder tmp = new StringBuilder();
            int k = s;
            if (k == -1) k = str.Length;
            for (int i = 0; i < k; i++)
            {
                tmp.Append(str[i]);
            }
            int integ = Convert.ToInt32(tmp.ToString());
            int count = 0;
            if (s == -1) return new Fraction(integ);
            int e = str.Length;
            while(e > s + 1)
            {
                num /= 0.1f;
                count++;
                e--;
            }
            int den = 1;
            for (int i = count; i > 0; i--)
                den *= 10;
            int nm;
            nm = Convert.ToInt32(num);
            return new Fraction(nm, den);
        }
        public void Reduction()
        {
            int i, less;
            do
            {
                if (Numerator < Denominator)
                    less = Numerator;
                less = Denominator;
                for (i = less; i > 0; i--)
                {
                    if(Numerator % i == 0 && Denominator % i == 0)
                    {
                        Numerator /= i;
                        Denominator /= i;
                        break;
                    }
                }
            } while (i != 1);
        }
        public void SubtractInteg()
        {
            int i = Denominator;
            while (i <= Numerator)
            {
                i += Denominator;
                Integ++;
            }
            if(i!=Numerator)
                i -= Denominator;
            Numerator -= i;
            if (Numerator == 0) Numerator = 1;
        }
        public static Fraction operator +(Fraction f1) => f1;
        public static Fraction operator +(Fraction f1, Fraction f2)
            => new Fraction(f1.Numerator * f2.Denominator + f2.Numerator * f1.Denominator, f1.Denominator * f2.Denominator);
        public static Fraction operator +(Fraction f1, int f2)
            => new Fraction(f1.Numerator + f2 * f1.Denominator, f1.Denominator);
        public static Fraction operator +(int f2, Fraction f1) => f1 + f2;
        public static Fraction operator +(Fraction f1, double f2)
        {
            Fraction f2con = new Fraction();
            f2con = f2con.ConvertToFract(Convert.ToSingle(f2));
            return new Fraction(f1.Numerator * f2con.Denominator + f2con.Numerator * f1.Denominator, f1.Denominator * f2con.Denominator);
        }
        public static Fraction operator +(double f2, Fraction f1) => f1 + f2;
        public static Fraction operator -(Fraction f1) => new Fraction(-f1.Numerator, f1.Denominator);
        public static Fraction operator -(Fraction f1, Fraction f2) => f1 + (-f2);
        public static Fraction operator -(Fraction f1, int f2) => f1 + (-f2);
        public static Fraction operator -(int f2, Fraction f1) => f1 + (-f2);
        public static Fraction operator -(Fraction f1, double f2) => f1 + (-f2);
        public static Fraction operator -(double f2, Fraction f1) => f1 + (-f2);
        public static Fraction operator *(Fraction f1, Fraction f2) => new Fraction(f1.Numerator * f2.Numerator, f1.Denominator * f2.Denominator);
        public static Fraction operator *(Fraction f1, int f2) => new Fraction(f1.Numerator * f2, f1.Denominator);
        public static Fraction operator *(int f2, Fraction f1) => f1 * f2;
        public static Fraction operator *(Fraction f1, double f2)
        {
            Fraction f2con = new Fraction();
            f2con = f2con.ConvertToFract(Convert.ToSingle(f2));
            return f1 * f2con;
        }
        public static Fraction operator *(double f2, Fraction f1) => f1 * f2;
        public static Fraction operator /(Fraction f1, Fraction f2)
        {
            if (f2.Numerator == 0)
                throw new DivideByZeroException();
            return new Fraction(f1.Numerator * f2.Denominator, f1.Denominator * f2.Numerator);
        }
        public static Fraction operator /(Fraction f1, int f2)
        {
            if (f2 == 0)
                throw new DivideByZeroException();
            return new Fraction(f1.Numerator, f1.Denominator * f2);
        }
        public static Fraction operator /(int f2, Fraction f1) => f1 / f2;
        public static Fraction operator /(Fraction f1, double f2)
        {
            if (f2 == 0)
                throw new DivideByZeroException();
            Fraction f2con = new Fraction();
            f2con = f2con.ConvertToFract(Convert.ToSingle(f2));
            return f1 / f2con;
        }
        public static Fraction operator /(double f2, Fraction f1) => f1 / f2;
        public static bool operator ==(Fraction f1, Fraction f2) => f1.Numerator == f2.Numerator && f1.Denominator == f2.Denominator;
        public static bool operator !=(Fraction f1, Fraction f2) => f1.Numerator != f2.Numerator && f1.Denominator != f2.Denominator;
        static int MLC(int a, int b)
        {
            int mlc = 0;
            for (int i = 0; i < (b * a + 1); i++)
            {
                if (i % b == 0 && i % a == 0)
                {
                    mlc = i;
                    if (i != 0)
                        break;
                }
            }
            return mlc;
        }
        public static bool operator >(Fraction f1, Fraction f2)
        {
            if (f1.Numerator * Fraction.MLC(f1.Denominator, f2.Denominator) / f1.Denominator
               > f2.Numerator * Fraction.MLC(f1.Denominator, f2.Denominator) / f2.Denominator)
                return true;
            else return false;
        }
        public static bool operator <(Fraction f1, Fraction f2)
        {
            if (f1.Numerator * Fraction.MLC(f1.Denominator, f2.Denominator) / f1.Denominator
               < f2.Numerator * Fraction.MLC(f1.Denominator, f2.Denominator) / f2.Denominator)
                return true;
            else return false;
        }
        public static bool operator <=(Fraction f1, Fraction f2)
        {
            if (f1.Numerator * Fraction.MLC(f1.Denominator, f2.Denominator) / f1.Denominator
               <= f2.Numerator * Fraction.MLC(f1.Denominator, f2.Denominator) / f2.Denominator)
                return true;
            else return false;
        }
        public static bool operator >=(Fraction f1, Fraction f2)
        {
            if (f1.Numerator * Fraction.MLC(f1.Denominator, f2.Denominator) / f1.Denominator
               >= f2.Numerator * Fraction.MLC(f1.Denominator, f2.Denominator) / f2.Denominator)
                return true;
            else return false;
        }
        public static bool operator true(Fraction f) => f.Numerator < f.Denominator;
        public static bool operator false(Fraction f) => f.Numerator > f.Denominator;
    }
    class Program
    {
        static void Main(string[] arg)
        {
            Fraction f = new Fraction(3, 4);
            int a = 10;
            Fraction f1 = f * a;
            Fraction f2 = a * f;
            double d = 1.5;
            Fraction f3 = f + d;
            Console.WriteLine($"{f}\n\n");
            Console.WriteLine($"{f1}\n\n");
            Console.WriteLine($"{f2}\n\n");
            Console.WriteLine($"{f3}\n\n");
        }
    }
}