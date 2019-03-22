using System;

namespace DEV_3
{
    /// <summary>
    /// Entry point of program.
    /// </summary>
    class EntryPoint
    {
        /// <summary>
        /// The main method takes arguments from command line(criterion, money, productivity) 
        /// and finds optimal team for this parameters
        /// </summary>
        /// <remarks>
        /// Employee(salary, productivity): Junior(500, 10), Middle(1100, 25), Senior(2500, 70), Lead(5000, 200)
        /// </remarks>
        /// <param name="args">Arguments from command line</param>
        static void Main(string[] args)
        {
            try
            {
                if (args.Length < 3)
                {
                    throw new Exception("3 arguments are required: criterion, money, productivity");
                }

                int.TryParse(args[0], out var criterion);
                int.TryParse(args[1], out var amountOfMoney);
                int.TryParse(args[2], out var productivity);
                var company = new Company();
                TeamSearcher teamSearher;
                switch (criterion)
                {
                    //Call for appropriate method, depending on the criterion entered
                    case 1:
                        teamSearher = new TeamSearcherWithMaxProductivity(amountOfMoney, productivity);
                        break;
                    case 2:
                        teamSearher = new TeamSearcherWithMinimumCost(amountOfMoney, productivity);
                        break;
                    case 3:
                        teamSearher = new TeamSearcherWithoutJuniors(amountOfMoney, productivity);
                        break;
                    default:
                        throw new Exception("Unknown criteria entered.");
                }
                var team = company.FindTeam(teamSearher);
                company.CountAndDisplayEmployeesInTeam(team);
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error: {ex.Message}");
            }
        }
    }
}
