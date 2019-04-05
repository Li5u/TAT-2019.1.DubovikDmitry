using System;

namespace ChainOfResponsibility
{
    /// <summary>
    /// Class for arbitrary triangles.
    /// </summary>
    class ArbitraryTriangle : Triangle
    {
        /// <summary>
        /// Constructor calls base constructor.
        /// </summary>
        /// <param name="a">point a</param>
        /// <param name="b">point b</param>
        /// <param name="c">point c</param>
        public ArbitraryTriangle(Point a, Point b, Point c)
            : base(a, b, c) { }

        /// <summary>
        /// Calculates square of the arbitrary triangle.
        /// </summary>
        /// <returns>Value of the square</returns>
        override public double GetSquare()
        {
            double p = (aSide + bSide + cSide) / 2;
            return Math.Sqrt(p * (p - aSide) * (p - bSide) * (p - cSide));
        }
    }
}