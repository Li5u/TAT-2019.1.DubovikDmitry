using System;

namespace ChainOfResponsibility
{
    /// <summary>
    /// Class for right triangle builders.
    /// </summary>
    class RightTriangleBuilder : TriangleBuilder
    {
        /// <summary>
        /// Constructor calls base construct.
        /// </summary>
        /// <param name="succuser">Next builder if this one can't make a triangle.</param>
        public RightTriangleBuilder(TriangleBuilder succuser)
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
            if (CheckIsItRight(a, b, c))
            {
                return new RightTriangle(a, b, c);
            }
            else
            {
                return Successor?.BuildTriangle(a, b, c);
            }
        }

        /// <summary>
        /// Takes three points and checks is it a right triangle.
        /// </summary>
        /// <param name="a">point a</param>
        /// <param name="b">point b</param>
        /// <param name="c">point c</param>
        /// <returns>true if it's points of right triangle</returns>
        private bool CheckIsItRight(Point a, Point b, Point c)
        {
            double aSide = a.GetDistance(b);
            double bSide = a.GetDistance(c);
            double cSide = b.GetDistance(c);
            return (Math.Abs(aSide * aSide - bSide * bSide - cSide * cSide) < epsilon
                || Math.Abs(bSide * bSide - aSide * aSide - cSide * cSide) < epsilon
                || Math.Abs(cSide * cSide - bSide * bSide - aSide * aSide) < epsilon);
        }
    }
}