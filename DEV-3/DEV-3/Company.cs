using System;
using System.Collections.Generic;

namespace DEV_3
{
    /// <summary>
    /// This class contains all employees which available now.
    /// </summary>
    class Company
    {
        private const int _juniorsQuantity = 50;
        private const int _middleQuantity = 30;
        private const int _seniorQuantity = 10;
        private const int _leadQuantity = 3;
        private List<Employee> _availableEmployees;

        /// <summary>
        /// The class constructor initializes fields.
        /// </summary>
        public Company()
        {
            _availableEmployees = new List<Employee>();
            for (int i = 0; i < _juniorsQuantity; i++)
            {
                _availableEmployees.Add(new Junior());
            }
            for (int i = 0; i < _middleQuantity; i++)
            {
                _availableEmployees.Add(new Middle());
            }
            for (int i = 0; i < _seniorQuantity; i++)
            {
                _availableEmployees.Add(new Senior());
            }
            for (int i = 0; i < _leadQuantity; i++)
            {
                _availableEmployees.Add(new Lead());
            }
        }

        /// <summary>
        /// This method returns list of employees needed for task.
        /// </summary>
        /// <param name="searcher">Searcher according to the customer's criteria</param>
        /// <returns></returns>
        public List<Employee> FindTeam(TeamSearcher searcher)
        {
            return (searcher.Choose(_availableEmployees));
        }

        /// <summary>
        /// This method counts all employees in team and display this information to the console.
        /// </summary>
        /// <param name="team"></param>
        public void CountAndDisplayEmployeesInTeam(List<Employee> team)
        {
            int leadCount = 0;
            int seniorCount = 0;
            int middleCount = 0;
            int juniorCount = 0;
            foreach (var a in team)
            {
                if (a is Lead)
                {
                    leadCount++;
                    continue;
                }
                if (a is Senior)
                {
                    seniorCount++;
                    continue;
                }
                if (a is Middle)
                {
                    middleCount++;
                    continue;
                }
                if (a is Junior)
                {
                    juniorCount++;
                    continue;
                }
            }
            Console.WriteLine($"Junior: {juniorCount}\nMiddle: {middleCount}\nSenior: {seniorCount}\nLead:{leadCount}");
        }
    }
}