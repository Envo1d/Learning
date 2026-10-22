using System;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using System.Threading;

namespace Homework
{
    /*
     Игра "Автомобильные гонки"
Разработать игру "Автомобильные гонки" с использованием событий.

1. В игре используется несколько типов автомобилей: спортивные, легковые, грузовые и автобусы.

2. Реализовать игру "Гонки". Принцып игры: Автомобили двигаются от старта к финишу
со скоростями, которые изменяются в установленных пределах случайным образом.
Победителем считается автомобиль, пришедший к финишу первым.

Рекомендации по выполнению работы:

1. Разработать абстрактный класс "автомобиль"
(класс Car). Собрать в нем общие поля, свойства
(например, скорость) методы (например, ехать).

2. Разработать классы автомобилей с конкретной
реализацией конструкторов и методов, свойств.
В классы автомобилей добавить необходимые события (например, финиш).

3. Класс игра должен производить запуск соревнований
автомобилей, выводить сообщения о текущем
положении автомобилей, сообщение об автомобиле,
победившем в гонках. Создать делегаты,
обеспечивающие вызов методов из классов
автомобилей (например, выйти на старт, начать гонку).

4. Игра заканчивается, когда какой-то из автомобилей
проехал определенное растояние (старт в положении 0, 
финиш в положении 100). Уведомление об окончании гонки (прибытии какого-либо автомобиля на финиш)
реализовать с помощью делегатов.
    */
    #region GameClasses
    class PrimitiveGraphics
    {
        public int PosX { get; set; }
        public int PosY { get; set; }

        byte stripPos = 10;

        int standartX = 5;
        int standartY = 20;

        private const int MF_BYCOMMAND = 0x00000000;
        public const int SC_MAXIMIZE = 0xF030;
        public const int SC_SIZE = 0xF000;

        [DllImport("user32.dll")]
        public static extern int DeleteMenu(IntPtr hMenu, int nPosition, int wFlags);

        [DllImport("user32.dll")]
        private static extern IntPtr GetSystemMenu(IntPtr hWnd, bool bRevert);

        [DllImport("kernel32.dll", ExactSpelling = true)]
        private static extern IntPtr GetConsoleWindow();
        public PrimitiveGraphics()
        {
            Console.SetWindowSize(160, 60);

            IntPtr handle = GetConsoleWindow();
            IntPtr sysMenu = GetSystemMenu(handle, false);
            if (handle != IntPtr.Zero)
            {
                DeleteMenu(sysMenu, SC_MAXIMIZE, MF_BYCOMMAND);
                DeleteMenu(sysMenu, SC_SIZE, MF_BYCOMMAND);
            }
        }
        public void DrawRace()
        {
            for (int i = 0; i < 61; i++)
            {
                Console.ForegroundColor = ConsoleColor.White;
                if (i != stripPos)
                {
                    Console.SetCursorPosition(1, i);
                    Console.Write("$");
                    Console.SetCursorPosition(158, i);
                    Console.Write("$");
                }
                else
                {
                    Console.SetCursorPosition(0, i);
                    Console.Write("$$$");
                    Console.SetCursorPosition(157, i);
                    Console.Write("$$$");
                }
                stripPos += 10;
                if (stripPos > 60)
                    stripPos = 10;
            }
        }
        public void Draw(SportCar sport)
        {
            if (sport.Number == 1)
            { PosX = standartX; }
            else PosX += 15;
            PosY = standartY;
            PosX += sport.Number + 5;
            PosY += sport.Position;
            Console.SetCursorPosition(PosX, PosY);
            Console.ForegroundColor = (ConsoleColor)sport.Color;
            Console.SetCursorPosition(PosX--, PosY++);
            Console.Write("#");
            Console.SetCursorPosition(PosX++, PosY++);
            Console.Write("###");
            Console.SetCursorPosition(PosX--, PosY++);
            Console.Write("#");
            Console.SetCursorPosition(PosX++, PosY++);
            Console.Write("###");
            Console.ForegroundColor = ConsoleColor.White;
            PosY++;
            Console.SetCursorPosition(PosX -= 3, PosY++);
            Console.Write($"Speed: {Math.Round(sport.Speed, 1)}");
            Console.SetCursorPosition(PosX, PosY++);
            Console.Write($"Distance: {Math.Round(sport.DrivenDistance, 1)}");
            Console.SetCursorPosition(PosX, PosY++);
            Console.Write($"Driver: {sport.DriverName}");

        }

