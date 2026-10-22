using System;
using System.Collections;
using System.Text;
using System.Threading;
using System.Xml.Serialization;

namespace Homework
{
    /*
     Задание 1
Разработать и протестировать набор классов для решения задачи подсчета зароботной платы сотрудников некоторой фирмы.

На фирме есть несколько способов оплаты труда:

ставка – указывается, сколько сотрудник получает за рабочий день; для каждого сотрудника записывается, сколько дней он отработал в месяце;
почасовая – указывается, сколько сотрудник получает в час, для каждого сотрудника; записывается, сколько часов он отработал в месяце
сдельная – указывается, сколько сотрудник получит за выполненную работу; для каждого сотрудника записываются суммы для каждой работы, 
что он успел сделать за месяц.
Программа должна уметь выводить отчет по всем сотрудникам фирмы о заработной плате в виде:

ФИО	    Вид оплаты	Сумма
Иванов	ставка	    3000 грн
Сидоров	почасовая	800 грн
Петров	сдельная	5500 грн


Задание 2
Для предыдущего задания вывести отчет с учетом налогов.

Для сотрудников, которые на ставке и почасовой оплате – налог 20%.
Для сотрудников со сдельной оплатой труда – 15%.
Программа должна уметь выводить отчет по всем сотрудникам фирмы о заработной плате в виде:

ФИО	    Налог, %	Сумма (грн)	К оплате (грн)
Иванов	20%	        3000	        2400
Сидоров	20%	        800	            640
Петров	15%	        5500	        4675


Задание 3
На основе предыдущего задания сделать новый отчет таким образом, что для сотрудников, у которых нет детей, ставка налога выше на 5%.

Задание 4
На основе предыдущего задания переделать отчет, с учетом того, что сотрудники с почасовой оплатой, половину зарплаты получают в валюте 
(тугриках), по курсу на день начисления заработной платы.

ФИО	    Налог, %	Сумма (грн)	К оплате (грн/тугрики) Курс 1/8
Иванов	20%	        3000	    2400
Сидоров	20%	        800	        320 / 40
Петров	15%	        5500	    4675


Задание 5
Фирма переводит часть сотрудников в офшорную зону. Сотрудники, находящиеся в офшоре, не платят налогов. 
Создать новый отчет с учетом данного нововведения.

Задание 6
Фирма вводит премии в 20% сотрудникам, которые работали больше 200 часов в месяц, но не находятся в офшоре. 
Премии должны суммироваться в основную зарплату. Создать новый отчет с учетом изменений.
    */
    enum PaymentMethod
    {
        Rate,
        Hourly,
        Piecework
    }

    class Persone : IComparable
    {
        public int Num { get; set; }
        public string FullName { get; set; }
        public PaymentMethod Method { get; set; }
        public float Pay { get; set; }
        public int DayTimeAmount { get; set; }
        public byte Tax { get; set; }
        public float Payment { get; set; }
        public float PaymentWTax { get; set; }
        public float PaymentTug { get; set; }
        public byte AmountOfChildren { get; set; }
        public bool IsChildSet { get; set; }
        public bool Offshore { get; set; }

        public Persone(string fullname, PaymentMethod method, int pay)
        {
            FullName = fullname;
            Method = method;
            Pay = pay;
            IsChildSet = false;
        }

        public override string ToString()
        {
            return $"№{Num} {FullName}\n";
        }

        public int CompareTo(object obj)
        {
            if (obj is Persone)
            {
                return FullName.CompareTo((obj as Persone).FullName);
            }
            throw new NotImplementedException();
        }
    }

    class Company
    {
        ArrayList personnel;
        static byte rhTax = 20;
        static byte pTax = 15;
        public string Owner { get; set; }
        public string Name { get; set; }
        public byte WorkingDays { get; set; }
        public byte WorkingHours { get; set; }
        public byte Course { get; set; }
        public bool IsChildInfoAdded { get; set; }
        public bool IsCourseSet { get; set; }
        public bool IsOffshoreSet { get; set; }

        public Company(string name, string owner)
        {
            personnel = new ArrayList();
            Owner = owner;
            Name = name;
            IsChildInfoAdded = false;
            IsCourseSet = false;
            IsOffshoreSet = false;
        }

