using System;

namespace DEV_5
{
    /// <summary>
    /// The class for bird objects.
    /// </summary>
    public class Bird : IFlyable
    {
        public int speed;
        public Point CurrentPoint { get; set; }
        public double Distance { get; set; }

        /// <summary>
        /// Constructor for the class initializes starting position.
        /// </summary>
        /// <param name="x">Starting X coordinate</param>
        /// <param name="y">Starting Y coordinate</param>
        /// <param name="z">Starting Z coordinate</param>
        public Bird(int x = 0, int y = 0, int z = 0)
        {
            CurrentPoint = new Point(x, y, z);
            speed = new Random().Next(1, 20);
        }

        /// <summary>
        /// This method changes current point of the object.
        /// </summary>
        /// <param name="newPoint">New point</param>
        public void FlyTo(Point newPoint)
        {
            Distance += CurrentPoint.GetDistance(newPoint);
            CurrentPoint = newPoint;
        }

        /// <summary>
        /// THis method calculates time that took the object to fly.
        /// </summary>
        /// <returns>Time of the flight</returns>
        public double GetFlyTime() => Distance / speed;

        /// <summary>
        /// This method returns type to the current object.
        /// </summary>
        /// <returns>Type to the current object</returns>
        public IFlyable WhoAmI() => this;
    }
}