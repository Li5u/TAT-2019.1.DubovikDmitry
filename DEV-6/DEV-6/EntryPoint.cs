using System;

namespace DEV_6
{
    /// <summary>
    /// Class contains entry point to the program.
    /// </summary>
    class EntryPoint
    {
        /// <summary>
        /// Creates cars list according to xml file and asks user for commands.
        /// </summary>
        /// <param name="args"></param>
        static void Main(string[] args)
        {
            var a = new TrucksXMLMaker();
            a.MakeXML();
            try
            {
                if (args.Length == 0)
                {
                    throw new Exception("File name not specified");
                }
                var carGetter = new XMLConverter(args[0]);
                var truckGetter = new XMLConverter(args[1]);
                var dealer = new CarsDealer(new CarsStock(carGetter.GetCars()), new CarsStock(truckGetter.GetCars()));
                dealer.GetInformation();
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error: {ex.Message}");
            }

        }
    }
}
