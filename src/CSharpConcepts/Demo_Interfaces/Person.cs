using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Demo_Interfaces
{
    class Person
    {
        public string Name { get; set; }

        // Demo of Aggregation
        public Driver DriverOfPerson { get; set; }
    }
}
