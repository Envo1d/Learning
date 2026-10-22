using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entity1
{
    class Program
    {
        static void Main(string[] args)
        {
            DataClasses1DataContext dtc = new DataClasses1DataContext(@"Data Source = localhost; User ID = db_user; Password = CHANGE_ME; Initial Catalog=Northwind; Connect Timeout = 30; Encrypt = False; TrustServerCertificate = False; ApplicationIntent = ReadWrite; MultiSubnetFailover = False");
            var products = (from product in dtc.Products select product).ToList();
            foreach (var prod in products)
            {
                Console.WriteLine($"{prod.ProductName}");
            }
            Console.Read();
        }
    }
}
