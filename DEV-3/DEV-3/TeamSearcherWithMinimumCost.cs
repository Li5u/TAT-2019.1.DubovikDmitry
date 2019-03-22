using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DEV_3
{
    class TeamSearcherWithMinimumCost : TeamSearcher
    {
        internal override List<Employee> Choose(List<Employee> availableEmployees, int amountOfMoney, int productivity)
        {
        leads:
            while (productivity > 0)
            {
                if (productivity * seniorEfficiency > lead.Salary)
                {
                    foreach (var employee in availableEmployees)
                    {
                        if (employee is Lead)
                        {
                            team.Add(employee);
                            availableEmployees.Remove(employee);
                            amountOfMoney -= lead.Salary;
                            currentProductivity += lead.Productivity;
                            productivity -=lead.Productivity;
                            goto leads;
                        }
                    }
                }
                goto seniors;
            }

        seniors:
            while (productivity > 0)
            {
                if (productivity * middleEfficiency > senior.Salary)
                {
                    foreach (var employee in availableEmployees)
                    {
                        if (employee is Senior && !(employee is Lead))
                        {
                            team.Add(employee);
                            availableEmployees.Remove(employee);
                            amountOfMoney -= senior.Salary;
                            currentProductivity += senior.Productivity;
                            productivity -= senior.Productivity;
                            goto seniors;
                        }
                    }
                }
                goto middles;
            }

        middles:
            while (productivity > 0)
            {
                if (productivity * juniorEfficiency > middle.Salary)
                {
                    foreach (var employee in availableEmployees)
                    {
                        if (employee is Middle && !(employee is Senior))
                        {
                            team.Add(employee);
                            availableEmployees.Remove(employee);
                            amountOfMoney -= middle.Salary;
                            currentProductivity += middle.Productivity;
                            productivity -=middle.Productivity;
                            goto middles;
                        }
                    }
                }
                goto juniors;
            }

        juniors:
            while (productivity > 0)
            {
                foreach (var employee in availableEmployees)
                {
                    if (employee is Junior && !(employee is Middle))
                    {
                        team.Add(employee);
                        availableEmployees.Remove(employee);
                        amountOfMoney -= junior.Salary;
                        currentProductivity += junior.Productivity;
                        productivity -= junior.Productivity;
                        goto juniors; ;
                    }
                }
                goto returnTeam;
            }

        returnTeam:
            if (amountOfMoney < 0)
            {
                foreach (var employee in team)
                {
                    availableEmployees.Add(employee);
                }
                throw new Exception("You don't have enought money for that productivity.");
            }
            if (productivity > 0)
            {
                foreach (var employee in team)
                {
                    availableEmployees.Add(employee);
                }
                throw new Exception("We don't have employees for that productivity.");
            }
            return team;
        }
    }
}
