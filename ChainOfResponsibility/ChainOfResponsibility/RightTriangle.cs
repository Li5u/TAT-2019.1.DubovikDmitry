using System;

namespace ChainOfResponsibility
{
    class RightTriangle : Triangle
    {
        public RightTriangle(Point a, Point b, Point c)
            : base(a, b, c) { }

        public override double GetSquare()
        {
            if(aSide > bSide && aSide > cSide)
            {
                return bSide * cSide / 2;
            }
            else if (bSide > aSide && bSide > cSide)
            {
                return aSide * cSide / 2;
            }
            else
            {
                return aSide * bSide / 2;
            }
        }

        public override void WhoAmI()
        {
            Console.WriteLine("Right");
        }
    }
}
