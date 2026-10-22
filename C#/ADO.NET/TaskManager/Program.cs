using System;
using System.Data.Common;
using System.Data.SqlClient;
using System.Runtime.InteropServices;
using System.Runtime.InteropServices.ComTypes;
using System.Text;

namespace ADO_NET_HW
{
    /*
Создать простой список задач.

Необходимо работать с данными:

- Название задачи
- Важность (от 1 до 5)
- Срок выполнения 

Данные отображать с учетом срочности и важности (вначале важные, потом срочные)

Данные нужно хранить в базе данных.
Важно: вместе с кодом отрпавляйте sql для создания структуры бд

Реализовать возможность добавления, удаления и редактирования задач. 
    */
    class TaskManager
    {
        SqlConnection server;
        public string Name { get; set; }
        public int Importance { get; set; }
        public string CurrentDate { get; set; }
        public string Term { get; set; }
        public string LastCommand { get; set; }
        public int Idx { get; set; }

        public TaskManager(string source, string uid, string pass)
        {
            server = new SqlConnection($"Data Source={source};Initial catalog=TaskManager;User ID={uid};Password={pass};");
        }

        public bool OpenEvent()
        {
            server.Open();
            if (server.State == System.Data.ConnectionState.Open)
                return true;
            throw new Exception($"Connection status : {server.State}\n");
        }
        public void Add(string name, int importance, DateTime term)
        {
            Name = name;
            Importance = importance;
            Term = term.Date.ToString("MM/dd/yyyy");
            CurrentDate = DateTime.Now.Date.ToString("MM/dd/yyyy");
            LastCommand = $@"insert into[dbo].[Information]([Name],[Importance],[Appointment date],[Period of execution])
            values (N'{Name}', {Importance}, '{CurrentDate}', '{Term}')";
            SqlCommand command = new SqlCommand(LastCommand, server);
        TryAdd:
            try { command.ExecuteNonQuery(); } catch (Exception msg) { Console.WriteLine(msg.Message); Console.WriteLine("Trying to add again"); goto TryAdd; }
            command.Dispose();
            Idx++;
        }
        public void DeleteAll()
        {
            LastCommand = $"delete from Information\nDBCC CHECKIDENT('Information', RESEED, 0)\n";
            SqlCommand command = new SqlCommand(LastCommand, server);
            command.ExecuteNonQuery();
            command.Dispose();
        }

        public void Delete(int idx)
        {
            if (idx <= Idx)
                Idx = idx;
            LastCommand = $@"delete from[dbo].[Information] where [Id]={idx} DBCC CHECKIDENT ('[Information]', RESEED, {Idx - 1})";
            SqlCommand command = new SqlCommand(LastCommand, server);
            command.ExecuteNonQuery();
            command.Dispose();
        }
        public void Select()
        {
            Console.WriteLine("Num | Name | Importance | Appointment date | Period of execution\n\n");
            for (byte i = 0; i < 2; i++)
            {
                if (i == 0) LastCommand = "select * from Information where Importance = 5 ";
                else LastCommand = "select * from Information where Importance < 5 order by DATEDIFF(day, [Appointment date], [Period of execution])";
                SqlCommand command = new SqlCommand(LastCommand, server);
                SqlDataReader reader = command.ExecuteReader();
                while (reader.Read())
                {
                    DateTime appoint = (DateTime)reader["Appointment date"];
                    DateTime execut = (DateTime)reader["Period of execution"];
                    Console.WriteLine($"N{reader.GetInt32(0)} | {reader["Name"]} | {reader["Importance"]} | {appoint.Date.ToString("dd.MM.yyyy")} | {execut.Date.ToString("dd.MM.yyyy")}\n");
                }
                reader.Close();
                command.Dispose();
            }
        }
        public void SelectOne(int i)
        {
            LastCommand = $"select * from Information where Id = {i}";
            SqlCommand command = new SqlCommand(LastCommand, server);
            try
            {
                SqlDataReader reader = command.ExecuteReader();
                Console.WriteLine("Num | Name | Importance | Appointment date | Period of execution\n\n");
                reader.Read();
                Console.WriteLine($"N{reader.GetInt32(0)} | {reader["Name"]} | {reader["Importance"]} | {reader["Appointment date"]} | {reader["Period of execution"]}\n");
                Name = (string)reader["Name"];
                Importance = (int)reader["Importance"];
                DateTime term = (DateTime)reader["Period of execution"];
                Term = term.Date.ToString("MM/dd/yyyy");
                reader.Close();
            }
            catch (Exception msg) { throw new Exception($"{msg.Message}"); }
        }

