namespace DEV_5
{
    /// <summary>
    /// The class for space sheep objects.
    /// </summary>
    public class SpaceShip: IFlyable
    {
        public const int speed = 8000 * 3600;    //8000 km/s in km/h
        public Point CurrentPoint { get; set; }
        public double Distance { get; set; }

        /// <summary>
        /// Constructor for the class initializes starting position.
        /// </summary>
        /// <param name="x">Starting X coordinate</param>
        /// <param name="y">Starting Y coordinate</param>
        /// <param name="z">Starting Z coordinate</param>
        public SpaceShip(int x = 0, int y = 0, int z = 0)
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
        public double GetFlyTime() => Distance / speed;

        /// <summary>
        /// This method returns type to the current object.
        /// </summary>
        /// <returns>Type to the current object</returns>
        public IFlyable WhoAmI() => this;
    }
}