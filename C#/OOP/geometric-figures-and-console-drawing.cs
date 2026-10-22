using System;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using System.Collections;

namespace Homework
{
    #region Geometric
    /*
        1. Разработать абстрактный класс Геометрическая-
Фигура с свойствами ПлощадьФигуры и ПериметрФигуры.

Разработать классы-наследники: Треугольник, Ква-
драт, Ромб, Прямоугольник, Параллелограмм, Трапеция,
Круг, Эллипс и реализовать свойства, которые однозначно
определяют объекты данных классов.

Реализовать интерфейс ПростойНУгольник, который
имеет свойства: Высота, Основание, УголМеждуОснова-
ниемИСмежнойСтороной, КоличествоСторон, Длины-
Сторон, Площадь, Периметр.

Реализовать класс СоставнаяФигура который может
состоять из любого количества ПростыхНУгольников.
Для данного класса определить метод нахождения пло-
щади фигуры.

Предусмотреть варианты невозможности задания
фигуры (введены отрицательные длины сторон или при
создании объекта треугольника существует пара сторон,
сумма длин которых меньше длины третьей стороны и т.п.)
    */
    interface ISimpleNGon
    {
        double Height { get; }
        float FigureBase { get; }
        float AngleSideBase { get; }
        byte SidesNum { get; }
        string SidesLenght { get; }
        double FigureArea { get; }
        double FigurePerimeter { get; }
        string Name { get; }
    }

    abstract class GeometricFigure
    {
        public double FigureArea { get; set; }
        public double FigurePerimeter { get; set; }
        public string Name { get; set; }
        public string GetInfo()
        {
            return $"Name: {Name}\nPerimeter: {FigurePerimeter}\nArea: {FigureArea}\n";
        }
    }
    enum TriangleType
    {
        Versatile = 1,
        Isosceles,
        Equilateral
    }
    class Triangle : GeometricFigure, ISimpleNGon
    {
        public byte SidesNum { get { return 3; } }
        public float SideAB { get; set; }
        public float SideBC { get; set; }
        public float SideCA { get; set; }
        public double Height { get; set; }
        public float FigureBase { get; set; }
        public float AngleSideBase { get; set; }
        public string SidesLenght { get; set; }
        public float AngleA { get; set; }
        public float AngleB { get; set; }
        public float AngleC { get; set; }
        public TriangleType Type { get; set; }
        public override string ToString()
        {
            return GetInfo() + $"Type: {Type}\nSide A = {SideAB}\nSide B = {SideBC}\nSide C = {SideCA}\nAngle A = {AngleA}\nAngle B = {AngleB}\nAngle C = {AngleC}\n";
        }

        public Triangle(float sideAB, float sideBC, float sideCA, float angleA, float angleB, float angleC)
        {
            if (angleA <= 0)
                throw new Exception($"Angle A = {angleA}");
            if (angleB <= 0)
                throw new Exception($"Angle B = {angleB}");
            if (angleC <= 0)
                throw new Exception($"Angle C = {angleC}");
            if (angleA + angleB + angleC != 180)
                throw new Exception("Sum of angles not != 180");
            if (sideAB <= 0)
                throw new Exception($"Side A = {sideAB}");
            if (sideBC <= 0)
                throw new Exception($"Side B = {sideBC}");
            if (sideCA <= 0)
                throw new Exception($"Side C = {sideCA}");
            bool inequality = false;
            if (sideAB < sideBC + sideCA)
                inequality = true;
            else if (sideBC < sideAB + sideCA)
                inequality = true;
            else if (sideCA < sideAB + sideBC)
                inequality = true;
            if (inequality == false)
                throw new Exception("It is impossible to create a triangle with such sides");
            else
            {
                Name = "Triangle";
                SideAB = sideAB;
                SideBC = sideBC;
                SideCA = sideCA;
                AngleA = angleA;
                AngleB = angleB;
                AngleC = angleC;
                if (SideAB != sideBC && SideBC != SideCA && SideCA != SideAB)
                    Type = TriangleType.Versatile;
                else if ((SideAB == SideBC && SideAB != SideCA) || (SideBC == SideCA && SideBC != SideAB) || (SideAB == SideCA && SideAB != SideBC))
                    Type = TriangleType.Isosceles;
                else Type = TriangleType.Equilateral;
                FigurePerimeter = SideAB + SideBC + SideCA;
                float semiPerimeter = (SideAB + SideBC + SideCA) / 2;
                FigureArea = Math.Sqrt(semiPerimeter * (semiPerimeter + SideAB) * (semiPerimeter + SideBC) * (semiPerimeter + SideCA));
                Height = (2 * Math.Sqrt(semiPerimeter * (semiPerimeter - SideAB) * (semiPerimeter - SideBC) * (semiPerimeter - SideCA))) / SideAB;
                FigureBase = SideAB;
                AngleSideBase = AngleA;
                if (FigureBase > SideBC)
                {
                    FigureBase = SideBC;
                    AngleSideBase = AngleB;
                }
                if (FigureBase > SideCA)
                {
                    FigureBase = SideCA;
                    AngleSideBase = AngleC;
                }
                SidesLenght = $"Side A = {SideAB}\nSide B = {SideBC}\nSide C = {SideCA}\n";
            }
        }
    }
    class Square : GeometricFigure, ISimpleNGon
    {
        public float AngleSideBase { get { return 90; } }
        public byte SidesNum { get { return 4; } }
        public string SidesLenght { get { return $"All 4 sides = {FigureBase}\n"; } }
        public float FigureBase { get; set; }
        public double Diagonal { get; set; }
        public double Height { get; set; }
        public override string ToString()
        {
            return GetInfo() + $"Side = {FigureBase}\nDiagonal = {Diagonal}\n";
        }