        public void Draw(StandartCar car)
        {
            if (car.Number == 1)
                PosX = standartX;
            else PosX += 15;
            PosY = standartY;
            PosX += car.Number + 5;
            PosY += car.Position;
            Console.SetCursorPosition(PosX, PosY);
            Console.ForegroundColor = (ConsoleColor)car.Color;
            Console.SetCursorPosition(PosX--, PosY++);
            Console.Write("#");
            Console.SetCursorPosition(PosX, PosY++);
            Console.Write("###");
            Console.SetCursorPosition(PosX, PosY++);
            Console.Write("###");
            Console.SetCursorPosition(++PosX, PosY++);
            Console.Write("#");
            Console.ForegroundColor = ConsoleColor.White;
            PosY++;
            Console.SetCursorPosition(PosX -= 3, PosY++);
            Console.Write($"Speed: {Math.Round(car.Speed, 1)}");
            Console.SetCursorPosition(PosX, PosY++);
            Console.Write($"Distance: {Math.Round(car.DrivenDistance,1)}");
            Console.SetCursorPosition(PosX, PosY++);
            Console.Write($"Driver: {car.DriverName}");
        }

        public void Draw(Truck truck)
        {
            if (truck.Number == 1)
                PosX = standartX;
            else PosX += 15;
            PosY = standartY;
            PosX += truck.Number + 5;
            PosY += truck.Position;
            Console.SetCursorPosition(PosX, PosY);
            Console.ForegroundColor = (ConsoleColor)truck.Color;
            Console.SetCursorPosition(PosX, PosY++);
            Console.Write("###");
            Console.SetCursorPosition(PosX++, PosY++);
            Console.Write("###");
            Console.SetCursorPosition(PosX, PosY++);
            Console.Write("#");
            Console.SetCursorPosition(PosX, PosY++);
            Console.Write("#");
            Console.ForegroundColor = ConsoleColor.White;
            PosY++;
            Console.SetCursorPosition(PosX -= 3, PosY++);
            Console.Write($"Speed: {Math.Round(truck.Speed, 1)}");
            Console.SetCursorPosition(PosX, PosY++);
            Console.Write($"Distance: {Math.Round(truck.DrivenDistance, 1)}");
            Console.SetCursorPosition(PosX, PosY++);
            Console.Write($"Driver: {truck.DriverName}");
        }

        public void Draw(Bus bus)
        {
            if (bus.Number == 1)
                PosX = standartX;
            else PosX += 15;
            PosY = standartY;
            PosX += bus.Number + 5;
            PosY += bus.Position;
            Console.SetCursorPosition(PosX, PosY);
            Console.ForegroundColor = (ConsoleColor)bus.Color;
            for (int i = 0; i < 4; i++)
            {
                Console.SetCursorPosition(PosX, PosY++);
                Console.Write("###");
            }
            Console.ForegroundColor = ConsoleColor.White;
            PosY++;
            Console.SetCursorPosition(PosX -= 3, PosY++);
            Console.Write($"Speed: {Math.Round(bus.Speed, 1)}");
            Console.SetCursorPosition(PosX, PosY++);
            Console.Write($"Distance: {Math.Round(bus.DrivenDistance, 1)}");
            Console.SetCursorPosition(PosX, PosY++);
            Console.Write($"Driver: {bus.DriverName}");
        }
    }
    class Game
    {
        public delegate void GameAI();
        public GameAI StartRace;
        public GameAI CalculatingPos;
        public delegate bool GameEnd(Car car);
        public GameEnd Finished;

