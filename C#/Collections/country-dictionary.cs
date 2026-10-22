using System;
using System.Collections.Generic;
using System.IO;
using System.Runtime.Serialization;
using System.Text;
using System.Linq;

namespace HW
{
    /*
     Создать примитивный англо-русский и русско-ан-
глийский словарь, содержащий пары слов — названий
стран на русском и английском языках. Пользователь
должен иметь возможность выбирать направление пе-
ревода и запрашивать перевод.
     */
    class RecoverFileNotFoundException : ApplicationException
    {
        public RecoverFileNotFoundException() { }
        public RecoverFileNotFoundException(string msg) : base(msg) { }
        public RecoverFileNotFoundException(string msg, Exception innerException) : base(msg, innerException) { }
        public RecoverFileNotFoundException(SerializationInfo info, StreamingContext context) : base(info, context) { }
    }
    class FileIsEmptyException : ApplicationException
    {
        public FileIsEmptyException() { }
        public FileIsEmptyException(string msg) : base(msg) { }
        public FileIsEmptyException(string msg, Exception innerException) : base(msg, innerException) { }
        public FileIsEmptyException(SerializationInfo info, StreamingContext context) : base(info, context) { }
    }
    class NoMatchesException : ApplicationException
    {
        public NoMatchesException() { }
        public NoMatchesException(string msg) : base(msg) { }
        public NoMatchesException(string msg, Exception innerException) : base(msg, innerException) { }
        public NoMatchesException(SerializationInfo info, StreamingContext context) : base(info, context) { }
    }
    class Translator
    {
        SortedList<string, string> words = new SortedList<string, string>();
        static string path = "words.txt";
        static string recover = "data";
        public SortedList<string, string> Words { get { return words; } }