        public Square(float side)
        {
            if (side <= 0)
                throw new Exception($"Side = {side}");
            Name = "Square";
            FigureBase = side;
            FigurePerimeter = FigureBase * 4;
            FigureArea = FigureBase * FigureBase;
            Diagonal = Math.Sqrt(2) * FigureBase;
            Height = Diagonal / 2;
        }
    }
    class Rhombus : GeometricFigure, ISimpleNGon
    {
        public double DiagonalBig { get; set; }
        public double DiagonalSml { get; set; }
        public float FigureBase { get; set; }
        public byte SidesNum { get { return 4; } }
        public string SidesLenght { get { return $"All 4 sides = {FigureBase}\n"; } }
        public double Height { get; set; }
        public float AngleBig { get; set; }
        public float AngleSml { get; set; }
        public float AngleSideBase { get; set; }
        public override string ToString()
        {
            return GetInfo() + $"Side = {FigureBase}\nDiagonal A = {DiagonalBig}\nDiagonal B = {DiagonalSml}\nHeight = {Height}\nAngle A = {AngleBig}\nAngle B = {AngleSml}\n";
        }

        public Rhombus(float side, float angleA, float angleB)
        {
            if (angleA <= 0)
                throw new Exception($"Bigger angle = {angleA}");
            if (angleB <= 0)
                throw new Exception($"Smaller angle = {angleB}");
            if (((angleA + angleB) * 2) != 360)
                throw new Exception("Sum of angles != 360");
            if (side <= 0)
                throw new Exception($"Side = {side}");
            Name = "Rhombus";
            FigureBase = side;
            AngleBig = angleA;
            AngleSml = angleB;
            DiagonalBig = 2 * side * Math.Cos(AngleSml / 2);
            DiagonalSml = 2 * side * Math.Cos(AngleBig / 2);
            Height = side * Math.Sin(AngleBig);
            FigurePerimeter = Height * 4;
            if (DiagonalBig == DiagonalSml)
                FigureArea = FigureBase * FigureBase;
            else
                FigureArea = 0.5 * (DiagonalBig * DiagonalSml);
        }
    }
    class Rectangle : GeometricFigure, ISimpleNGon
    {
        public float AngleSideBase { get { return 90; } }
        public float Lenght { get; set; }
        public float Width { get; set; }
        public float FigureBase { get; set; }
        public byte SidesNum { get { return 4; } }
        public string SidesLenght { get { return $"Lenght = {Lenght}\nWidth = {Width}\n"; } }
        public double Height { get; set; }
        public override string ToString()
        {
            return GetInfo() + $"Lenght = {Lenght}\nWidth = {Width}\n";
        }

        public Rectangle(float lenght, float width)
        {
            if (lenght <= 0)
                throw new Exception($"Lenght = {lenght}");
            if (width <= 0)
                throw new Exception($"Width = {width}");
            Name = "Rectangle";
            Lenght = lenght;
            Width = width;
            FigurePerimeter = (Lenght + Width) * 2;
            FigureArea = Lenght * Width;
            FigureBase = lenght;
            Height = width;
        }
    }
    class Parallelogram : GeometricFigure, ISimpleNGon
    {
        public float SideA { get; set; }
        public float SideB { get; set; }
        public double DiagonalA { get; set; }
        public double DiagonalB { get; set; }
        public float FigureBase { get; set; }
        public float AngleSideBase { get; set; }
        public byte SidesNum { get { return 4; } }
        public string SidesLenght { get { return $"Side A,C = {SideA}\nSide B,D = {SideB}\n"; } }
        public double Height { get; set; }
        public float AngleA { get; set; }
        public float AngleB { get; set; }
        public override string ToString()
        {
            return GetInfo() + $"Side A,C = {SideA}\nSide B,D = {SideB}\nDiagonal A = {DiagonalA}\nDiagonal B = {DiagonalB}\nAngle A,C = {AngleA}\nAngle B,D = {AngleB}\n";
        }

