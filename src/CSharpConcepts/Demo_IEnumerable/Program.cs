using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Demo_IEnumerable
{
    class Program
    {
        static void Main(string[] args)
        {
            Company objCompany = new Company("Microsoft");
            objCompany.AddEmployee("Bill Gates");
            objCompany.AddEmployee("Scott");

            Console.WriteLine("Displaying using the method invocation");
            objCompany.DisplayAllEmployee();
            Console.WriteLine();

            Console.WriteLine("--- Demo of IEnumerable interface implementation");
            Console.WriteLine("Employees for the company: {0}", objCompany.CompanyName);
            foreach(Employee emp in objCompany)         // GetEnumerator() method is called implicitly
            {
                Console.WriteLine("{0} {1}", emp.EmployeeID, emp.EmployeeName);

                // NOTE: this is a READONLY-FORWARD only loop variable because it is inside a FOREACH loop
                // emp = new Employee( 10, "New Employee here" );
            }
        }
    }
}
