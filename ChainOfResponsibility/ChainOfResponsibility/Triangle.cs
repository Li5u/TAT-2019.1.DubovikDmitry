namespace ChainOfResponsibility
{
    /// <summary>
    /// Abstract class for triangles.
    /// </summary>
    abstract class Triangle
    {
        internal Point a;
        internal Point b;
        internal Point c;
        internal double aSide;
        internal double bSide;
        internal double cSide;

        /// <summary>
        /// Constructor initializes points of the triangle.
        /// </summary>
        /// <param name="a">point a</param>
        /// <param name="b">point b</param>
        /// <param name="c">point c</param>
        public Triangle(Point a, Point b, Point c)
        {
            this.a = a;
            this.b = b;
            this.c = c;
            aSide = a.GetDistance(b);
            bSide = a.GetDistance(c);
            cSide = b.GetDistance(c);
        }

        /// <summary>
        /// Abstract method calculates square of the triangle.
        /// </summary>
        /// <returns></returns>
        public abstract double GetSquare();
    
        /// <summary>
        /// Returns type of triangle
        /// </summary>
        /// <returns>type of triangle</returns>
        public string WhoAmI() => GetType().Name;
    }
}