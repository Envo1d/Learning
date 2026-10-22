using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.IO;
using System.Linq;
using System.Text.Json;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace ASP_HW1.Models
{
    public class Contact
    {
        public string Name { get; set; }
        public int Number { get; set; }
        public int AlterNumber { get; set; }
        [EmailAddress]
        public string Email { get; set; }
        public string Description { get; set; }
    }
    public static class Contacts
    {
        public static List<Contact> ContactsList { get; set; } = new List<Contact>();
        public static void AddNew(string name, int number, int altNumber, string email, string desc) => 
            ContactsList.Add(new Contact { Name = name, Number = number, AlterNumber = altNumber, Email = email, Description = desc });
        public static void DeleteElem(int idx)
        {
            ContactsList.RemoveAt(idx); 
        }
        public static async void SaveToFile(string path)
        {
            if (path.Contains(".xml"))
            {
                XmlSerializer serializer = new XmlSerializer(typeof(List<Contact>));
                var filepath = Path.Combine("wwwroot/Files", path);
                using (FileStream fs = new FileStream(filepath, FileMode.Create))
                {
                    try
                    {
                        serializer.Serialize(fs, ContactsList);
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
                        await JsonSerializer.SerializeAsync<List<Contact>>(fs, ContactsList);
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
                ContactsList.Clear();
                using (FileStream fs = new FileStream(filepath, FileMode.Open))
                {
                    try
                    {
                        ContactsList = (List<Contact>)serializer.Deserialize(fs);
                    }
                    catch (Exception e)
                    {}
                }
            }
            else
            {
                var filepath = Path.Combine("wwwroot/Files", path);
                using (FileStream fs = new FileStream(filepath, FileMode.Open))
                {
                    try
                    {
                        ContactsList = await JsonSerializer.DeserializeAsync<List<Contact>>(fs);
                    }
                    catch (Exception e)
                    {}
                }
            }
        }
    }
}