        public Parallelogram(float side1, float side2, float a, float b)
        {
            if (side1 <= 0)
                throw new Exception($"Side A = {side1}");
            if (side2 <= 0)
                throw new Exception($"Side B = {side2}");
            if (a <= 0)
                throw new Exception($"Angle A = {a}");
            if (b <= 0)
                throw new Exception($"Angle B = {b}");
            if (a + b != 180)
                throw new Exception("It's not a parallelogram");
            Name = "Parallelogram";
            AngleA = a;
            AngleB = b;
            DiagonalA = Math.Sqrt((SideA * SideA) + (SideB * SideB) + (2 * SideA * SideB * Math.Cos(b)));
            DiagonalB = Math.Sqrt((SideA * SideA) + (SideB * SideB) - (2 * SideA * SideB * Math.Cos(b)));
            FigurePerimeter = (SideA + SideB) * 2;
            double semiPerimeter = (SideA + SideB + DiagonalA) / 2;
            FigureArea = Math.Sqrt(semiPerimeter * (semiPerimeter + SideA) * (semiPerimeter * SideB) * (semiPerimeter * DiagonalA));
            Height = FigureArea / SideB;
            FigureBase = SideB;
            AngleSideBase = AngleB;
        }
    }
    enum TrapezoidType
    {
        IsoscelesTrapezoid = 1,
        RectangularTrapezoid
    }
    class Trapezoid : GeometricFigure, ISimpleNGon
    {
        public float BaseA { get; set; }
        public float BaseB { get; set; }
        public float SideA { get; set; }
        public float SideB { get; set; }
        public TrapezoidType Type { get; set; }
        public double Height { get; set; }
        public float AngleSideABaseA { get; set; }
        public float AngleSideABaseB { get; set; }
        public float AngleSideBBaseA { get; set; }
        public float AngleSideBBaseB { get; set; }
        public float FigureBase { get { return BaseB; } }
        public float AngleSideBase { get { return AngleSideABaseA; } }
        public byte SidesNum { get { return 4; } }
        public string SidesLenght { get { return $"Base A = {BaseA}\nBase B = {BaseB}\nSide A = {SideA}\nSide B = {SideB}"; } }
        public override string ToString()
        {
            return GetInfo() + $"Type: {Type}\nBase A = {BaseA}\nBase B = {BaseB}\nSide A = {SideA}\nSide B = {SideB}\nAngle A = {AngleSideABaseA}\nAngle B = {AngleSideABaseB}\nAngle C = {AngleSideBBaseA}\nAngle D = {AngleSideBBaseB}";
        }

        public Trapezoid(float baseA, float baseB, float sideA, float sideB, float anglAA, float anglAB, float anglBA, float anglBB)
        {
            if (anglAA + anglAB + anglBA + anglBB != 360)
                throw new Exception("Sum of angles != 360⁰");
            if ((anglAA == 90 && anglAB == 90) || (anglBA == 90 && anglBB == 90))
                Type = TrapezoidType.RectangularTrapezoid;
            else Type = TrapezoidType.IsoscelesTrapezoid;
            if (baseA <= 0)
                throw new Exception($"Base A = {baseA}");
            if (baseB <= 0)
                throw new Exception($"Base B = {baseB}");
            if (sideA <= 0)
                throw new Exception($"Side A = {sideA}");
            if (sideB <= 0)
                throw new Exception($"Side B = {sideB}");
            Name = "Trapezoid";
            BaseA = baseA;
            BaseB = baseB;
            SideA = sideA;
            SideB = sideB;
            AngleSideABaseA = anglAA;
            AngleSideABaseB = anglAB;
            AngleSideBBaseA = anglBA;
            AngleSideBBaseB = anglBB;
            Height = Math.Sqrt((SideA * SideA) - 0.25 * Math.Pow((((SideA * SideA) - (SideB * SideB)) / (BaseB - BaseA)) + (BaseB - BaseA), 2));
            FigurePerimeter = BaseA + BaseB + SideA + SideB;
            FigureArea = 0.5 * (BaseA + BaseB) * Height;
        }
    }
    class Circle : GeometricFigure
    {
        public float Radius { get; set; }
        public float Diameter { get; set; }
        public override string ToString()
        {
            return GetInfo() + $"Radius = {Radius}\nDiameter = {Diameter}\n";
        }
        public Circle(float rad)
        {
            if (rad <= 0)
                throw new Exception($"Radius = {rad}");
            Name = "Circle";
            Diameter = 2 * rad;
            Radius = rad;
            FigureArea = Math.PI * (Radius * Radius);
            FigurePerimeter = Math.PI * Diameter;
        }
    }
    class Ellipse : GeometricFigure
    {
        public float SemiMajorAxis { get; set; }
        public float SemiMinorAxis { get; set; }
        public override string ToString()
        {
            return GetInfo() + $"Semi-major axis = {SemiMajorAxis}\nSemi-minor axis = {SemiMinorAxis}";
        }

