using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Demo_Class
{
    class Program
    {
        static void Main(string[] args)
        {
            MyEmployeeClass employee = new MyEmployeeClass();   // Declaration, Instantiation & Initialization
            employee.EmployeeID = 1;
            employee.EmployeeName = "First Employee";

            MyEmployeeClass employee2 = new MyEmployeeClass(); // Declaration, Instantiation & Initialization
            employee2.EmployeeID = 2;
            employee2.EmployeeName = "Second Employee";

            Console.WriteLine("{0} {1}", employee.EmployeeID, employee.EmployeeName);
            Console.WriteLine("{0} {1}", employee2.EmployeeID, employee2.EmployeeName);
            Console.WriteLine();

            MyEmployeeClass emp;
            emp = employee;                     // reference type assignment
            emp.EmployeeName = emp.EmployeeName.ToUpper();
            Console.WriteLine("Emp:      {0} {1}", emp.EmployeeID, emp.EmployeeName);
            Console.WriteLine("Employee: {0} {1}", employee.EmployeeID, employee.EmployeeName);
        }
    }
}
