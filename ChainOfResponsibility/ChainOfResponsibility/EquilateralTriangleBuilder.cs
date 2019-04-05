using System;

namespace ChainOfResponsibility
{
    class EquilateralTriangleBuilder : Builder
    {
        public EquilateralTriangleBuilder(Builder succuser)
            : base(succuser) { }
        public override Triangle BuildTriangle(Point a, Point b, Point c)
        {
            double aSide = a.GetDistance(b);
            double bSide = a.GetDistance(c);
            double cSide = b.GetDistance(c);
            if (Math.Abs(aSide - cSide) < epsilon && Math.Abs(bSide - cSide) < epsilon) 
            {
                return new EquilateralTriangle(a, b, c);
            }
            else
            {
                return Successor.BuildTriangle(a, b, c);
            }
        }
    }
}