        public Ellipse(float majAx, float minAx)
        {
            if (majAx <= 0)
                throw new Exception($"Semi-major axis = {SemiMajorAxis}");
            if (minAx <= 0)
                throw new Exception($"Semi-minor axis = {SemiMinorAxis}");
            Name = "Ellipse";
            FigurePerimeter = (Math.PI * SemiMajorAxis * SemiMinorAxis + (SemiMajorAxis - SemiMinorAxis)) / (SemiMajorAxis + SemiMinorAxis);
            FigureArea = Math.PI * SemiMajorAxis * SemiMinorAxis;
        }
    }
    class CompoundFigure
    {
        List<ISimpleNGon> nGons = new List<ISimpleNGon>();

        public void AddTriangle(float sideAB, float sideBC, float sideCA, float angleA, float angleB, float angleC)
            => nGons.Add(new Triangle(sideAB, sideBC, sideCA, angleA, angleB, angleC));
        public void AddSquare(float side)
            => nGons.Add(new Square(side));
        public void AddRhombus(float side, float angleA, float angleB)
            => nGons.Add(new Rhombus(side, angleA, angleB));
        public void AddRectangle(float lenght, float width)
            => nGons.Add(new Rectangle(lenght, width));
        public void AddParallelogram(float side1, float side2, float a, float b)
            => nGons.Add(new Parallelogram(side1, side2, a, b));
        public void AddTrapezoid(float baseA, float baseB, float sideA, float sideB, float anglAA, float anglAB, float anglBA, float anglBB)
            => nGons.Add(new Trapezoid(baseA, baseB, sideA, sideB, anglAA, anglAB, anglBA, anglBB));
        public void ShowHeights()
        {
            foreach (var figure in nGons)
                Console.WriteLine($"{figure.Name}\nHeight: {figure.Height}\n");
        }
        public void ShowBasesAndAnglesNear()
        {
            foreach (var figure in nGons)
                Console.WriteLine($"{figure.Name}\nBase = {figure.FigureBase}\nAngle = {figure.AngleSideBase}\n");
        }
        public void ShowSidesNumAndLengths()
        {
            foreach (var figure in nGons)
                Console.WriteLine($"{figure.Name}\nSides num = {figure.SidesNum}\nSides length:\n{figure.SidesLenght}\n");
        }
        public void ShowAreasAndPerimeter()
        {
            foreach (var figure in nGons)
                Console.WriteLine($"{figure.Name}\nArea = {figure.FigureArea}\nPerimeter = {figure.FigurePerimeter}\n");
        }
        public double FigureArea()
        {
            double result = 0;
            foreach (var figure in nGons)
                result += figure.FigureArea;
            return result;
        }
        public bool IsCreated()
        {
            if (nGons.Count == 0)
                return false;
            return true;
        }
    }
    class UITask1
    {
        CompoundFigure figure = new CompoundFigure();

