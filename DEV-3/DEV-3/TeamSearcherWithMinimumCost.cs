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
            int currentProductivity = 0;
            double leadEfficiency = _lead.Salary / (double)_lead.Productivity;
            double seniorEfficiency = _senior.Salary / (double)_senior.Productivity;
            double middleEfficiency = _middle.Salary / (double)_middle.Productivity;
            double juniorEfficiency = _junior.Salary / (double)_junior.Productivity;

        leads:
            while (productivity > 0)
            {
                if (productivity * seniorEfficiency > _lead.Salary)
                {
                    foreach (var employee in availableEmployees)
                    {
                        if (employee is Lead)
                        {
                            team.Add(employee);
                            availableEmployees.Remove(employee);
                            amountOfMoney -= _lead.Salary;
                            currentProductivity += _lead.Productivity;
                            productivity -= _lead.Productivity;
                            goto leads;
                        }
                    }
                }
                goto seniors;
            }

        seniors:
            while (productivity > 0)
            {
                if (productivity * middleEfficiency > _senior.Salary)
                {
                    foreach (var employee in availableEmployees)
                    {
                        if (employee is Senior && !(employee is Lead))
                        {
                            team.Add(employee);
                            availableEmployees.Remove(employee);
                            amountOfMoney -= _senior.Salary;
                            currentProductivity += _senior.Productivity;
                            productivity -= _senior.Productivity;
                            goto seniors;
                        }
                    }
                }
                goto middles;
            }

        middles:
            while (productivity > 0)
            {
                if (productivity * juniorEfficiency > _middle.Salary)
                {
                    foreach (var employee in availableEmployees)
                    {
                        if (employee is Middle && !(employee is Senior))
                        {
                            team.Add(employee);
                            availableEmployees.Remove(employee);
                            amountOfMoney -= _middle.Salary;
                            currentProductivity += _middle.Productivity;
                            productivity -= _middle.Productivity;
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
                        amountOfMoney -= _junior.Salary;
                        currentProductivity += _junior.Productivity;
                        productivity -= _junior.Productivity;
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
                throw new Exception("You don't have enought money for taht productivity.");
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
