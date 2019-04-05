using System;

namespace ChainOfResponsibility
{
    class Program
    {
        static void Main(string[] args)
        {
            var triangleBuilder = new RightTriangleBuilder(
                                  new EquilateralTriangleBuilder(
                                  new JustTriangleBuilder(null)));

            var triangle1 = triangleBuilder.BuildTriangle(new Point(0, 0), new Point(0, 1), new Point(5, 0));
            triangle1.WhoAmI();
            Console.WriteLine(triangle1.GetSquare());

            var triangle2 = triangleBuilder.BuildTriangle(new Point(3, 9), new Point(3, 1), new Point(7, 8));
            triangle2.WhoAmI();
            Console.WriteLine(triangle2.GetSquare());

            var triangle3 = triangleBuilder.BuildTriangle(new Point(0, 0), new Point(0, 1), new Point(0, 2));
            triangle3.WhoAmI();
            Console.WriteLine(triangle3.GetSquare());
        }
    }
}
