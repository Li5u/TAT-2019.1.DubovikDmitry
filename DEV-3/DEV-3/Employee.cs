﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DEV_3
{
    class Employee
    {
        public int Salary { get; protected set; }
        public int Productivity { get; protected set; }

        public Employee()
        {
            Salary = 500;
            Productivity = 10;
        }
    }
}