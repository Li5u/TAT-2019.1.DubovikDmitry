using System;

namespace ChainOfResponsibility
{
    class JustTriangle : Triangle
    {
        public JustTriangle(Point a, Point b, Point c)
            : base(a, b, c) { }

        override public double GetSquare()
        {
            double p = (aSide + bSide + cSide) / 2;
            return Math.Sqrt(p * (p - aSide) * (p - bSide) * (p - cSide));
        }

        public override void WhoAmI()
        {
            Console.WriteLine("Just");
        }
    }
}
