using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Demo_IEnumerable
{
    class Employee
    {
        public int EmployeeID { get; private set; }
        public string EmployeeName { get; private set; }

        public Employee(int id, string name)
        {
            this.EmployeeID = id;
            this.EmployeeName = name;
        }
    }
}
