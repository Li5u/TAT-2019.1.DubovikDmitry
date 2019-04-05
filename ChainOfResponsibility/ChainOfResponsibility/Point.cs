using System;

namespace ChainOfResponsibility
{
    /// <summary>
    /// Struct for 2D point.
    /// </summary>
    struct Point
    {
        public double x;
        public double y;

        /// <summary>
        /// Constructor initializes coordinates of the point.
        /// </summary>
        /// <param name="x">x coordinate</param>
        /// <param name="y">y coordinate</param>
        public Point(double x, double y)
        {
            this.x = x;
            this.y = y;
        }

        /// <summary>
        /// Calculates length between this point and another.
        /// </summary>
        /// <param name="another">another Point object</param>
        /// <returns>Length between points</returns>
        public double GetDistance(Point another)
        {
            return  Math.Sqrt(Math.Pow(x - another.x, 2) + Math.Pow(y - another.y, 2));
        }
    }
}