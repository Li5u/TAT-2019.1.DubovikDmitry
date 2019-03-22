using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DEV_3
{
    abstract class TeamSearcher
    {
        protected Junior junior;
        protected Middle middle;
        protected Senior senior;
        protected Lead lead;
        protected double seniorEfficiency;
        protected double middleEfficiency;
        protected double juniorEfficiency;
        protected int currentProductivity = 0;
        protected List<Employee> team;

        public TeamSearcher()
        {
            team = new List<Employee>();
            junior = new Junior();
            middle = new Middle();
            senior = new Senior();
            lead = new Lead();
            seniorEfficiency = senior.Salary / (double)senior.Productivity;
            middleEfficiency = middle.Salary / (double)middle.Productivity;
            juniorEfficiency = junior.Salary / (double)junior.Productivity;
        }

        internal virtual List<Employee> Choose(List<Employee> availableEmployees, int amountOfMoney, int productivity)
        {
            return team;
        }
    }
}