        PrimitiveGraphics graph = new PrimitiveGraphics();
        public List<Car> cars = new List<Car>();
        const byte maxCars = 5;
        public int RaceDistance { get; set; }


        void SetPos()
        {
            cars.Sort();
            byte i = 1;
            foreach (var car in cars)
            {
                car.Position = i;
                i++;
            }
        }
        bool CheckEnd(Car car)
        {
            if (car.DrivenDistance >= car.TrackDistance)
            {
                Console.Clear();
                if ((car as SportCar) != null)
                    graph.Draw(car as SportCar);
                else if ((car as StandartCar) != null)
                    graph.Draw(car as StandartCar);
                else if ((car as Truck) != null)
                    graph.Draw(car as Truck);
                else if ((car as Bus) != null)
                    graph.Draw(car as Bus);
                Console.WriteLine("\n\t\t\tWinner!");
                return true; 
            }
            else return false;
        }
        public void AddCar()
        {
            if(cars.Count == maxCars)
                Console.WriteLine("No more places");
            else {
                var key = new ConsoleKeyInfo();
                Console.WriteLine($"Free places for arrival - {maxCars - cars.Count}\n");
                Console.WriteLine("Enter driver name");
                string name = Console.ReadLine();
            Type:
                Console.WriteLine("Select car type:\n1 - Sport car\n2 - Passenger car\n3 - Truck\n4 - Bus");
                key = Console.ReadKey(true);
                switch (key.Key)
                {
                    case ConsoleKey.D1:
                        cars.Add(new SportCar(name));
                        Console.WriteLine("Done");
                        break;
                    case ConsoleKey.D2:
                        cars.Add(new StandartCar(name));
                        Console.WriteLine("Done");
                        break;
                    case ConsoleKey.D3:
                        cars.Add(new Truck(name));
                        Console.WriteLine("Done");
                        break;
                    case ConsoleKey.D4:
                        cars.Add(new Bus(name));
                        Console.WriteLine("Done");
                        break;
                    default:
                        goto Type;
                }
            }
        }

        public void Race()
        {
            if (cars[0] == null || cars[1] == null)
                throw new ApplicationException("No cars to participate");

            Console.WriteLine("Set trace distance (m):");
            
            try { RaceDistance = Convert.ToInt32(Console.ReadLine()); }
            catch(FormatException msg) { throw; }
            catch(Exception msg) { throw; }

            byte i = 1;
            foreach (var car in cars)
            {
                car.Number = i;
                i++;
            }

            foreach (var car in cars)
            {
                StartRace += car.Accelerate;
                StartRace += car.Drive;
                car.TrackDistance = RaceDistance;
            }

            Finished = CheckEnd;
            CalculatingPos += SetPos;

            bool f = true;

            while (f == true)
            {
                StartRace?.Invoke();
                CalculatingPos?.Invoke();
                Console.Clear();
                foreach (var car in cars)
                {
                    if (Finished.Invoke(car) == true)
                    {
                        f = false;
                        break;
                    }
                    else
                    {
                        graph.DrawRace();
                        if ((car as SportCar) != null)
                            graph.Draw(car as SportCar);
                        else if ((car as StandartCar) != null)
                            graph.Draw(car as StandartCar);
                        else if ((car as Truck) != null)
                            graph.Draw(car as Truck);
                        else if ((car as Bus) != null)
                            graph.Draw(car as Bus);
                    }
                }
                Thread.Sleep(1000);
            }
            Console.ReadKey(true);
            cars.Clear();
        }
    }
    #endregion
    #region CarClasses
    delegate void CarHandler();

    abstract class Car : IComparable<Car>
    {
        protected float converter = 0.27777777778f;
        public string Name { get; set; }
        public double Speed { get; set; }
        public int MaxSpeed { get; set; }
        public double AccelerationMultiplier { get; set; }
        public int TrackDistance { get; set; }
        public int Color { get; set; }
        public byte Position { get; set; }
        public byte Number { get; set; }
        public double DrivenDistance { get; set; }

