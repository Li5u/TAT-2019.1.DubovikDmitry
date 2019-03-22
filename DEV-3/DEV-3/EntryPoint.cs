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
            TeamSearcher ts = new TeamSearcherWithMaxProductivity(13000, 405);
            var dimaEntertainment = new Company();
            var team = dimaEntertainment.FindTeam(ts);
            dimaEntertainment.CountAndDisplayEmployeesInTeam(team);
        }
    }
}