        public ArrayList Personnel { get { return personnel; } }

        public void AddPersone(string fullname, PaymentMethod method, int pay)
        {
            personnel.Add(new Persone (fullname, method, pay));
            personnel.Sort();
        }

        public void RemovePersone(string name)
        {
            int i = 0;
            foreach(Persone persone in personnel)
            {
                if (persone.FullName == name)
                    break;
                i++;
            }
            personnel.RemoveAt(i);
            personnel.Sort();
        }

        public void Stage1()
        {
            foreach (Persone persone in personnel)
            {
                if(persone.Method == PaymentMethod.Rate)
                {
                    persone.Payment = (persone.Pay * persone.DayTimeAmount) / WorkingDays; 
                }
                else 
                {
                    persone.Payment = persone.Pay * persone.DayTimeAmount;
                }
            }
        }

        public void Stage2(bool child = false, bool offs = false, bool prem = false)
        {
            Stage1();
            foreach (Persone persone in personnel)
            {
                if (prem == true && (persone.Method == PaymentMethod.Rate || persone.Method == PaymentMethod.Hourly && persone.Offshore == false))
                {
                    if (persone.Method == PaymentMethod.Rate && persone.DayTimeAmount * WorkingHours > 200)
                        persone.Payment += persone.Payment - (persone.Payment * 0.2f);
                    if (persone.Method == PaymentMethod.Hourly && persone.DayTimeAmount > 200)
                        persone.Payment += persone.Payment - (persone.Payment * 0.2f); 
                }
                if (offs == true && persone.Offshore == true)
                {
                    persone.Tax = 0;
                    persone.PaymentWTax = persone.Payment;
                }
                else
                {
                    if (persone.Method == PaymentMethod.Rate || persone.Method == PaymentMethod.Hourly)
                    {
                        persone.Tax = rhTax;
                    }
                    else
                    {
                        persone.Tax = pTax;
                    }
                    if (child == true && persone.AmountOfChildren == 0)
                        persone.Tax += 5;
                    persone.PaymentWTax = (persone.Payment - (persone.Payment * (float)(persone.Tax * 0.01)));
                }
            }
        }

        public void Stage3(bool offs = false, bool prem = false) { Stage2(true, offs, prem); }

        public void Stage4(bool offs = false, bool prem = false)
        {
            Stage3(offs, prem);
            foreach (Persone persone in Personnel)
            {
                if (persone.Method == PaymentMethod.Hourly)
                {
                    persone.PaymentTug = persone.PaymentWTax /= 2;
                    persone.PaymentTug /= Course;
                }
            }
        }

        public void Stage5(bool prem = false)
        {
            Stage4(true, prem);
        }

        public void Stage6()
        {
            Stage5(true);
        }
    }

    class UI
    {
        Company company;

        public void CreateCompany()
        {
            Console.WriteLine("Введите название компании");
            string name = Console.ReadLine();
            Console.WriteLine("Введите владельца компании");
            string owner = Console.ReadLine();
            Console.Write("\nСоздание"); Thread.Sleep(500);
            for (byte i = 0; i < 3; i++)
            { Console.Write("."); Thread.Sleep(500); }
            company = new Company(name, owner);
        }

        public override string ToString()
        {
            if (company.WorkingDays == 0 && company.WorkingDays == 0)
                return $"Название компании: {company.Name}\nВладелец: {company.Owner}\n";
            else
                return $"Название компании: {company.Name}\nВладелец: {company.Owner}\nРабочих дней: {company.WorkingDays}\nРабочих часов: {company.WorkingHours}\n";
        }

        public void SetWorkDaysHours()
        {
            Console.WriteLine("Введите кол-во рабочих дней");
            byte days;
        Days:
            try
            {
                days = Convert.ToByte(Console.ReadLine());
            }
            catch (Exception msg)
            {
                Console.WriteLine(msg.GetType().Name);
                Console.WriteLine(msg.Message);
                goto Days;
            }
            Console.WriteLine("Введите кол-во рабочих часов в день");
            byte hours;
        Hours:
            try
            {
                hours = Convert.ToByte(Console.ReadLine());
            }
            catch (Exception msg)
            {
                Console.WriteLine(msg.GetType().Name);
                Console.WriteLine(msg.Message);
                goto Hours;
            }
            company.WorkingDays = days;
            company.WorkingHours = hours;
        }

