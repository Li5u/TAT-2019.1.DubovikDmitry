using System;

namespace ChainOfResponsibility
{
    /// <summary>
    /// Class for arbitrary triangle builders.
    /// </summary>
    class ArbitraryTriangleBuilder : TriangleBuilder
    {
        /// <summary>
        /// Constructor calls base construct.
        /// </summary>
        /// <param name="succuser">Next builder if this one can't make a triangle.</param>
        public ArbitraryTriangleBuilder(TriangleBuilder succuser)
            : base(succuser) { }

        /// <summary>
        /// Takes three points and builds triangle according to them if it possible.
        /// </summary>
        /// <param name="a">point a</param>
        /// <param name="b">point b</param>
        /// <param name="c">point c</param>
        /// <returns>new Triangle object</returns>
        public override Triangle BuildTriangle(Point a, Point b, Point c)
        {
            if (CheckIsItTriangle(a, b, c))  
            {
                return new ArbitraryTriangle(a, b, c);
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

        /// <summary>
        /// Takes three points and checks is it a triangle.
        /// </summary>
        /// <param name="a">point a</param>
        /// <param name="b">point b</param>
        /// <param name="c">point c</param>
        /// <returns>true if it's points of triangle</returns>
        private bool CheckIsItTriangle(Point a, Point b, Point c)
        {
            double aSide = a.GetDistance(b);
            double bSide = a.GetDistance(c);
            double cSide = b.GetDistance(c);
            return (aSide - bSide - cSide < 0 && bSide - aSide - cSide < 0 && cSide - bSide - aSide < 0);
        }
    }
}