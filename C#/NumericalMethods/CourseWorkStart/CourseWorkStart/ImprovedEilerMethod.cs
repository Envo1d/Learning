using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NCalc;

namespace CourseWorkStart
{
    public class ImprovedEilerMethod
    {
        public int Iterations { get; private set; }
        public double Step { get; private set; }
        public double Start { get; private set; }
        public double End { get; private set; }
        public double Y { get; private set; }
        private string Func { get; set; }
        public List<double> IterX { get; private set; }
        public List<double> IterY { get; private set; }
        public List<double> TablFunc { get; private set; }
        public List<double> HarTabFunc { get; private set; }
        public List<double> FuncSum { get; private set; }
        public List<double> LIterY { get; private set; }
        public byte Params { get; private set; } = 7;

        public ImprovedEilerMethod() { }
        public ImprovedEilerMethod(double step, double start, double end, double startY, string function) 
        { 
            Step = step; 
            Start = start;
            End = end;
            Y = startY;
            Func = function.Substring(function.IndexOf('=') + 1);
            IterX = new();
            IterY = new();
            FuncSum = new();
            TablFunc = new();
            HarTabFunc = new();
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
            while(Math.Round(x,2)<=End)
            {
                IterX.Add(x);
                IterY.Add(y);
                TablFunc.Add(GetResFromFunc(x, y));
                HarTabFunc.Add(GetResFromFunc(x + Step, y + (Step * TablFunc.Last())));
                FuncSum.Add(TablFunc.Last() + HarTabFunc.Last());
                LIterY.Add(y + ((Step / 2) * FuncSum.Last()));
                x = x + Step;
                y = LIterY.Last();
                counter++;
            }
            Iterations = counter;
        }
    }
}
