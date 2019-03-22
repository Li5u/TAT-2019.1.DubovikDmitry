using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DEV_3
{
    /// <summary>
    /// Abstract class for searchers by criteria.
    /// </summary>
    abstract class TeamSearcher
    {
        protected Junior junior;
        protected Middle middle;
        protected Senior senior;
        protected Lead lead;
        protected double SeniorEfficiency { get; set; }
        protected double MiddleEfficiency { get; set; }
        protected double JuniorEfficiency { get; set; }
        protected int currentProductivity = 0;
        protected List<Employee> team;
        protected int AmountOfMoney { get; set; }
        protected int Productivity { get; set; }

        /// <summary>
        /// The class constructor initializes fields.
        /// </summary>
        public TeamSearcher()
        {
            team = new List<Employee>();
            junior = new Junior();
            middle = new Middle();
            senior = new Senior();
            lead = new Lead();
            SeniorEfficiency = senior.Salary / (double)senior.Productivity;
            MiddleEfficiency = middle.Salary / (double)middle.Productivity;
            JuniorEfficiency = junior.Salary / (double)junior.Productivity;
        }

        internal virtual List<Employee> Choose(List<Employee> availableEmployees)
        {
            return team;
        }
    }
}