        public abstract void Drive();
        public void Accelerate()
        {
            if (Speed < MaxSpeed)
                Speed += 1 + AccelerationMultiplier;
            else Speed = MaxSpeed;
        }

        public int CompareTo(Car second)
        {
            return (second.DrivenDistance).CompareTo(DrivenDistance);
        }
    }

    class SportCar : Car
    {
        public event CarHandler Finish;
        public event CarHandler Ride;
        public string DriverName { get; set; }

        public SportCar(string name = "")
        {
            Random rand = new Random();
            AccelerationMultiplier = rand.NextDouble();
            MaxSpeed = rand.Next(200, 251);
            if (name != "")
                DriverName = name;
            Finish += () => Speed = 0;
            Name = "Sport Car";
            Color = rand.Next(1, 15);
        }

        public override void Drive()
        {
            Ride?.Invoke();
            DrivenDistance += (Speed * converter) / 2;
            if (DrivenDistance >= TrackDistance)
                Finish?.Invoke();
        }
    }

    class StandartCar : Car
    {
        public event CarHandler Finish;
        public event CarHandler Ride;
        public string DriverName { get; set; }

        public StandartCar(string name = "")
        {
            Random rand = new Random();
            AccelerationMultiplier = rand.NextDouble();
            MaxSpeed = rand.Next(180, 211);
            if (name != "")
                DriverName = name;
            Finish += () => Speed = 0;
            Name = "Standart Car";
            Color = rand.Next(1, 15);
        }

        public override void Drive()
        {
            Ride?.Invoke();
            DrivenDistance += (Speed * converter) / 2;
            if (DrivenDistance >= TrackDistance)
                Finish?.Invoke();
        }
    }

    class Truck : Car
    {
        public event CarHandler Finish;
        public event CarHandler Ride;
        public string DriverName { get; set; }

        public Truck(string name = "")
        {
            Random rand = new Random();
            AccelerationMultiplier = rand.NextDouble();
            MaxSpeed = rand.Next(150, 191);
            if (name != "")
                DriverName = name;
            Finish += () => Speed = 0;
            Name = "Truck";
            Color = rand.Next(1, 15);
        }

        public override void Drive()
        {
            Ride?.Invoke();
            DrivenDistance += (Speed * converter) / 2;
            if (DrivenDistance >= TrackDistance)
                Finish?.Invoke();
        }
    }
    class Bus: Car
    {
        public event CarHandler Finish;
        public event CarHandler Ride;
        public string DriverName { get; set; }

        public Bus(string name = "")
        {
            Random rand = new Random();
            AccelerationMultiplier = rand.NextDouble();
            MaxSpeed = rand.Next(150, 181);
            if (name != "")
                DriverName = name;
            Finish += () => Speed = 0;
            Name = "Bus";
            Color = rand.Next(1, 15);
        }

        public override void Drive()
        {
            Ride?.Invoke();
            DrivenDistance += (Speed * converter) / 2;
            if (DrivenDistance >= TrackDistance)
                Finish?.Invoke();
        }
    }
    #endregion
    class Program
    {
        static void Main(string[] arg)
        {
            Game game = new Game();
            var key = new ConsoleKeyInfo();
            do
            {
                Console.Clear();
                Console.WriteLine("Game menu\n\n");
                Console.WriteLine("1 - Add car to race\n2 - Start race\nEsc - exit");
            Key:
                key = Console.ReadKey(true);
                if (key.Key == ConsoleKey.D1)
                {
                    Console.Clear();
                    game.AddCar();
                    Console.ReadKey();
                }
                else if (key.Key == ConsoleKey.D2)
                {
                    Console.Clear();
                    try
                    {
                        game.Race();
                    }
                    catch (Exception msg) { Console.WriteLine(msg.Message); }
                    Console.ReadKey();
                }
                else if (key.Key != ConsoleKey.Escape) goto Key;
            } while (key.Key != ConsoleKey.Escape);
        }
    }
}