        public void Add()
        {
            var key = new ConsoleKeyInfo();
            Console.Clear();
            Console.WriteLine("1 - Add triangle\n2 - Add square\n3 - Add rhombus\n4 - Add rectangle\n5 - Add parallelogram\n6 - Add trapezoid");
            key = Console.ReadKey(true);
            switch (key.Key)
            {
                case ConsoleKey.D1:
                    Console.Clear();
                    Console.WriteLine("Enter AB side:");
                    float sideAb = Convert.ToSingle(Console.ReadLine());
                    Console.WriteLine("Enter BC side:");
                    float sideBc = Convert.ToSingle(Console.ReadLine());
                    Console.WriteLine("Enter Ca side:");
                    float sideCa = Convert.ToSingle(Console.ReadLine());
                    Console.WriteLine("Enter angle A:");
                    float angleA = Convert.ToSingle(Console.ReadLine());
                    Console.WriteLine("Enter angle B:");
                    float angleB = Convert.ToSingle(Console.ReadLine());
                    Console.WriteLine("Enter angle C:");
                    float angleC = Convert.ToSingle(Console.ReadLine());
                    figure.AddTriangle(sideAb, sideBc, sideCa, angleA, angleB, angleC);
                    Console.ReadKey();
                    break;
                case ConsoleKey.D2:
                    Console.Clear();
                    Console.WriteLine("Enter square side lenght:");
                    float squareSide = Convert.ToSingle(Console.ReadLine());
                    figure.AddSquare(squareSide);
                    Console.ReadKey();
                    break;
                case ConsoleKey.D3:
                    Console.Clear();
                    Console.WriteLine("Enter rhombus side lenght:");
                    float rhombusSide = Convert.ToSingle(Console.ReadLine());
                    Console.WriteLine("Enter bigger angle:");
                    float bigangle = Convert.ToSingle(Console.ReadLine());
                    Console.WriteLine("Enter smaller angle:");
                    float smlangle = Convert.ToSingle(Console.ReadLine());
                    if (smlangle > bigangle)
                    {
                        float tmp = bigangle;
                        bigangle = smlangle;
                        smlangle = tmp;
                    }
                    figure.AddRhombus(rhombusSide, bigangle, smlangle);
                    Console.ReadKey();
                    break;
                case ConsoleKey.D4:
                    Console.Clear();
                    Console.WriteLine("Enter rectangle lenght:");
                    float lenght = Convert.ToSingle(Console.ReadLine());
                    Console.WriteLine("Enter rectangle width:");
                    float width = Convert.ToSingle(Console.ReadLine());
                    if (lenght != width)
                        figure.AddRectangle(lenght, width);
                    else figure.AddSquare(lenght);
                    Console.ReadKey();
                    break;
                case ConsoleKey.D5:
                    Console.Clear();
                    Console.WriteLine("Enter side AD :");
                    float side1 = Convert.ToSingle(Console.ReadLine());
                    Console.WriteLine("Enter side BC :");
                    float side2 = Convert.ToSingle(Console.ReadLine());
                    if (side1 == side2)
                        figure.AddSquare(side1);
                    else
                    {
                        Console.WriteLine("Enter angle <BAD:");
                        float a = Convert.ToSingle(Console.ReadLine());
                        Console.WriteLine("Enter angle <CDA");
                        float b = Convert.ToSingle(Console.ReadLine());
                        figure.AddParallelogram(side1, side2, a, b);
                    }
                    Console.ReadKey();
                    break;
                case ConsoleKey.D6:
                    Console.Clear();
                    Console.WriteLine("Enter smaller base (a):");
                    float basea = Convert.ToSingle(Console.ReadLine());
                    Console.WriteLine("Enter bigger base (b):");
                    float baseb = Convert.ToSingle(Console.ReadLine());
                    Console.WriteLine("Enter side A:");
                    float sidea = Convert.ToSingle(Console.ReadLine());
                    Console.WriteLine("Enter side B:");
                    float sideb = Convert.ToSingle(Console.ReadLine());
                    Console.WriteLine("Enter angle between side A and base a");
                    float angleaa = Convert.ToSingle(Console.ReadLine());
                    Console.WriteLine("Enter angle between side A and base b");
                    float angleab = Convert.ToSingle(Console.ReadLine());
                    Console.WriteLine("Enter angle between side B and base a");
                    float angleba = Convert.ToSingle(Console.ReadLine());
                    Console.WriteLine("Enter angle between side B and base b");
                    float anglebb = Convert.ToSingle(Console.ReadLine());
                    figure.AddTrapezoid(basea, baseb, sidea, sideb, angleaa, angleab, angleba, anglebb);
                    Console.ReadKey();
                    break;
            }
        }
        public void Show()
        {
            if (!figure.IsCreated())
                throw new Exception("Figure not created!");
            ConsoleKeyInfo key = new ConsoleKeyInfo();
            Console.Clear();
            Console.WriteLine("1 - Show heights\n2 - Show info about sides\n3 - Show areas and perimeters\n4 - Show bases and angles");
            key = Console.ReadKey(true);
            switch (key.Key)
            {
                case ConsoleKey.D1:
                    Console.Clear();
                    figure.ShowHeights();
                    Console.ReadKey();
                    break;
                case ConsoleKey.D2:
                    Console.Clear();
                    figure.ShowSidesNumAndLengths();
                    Console.ReadKey();
                    break;
                case ConsoleKey.D3:
                    Console.Clear();
                    figure.ShowAreasAndPerimeter();
                    Console.ReadKey();
                    break;
                case ConsoleKey.D4:
                    Console.Clear();
                    figure.ShowBasesAndAnglesNear();
                    Console.ReadKey();
                    break;
            }
        }
        public void CalculateArea()
        {
            if (!figure.IsCreated())
                throw new Exception("Figure not created!");
            double result = figure.FigureArea();
            Console.WriteLine($"Total figure area = {result}");
        }
    }
    #endregion
    #region Draw
    /*
        2. Написать приложение, которое будет отображать
в консоли простейшие геометрические фигуры заданные
пользователем. Пользователь выбирает фигуру и задает ее
расположение на экране, а также размер и цвет с помощью
меню. Все заданные пользователем фигуры отобража-
ются одновременно на экране. Фигуры (прямоугольник,
ромб, треугольник, трапеция, многоугольник) рисуются
звездочками или другими символами. Для реализации
программы необходимо разработать иерархию классов
(продумать возможность абстрагирования).
Для хранения всех, заданных пользователем фигур,
создать класс «Коллекция геометрических фигур» с ме-
тодом «Отобразить все фигуры». Чтобы отобразить все
фигуры указанным методом требуется использовать
оператор foreach, для чего в классе «Коллекция геометри-
ческих фигур» необходимо реализовать соответствующие
интерфейсы.
    */
    abstract class BaseFigure
    {
        public byte Base { get; set; }
        public ConsoleColor Color { get; set; }
        public virtual void Draw() { Console.WriteLine("Base"); }
        public int PosX { get; set; }
        public int PosY { get; set; }
    }
    class RectangleD : BaseFigure
    {
        public override string ToString()
        {
            Draw();
            return "";
        }
        public byte Height { get; set; }
        public override void Draw()
        {
            Console.ForegroundColor = Color;
            for (int i = 0; i < Height; i++)
            {
                Console.SetCursorPosition(PosX, PosY + i);
                for (int j = 0; j < Base; j++)
                {
                    Console.Write("*");
                }
            }
        }
    }
    class TriangleD : BaseFigure
    {
        public override string ToString()
        {
            Draw();
            return "";
        }
        public override void Draw()
        {
            Console.ForegroundColor = Color;
            PosY += Base - 1;
            for (int i = 0; i < Base - (Base / 2); i++)
            {
                Console.SetCursorPosition(PosX + i, PosY - i);
                for (int j = 0; j < (Base / 2) - i + 1; j++)
                {
                    Console.Write("*");
                }
                for (int j = 1; j < (Base / 2) - i + 1; j++)
                {
                    Console.Write("*");
                }
            }
        }
    }
    class RectangularTriangle : BaseFigure
    {
        public override string ToString()
        {
            Draw();
            return "";
        }
        public override void Draw()
        {
            Console.ForegroundColor = Color;
            PosY += Base - 1;
            for (int i = 0; i < Base; i++)
            {
                Console.SetCursorPosition(PosX + i, PosY - i);
                for (int j = 0; j < Base - i; j++)
                {
                    Console.Write("*");
                }
            }
        }
    }
    class RhombusD : BaseFigure
    {
        public override string ToString()
        {
            Draw();
            return "";
        }
        public override void Draw()
        {
            Console.ForegroundColor = Color;
            PosY += Base - 1;
            for (int i = 0; i < Base - (Base / 2); i++)
            {
                Console.SetCursorPosition(PosX + i, PosY - i);
                for (int j = 0; j < (Base / 2) - i + 1; j++)
                {
                    Console.Write("*");
                }
                for (int j = 1; j < (Base / 2) - i + 1; j++)
                {
                    Console.Write("*");
                }
            }
            for (int i = 0; i < Base; i++)
            {
                Console.SetCursorPosition(PosX + i, PosY + i);
                for (int j = (Base / 2) - i + 1; j > 0; j--)
                {
                    Console.Write("*");
                }
                for (int j = (Base / 2) - i + 1; j > 1; j--)
                {
                    Console.Write("*");
                }
            }
        }
    }
    class TrapezoidD : BaseFigure
    {
        public override string ToString()
        {
            Draw();
            return "";
        }
        public byte BaseB { get; set; }

