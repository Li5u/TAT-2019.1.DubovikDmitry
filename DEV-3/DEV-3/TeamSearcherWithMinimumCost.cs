using System;
using System.Collections.Generic;

namespace DEV_3
{
    /// <summary>
    /// This class can find the cheapest team for required productiviry.
    /// </summary>
    class TeamSearcherWithMinimumCost : TeamSearcher
    {
        /// <summary>
        /// The class constructor initializes fields.
        /// </summary>
        /// <param name="amountOfMoney">Amount of money that costumer has</param>
        /// <param name="productivity">Productivity that costumer requires</param>
        public TeamSearcherWithMinimumCost(int amountOfMoney, int productivity)
        {
            AmountOfMoney = amountOfMoney;
            Productivity = productivity;
        }

        /// <summary>
        /// This method finds and returns the cheapest team for required productiviry.
        /// </summary>
        /// <param name="availableEmployees"></param>
        /// <returns></returns>
        internal override List<Employee> Choose(List<Employee> availableEmployees)
        {
        leads:
            while (Productivity > 0)
            {
                if (Productivity * SeniorEfficiency > lead.Salary)
                {
                    foreach (var employee in availableEmployees)
                    {
                        if (employee is Lead)
                        {
                            team.Add(employee);
                            availableEmployees.Remove(employee);
                            AmountOfMoney -= lead.Salary;
                            currentProductivity += lead.Productivity;
                            Productivity -=lead.Productivity;
                            goto leads;
                        }
                    }
                }
                goto seniors;// Go to label seniors if company doesn't have or doesn't need more leads.
            }

        seniors:
            while (Productivity > 0)
            {
                if (Productivity * MiddleEfficiency > senior.Salary)
                {
                    foreach (var employee in availableEmployees)
                    {
                        if (employee is Senior && !(employee is Lead))
                        {
                            team.Add(employee);
                            availableEmployees.Remove(employee);
                            AmountOfMoney -= senior.Salary;
                            currentProductivity += senior.Productivity;
                            Productivity -= senior.Productivity;
                            goto seniors;
                        }
                    }
                }
                goto middles;// Go to label middles if company doesn't have or doesn't need more seniors.
            }

        middles:
            while (Productivity > 0)
            {
                if (Productivity * JuniorEfficiency > middle.Salary)
                {
                    foreach (var employee in availableEmployees)
                    {
                        if (employee is Middle && !(employee is Senior))
                        {
                            team.Add(employee);
                            availableEmployees.Remove(employee);
                            AmountOfMoney -= middle.Salary;
                            currentProductivity += middle.Productivity;
                            Productivity -=middle.Productivity;
                            goto middles;
                        }
                    }
                }
                goto juniors;// Go to label juniorss if company doesn't have or doesn't need more middles.
            }

        juniors:
            while (Productivity > 0)
            {
                foreach (var employee in availableEmployees)
                {
                    if (employee is Junior && !(employee is Middle))
                    {
                        team.Add(employee);
                        availableEmployees.Remove(employee);
                        AmountOfMoney -= junior.Salary;
                        currentProductivity += junior.Productivity;
                        Productivity -= junior.Productivity;
                        goto juniors;
                    }
                }
                goto returnTeam;// Go to label returnTeam if company doesn't have or doesn't need more juniors.
            }

        returnTeam:
            if (AmountOfMoney < 0)
            {
                foreach (var employee in team)
                {
                    availableEmployees.Add(employee);
                }
                throw new Exception("You don't have enought money for that productivity.");
            }
            if (Productivity > 0)
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