        public void Add()
        {
            Console.WriteLine("Введите ФИО");
            string fullname = Console.ReadLine();
            Console.WriteLine("Введите метод оплаты\n\nДоступные методы:");
            string[] methods = Enum.GetNames(typeof(PaymentMethod));
            foreach (var method in methods)
                Console.WriteLine(method);
            Console.WriteLine();
            PaymentMethod meth;
        Method:
            try { meth = (PaymentMethod)Enum.Parse(typeof(PaymentMethod), Console.ReadLine()); }
            catch (Exception msg) { Console.WriteLine(msg.GetType().Name); Console.WriteLine(msg.Message); goto Method; }

            Console.WriteLine("Введите сумму оплаты");
            int pay;
        Pay:
            try { pay = Convert.ToInt32(Console.ReadLine()); }
            catch (Exception msg) { Console.WriteLine(msg.GetType().Name); Console.WriteLine(msg.Message); goto Pay; }
            company.AddPersone(fullname, meth, pay);
        }

        public void Remove()
        {
            Console.WriteLine("Введите ФИО сотрудника");
            string name = Console.ReadLine();
            company.RemovePersone(name);
        }

        public void AddChildrenInfo()
        {
            if (company.Personnel.Count == 0)
                throw new Exception("Список сотрудников пуст\n");
            var key = new ConsoleKeyInfo();
            Choice:
            Console.WriteLine("Ввести информацию для новых сотрудников/обновить всем (y/n)");
            key = Console.ReadKey();
            if (key.Key == ConsoleKey.Y)
            {
                foreach (Persone persone in company.Personnel)
                {
                    if (persone.IsChildSet == false)
                    {
                        Console.WriteLine(persone);
                        Console.WriteLine("\nВведите кол-во детей");
                    Child:
                        try { persone.AmountOfChildren = Convert.ToByte(Console.ReadLine()); }
                        catch (Exception msg)
                        { Console.WriteLine(msg.GetType().Name); Console.WriteLine(msg.Message); goto Child; }
                        persone.IsChildSet = true;
                    }
                }
            }
            else if (key.Key == ConsoleKey.N)
            {
                foreach (Persone persone in company.Personnel)
                {
                    Console.WriteLine(persone);
                    Console.WriteLine("\nВведите кол-во детей");
                Child:
                    try { persone.AmountOfChildren = Convert.ToByte(Console.ReadLine()); }
                    catch (Exception msg)
                    { Console.WriteLine(msg.GetType().Name); Console.WriteLine(msg.Message); goto Child; }
                    persone.IsChildSet = true;
                }
            }
            else goto Choice;
            company.IsChildInfoAdded = true;
        }

        public void SetCourse()
        {
            Course:
            Console.WriteLine("Введите курс гривны к тугрикам ( ? : 1)");
            try
            { company.Course = Convert.ToByte(Console.ReadLine()); }
            catch(Exception msg)
            {
                Console.WriteLine(msg.GetType().Name);
                Console.WriteLine(msg.Message);
                goto Course;
            }
            company.IsCourseSet = true;
        }

        public void SetOffshore()
        {
            if (company.Personnel.Count == 0)
                throw new Exception("Список сотрудников пуст\n");
            Console.WriteLine($"В компании {company.Personnel.Count} человек\n");
            int j = 1;
            foreach (Persone persone in company.Personnel)
            {
                persone.Num = j;
                Console.WriteLine(persone);
            }
            int fidx, lidx;
            Num:
            Console.WriteLine("Введите номер человека с какого начинать и каким закончить");
            try
            {
                fidx = Convert.ToInt32(Console.ReadLine());
                lidx = Convert.ToInt32(Console.ReadLine());
            }
            catch(Exception msg)
            {
                Console.WriteLine(msg.GetType().Name);
                Console.WriteLine(msg.Message);
                goto Num;
            }
            if(fidx <= 0 || lidx <= 0)
            {
                Console.WriteLine("Номер меньше или равен нулю");
                Console.ReadKey();
                goto Num;
            }
            if(fidx > company.Personnel.Count || lidx > company.Personnel.Count)
            {
                Console.WriteLine("Такого номер нет в списке");
                Console.ReadKey();
                goto Num;
            }
            lidx--;
            fidx--;
            if(lidx < fidx)
            {
                int tmp = fidx;
                fidx = lidx;
                lidx = tmp;
            }
            int i = 0;
            foreach (Persone persone in company.Personnel)
            {
                if (i >= fidx && i <= lidx)
                    persone.Offshore = true;
                else persone.Offshore = false;
                i++;
            }
            company.IsOffshoreSet = true;
        }