        public override void Draw()
        {
            Console.ForegroundColor = Color;
            for (int i = 0; i <= BaseB - Base; i++)
            {
                Console.SetCursorPosition(PosX, PosY + i);
                for (int j = 0; j < Base + i; j++)
                {
                    Console.Write("*");
                }
            }
        }
    }
    class Polygon : BaseFigure
    {
        public override string ToString()
        {
            Draw();
            return "";
        }
        public override void Draw()
        {
            Console.ForegroundColor = Color;

            int Base2 = Base;
            PosY += Base + (Base / 2);
            for (int i = 0; i < Base; i++)
            {
                Console.SetCursorPosition(PosX + i, PosY + i);
                for (int j = Base + i; j < Base + Base + Base - 2; j++)
                {
                    Console.Write("*");
                }
                for (int j = Base + i; j < Base + Base; j++)
                {
                    Console.Write("*");
                }
            }
            Base2 = Increase(Base2, Base - 1);
            PosY -= Base + (Base / 2);
            PosY += Base + (Base / 2);
            for (int i = 0; i < Base2 - (Base2 / 2); i++)
            {
                Console.SetCursorPosition(PosX + i, PosY - i);
                for (int j = 0; j < (Base2 / 2) - i + 1; j++)
                {
                    Console.Write("*");
                }
                for (int j = 1; j < (Base2 / 2) - i + 1; j++)
                {
                    Console.Write("*");
                }
            }

        }
        int Increase(int i, int j)
        {
            if (j <= 0) return i;
            else
            {
                j--;
                i += 2;
                return Increase(i, j);
            }
        }
    }
    class FigureCollection : IEnumerable
    {
        List<BaseFigure> figures = new List<BaseFigure>();

        public void AddTriangle(byte side, ConsoleColor color, int x, int y, bool type)
        {
            if (type == false)
            {
                figures.Add(new TriangleD { Base = side, Color = color, PosX = x, PosY = y });
            }
            else
            {
                figures.Add(new RectangularTriangle { Base = side, Color = color, PosX = x, PosY = y });
            }
        }
        public void AddTrapezoid(byte baseA, byte baseB, ConsoleColor color, int x, int y)
          =>  figures.Add(new TrapezoidD { Base = baseA, BaseB = baseB, Color = color, PosX = x, PosY = y });
        public void AddRectangle(byte side, byte height, int x, int y, ConsoleColor color)
          => figures.Add(new RectangleD { Base = side, Height = height, Color = color, PosX = x, PosY = y });
        public void AddRhombus(byte side, ConsoleColor color, int x, int y)
            => figures.Add(new RhombusD { Base = side, Color = color, PosX = x, PosY = y });
        public void AddPolygon(byte side, ConsoleColor color, int x, int y)
            => figures.Add(new Polygon { Base = side, Color = color, PosX = x, PosY = y });
        public void DrawAll()
        {
            foreach (object figure in this)
                try { Console.WriteLine(figure); } catch (Exception msg) { continue; }
        }
        public IEnumerator GetEnumerator()
        {
            return figures.GetEnumerator();
        }
    }
    class FiguresUI
    {
        FigureCollection fc = new FigureCollection();

