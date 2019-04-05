﻿using System;

namespace ChainOfResponsibility
{
    /// <summary>
    /// Class for equilateral triangle builders.
    /// </summary>
    class EquilateralTriangleBuilder : TriangleBuilder
    {
        /// <summary>
        /// Constructor calls base construct.
        /// </summary>
        /// <param name="succuser">Next builder if this one can't make a triangle.</param>
        public EquilateralTriangleBuilder(TriangleBuilder succuser)
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
            if (CheckIsItEquilateral(a, b, c))  
            {
                return new EquilateralTriangle(a, b, c);
            }
            else
            {
                return Successor?.BuildTriangle(a, b, c);
            }
        }

        /// <summary>
        /// Takes three points and checks is it a equilateral triangle.
        /// </summary>
        /// <param name="a">point a</param>
        /// <param name="b">point b</param>
        /// <param name="c">point c</param>
        /// <returns>true if it's points of equilateral triangle</returns>
        private bool CheckIsItEquilateral(Point a, Point b, Point c)
        {
            double aSide = a.GetDistance(b);
            double bSide = a.GetDistance(c);
            double cSide = b.GetDistance(c);
            return (Math.Abs(aSide - cSide) < epsilon && Math.Abs(bSide - cSide) < epsilon);
        }
    }
}