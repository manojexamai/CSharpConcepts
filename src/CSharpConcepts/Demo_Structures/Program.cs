using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Demo_Structures
{
    class Program
    {
        static void Main(string[] args)
        {
            // int i = 10;

            MyEmployeeStructure employee;
            employee.EmployeeID = 1;
            employee.EmployeeName = "First Employee";

            MyEmployeeStructure employee2;
            employee2.EmployeeID = 2;
            employee2.EmployeeName = "Second Employee";

            Console.WriteLine("{0} {1}", employee.EmployeeID, employee.EmployeeName);
            Console.WriteLine("{0} {1}", employee2.EmployeeID, employee2.EmployeeName);
            Console.WriteLine();

            MyEmployeeStructure emp;
            emp = employee;                     // value type assignment
            emp.EmployeeName = emp.EmployeeName.ToUpper();
            Console.WriteLine("Emp:      {0} {1}", emp.EmployeeID, emp.EmployeeName);
            Console.WriteLine("Employee: {0} {1}", employee.EmployeeID, employee.EmployeeName);
        }
    }
}