        public Translator()
        {
            string fileData;
            byte[] fileBytes = null;
            FileStream fs = null;
            try { fs = new FileStream(path, FileMode.Open, FileAccess.Read, FileShare.Read); }
            catch (FileNotFoundException msg)
            {
                Console.WriteLine(msg.GetType());
                Console.WriteLine(msg.Message);
                FileStream rc;
                try { rc = new FileStream(recover, FileMode.Open, FileAccess.Read, FileShare.Read); }
                catch (FileNotFoundException message) { throw new RecoverFileNotFoundException(message.Message); }
                fileBytes = new byte[(int)rc.Length];
                rc.Read(fileBytes, 0, fileBytes.Length);
                File.Copy(recover, path);
                rc.Dispose();
                rc.Close();
            }
            if (fileBytes == null)
            {
                fileBytes = new byte[(int)fs.Length];
                fs.Read(fileBytes, 0, fileBytes.Length);
                fs.Dispose();
                fs.Close();
            }
            fileData = Encoding.Default.GetString(fileBytes);
            int index = fileData.IndexOf('\n');
            if (index != -1)
            {
                string tmp = "";
                string tmp1 = "";
                string tmp2;
                for (int i = 0; i < fileData.Length; i++)
                {
                    if (fileData[i] == '-')
                    {
                        tmp1 = tmp;
                        i++;
                        tmp = "";
                    }
                    if (fileData[i] == '\r')
                    {
                        tmp2 = tmp;
                        words.Add(tmp1, tmp2);
                        tmp = "";
                        continue;
                    }
                    if (fileData[i] == '\n')
                        continue;
                    tmp += fileData[i];
                }
            }
            else throw new FileIsEmptyException("File is empty\n");
        }
        public static void CreateRecoverFile(string newData, bool isFile)
        {
            if (isFile == false)
            {
                FileStream recoverFile = new FileStream(recover, FileMode.Create, FileAccess.Write, FileShare.None);
                byte[] dataBytes = Encoding.Default.GetBytes(newData);
                recoverFile.Write(dataBytes, 0, dataBytes.Length);
                recoverFile.Dispose();
                recoverFile.Close();
            }
            else
            {
                File.Copy(newData, recover);
            }
        }
        public void Add(string eng, string ru)
        {
            byte[] toFile = Encoding.Default.GetBytes("\n" + eng + "-" + ru);
            FileStream file = new FileStream(path, FileMode.Append, FileAccess.Write, FileShare.None);
            file.Write(toFile, 0, toFile.Length);
            file.Dispose();
            file.Close();
            try
            {
                words.Add(eng, ru);
            }
            catch (ArgumentException msg) { throw; }
        }
        public void RevertToOriginal()
        {
            File.Copy(recover, path, true);
        }
        public string GetEng(string ru)
        {
            if (words.ContainsValue(ru) == false)
                throw new NoMatchesException("No matches!");
            string outstr = words.FirstOrDefault(x => x.Value == ru).Key;
            return outstr;
        }
        public string GetRu(string eng)
        {
            if (words.ContainsKey(eng) == false)
                throw new NoMatchesException("No matches!");
            string outstr = words.GetValueOrDefault(eng);
            return outstr;
        }
    }
    class TranslatorUI
    {
        Translator tr;
        public void Create()
        {
            try { tr = new Translator(); }
            catch (RecoverFileNotFoundException msg)
            {
                Console.WriteLine(msg.Message);
                Console.WriteLine("Ввести\n1 - данные самостоятельно для файла восстановлениня\n2 - путь к файлу для снятия копии");
                var key = new ConsoleKeyInfo();
                string str;
            Key:
                key = Console.ReadKey();
                switch (key.Key)
                {
                    case ConsoleKey.D1:
                        Console.WriteLine("Слова вводить в ввиде Enter-Вводить\nЧтобы остановить ввод нажмите Esc\n");
                        StringBuilder builder = new StringBuilder();
                    Str:
                        str = Console.ReadLine();
                        builder.Append(str + "\n");
                        key = Console.ReadKey();
                        if (key.Key != ConsoleKey.Escape)
                            goto Str;
                        Translator.CreateRecoverFile(builder.ToString(), false);
                        break;
                    case ConsoleKey.D2:
                        Console.WriteLine("Укажите путь к файлу C:/");
                        str = Console.ReadLine();
                        Translator.CreateRecoverFile(str, true);
                        break;
                    default:
                        goto Key;
                }
                try { tr = new Translator(); } catch (Exception msg2) { Console.WriteLine(msg2.Message); }
            }
            catch (Exception msg) { Console.WriteLine(msg.Message); }
        }
        public void AddNew()
        {
            Console.WriteLine("Введите слово на Английском");
            string eng = Console.ReadLine();
            Console.WriteLine("Введите слово на Русском");
            string ru = Console.ReadLine();
            try { tr.Add(eng, ru); } catch (Exception msg) { Console.WriteLine(msg.GetType()); Console.WriteLine(msg.Message); }
        }
        public void Return()
        {
            Console.WriteLine("Вернуть к исходному состоянию (y/n)");
            var key = new ConsoleKeyInfo();
            key = Console.ReadKey();
            if (key.Key == ConsoleKey.Y)
                tr.RevertToOriginal();
        }
        public void TrFromEng()
        {
            Console.WriteLine("Введите слово:");
            string str = Console.ReadLine();
            Console.WriteLine("РУ: " + tr.GetRu(str));
        }
        public void TrFromRu()
        {
            Console.WriteLine("Введите слово:");
            string str = Console.ReadLine();
            Console.WriteLine("ENG: " + tr.GetEng(str));
        }
    }
    class Program
    {
        static void Main(string[] args)
        {
            TranslatorUI ui = new TranslatorUI();
            try { ui.Create(); } catch (Exception msg) { Console.WriteLine(msg.GetType()); Console.WriteLine(msg.Message); }
            var key = new ConsoleKeyInfo();
            do
            {
                Console.Clear();
                Console.WriteLine("1 - Перевести с русского\n2 - Перевести с английского\n3 - Добавить новое слово в словарь\n4 - Сбросить файл словаря к исходному состоянию\nEsc - выход");
                key = Console.ReadKey();
                try
                {
                    switch (key.Key)
                    {
                        case ConsoleKey.D1:
                            Console.Clear();
                            ui.TrFromRu();
                            Console.ReadKey();
                            break;
                        case ConsoleKey.D2:
                            Console.Clear();
                            ui.TrFromEng();
                            Console.ReadKey();
                            break;
                        case ConsoleKey.D3:
                            Console.Clear();
                            ui.AddNew();
                            Console.ReadKey();
                            break;
                        case ConsoleKey.D4:
                            Console.Clear();
                            ui.Return();
                            Console.ReadKey();
                            break;
                    }
                }
                catch (Exception msg) { Console.WriteLine(msg.Message); }
            } while (key.Key != ConsoleKey.Escape);
        }
    }
}