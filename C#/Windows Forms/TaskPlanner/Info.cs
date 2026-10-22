using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Xml.Serialization;
using System.Xml;

namespace Exam
{
    [Serializable]
    [XmlType("Information")]
    public class Information
    {
        [XmlElement("Name")]
        public string Name { get; set; }
        [XmlElement("DateTime")]
        public DateTime DateTime { get; set; }
        [XmlElement("Priority")]
        public Priority Priority { get; set; }
        [XmlElement("Tags")]
        public string Tags { get; set; } = "";
        [XmlElement("Comment")]
        public string Comment { get; set; } = "";
        [XmlElement("File")]
        public string PathToFile { get; set; } = "";

        public override string ToString()
        {
            return $"{nameof(Name)}: {Name}, {nameof(DateTime)}: {DateTime.ToShortDateString()}, {nameof(Priority)}: {Enum.GetName(typeof(Priority), Priority)}, {nameof(Tags)}: {Tags}, {nameof(Comment)}: {Comment}";
        }

        public Information() { }
    }
    public class SaveLoad
    {
        [Serializable]
        [XmlRoot("TaskList")]
        [XmlInclude(typeof(Information))]
        public class Info
        {
            [XmlArray("TaskList")]
            [XmlArrayItem("Tasks")]
            public List<Information> tasks = new List<Information>();

            public Info() { }
        }
        public Info info = new Info();

        public void Save(Stream stream)
        {
            Type[] type = { typeof(Information) };
            XmlSerializer formatter = new XmlSerializer(typeof(Info), type);

            using (Stream s = stream)
            {
                formatter.Serialize(s, info);
            }
        }
        public void Save(string path)
        {
            Type[] type = { typeof(Information) };
            XmlSerializer formatter = new XmlSerializer(typeof(Info), type);

            using (StreamWriter s = new StreamWriter(path))
            {
                formatter.Serialize(s, info);
            }
        }
        public void Load(Stream stream)
        {
            Type[] type = { typeof(Information) };
            XmlSerializer formatter = new XmlSerializer(typeof(Info), type);

            using (Stream s = stream)
            {
                if (s.Length != 0)
                {
                    info = null;
                    info = (Info)formatter.Deserialize(s);
                }
            }
        }
        public void Clear()
        {
            info.tasks.Clear();
        }
    }

    [Serializable]
    public enum Priority
    {
        [XmlEnum]
        Low,
        [XmlEnum]
        Middle,
        [XmlEnum]
        High
    }
}
