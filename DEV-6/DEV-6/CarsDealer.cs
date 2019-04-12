using System;
using System.Collections.Generic;

namespace DEV_6
{
    /// <summary>
    /// This class gives info abous cars stock to user.
    /// </summary>
    class CarsDealer
    {
        private ICommand Command { get; set; }
        private CarsStock CarsStock { get; set; }
        private CarsStock TrucksStock { get; set; }
        private List<ICommand> _commandsToExecute = new List<ICommand>();

        /// <summary>
        /// Constructor initializes fields.
        /// </summary>
        /// <param name="carsStock">Stock of cars</param>
        public CarsDealer(CarsStock carsStock, CarsStock trucksStock)
        {
            CarsStock = carsStock;
            TrucksStock = trucksStock;
        }

        /// <summary>
        /// Displays information according to chosen command.
        /// </summary>
        public void GetInformation()
        {
            Console.WriteLine("You have commands :\n1)count types\n2)count all\n3)average price\n4)average price <type>\n5)exit\n6)execute");
            Console.WriteLine("Enter command : ");
            string command = String.Empty;
            while ((command = Console.ReadLine().ToLower()) != "exit")
            {
                if (command == "execute")
                {
                    foreach(var com in _commandsToExecute)
                    {
                        Console.WriteLine(com?.Execute());
                    }
                }

                else if (command == "count types")
                {
                    Command = new CountTypesCommand(ChooseCarsStock());
                    _commandsToExecute.Add(Command);
                    Console.WriteLine(Command?.Execute());
                }

                else if (command == "count all")
                {
                    Command = new CountAllCommand(ChooseCarsStock());
                    _commandsToExecute.Add(Command);
                    Console.WriteLine(Command?.Execute());
                }

                else if (command == "average price")
                {
                    Command = new AveragePriceCommand(ChooseCarsStock());
                    _commandsToExecute.Add(Command);
                    Console.WriteLine(Command?.Execute());
                }

                else if (command.Contains("average price"))
                {
                    bool isBrandOnTheStock = false;
                    foreach (var car in CarsStock.Cars)
                    {
                        if (command.Contains(car.Brand.ToLower()))
                        {
                            Command = new AveragePriceByBrandCommand(ChooseCarsStock(), car.Brand);
                            _commandsToExecute.Add(Command);
                            isBrandOnTheStock = true;
                            Console.WriteLine(Command?.Execute());
                            break;
                        }
                    }

                    if (!isBrandOnTheStock)
                    {
                        Console.WriteLine("We dont have cars of this brand.");
                    }   
                }

                else
                {
                    Console.WriteLine("This command does not exist. Please enter from the suggested list.");
                }
            }
        }
        
        /// <summary>
        /// Returns required cars stock.
        /// </summary>
        /// <returns></returns>
        private CarsStock ChooseCarsStock()
        {
            Console.WriteLine("Enter type of car(car/truck):");

            if (Console.ReadLine() == "car")
            {
                return CarsStock;
            }

            else if (Console.ReadLine() == "truck")
            {
                return TrucksStock;
            }

            else
            {
                throw new Exception("Wrong car type!");
            }
        }
    }
}
