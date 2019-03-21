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
            return(searcher.Choose(_availableEmployees, amountOfMoney, productivity));
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="productivity"></param>
        /// <returns></returns>
        /*private List<int> FindEmployeesBySecondCriterion(int productivity)
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
            return _employees;*/
       
    }
}
