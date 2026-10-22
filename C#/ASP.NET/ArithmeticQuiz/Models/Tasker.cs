using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ASP_HW2.Models
{
    public static class Tasker
    {
        public static byte Counter { get; set; } = 0;
        public static int CorrectAnswer { get; set; }
        public static string CurrentQuestion { get; set; }
        public static string TimerFormat { get; } = "mm:ss";
        public static DateTime Timer { get; private set; } = DateTime.ParseExact("03:00", TimerFormat, CultureInfo.InvariantCulture);

        private static Random rnd = new();

        public static string GetTask()
        {
            int a, b;
            a = rnd.Next(0, 201);
            b = rnd.Next(0, 201);
            if (Counter<=5)
            {
                Counter++;
                CorrectAnswer = a + b;
                CurrentQuestion = $"{a} + {b}";
                return CurrentQuestion;
            }
            else
            {
                Counter++;
                CorrectAnswer = a - b;
                CurrentQuestion = $"{a} - {b}";
                return CurrentQuestion;
            }
        }
    }
}