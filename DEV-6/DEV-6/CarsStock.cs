using System.Collections.Generic;
using System.Linq;

namespace DEV_6
{
    /// <summary>
    /// Class contains list of available cars and methods that give information about it.
    /// </summary>
    class CarsStock
    {
        public List<Car> Cars { get; private set; }

        /// <summary>
        /// Constructor initializes fields.
        /// </summary>
        /// <param name="cars">List of cars</param>
        public CarsStock(List<Car> cars)
        {
            Cars = cars;
        }

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
        /// Method counts number of cars
        /// </summary>
        /// <returns>Number of cars</returns>
        public int CountCars()
        {
            return Cars.Count();
        }

        /// <summary>
        /// Calculates average price of all cars.
        /// </summary>
        /// <returns>Average price</returns>
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
        /// Calculates average price for a specific brand.
        /// </summary>
        /// <param name="brand">Brand</param>
        /// <returns>Average price</returns>
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
