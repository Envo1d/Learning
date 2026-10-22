using NCalc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CourseWorkStart
{
    public class RungeKuttaMethod
    {
        public int Iterations { get; private set; }
        public double Step { get; private set; }
        public double Start { get; private set; }
        public double End { get; private set; }
        public double Y { get; private set; }
        private string Func { get; set; }
        public List<double> IterX { get; private set; }
        public List<double> IterY { get; private set; }
        public List<double> K1 { get; private set; }
        public List<double> K2 { get; private set; }
        public List<double> K3 { get; private set; }
        public List<double> K4 { get; private set; }
        public List<double> LIterY { get; private set; }
        public byte Params { get; private set; } = 8;

        public RungeKuttaMethod() { }

        public RungeKuttaMethod(double step, double start, double end, double startY, string function)
        {
            Step = step;
            Start = start;
            End = end;
            Y = startY;
            Func = function.Substring(function.IndexOf('=') + 1);
            IterX = new();
            IterY = new();
            K1 = new();
            K2 = new();
            K3 = new();
            K4 = new();
            LIterY = new();
        }

        private double GetResFromFunc(double x, double y)
        {
            Expression e = new Expression(Func);
            if (Func.Contains("y"))
                e.Parameters["y"] = y;
            e.Parameters["x"] = x;
            if (Func.Contains("Pi"))
                e.Parameters["Pi"] = Math.PI;
            if (Func.Contains("E"))
                e.Parameters["E"] = Math.E;
            if (Func.Contains("Cot"))
                e.Parameters["Cot"] = new Expression("1 / Tan(x)");
            if (Func.Contains("x^2"))
                e.Parameters["x^2"] = new Expression("x * [x]");
            if (Func.Contains("y^2"))
                e.Parameters["y^2"] = new Expression("y * [y]");
            double res = Convert.ToDouble(e.Evaluate());
            return res;
        }

        public void Calculate()
        {
            int counter = 0;
            double x, y;
            x = Start;
            y = Y;
            while (Math.Round(x, 2) <= End)
            {
                IterX.Add(x);
                IterY.Add(y);
                K1.Add(GetResFromFunc(x, y));
                K2.Add(GetResFromFunc(x + (Step / 2), y + ((Step * K1.Last()) / 2)));
                K3.Add(GetResFromFunc(x + (Step / 2), y + ((Step * K2.Last()) / 2)));
                K4.Add(GetResFromFunc(x + Step, y + (Step * K3.Last())));
                LIterY.Add((Step / 6) * (K1.Last() + (2 * K2.Last()) + (2 * K3.Last()) + K4.Last()));
                x = x + Step;
                y = y + LIterY.Last();
                counter++;
            }
            Iterations = counter;
        }
    }
}
