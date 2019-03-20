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
                case 2:
                    FindEmployeesBySecondCriterion(productivity);
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

        /// <summary>
        /// 
        /// </summary>
        /// <param name="productivity"></param>
        /// <returns></returns>
        private List<int> FindEmployeesBySecondCriterion(int productivity)
        {
            double leadEfficiency = _lead.Salary / (double)_lead.Productivity;
            double seniorEfficiency = _senior.Salary / (double)_senior.Productivity;
            double middleEfficiency = _middle.Salary / (double)_middle.Productivity;
            double juniorEfficiency = _junior.Salary / (double)_junior.Productivity;

            while (productivity > 0)
            {
                _employees[3]++;
                productivity -= _lead.Productivity;
                if (productivity < 0 && Math.Abs(productivity) * leadEfficiency > _senior.Salary)
                {
                    _employees[3]--;
                    productivity += _lead.Productivity;
                    break;
                }

            }
            
            while (productivity > 0)
            {
                _employees[2]++;
                productivity -= _senior.Productivity;
                if (productivity < 0 && Math.Abs(productivity) * seniorEfficiency > _middle.Salary)
                {
                    _employees[2]--;
                    productivity += _senior.Productivity;
                    break;
                }
            }
            
            while (productivity > 0)
            {
                _employees[1]++;
                productivity -= _middle.Productivity;
                if (productivity < 0 && Math.Abs(productivity) * middleEfficiency > _junior.Salary)
                {
                    _employees[1]--;
                    productivity += _middle.Productivity;
                    break;
                }
            }
            
            while (productivity > 0)
            {
                _employees[0]++;
                productivity -= _junior.Productivity;
            }
            return _employees;
        }
    }
}
