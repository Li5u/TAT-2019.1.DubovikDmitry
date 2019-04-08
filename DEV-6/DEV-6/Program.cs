using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DEV_6
{
    class Program
    {
        static void Main(string[] args)
        {
            //var b = new XMLMaker();
            //b.MakeXML();
            var a = new CarsStock("CarsStock.xml");
            Console.WriteLine(a.CountCars());
        }
    }
}
