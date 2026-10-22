using System;
using System.Linq;
using System.Text;

namespace Homework
{
    class Program
    {
        static void Main(string[] arg)
        {
            Console.WriteLine("\t\tЗадание №1");
            Console.WriteLine("\nEnter string");
            string original_string = Console.ReadLine();
            string changed_string = Ex1(original_string);
            Console.WriteLine(changed_string);
            Console.ReadKey();
            Console.Clear();

            Console.WriteLine("\t\tЗадание №2");
            Ex2();
            Console.ReadKey();
            Console.Clear();

            Console.WriteLine("\t\tЗадание №3");
            Ex3();
            Console.ReadKey();
            Console.Clear();

            Console.InputEncoding = Encoding.Unicode;
            Console.OutputEncoding = Encoding.Unicode;
            Console.WriteLine("\t\tЗадание №4");
            Ex4();
            Console.ReadKey();
            Console.Clear();
            Console.InputEncoding = Encoding.ASCII;
            Console.OutputEncoding = Encoding.ASCII;

            Console.WriteLine("\t\tЗадание №5\n\t\tConvert to Roman\n");
            Ex5();
            Console.ReadKey();
            Console.Clear();
        }
        static string Ex1(string str)
        {
            /*Дана строка original_string. Реализовать функционал который возвращает прореженную строку change_string, 
            оставляя только каждый третий символ.*/

            string changed = "";
            for (int i = 2; i < str.Length; i += 3)
            {
                changed += str[i];
            }
            return changed;
        }
        static void Ex2()
        {
            /*
            Подсчет гласных букв в строке var_string.

            Примечание:
            для простоты строка var_string состоит из букв латинского алфавита; набор гласных принимаем за 
            'a', 'e', 'i', 'o', 'u'; программа должна быть нечувствительна к регистру.

            Пример var_string = "hApPyHalLOweEn!" counting_vowels = 5
            */

            Console.WriteLine("Enter string");
            string var_string = Console.ReadLine();
            Console.WriteLine("\n\nvar_string = {0}", var_string);
            var_string = var_string.ToLower();
            int counting_vowels = 0;
            for (int i = 0; i < var_string.Length; i++)
            {
                if (var_string[i] == 'a' || var_string[i] == 'e' || var_string[i] == 'i' || var_string[i] == 'o' || var_string[i] == 'u')
                    counting_vowels++;
            }
            Console.WriteLine("Counting_vowels = {0}", counting_vowels);
        }
        static void Ex3()
        {
            /*
             Реализовать подсчет количества вхождений подстроки "wow" в строке var_string.
             Пишите свой код в следующем окне, предполагая, что var_string уже определена. 
             Описываете логику и не забываем печатать результат print(count)

             Пример var_string = "wowhatamanwowowpalehche" count = 3
            */

            string var_string = "wowhatamanwowowpalehche";
            int count = 0;
            int index = var_string.IndexOf("wow");
            if (index != -1)
            {
                count++;
                for (; index < var_string.Length;)
                {
                    index = var_string.IndexOf("wow", index + 1);
                    if (index == -1)
                        break;
                    else count++;
                }
                Console.WriteLine("var_string = " + var_string + " count = " + count);
            }
            else Console.WriteLine("No matches");
        }
        static void Ex4()
        {
            /*
            Дан кусок текста. Соберите все заглавные буквы в одно слово в том порядке как они встречаются в куске текста.

            Например: текст = "How are you? Eh, ok. Low or Lower? Ohhh.", если мы соберем все заглавные буквы, то получим сообщение "HELLO".

            Входные данные: Текст как строка (юникод).

            Выходные данные: Секретное сообщение как строка или пустая строка. 
            */
            Console.WriteLine("Enter string");
            string ts = Console.ReadLine();
            string otp = "";
            for (int i = 0; i < ts.Length; i++)
            {
                if (char.IsLower(ts[i]) == false && ts[i] > '\u0040' && ts[i] <= '\u005A')
                    otp += ts[i];
            }
            Console.WriteLine(otp);
        }
        static void Ex5()
        {
            /*
            Римские цифры пришли к нам из древней римской системы счета. Они основаны на особых буквах алфавита, которые в различных сочетаниях,
            путем суммирования (а иногда и разницы) описывают различные числа. 

            Первые 10 римских чисел это:
            I, II, III, IV, V, VI, VII, VIII, IX, and X.

            Римская система счета имеет десятичное основание, но она непозиционная и не включает в себя 0 (ноль). 
            Римские числа образуются путем комбинации следующих семи символов: Символ Значение I 1 (unus) V 5 (quinque) X 10 (decem) 
            L 50 (quinquaginta) C 100 (centum) D 500 (quingenti) M 1,000 (mille)

            Узнать больше о римских цифрах вы можете в статье на Википедии.

            В этой задаче, вам необходимо преобразовать данное целое число (от 1 до 3999) в римскую систему счета.

            Вх. данные: Число, как целочисленное (int).

            Вых. данные: Римское число, как строка (str). 
            */

            string[] roman = new string[13] { "I", "IV", "V", "IX", "X", "XL", "L", "XC", "C", "CD", "D", "CM",
            "M"};
            Console.WriteLine("Enter number");
            int a_digit = Convert.ToInt32(Console.ReadLine());
            if( a_digit < 4000 && a_digit != 0)
            {
                StringBuilder romanout = new StringBuilder();
                if(a_digit < 0)
                {
                    romanout.Append("-");
                    a_digit = -a_digit;
                }
                string num = a_digit.ToString();
                int col = num.Length;
                int type;
                if (col == 1)
                    type = 1;
                else if (col == 2)
                    type = 10;
                else if (col == 3)
                    type = 100;
                else
                    type = 1000;
                for(int i = 0; i < col; i++)
                {
                    if(type == 1)
                    {
                        int d = int.Parse(num[i].ToString());
                        if (d == 0) continue;
                        else if (d == 9) romanout.Append(roman[3]);
                        else if (d < 9 && d > 5)
                        {
                            romanout.Append(roman[2]);
                            int r = d - 5;
                            while (r != 0)
                            {
                                romanout.Append(roman[0]);
                                r--;
                            }
                        }
                        else if (d == 5)
                            romanout.Append(roman[2]);
                        else if (d == 4)
                            romanout.Append(roman[1]);
                        else
                        {
                            int r = 0 + d;
                            while(r!=0)
                            {
                                romanout.Append(roman[0]);
                                r--;
                            }
                        }
                    }
                    else if (type == 10)
                    {
                        int d = int.Parse(num[i].ToString());
                        if (d == 0) continue;
                        else if (d == 9) romanout.Append(roman[7]);
                        else if (d < 9 && d > 5)
                        {
                            romanout.Append(roman[6]);
                            int r = d - 5;
                            while (r != 0)
                            {
                                romanout.Append(roman[4]);
                                r--;
                            }
                        }
                        else if (d == 5)
                            romanout.Append(roman[6]);
                        else if (d == 4)
                            romanout.Append(roman[5]);
                        else
                        {
                            int r = 0 + d;
                            while (r != 0)
                            {
                                romanout.Append(roman[4]);
                                r--;
                            }
                        }
                        type /= 10;
                    }
                    else if (type == 100)
                    {
                        int d = int.Parse(num[i].ToString());
                        if (d == 0) continue;
                        else if (d == 9) romanout.Append(roman[11]);
                        else if (d < 9 && d > 5)
                        {
                            romanout.Append(roman[10]);
                            int r = d - 5;
                            while (r != 0)
                            {
                                romanout.Append(roman[8]);
                                r--;
                            }
                        }
                        else if (d == 5)
                            romanout.Append(roman[10]);
                        else if (d == 4)
                            romanout.Append(roman[9]);
                        else
                        {
                            int r = 0 + d;
                            while (r != 0)
                            {
                                romanout.Append(roman[8]);
                                r--;
                            }
                        }
                        type /= 10;
                    }
                    else if (type==1000)
                    {
                        int d = int.Parse(num[i].ToString());
                        if (d == 0) continue;
                        int r = 0 + d;
                        while (r != 0)
                        {
                            romanout.Append(roman[12]);
                            r--;
                        }
                        type /= 10;
                    }
                }
                Console.WriteLine("Roman:  " + romanout);
            }
            else Console.WriteLine("Number greater 3999 or less/equals 0");
        }
    }
}