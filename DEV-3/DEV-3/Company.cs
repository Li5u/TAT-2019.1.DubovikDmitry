using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DEV_3
{
    /// <summary>
    /// 
    /// </summary>
    class Company
    {
        private const int _juniorsQuantity = 50;
        private const int _middleQuantity = 30;
        private const int _seniorQuantity = 10;
        private const int _leadQuantity = 3;
        private List<Employee> _availableEmployees;

        /// <summary>
        /// 
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
        /// <param name="amountOfMoney"></param>
        /// <param name="productivity"></param>
        /// <param name="criterion"></param>
        /// <returns></returns>
        public List<Employee> FindTeam(TeamSearcher searcher, int amountOfMoney, int productivity)
        {
            return (searcher.Choose(_availableEmployees, amountOfMoney, productivity));
        }

        public void CountAndDisplayTeam(List<Employee> team)
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