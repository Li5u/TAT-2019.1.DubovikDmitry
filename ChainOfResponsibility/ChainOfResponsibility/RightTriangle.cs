namespace ChainOfResponsibility
{
    /// <summary>
    /// Class for right triangles.
    /// </summary>
    class RightTriangle : Triangle
    {
        /// <summary>
        /// Constructor calls base constructor.
        /// </summary>
        /// <param name="a">point a</param>
        /// <param name="b">point b</param>
        /// <param name="c">point c</param>
        public RightTriangle(Point a, Point b, Point c)
            : base(a, b, c) { }

        /// <summary>
        /// Calculates square of the right triangle.
        /// </summary>
        /// <returns>Value of the square</returns>
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
    }
}