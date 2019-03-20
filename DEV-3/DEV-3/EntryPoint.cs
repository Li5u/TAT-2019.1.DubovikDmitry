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
            TeamSearcher ts = new TeamSearcher();
            var team = ts.FindTeam(2200, 205, 2);
            Console.WriteLine($"Junior: {team[0]}\nMiddle: {team[1]}\nSenior: {team[2]}\nLead:{team[3]}");
        }
    }
}
