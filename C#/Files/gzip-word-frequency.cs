using System;
using System.IO;
using System.IO.Compression;
using System.Collections;
using System.Collections.Generic;
using System.Text;
using System.Linq;

namespace Homework
{
    /*
     Написать программу для подсчета наиболее встречающихся слов в неком тексте произведения Алиса в стране чудес.  
Файл с текстом находится в файле alice.txt.gz. Файл сжат при архиватором gzip. Необходимо открыть файл не распаковывая файл на жесткий диск.
При выводе результатов привести первые 10 наиболее встречающихся слова с указанием их количества.  
Считать только слова длиной более 3 символов.

Пример вывода:    

алиса: 406  
сказала: 126  
было: 105  
сказал: 100  
если: 87  
только: 87  
очень: 71  
когда: 64  
король: 61  
подумала: 61    
 

Подсчет слов не должен учитывать регистр и знаки препинания
     */

    class Counter
    {
        const string path = "alice.txt.gz";
        Dictionary<string, int> result = new Dictionary<string, int>();

        public void Analyze()
        {
            using (FileStream fileStream = new FileStream(path, FileMode.Open, FileAccess.Read))
            {
                using (GZipStream decompressedFile = new GZipStream(fileStream, CompressionMode.Decompress))
                {
                    //string text;
                    //long bytesRead = 0;
                    //byte[] buffer = new byte[ushort.MaxValue * 6];
                    //char[] toRemove = { ' ', '.', ',', '!', '?', '\\', '"', '/', '#', '$', '@', '&', '*', '(', ')', '-', '\r', '\n', '\t', '\'',
                    //'\"', '\v', '\b', '\f', '\a', '\0', '_', '[', ']', '{', '}', ';', ':'};
                    //while ((bytesRead = decompressedFile.Read(buffer, 0, buffer.Length)) > 0)
                    //{
                    //    text = Encoding.UTF8.GetString(buffer);
                    //    string[] words = text.ToLower().Split(toRemove, StringSplitOptions.RemoveEmptyEntries);
                    //    foreach (var word in words)
                    //    {
                    //        if (word.Length > 3)
                    //        {
                    //            if (result.ContainsKey(word)) result[word] += 1;
                    //            else result.Add(word, 1);
                    //        }
                    //    }
                    //}
                    using (StreamReader stream = new StreamReader(decompressedFile))
                    {
                        string text;
                        char[] toRemove = { ' ', '.', ',', '!', '?', '\\', '"', '/', '#', '$', '@', '&', '*', '(', ')', '-', '\r', '\n', '\t', '\'',
                        '\"', '\v', '\b', '\f', '\a', '\0', '_', '[', ']', '{', '}', ';', ':'};
                        while ((text = stream.ReadLine()) != null)
                        {
                            string[] words = text.ToLower().Split(toRemove, StringSplitOptions.RemoveEmptyEntries);
                            foreach (var word in words)
                            {
                                if (word.Length > 3)
                                {
                                    if (result.ContainsKey(word)) result[word] += 1;
                                    else result.Add(word, 1);
                                }
                            }
                        }
                    }
                }
            }
        }

        public void GetResult()
        {
            var values = result.OrderByDescending(r => r.Value).Select(r => r.Value).Take(10).ToList();
            var keys = result.OrderByDescending(r => r.Value).Select(r => r.Key).Take(10).ToList();

            for (int i = 0; i < 10; i++)
            {
                Console.WriteLine($"{keys[i]}: {values[i]}");
            }
        }
    }

    class Program
    {
        static void Main(string[] arg)
        {
            Counter counter = new Counter();
            counter.Analyze();
            counter.GetResult();
            Console.ReadKey();
        }
    }
}