        public void Update(int i, string name, int importance, DateTime term)
        {
            if (term != default)
                Term = term.Date.ToString("MM/dd/yyyy");
            if (name != null)
                Name = name;
            if (importance != 0)
                Importance = importance;
            LastCommand = $"update Information set Name = N'{Name}', Importance = {Importance}, [Period of execution] = N'{Term}' where Id = {i}";
            SqlCommand command = new SqlCommand(LastCommand, server);
            command.ExecuteNonQuery();
            command.Dispose();
        }

        public void ExitEvent()
        {
            server.Close();
            server.Dispose();
        }
    }
    class TaskManagerUI
    {
        TaskManager prog;
        public TaskManagerUI()
        {
            Console.Write("Data source=");
            string source = Console.ReadLine();
            Console.Write("User ID=");
            string uid = Console.ReadLine();
            Console.Write("Password=");
            string pass = Console.ReadLine();
            prog = new TaskManager(source, uid, pass);
        }

        public void Open() => prog.OpenEvent();
        public void Exit() => prog.ExitEvent();
        public void Add()
        {
            Console.WriteLine("Enter task name");
            string name = Console.ReadLine();
        Imp:
            Console.WriteLine("Enter importance (1-5)");
            int importance;
            if (int.TryParse(Console.ReadLine(), out importance))
            {
                if (!(importance >= 1 && importance <= 5))
                    goto Imp;
            }
            else goto Imp;
            Term:
            Console.WriteLine("Enter term");
            DateTime term;
            try { term = Convert.ToDateTime(Console.ReadLine()); } catch (Exception msg) { Console.WriteLine(msg.Message); goto Term; }

            prog.Add(name, importance, term);
        }
        public void RemoveAll() => prog.DeleteAll();

        public void Remove()
        {
            GetData();
            int i;
        Ent:
            Console.WriteLine("\nEnter task num to delete");
            if (int.TryParse(Console.ReadLine(), out i))
                prog.Delete(i);
            else goto Ent;
        }
        public void GetData() => prog.Select();

        public void Update()
        {
        Ent:
            Console.WriteLine("Enter num of task to update");
            int idx;
            try { idx = Convert.ToInt32(Console.ReadLine()); } catch (Exception msg) { Console.WriteLine(msg.Message); goto Ent; }
            prog.SelectOne(idx);
            Console.WriteLine("\nTo skip value just press 'Enter'");
            string str, name = null;
            int importance = 0;
            DateTime term = default;
            Console.WriteLine("Enter new name");
            str = Console.ReadLine();
            if (str != "")
                name = str;
            Imp:
            Console.WriteLine("Enter new importance value");
            str = Console.ReadLine();
            if (str != "")
            {
                if (int.TryParse(str, out importance))
                {
                    if (!(importance >= 1 && importance <= 5))
                        goto Imp;
                }
                else goto Imp;
            }
        Date:
            Console.WriteLine("Enter new term date (dd.mm.yyyy)");
            str = Console.ReadLine();
            if (str != "")
            {
                try { term = Convert.ToDateTime(str); } catch (Exception msg) { Console.WriteLine(msg.Message); goto Date; }
            }
            prog.Update(idx, name, importance, term);
        }
    }
    class Program
    {
        static void Main(string[] args)
        {
            TaskManagerUI task = new TaskManagerUI();
            try { task.Open(); } catch (Exception msg) { Console.WriteLine(msg.Message); throw new Exception($"{msg.Message}"); }
            var key = new ConsoleKeyInfo();
            do
            {
                Console.Clear();
                Console.WriteLine("Task List Base\n\n1 - Add new task\n2 - Remove all tasks\n3 - Remove task\n4 - Update task\n5 - Show list\nEsc - выход");
                key = Console.ReadKey(true);
                try
                {
                    switch (key.Key)
                    {
                        case ConsoleKey.D1:
                            Console.Clear();
                            task.Add();
                            Console.ReadKey();
                            break;
                        case ConsoleKey.D2:
                            Console.Clear();
                            task.RemoveAll();
                            Console.ReadKey();
                            break;
                        case ConsoleKey.D3:
                            Console.Clear();
                            task.Remove();
                            Console.ReadKey();
                            break;
                        case ConsoleKey.D4:
                            Console.Clear();
                            task.Update();
                            Console.ReadKey();
                            break;
                        case ConsoleKey.D5:
                            Console.Clear();
                            task.GetData();
                            Console.ReadKey();
                            break;
                    }
                }
                catch (Exception msg) { Console.WriteLine(msg.Message); Console.ReadKey(); }
            } while (key.Key != ConsoleKey.Escape);
            task.Exit();
        }
    }
}
