namespace ChainOfResponsibility
{
    /// <summary>
    /// Abstract class for triangle builders.
    /// </summary>
    abstract class TriangleBuilder
    {
        internal double epsilon = 0.001;
        public TriangleBuilder Successor { get; set; }

        /// <summary>
        /// The class constructor.
        /// </summary>
        /// <param name="successor">Next builder if this one can't make a triangle.</param>
        public TriangleBuilder(TriangleBuilder successor)
        {
            Successor = successor;
        }

        /// <summary>
        /// Builds triangle by points.
        /// </summary>
        /// <param name="a">point a</param>
        /// <param name="b">point b</param>
        /// <param name="c">point c</param>
        /// <returns>Triangle object</returns>
        virtual public Triangle BuildTriangle(Point a, Point b, Point c)
        {
            return new ArbitraryTriangle(a, b, c);
        }
    }
}