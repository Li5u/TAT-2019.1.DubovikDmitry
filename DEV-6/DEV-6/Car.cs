using System;

namespace DEV_6
{
    /// <summary>
    /// Class contains info about car
    /// </summary>
    class Car
    {
        public string Name { get; private set; }
        public string Brand { get; private set; }
        public string Model { get; private set; }
        public int Price { get; private set; }

        /// <summary>
        /// Constructor initializes fields.
        /// </summary>
        /// <param name="name">Name of the car</param>
        /// <param name="brand">Brand of the car</param>
        /// <param name="model">Model of the car</param>
        /// <param name="price">Price of the car</param>
        public Car(string name, string brand, string model, int price)
        {
            Name = name != string.Empty ? name : throw new Exception("Name should not be empty.");
            Brand = brand != string.Empty ? brand : throw new Exception("Brand should not be empty.");
            Model = model != string.Empty ? model : throw new Exception("Model should not be empty.");
            Price = price >= 0 ? price : throw new Exception("Price should be non-negative.");
        }
    }
}
