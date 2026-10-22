using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace WindowsFormsHW4
{
    [Serializable]
    [XmlType("Answers")]
    public class Car
    {
        [XmlElement("Id")]
        public int Id { get; set; }
        [XmlElement("Model")]
        public string Model { get; set; }
        [XmlElement("Price")]
        public decimal Price { get; set; }
        [XmlElement("Sold")]
        public bool Sold { get; set; }

        public Car() { }

        public override string ToString()
        {
            return $"{nameof(Id)}: {Id}, {nameof(Model)}: {Model}, {nameof(Price)}: {Price}, {nameof(Sold)}: {Sold}";
        }
    }
}
