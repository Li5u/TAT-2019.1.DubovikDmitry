using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace DEV_6
{
    class CarsStock
    {
        public List<Car> Cars { get; private set; }

  
        public CarsStock(List<Car> cars) => Cars = cars;

        /// <summary>
        /// Method counts number of types.
        /// </summary>
        /// <returns>Number of brand</returns>
        public int CountBrands()
        {
            HashSet<string> brands = new HashSet<string>();

            foreach (var car in Cars)
            {
                brands.Add(car.Brand);
            }

            return brands.Count;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public int CountCars() => Cars.Count();


        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public double GetAveragePrice()
        {
            int totalPrice = 0;
            foreach (var car in Cars)
            {
                totalPrice += car.Price;
            }
            return totalPrice / CountCars();
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="brand"></param>
        /// <returns></returns>
        public double GetAveragePriceByBrand(string brand)
        {
            int totalPrice = 0;
            int carsByBrandCounter = 0;
            foreach (var car in Cars)
            {
                if(car.Brand == brand)
                {
                    totalPrice += car.Price;
                    carsByBrandCounter += 1;
                }
            }
            return totalPrice / carsByBrandCounter;
        }
    }
}
