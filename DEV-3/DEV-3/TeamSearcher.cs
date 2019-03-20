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
    class TeamSearcher
    {
        private List<int> _employees;
        private Junior _junior;
        private Middle _middle;
        private Senior _senior;
        private Lead _lead;

        /// <summary>
        /// 
        /// </summary>
        public TeamSearcher()
        {
            _employees = new List<int> { 0, 0, 0, 0 };
            _junior = new Junior();
            _middle = new Middle();
            _senior = new Senior();
            _lead = new Lead();
        }

        /// <summary>
        /// This method returns list of employees needed for task.
        /// </summary>
        /// <param name="amountOfMoney"></param>
        /// <param name="productivity"></param>
        /// <param name="criterion"></param>
        /// <returns></returns>
        public List<int> FindTeam(int amountOfMoney, int productivity, int criterion)
        { 
            switch (criterion)
            {
                case 1:
                    FindEmployeesByFirstCriterion(amountOfMoney);
                    break;
            }
            return _employees;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="amountOfMoney"></param>
        /// <returns></returns>
        private List<int> FindEmployeesByFirstCriterion(int amountOfMoney)
        {
            while (amountOfMoney > _lead.Salary)
            {
                _employees[3]++;
                amountOfMoney -= _lead.Salary;
            }
            while (amountOfMoney > _senior.Salary)
            {
                _employees[2]++;
                amountOfMoney -= _senior.Salary;
            }
            while (amountOfMoney > _middle.Salary)
            {
                _employees[1]++;
                amountOfMoney -= _middle.Salary;
            }
            while (amountOfMoney > _junior.Salary)
            {
                _employees[0]++;
                amountOfMoney -= _junior.Salary;
            }
            return _employees;
        }
    }
}
