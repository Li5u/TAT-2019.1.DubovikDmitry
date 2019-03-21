using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DEV_3
{
    class EntryPoint
    {
        static void Main(string[] args)
        {
            var ts = new TeamSearcherWithMaxProductivity();
            var dimaEntertainment = new Company();
            var team = dimaEntertainment.FindTeam(ts, 10000, 400);
            int leadCount = 0;
            int seniorCount = 0;
            int middleCount = 0;
            int juniorCount = 0;
            foreach(var a in team)
            {
                if(a is Lead)
                {
                    leadCount++;
                    continue;
                }
                if(a is Senior)
                {
                    seniorCount++;
                    continue;
                }
                if (a is Middle)
                {
                    middleCount++;
                    continue;
                }
                if (a is Junior)
                {
                    juniorCount++;
                    continue;
                }
            }
            Console.WriteLine($"Junior: {juniorCount}\nMiddle: {middleCount}\nSenior: {seniorCount}\nLead:{leadCount}");
        }
    }
}
