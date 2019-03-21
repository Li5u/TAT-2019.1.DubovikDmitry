using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DEV_3
{
    class TeamSearcherWithMaxProductivity : TeamSearcher
    {
        internal override  List<Employee> Choose(List<Employee> availableEmployees, int amountOfMoney, int productivity)
        {
            int currentProductivity = 0;
        leads:
            while (amountOfMoney >= _lead.Salary)
            {
                foreach (var employee in availableEmployees)
                {
                    if (employee is Lead)
                    {
                        team.Add(employee);
                        availableEmployees.Remove(employee);
                        amountOfMoney -= _lead.Salary;
                        currentProductivity += _lead.Productivity;
                        goto leads;
                    }
                }
                goto seniors;
            }
        seniors:
            while (amountOfMoney >= _senior.Salary)
            {
                foreach (var employee in availableEmployees)
                {
                    if (employee is Senior)
                    {
                        team.Add(employee);
                        availableEmployees.Remove(employee);
                        amountOfMoney -= _senior.Salary;
                        currentProductivity += _senior.Productivity;
                        goto seniors;
                    }
                }
                goto middles;
            }
        middles:
            while (amountOfMoney >= _middle.Salary)
            {
                foreach (var employee in availableEmployees)
                {
                    if (employee is Middle)
                    {
                        team.Add(employee);
                        availableEmployees.Remove(employee);
                        amountOfMoney -= _middle.Salary;
                        currentProductivity += _middle.Productivity;
                        goto middles;
                    }
                }
                goto juniors;
            }
        juniors:
            while (amountOfMoney >= _junior.Salary)
            {
                foreach (var employee in availableEmployees)
                {
                    if (employee is Junior)
                    {
                        team.Add(employee);
                        availableEmployees.Remove(employee);
                        amountOfMoney -= _junior.Salary;
                        currentProductivity += _junior.Productivity;
                        goto juniors; ;
                    }
                }
                goto returnTeam;
            }
        returnTeam:
            if (currentProductivity < productivity)
            {
                if (availableEmployees.Count == 0)
                {
                    foreach (var employee in team)
                    {
                        availableEmployees.Add(employee);
                    }
                    throw new Exception("We don't have employees for that productivity.");

                }
                foreach (var employee in team)
                {
                    availableEmployees.Add(employee);
                }
                throw new Exception("You don't have enough money for that productivity.");
            }
            return team;
        }

    }
}
