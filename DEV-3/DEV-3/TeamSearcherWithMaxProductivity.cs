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
        leads:
            while (amountOfMoney >= lead.Salary)
            {
                foreach (var employee in availableEmployees)
                {
                    if (employee is Lead)
                    {
                        team.Add(employee);
                        availableEmployees.Remove(employee);
                        amountOfMoney -= lead.Salary;
                        currentProductivity += lead.Productivity;
                        goto leads;
                    }
                }
                goto seniors;
            }

        seniors:
            while (amountOfMoney >= senior.Salary)
            {
                foreach (var employee in availableEmployees)
                {
                    if (employee is Senior && !(employee is Lead))
                    {
                        team.Add(employee);
                        availableEmployees.Remove(employee);
                        amountOfMoney -= senior.Salary;
                        currentProductivity += senior.Productivity;
                        goto seniors;
                    }
                }
                goto middles;
            }

        middles:
            while (amountOfMoney >= middle.Salary)
            {
                foreach (var employee in availableEmployees)
                {
                    if (employee is Middle && !(employee is Senior))
                    {
                        team.Add(employee);
                        availableEmployees.Remove(employee);
                        amountOfMoney -= middle.Salary;
                        currentProductivity += middle.Productivity;
                        goto middles;
                    }
                }
                goto juniors;
            }

        juniors:
            while (amountOfMoney >= junior.Salary)
            {
                foreach (var employee in availableEmployees)
                {
                    if (employee is Junior && !(employee is Middle))
                    {
                        team.Add(employee);
                        availableEmployees.Remove(employee);
                        amountOfMoney -= junior.Salary;
                        currentProductivity += junior.Productivity;
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
