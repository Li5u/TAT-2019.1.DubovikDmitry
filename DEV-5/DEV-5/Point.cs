using System;

namespace DEV_5
{
    /// <summary>
    /// Struct for points.
    /// </summary>
    public struct Point
    {
        public int X { get; set; }
        public int Y { get; set; }
        public int Z { get; set; }

        /// <summary>
        /// The class constructor initializes fields.
        /// </summary>
        /// <param name="x">X coordinate</param>
        /// <param name="y">Y coordinate</param>
        /// <param name="z">Z coordinate</param>
        public Point(int x, int y, int z)
        {
            X = x;
            Y = y;
            Z = z;
        }

        /// <summary>
        /// This method calculates distance between this point and another one.
        /// </summary>
        /// <param name="anotherPoint">Another Point</param>
        /// <returns>Distance between two points</returns>
        public double GetDistance(Point anotherPoint) =>
            Math.Sqrt(Math.Pow(anotherPoint.X - X, 2) +
                      Math.Pow(anotherPoint.Y - Y, 2) +
                      Math.Pow(anotherPoint.Z - Z, 2));
    }
}