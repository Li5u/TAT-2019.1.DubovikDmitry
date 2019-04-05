using System;

namespace ChainOfResponsibility
{
    class Point
    {
        public double x;
        public double y;

        public Point(double x, double y)
        {
            this.x = x;
            this.y = y;
        }

        public double GetDistance(Point another)
        {
            return  Math.Sqrt(Math.Pow(x - another.x, 2) + Math.Pow(y - another.y, 2));
        }
    }
}
