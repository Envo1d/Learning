using System;
using System.Collections.Generic;
using System.Xml.Serialization;
using System.IO;

namespace WindowsFormsHW4
{
    public class SaveLoad
    {

        [Serializable]
        [XmlRoot("CarList")]
        [XmlInclude(typeof(Car))]
        public class Info
        {
            [XmlArray("CarList")]
            [XmlArrayItem("Cars")]
            public List<Car> cars = new List<Car>();

            public Info() { }
        }

        public Info info = new Info();

        public void Save(Stream stream)
        {
            Type[] type = { typeof(Car) };
            XmlSerializer formatter = new XmlSerializer(typeof(Info), type);

            using(Stream s = stream)
            {
                formatter.Serialize(s, info);
            }
        }
        public void Load(Stream stream)
        {
            Type[] type = { typeof(Car) };
            XmlSerializer formatter = new XmlSerializer(typeof(Info), type);

            using (Stream s = stream)
            {
                if(s.Length != 0)
                {
                    info = null;
                    info = (Info)formatter.Deserialize(s);
                }
            }
        }
        public void Clear()
        {
            info.cars.Clear();
        }
    }
}
