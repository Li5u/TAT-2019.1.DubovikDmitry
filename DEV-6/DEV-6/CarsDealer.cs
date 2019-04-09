using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DEV_6
{
    class CarsDealer
    {
        ICommand command;

        public void SetCommand(ICommand command)
        {
            this.command = command;
        }

        public int GetInformation()
        {
            return command.Execute();
        }
    }
}