        public void GetReport()
        {
            if (company.WorkingDays == 0)
                throw new Exception("Не задано кол-во рабочих дней\n");
            if (company.Personnel.Count == 0)
                throw new Exception("В компании нет работников\n");
            var key = new ConsoleKeyInfo();
            Console.WriteLine("1 - Отчёт №1\n2 - Отчёт №2\n3 - Отчёт №3\n4 - Отчёт №4\n5 - Отчёт №5\n6 - Отчёт №6\n");
            key = Console.ReadKey(true);
            if (key.Key >= ConsoleKey.D3 && key.Key <= ConsoleKey.D6)
                if (company.IsChildInfoAdded == false)
                    AddChildrenInfo();
            if (key.Key >= ConsoleKey.D4 && key.Key <= ConsoleKey.D6)
                if (company.IsCourseSet == false)
                    SetCourse();
            if(key.Key >= ConsoleKey.D5 && key.Key <= ConsoleKey.D6)
            {
                if (company.IsOffshoreSet == false)
                    SetOffshore();
            }
            foreach (Persone persone in company.Personnel)
            {
                Console.WriteLine($"{persone.FullName} | {persone.Method}\n");
                if (persone.Method == PaymentMethod.Rate)
                {
                    Console.WriteLine("Введите кол-во отработанных дней");
                    int days;
                Days:
                    try { days = Convert.ToInt32(Console.ReadLine()); } 
                    catch (Exception msg) { Console.WriteLine(msg.GetType().Name); Console.WriteLine(msg.Message); goto Days; }
                    if (days > company.WorkingDays)
                        goto Days;
                    persone.DayTimeAmount = days;
                }
                else if(persone.Method == PaymentMethod.Hourly)
                {
                    Console.WriteLine("Введите кол-во отработанных часов");
                    int hours;
                Hours:
                    try { hours = Convert.ToInt32(Console.ReadLine()); }
                    catch (Exception msg) { Console.WriteLine(msg.GetType().Name); Console.WriteLine(msg.Message); goto Hours; }

                    persone.DayTimeAmount = hours;
                }
                else
                {
                    Console.WriteLine("Введите кол-во выполненных работ");
                    int tasks;
                Tasks:
                    try { tasks = Convert.ToInt32(Console.ReadLine()); }
                    catch (Exception msg) { Console.WriteLine(msg.GetType().Name); Console.WriteLine(msg.Message); goto Tasks; }

                    persone.DayTimeAmount = tasks;
                }
            }
            switch(key.Key)
            {
                case ConsoleKey.D1:
                    company.Stage1();
                    break;
                case ConsoleKey.D2:
                    company.Stage2();
                    break;
                case ConsoleKey.D3:
                    company.Stage3();
                        break;
                case ConsoleKey.D4:
                    company.Stage4();
                    break;
                case ConsoleKey.D5:
                    company.Stage5();
                    break;
                case ConsoleKey.D6:
                    company.Stage6();
                    break;
            }
            var strout = new StringBuilder();
            strout.Append("ФИО | ");
            if (key.Key == ConsoleKey.D5 || key.Key == ConsoleKey.D6)
                strout.Append("В оффшоре | ");
            if (key.Key == ConsoleKey.D1)
                strout.Append("Вид оплаты | ");
            else
                strout.Append("Налог, % | ");
            strout.Append("Сумма (грн)");
            if(key.Key != ConsoleKey.D1)
            {
                if (key.Key == ConsoleKey.D2 || key.Key == ConsoleKey.D3)
                    strout.Append(" | К оплате (грн)");
                else 
                {
                    strout.Append($" | К оплате (грн / тугрики) Курс 1/{company.Course}");
                }
            }
            strout.Append("\n\n");
            foreach (Persone persone in company.Personnel)
            {
                strout.Append($"{persone.FullName} | ");
                if (key.Key == ConsoleKey.D5 || key.Key == ConsoleKey.D6)
                {
                    if (persone.Offshore == true)
                        strout.Append("+ | ");
                    else strout.Append("- | ");
                }
                if (key.Key == ConsoleKey.D1)
                    strout.Append($"{persone.Method} | ");
                else strout.Append($"{persone.Tax}% | ");
                strout.Append($"{persone.Payment}");
                if(key.Key != ConsoleKey.D1)
                {
                    if (key.Key == ConsoleKey.D2 || key.Key == ConsoleKey.D3)
                        strout.Append($" | {persone.PaymentWTax}");
                    else
                    {
                        if (persone.Method == PaymentMethod.Hourly)
                            strout.Append($" | {persone.PaymentWTax}/{persone.PaymentTug}");
                        else strout.Append($" | {persone.PaymentWTax}");
                    }
                }
                strout.Append("\n\n");
            }
            Console.Clear();
            if(key.Key == ConsoleKey.D2)
                Console.WriteLine("Для сотрудников, которые на ставке и почасовой оплате – налог 20%.\nДля сотрудников со сдельной оплатой труда – 15 %.\n\n");
            else if(key.Key == ConsoleKey.D3)
                Console.WriteLine("Для сотрудников, у которых нет детей, ставка налога выше на 5%\n\n");
            else if(key.Key == ConsoleKey.D4)
                Console.WriteLine("Сотрудники с почасовой оплатой, половину зарплаты получают в валюте (тугриках), по курсу на день начисления заработной платы\n\n");
            else if(key.Key == ConsoleKey.D5)
                Console.WriteLine("Фирма переводит часть сотрудников в офшорную зону.\nСотрудники, находящиеся в офшоре, не платят налогов\n\n");
            else if(key.Key == ConsoleKey.D6)
                Console.WriteLine("Премии в 20% сотрудникам, которые работали больше 200 часов в месяц, но не находятся в офшоре.\n\n");
            Console.WriteLine(strout);
        }
    }