        public void Add()
        {
            var key = new ConsoleKeyInfo();
            Console.Clear();
            Console.WriteLine("1 - Создать треугольник\n2 - Создать прямоугольник\n3 - Создать ромб\n4 - Создать трапецию\n5 - Создать пятиугольник\n");
            key = Console.ReadKey(true);
            switch (key.Key)
            {
                case ConsoleKey.D1:
                    Console.Clear();
                    Console.WriteLine("Размер окна X = 100, Y = 50 символов\n");
                    Console.WriteLine("Введите размер стороны (кол-во символов):");
                    byte side = Convert.ToByte(Console.ReadLine());
                    string[] colors = Enum.GetNames(typeof(ConsoleColor));
                    foreach(var clr in colors)
                        Console.WriteLine(clr);
                    Console.WriteLine("Введите цвет фигуры:");
                    string col = Console.ReadLine();
                    ConsoleColor color = (ConsoleColor)Enum.Parse(typeof(ConsoleColor), col);
                    Console.WriteLine("Введите отступ влево по Х:");
                    int x = Convert.ToInt32(Console.ReadLine());
                    Console.WriteLine("Введите отступ вниз по Y:");
                    int y = Convert.ToInt32(Console.ReadLine());
                    Console.WriteLine("Треугольник прямоугольный/равносторонний (y/n):");
                    bool type = false;
                Choice:
                    key = Console.ReadKey(true);
                    if (key.Key == ConsoleKey.Y)
                        type = true;
                    else if (key.Key == ConsoleKey.N)
                        type = false;
                    else goto Choice;
                    fc.AddTriangle(side, color, x, y, type);
                    Console.ReadKey();
                    break;
                case ConsoleKey.D2:
                    Console.Clear();
                    Console.WriteLine("Размер окна X = 100, Y = 50 символов\n");
                    Console.WriteLine("Введите длину прямоугольника (кол-во символов):");
                    side = Convert.ToByte(Console.ReadLine());
                    Console.WriteLine("Введите высоту прямоугольника (кол-во символов):");
                    byte height = Convert.ToByte(Console.ReadLine());
                    colors = Enum.GetNames(typeof(ConsoleColor));
                    foreach (var clr in colors)
                        Console.WriteLine(clr);
                    Console.WriteLine("Введите цвет фигуры:");
                    col = Console.ReadLine();
                    color = (ConsoleColor)Enum.Parse(typeof(ConsoleColor), col);
                    Console.WriteLine("Введите отступ влево по Х:");
                    x = Convert.ToInt32(Console.ReadLine());
                    Console.WriteLine("Введите отступ вниз по Y:");
                    y = Convert.ToInt32(Console.ReadLine());
                    fc.AddRectangle(side, height, x, y, color);
                    Console.ReadKey();
                    break;
                case ConsoleKey.D3:
                    Console.Clear();
                    Console.WriteLine("Размер окна X = 100, Y = 50 символов\n");
                    Console.WriteLine("Введите сторону ромба (кол-во символов):");
                    side = Convert.ToByte(Console.ReadLine());
                    colors = Enum.GetNames(typeof(ConsoleColor));
                    foreach (var clr in colors)
                        Console.WriteLine(clr);
                    Console.WriteLine("Введите цвет фигуры:");
                    col = Console.ReadLine();
                    color = (ConsoleColor)Enum.Parse(typeof(ConsoleColor), col);
                    Console.WriteLine("Введите отступ влево по Х:");
                    x = Convert.ToInt32(Console.ReadLine());
                    Console.WriteLine("Введите отступ вниз по Y:");
                    y = Convert.ToInt32(Console.ReadLine());
                    fc.AddRhombus(side, color, x, y);
                    Console.ReadKey();
                    break;
                case ConsoleKey.D4:
                    Console.Clear();
                    Console.WriteLine("Размер окна X = 100, Y = 50 символов\n");
                    Console.WriteLine("Введите длину меньшей основы (кол-во символов):");
                    side = Convert.ToByte(Console.ReadLine());
                    Console.WriteLine("Введите длину большей основы (кол-во символов):");
                    byte baseB = Convert.ToByte(Console.ReadLine());
                    colors = Enum.GetNames(typeof(ConsoleColor));
                    foreach (var clr in colors)
                        Console.WriteLine(clr);
                    Console.WriteLine("Введите цвет фигуры:");
                    col = Console.ReadLine();
                    color = (ConsoleColor)Enum.Parse(typeof(ConsoleColor), col);
                    Console.WriteLine("Введите отступ влево по Х:");
                    x = Convert.ToInt32(Console.ReadLine());
                    Console.WriteLine("Введите отступ вниз по Y:");
                    y = Convert.ToInt32(Console.ReadLine());
                    fc.AddTrapezoid(side, baseB, color, x, y);
                    Console.ReadKey();
                    break;
                case ConsoleKey.D5:
                    Console.Clear();
                    Console.WriteLine("Размер окна X = 100, Y = 50 символов\n");
                    Console.WriteLine("Введите размер стороны (кол-во символов):");
                    side = Convert.ToByte(Console.ReadLine());
                    colors = Enum.GetNames(typeof(ConsoleColor));
                    foreach (var clr in colors)
                        Console.WriteLine(clr);
                    Console.WriteLine("Введите цвет фигуры:");
                    col = Console.ReadLine();
                    color = (ConsoleColor)Enum.Parse(typeof(ConsoleColor), col);
                    Console.WriteLine("Введите отступ влево по Х:");
                    x = Convert.ToInt32(Console.ReadLine());
                    Console.WriteLine("Введите отступ вниз по Y:");
                    y = Convert.ToInt32(Console.ReadLine());
                    fc.AddPolygon(side, color, x, y);
                    Console.ReadKey();
                    break;
            }
        }
        public void Show()
        {
            Console.WriteLine("Фигуры рисуються по очереди добавления и могут пересекаться\nЕсли фигура не дорисована - вышла за пределы экрана\n");
            Console.ReadKey();
            Console.Clear();
            fc.DrawAll();
            Console.ReadKey();
            Console.ForegroundColor = ConsoleColor.White;
        }
    }
    #endregion
    class Program
    {

