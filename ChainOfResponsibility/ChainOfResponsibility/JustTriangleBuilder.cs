using System;

namespace ChainOfResponsibility
{
    class JustTriangleBuilder : Builder
    {
        public JustTriangleBuilder(Builder succuser)
            : base(succuser) { }
        public override Triangle BuildTriangle(Point a, Point b, Point c)
        {
            double aSide = a.GetDistance(b); 
            double bSide = a.GetDistance(c);
            double cSide = b.GetDistance(c);
            if (aSide - bSide - cSide < 0 && bSide - aSide - cSide < 0 && cSide - bSide - aSide < 0) 
            {
                return new JustTriangle(a, b, c);
            }
            else if (Successor != null)
            {
                return Successor.BuildTriangle(a, b, c);
            }
            else
            {
                throw new Exception("Cant build triangle");
            }
        }
    }
}
