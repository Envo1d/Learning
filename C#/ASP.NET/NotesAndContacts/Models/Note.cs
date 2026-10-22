using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text.Json;
using System.Threading.Tasks;
using System.Xml.Serialization;
using System.Runtime.Serialization.Formatters.Binary;

namespace ASP_HW1.Models
{
    [Serializable]
    public class Note
    {
        public string Title { get; set; }
        public string Text { get; set; }
        public string Tags { get; set; }
        public DateTime CreatedAt { get; set; }
        public Note() { }
    }
    [Serializable]
    public static class Notes
    {
        public static List<Note> Notices { get; set; } = new List<Note>();
        public static void AddNew(string title, string text, string tags)
        {
            Notices.Add(new Note { Title = title, Text = text, Tags = tags, CreatedAt = DateTime.Now });
        }
        public static void DeleteElem(int idx)
        {
            Notices.RemoveAt(idx);
        }
        public static async void SaveToFile(string path)
        {
            if (path.Contains(".xml"))
            {
                XmlSerializer serializer = new XmlSerializer(typeof(List<Note>));
                var filepath = Path.Combine("wwwroot/Files", path);
                using (FileStream fs = new FileStream(filepath, FileMode.Create))
                {
                    try
                    {
                        serializer.Serialize(fs, Notices);
                    }
                    catch (Exception e)
                    { }
                }
            }
            else
            {
                var filepath = Path.Combine("wwwroot/Files", path);
                using (FileStream fs = new FileStream(filepath, FileMode.Create))
                {
                    try
                    {
                        await JsonSerializer.SerializeAsync<List<Note>>(fs, Notices);
                    }
                    catch (Exception e)
                    { }
                }
            }
        }
        public static async void LoadFromFile(string path)
        {
            if (path.Contains(".xml"))
            {
                XmlSerializer serializer = new XmlSerializer(typeof(List<Note>));
                var filepath = Path.Combine("wwwroot/Files", path);
                Notices.Clear();
                using (FileStream fs = new FileStream(filepath, FileMode.Open))
                {
                    try
                    {
                        Notices = (List<Note>)serializer.Deserialize(fs);
                    }
                    catch (Exception e)
                    { }
                }
            }
            else
            {
                var filepath = Path.Combine("wwwroot/Files", path);
                using (FileStream fs = new FileStream(filepath, FileMode.Open))
                {
                    try
                    {
                        Notices = await JsonSerializer.DeserializeAsync<List<Note>>(fs);
                    }
                    catch (Exception e)
                    { }
                }
            }
        }
    }
}
