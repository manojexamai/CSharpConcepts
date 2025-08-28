using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Demo_Constructors
{
    class Employee
    {
        // Properties for the INSTANCE
        public int ID { 
            get; 
            private set;            // can be changed by code in current class!
        }

        public string Name { get; private set; }

        // Parameterized INSTANCE Constructor
        public Employee(int id, string name)
        {
            this.ID = id;
            this.Name = name;
        }
    }
}
