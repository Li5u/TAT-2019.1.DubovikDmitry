using System;

namespace ChainOfResponsibility
{
    /// <summary>
    /// Entry point of the program that calculates square of the triangle.
    /// </summary>
    class EntryPoint
    {
        /// <summary>
        /// Entry point creates triangle builder and it builds triangle with three points
        /// If successfully then gets square of the triangle.
        /// </summary>
        static void Main(string[] args)
        {
            try
            {
                var triangleBuilder = new RightTriangleBuilder(
                                      new EquilateralTriangleBuilder(
                                      new ArbitraryTriangleBuilder(null)));

                var triangle1 = triangleBuilder.BuildTriangle(new Point(0, 0), new Point(0, 1), new Point(5, 0));
                Console.WriteLine(triangle1.WhoAmI());
                Console.WriteLine(triangle1.GetSquare());

                var triangle2 = triangleBuilder.BuildTriangle(new Point(3, 9), new Point(3, 1), new Point(7, 8));
                Console.WriteLine(triangle2.WhoAmI());
                Console.WriteLine(triangle2.GetSquare());

                var triangle3 = triangleBuilder.BuildTriangle(new Point(0, 0), new Point(0, 1), new Point(0, 2));
                Console.WriteLine(triangle3.WhoAmI());
                Console.WriteLine(triangle3.GetSquare());
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }
    }
}