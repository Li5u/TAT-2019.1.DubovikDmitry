﻿using System;

namespace DEV_6
{
    /// <summary>
    /// This class gives info abous cars stock to user.
    /// </summary>
    class CarsDealer
    {
        private ICommand Command { get; set; }
        private CarsStock CarsStock { get; set; }

        /// <summary>
        /// Constructor initializes fields
        /// </summary>
        /// <param name="carsStock">Stock of cars</param>
        public CarsDealer(CarsStock carsStock) => CarsStock = carsStock;

        /// <summary>
        /// Displays information according to chosen command
        /// </summary>
        public void GetInformation()
        {
            Console.WriteLine("You have commands :\n1)count types\n2)count all\n3)average price\n4)average price <type>\n5)exit");
            Console.WriteLine("Enter command : ");
            string command = String.Empty;
            while ((command = Console.ReadLine().ToLower()) != "exit")
            {
                if (command == "count types")
                {
                    Command = new CountTypesCommand(CarsStock);
                    Console.WriteLine(Command.Execute());
                }

                else if (command == "count all")
                {
                    Command = new CountAllCommand(CarsStock);
                    Console.WriteLine(Command.Execute());
                }

                else if (command == "average price")
                {
                    Command = new AveragePriceCommand(CarsStock);
                    Console.WriteLine(Command.Execute());
                }

                else if (command.Contains("average price"))
                {
                    bool isBrandOnTheStock = false;
                    foreach (var car in CarsStock.Cars)
                    {
                        if (command.Contains(car.Brand.ToLower()))
                        {
                            Command = new AveragePriceByBrandCommand(CarsStock, car.Brand);
                            Console.WriteLine(Command.Execute());
                            isBrandOnTheStock = true;
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
    }
}
