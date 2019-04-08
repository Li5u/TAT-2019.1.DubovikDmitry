﻿using System;

namespace ChainOfResponsibility
{
    /// <summary>
    /// Class for equilateral triangles.
    /// </summary>
    class EquilateralTriangle : Triangle
    {
        /// <summary>
        /// Constructor calls base constructor.
        /// </summary>
        /// <param name="a">point a</param>
        /// <param name="b">point b</param>
        /// <param name="c">point c</param>
        public EquilateralTriangle(Point a, Point b, Point c)
            : base(a, b, c) { }

        /// <summary>
        /// Calculates square of the equilateral triangle.
        /// </summary>
        /// <returns>Value of the square</returns>
        public override double GetSquare()
        {
            return Math.Sqrt(3) * aSide * aSide / 4;
        }
    }
}