        static void Main(string[] arg)
        {
            var key = new ConsoleKeyInfo();
            Console.WriteLine("1 - Task 1\n2 - Task 2");
        Key:
            key = Console.ReadKey(true);
            if (key.Key == ConsoleKey.D1)
                Task1();
            else if (key.Key == ConsoleKey.D2)
                Task2();
            else goto Key;
        }
        static void Task1()
        {
            UITask1 n = new UITask1();
            ConsoleKeyInfo key = new ConsoleKeyInfo();
            do
            {
                Console.Clear();
                Console.WriteLine("Compound Figure\n");
                Console.WriteLine("1 - Add new figure\n2 - Show info\n3 - Calculate figure area\nEsc - выход");
                key = Console.ReadKey(true);
                try
                {
                    switch (key.Key)
                    {
                        case ConsoleKey.D1:
                            Console.Clear();
                            n.Add();
                            Console.ReadKey();
                            break;
                        case ConsoleKey.D2:
                            Console.Clear();
                            n.Show();
                            Console.ReadKey();
                            break;
                        case ConsoleKey.D3:
                            Console.Clear();
                            n.CalculateArea();
                            Console.ReadKey();
                            break;
                    }
                }
                catch (Exception msg) { Console.WriteLine(msg.Message); Console.ReadKey(); }
            } while (key.Key != ConsoleKey.Escape);
        }

        private const int MF_BYCOMMAND = 0x00000000;
        public const int SC_CLOSE = 0xF060;
        public const int SC_MINIMIZE = 0xF020;
        public const int SC_MAXIMIZE = 0xF030;
        public const int SC_SIZE = 0xF000;

        [DllImport("user32.dll")]
        public static extern int DeleteMenu(IntPtr hMenu, int nPosition, int wFlags);

        [DllImport("user32.dll")]
        private static extern IntPtr GetSystemMenu(IntPtr hWnd, bool bRevert);

        [DllImport("kernel32.dll", ExactSpelling = true)]
        private static extern IntPtr GetConsoleWindow();
        static void Task2()
        {
            Console.SetWindowSize(100, 50);
            IntPtr handle = GetConsoleWindow();
            IntPtr sysMenu = GetSystemMenu(handle, false);
            if (handle != IntPtr.Zero)
            {
                DeleteMenu(sysMenu, SC_MINIMIZE, MF_BYCOMMAND);
                DeleteMenu(sysMenu, SC_MAXIMIZE, MF_BYCOMMAND);
                DeleteMenu(sysMenu, SC_SIZE, MF_BYCOMMAND);
            }
            FiguresUI n = new FiguresUI();
            ConsoleKeyInfo key = new ConsoleKeyInfo();
            do
            {
                Console.Clear();
                Console.WriteLine("1 - Создать фигуру\n2 - Нарисовать все фигуры\nEsc - выход");
                key = Console.ReadKey(true);
                try
                {
                    switch (key.Key)
                    {
                        case ConsoleKey.D1:
                            Console.Clear();
                            n.Add();
                            Console.ReadKey();
                            break;
                        case ConsoleKey.D2:
                            Console.Clear();
                            n.Show();
                            Console.ReadKey();
                            break;
                    }
                }
                catch (Exception msg) { Console.WriteLine(msg.Message); Console.ReadKey(); }
            } while (key.Key != ConsoleKey.Escape);
        }
    }
}