    class Program
    {
        static void Main(string[] arg)
        {
            UI n = new UI();
            n.CreateCompany();
            ConsoleKeyInfo key = new ConsoleKeyInfo();
            do
            {
                Console.Clear();
                Console.WriteLine(n);
                Console.WriteLine("1 - Добавить работника (список сортируется)\n2 - Удалить сотрудника\n3 - Ввод рабочих дней и часов\n4 - Ввести информацию о детях\n5 - Ввести курс\n6 - Перевод в оффшор(При добавлении новых сотрудников обновить)\n7 - Получить отчёт\nEsc - выход");
                key = Console.ReadKey(true);
                switch (key.Key)
                {
                    case ConsoleKey.D1:
                        Console.Clear();
                        n.Add();
                        Console.ReadKey();
                        break;
                    case ConsoleKey.D2:
                        Console.Clear();
                        n.Remove();
                        Console.ReadKey();
                        break;
                    case ConsoleKey.D3:
                        Console.Clear();
                        n.SetWorkDaysHours();
                        Console.ReadKey();
                        break;
                    case ConsoleKey.D4:
                        Console.Clear();
                        try { n.AddChildrenInfo(); } catch (Exception msg) { Console.WriteLine(msg.Message); }
                        Console.ReadKey();
                        break;
                    case ConsoleKey.D5:
                        Console.Clear();
                        n.SetCourse();
                        Console.ReadKey();
                        break;
                    case ConsoleKey.D6:
                        Console.Clear();
                        try { n.SetOffshore(); } catch (Exception msg) { Console.WriteLine(msg.Message); }
                        Console.ReadKey();
                        break;
                    case ConsoleKey.D7:
                        Console.Clear();
                        try { n.GetReport(); } catch (Exception msg) { Console.WriteLine(msg.Message); }
                        Console.ReadKey();
                        break;
                }
            } while (key.Key != ConsoleKey.Escape);
        }
    }
}