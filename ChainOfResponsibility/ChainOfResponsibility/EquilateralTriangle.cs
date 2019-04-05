using System;

namespace ChainOfResponsibility
{
    class EquilateralTriangle : Triangle
    {
        public EquilateralTriangle(Point a, Point b, Point c)
            : base(a, b, c) { }

        public override double GetSquare()
        {
            return Math.Sqrt(3) * aSide * aSide / 4;
        }

        public override void WhoAmI()
        {
            Console.WriteLine("Equilateral");
        }
    }
}
