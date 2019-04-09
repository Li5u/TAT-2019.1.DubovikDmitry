using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DEV_6
{
    class CountTypesCommand : ICommand
    {
        CarsStock carsStock;

        public CountTypesCommand(CarsStock carsStock) => this.carsStock = carsStock;

        public int Execute()
        {
            return carsStock.CountBrands();
        }
    }
}
