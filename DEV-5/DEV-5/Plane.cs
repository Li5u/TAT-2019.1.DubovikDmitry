using System;

namespace DEV_5
{
    /// <summary>
    /// The class for plane objects.
    /// </summary>
    public class Plane : IFlyable
    {
        private const int startSpeed = 200;
        private const int speedIncrease = 10;
        private const int distanceOfChangeSpeed = 10;
        public Point CurrentPoint { get; set; }
        public double Distance { get; set; }

        /// <summary>
        /// Constructor for the class initializes starting position.
        /// </summary>
        /// <param name="x">Starting X coordinate</param>
        /// <param name="y">Starting Y coordinate</param>
        /// <param name="z">Starting Z coordinate</param>
        public Plane(int x = 0, int y = 0, int z = 0)
        {
            CurrentPoint = new Point(x, y, z);
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
        public double GetFlyTime()
        {
            double time = 0;
            int currentSpeed = startSpeed;
            while (Distance > 0)
            {
                if (Distance > distanceOfChangeSpeed)
                {
                    time += distanceOfChangeSpeed / (Double)currentSpeed;
                    Distance -= distanceOfChangeSpeed;
                    currentSpeed += speedIncrease;
                }
                else
                {
                    time += Distance / currentSpeed;
                    Distance = 0;
                }
            }
            return time;
        }

        /// <summary>
        /// This method returns type to the current object.
        /// </summary>
        /// <returns>Type to the current object</returns>
        public IFlyable WhoAmI() => this;
    }
}