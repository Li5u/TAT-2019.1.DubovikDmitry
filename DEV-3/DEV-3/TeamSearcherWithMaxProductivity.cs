using System;
using System.Collections.Generic;

namespace DEV_3
{
    /// <summary>
    /// This class can find the best team for money that costumer has.
    /// </summary>
    class TeamSearcherWithMaxProductivity : TeamSearcher
    {
        /// <summary>
        /// The class constructor initializes fields.
        /// </summary>
        /// <param name="amountOfMoney">Amount of money that costumer has</param>
        /// <param name="productivity">Productivity that costumer requires</param>
        public TeamSearcherWithMaxProductivity(int amountOfMoney, int productivity)
        {
            AmountOfMoney = amountOfMoney;
            Productivity = productivity;
        }

        /// <summary>
        /// This method finds and returns the best team for money that costumer has.
        /// </summary>
        /// <param name="availableEmployees"></param>
        /// <returns></returns>
        internal override  List<Employee> Choose(List<Employee> availableEmployees)
        {
        leads:
            while (AmountOfMoney >= lead.Salary)
            {
                foreach (var employee in availableEmployees)
                {
                    if (employee is Lead)
                    {
                        team.Add(employee);
                        availableEmployees.Remove(employee);
                        AmountOfMoney -= lead.Salary;
                        currentProductivity += lead.Productivity;
                        goto leads;
                    }
                }
                goto seniors;// Go to label seniors if company doesn't have or doesn't need more leads.
            }

        seniors:
            while (AmountOfMoney >= senior.Salary)
            {
                foreach (var employee in availableEmployees)
                {
                    if (employee is Senior && !(employee is Lead))
                    {
                        team.Add(employee);
                        availableEmployees.Remove(employee);
                        AmountOfMoney -= senior.Salary;
                        currentProductivity += senior.Productivity;
                        goto seniors;
                    }
                }
                goto middles;// Go to label middles if company doesn't have or doesn't need more seniors.
            }

        middles:
            while (AmountOfMoney >= middle.Salary)
            {
                foreach (var employee in availableEmployees)
                {
                    if (employee is Middle && !(employee is Senior))
                    {
                        team.Add(employee);
                        availableEmployees.Remove(employee);
                        AmountOfMoney -= middle.Salary;
                        currentProductivity += middle.Productivity;
                        goto middles;
                    }
                }
                goto juniors;// Go to label juniors if company doesn't have or doesn't need more middles.
            }

        juniors:
            while (AmountOfMoney >= junior.Salary)
            {
                foreach (var employee in availableEmployees)
                {
                    if (employee is Junior && !(employee is Middle))
                    {
                        team.Add(employee);
                        availableEmployees.Remove(employee);
                        AmountOfMoney -= junior.Salary;
                        currentProductivity += junior.Productivity;
                        goto juniors;
                    }
                }
                goto returnTeam;// Go to label returnTeam if company doesn't have or doesn't need more juniors.
            }

        returnTeam:
            if (currentProductivity < Productivity)
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
