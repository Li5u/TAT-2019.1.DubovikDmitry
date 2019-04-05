using System;

namespace ChainOfResponsibility
{
    class RightTriangleBuilder : Builder
    {
        public RightTriangleBuilder(Builder succuser)
            : base(succuser) { }

        public override Triangle BuildTriangle(Point a, Point b, Point c)
        {
            double aSide = a.GetDistance(b); 
            double bSide = a.GetDistance(c);
            double cSide = b.GetDistance(c);
            if (Math.Abs(aSide * aSide - bSide * bSide - cSide * cSide) < epsilon || Math.Abs(bSide * bSide - aSide * aSide - cSide * cSide) < epsilon || Math.Abs(cSide * cSide - bSide * bSide - aSide * aSide) < epsilon)
            {
                return new RightTriangle(a, b, c);
            }
            else
            {
                return Successor?.BuildTriangle(a, b, c);
            }
        }
    }
}
