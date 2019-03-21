using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DEV_3
{
    abstract class TeamSearcher
    {
        protected Junior _junior;
        protected Middle _middle;
        protected Senior _senior;
        protected Lead _lead;
        protected List<Employee> team;

        public TeamSearcher()
        {
            team = new List<Employee>();
            _junior = new Junior();
            _middle = new Middle();
            _senior = new Senior();
            _lead = new Lead();
        }

        internal virtual List<Employee> Choose(List<Employee> availableEmployees, int amountOfMoney, int productivity)
        {
            return team;
        }
    }
}
