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
            var converter = new XMLConverter("CarsStock.xml");
            var cars = converter.GetCars();
            var dima = new CarsStock(cars);

            Console.WriteLine(dima.CountBrands());
            Console.WriteLine(dima.CountCars());
            Console.WriteLine(dima.GetAveragePrice());
            Console.WriteLine(dima.GetAveragePriceByBrand("Ford"));
        }
    }
}
