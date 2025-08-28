using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Demo_Indexer
{
    /// <summary>
    ///     Demo for Indexer
    /// </summary>
    class Program
    {
        static void Main(string[] args)
        {

            int[] arr = new int[5] { 10, 20, 30, 40, 50 };
            // arr[3] == 40,        3 is the INDEX position in the collection of "arr"


            Company objCompany = new Company("Microsoft");
            objCompany.AddEmployee("Bill Gates");
            objCompany.AddEmployee("Scott");
            objCompany.DisplayAllEmployee();


            // retrieve the employee object identified by the index "Bill Gates"
            // in the collection exposed by the object "objCompany"
            Employee empSecond = objCompany[2];
            Employee empFirst = objCompany["Bill Gates"];

            Console.WriteLine("Employee ID: {0}", 
                objCompany["Bill Gates"].EmployeeID);
            Console.WriteLine("Employee ID: {0}",
                objCompany.GetEmployeeByName("Bill Gates").EmployeeID);
        }
    }
}
