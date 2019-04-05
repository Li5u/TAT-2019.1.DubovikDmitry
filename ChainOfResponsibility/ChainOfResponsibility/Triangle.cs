using System;

namespace ChainOfResponsibility
{
    class Triangle
    {
        internal Point a;
        internal Point b;
        internal Point c;
        internal double aSide;
        internal double bSide;
        internal double cSide;

        public Triangle() {}

        public Triangle(Point a, Point b, Point c)
        {
            this.a = a;
            this.b = b;
            this.c = c;
            aSide = Math.Sqrt(Math.Pow(a.x - b.x, 2) + Math.Pow(a.y - b.y, 2));
            bSide = Math.Sqrt(Math.Pow(a.x - c.x, 2) + Math.Pow(a.y - c.y, 2));
            cSide = Math.Sqrt(Math.Pow(b.x - c.x, 2) + Math.Pow(b.y - c.y, 2));
        }

        virtual public double GetSquare()
        {
            double p = (aSide + bSide + cSide) / 2;
            return Math.Sqrt(p * (p - aSide) * (p - bSide) * (p - cSide));
        }

        virtual public void WhoAmI() { }
    }
}
