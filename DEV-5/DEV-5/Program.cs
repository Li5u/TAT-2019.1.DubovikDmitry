using System;
    
namespace DEV_5
{
    /// <summary>
    /// This class creates flying objects for flight to the point. 
    /// </summary>
    class Program
    {
        /// <summary>
        /// Entry point of the program that calculates and displays time that took different flying object to fly.
        /// </summary>
        /// <param name="args"></param>
        static void Main(string[] args)
        {
            try
            {
                var targetPoint = new Point(100, 200, 800);
                var flyingObjects = new IFlyable[] { new Bird(), new Plane(), new SpaceShip() };
                foreach (var flyingObject in flyingObjects)
                {
                    flyingObject.FlyTo(targetPoint);
                    Console.WriteLine($"{flyingObject.WhoAmI()}: {flyingObject.GetFlyTime()}");
                }
            }
            catch (Exception e)
            {
                Console.WriteLine($"Error : {e.Message}");
            }
        }
    }
}
