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
            Console.WriteLine("You have commands :\n1)count types\n2)count all\n3)average price\n4)average price <type>\n5)execute\n6)exit");
            Console.WriteLine("Enter command(1-6) : ");

            bool isInformationNeed = true;

            while (isInformationNeed)
            {
                if (!int.TryParse(Console.ReadLine(), out int input))
                {
                    throw new Exception("Incorrect input data");
                }

                if ((AvailableCommands)input == AvailableCommands.Execute)
                {
                    foreach(var com in _commandsToExecute)
                    {
                        Console.WriteLine(com?.Execute());
                    }
                }

                else if ((AvailableCommands)input == AvailableCommands.CountTypes)
                {
                    Command = new CountTypesCommand(ChooseCarsStock());
                    _commandsToExecute.Add(Command);
                    Console.WriteLine(Command?.Execute());
                }

                else if ((AvailableCommands)input == AvailableCommands.CountAll)
                {
                    Command = new CountAllCommand(ChooseCarsStock());
                    _commandsToExecute.Add(Command);
                    Console.WriteLine(Command?.Execute());
                }

                else if ((AvailableCommands)input == AvailableCommands.AveragePrice)
                {
                    Command = new AveragePriceCommand(ChooseCarsStock());
                    _commandsToExecute.Add(Command);
                    Console.WriteLine(Command?.Execute());
                }

                else if ((AvailableCommands)input == AvailableCommands.AveragePriceType)
                {
                    bool isBrandOnTheStock = false;

                    Console.WriteLine("Enter car brand:");
                    string brand = Console.ReadLine();

                    foreach (var car in CarsStock.Cars)
                    {
                        if (brand == car.Brand.ToLower())
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

                else if ((AvailableCommands)input == AvailableCommands.Exit)
                {
                    isInformationNeed = false;
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
            Console.WriteLine("Enter type of car(passenger(1)/truck(2):");

            if (!int.TryParse(Console.ReadLine(), out int input))
            {
                throw new Exception("Incorrect input data");
            }

            if ((CarTypes)input == CarTypes.Passenger)
            {
                return CarsStock;
            }

            else if ((CarTypes)input == CarTypes.Truck)
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
