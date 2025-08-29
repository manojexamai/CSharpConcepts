using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Demo_IEnumerator
{
    /// <summary>
    ///     Demo for the interface: IEnumerator 
    /// </summary>
    class Program
    {
        static void Main(string[] args)
        {
            Company objCompany = new Company("Microsoft");
            //objCompany.AddEmployee( "First employee" );
            //objCompany.AddEmployee( "Second employee" );
            //objCompany.AddEmployee( "Third employee" );
            //objCompany.DisplayAllEmployee();
            //Console.WriteLine();

            //Employee? EmployeeWithId2 = objCompany[2];
            //if ( EmployeeWithId2 is null )
            //{
            //    Console.WriteLine( "Employee with ID: 2 not found" );
            //}
            //else
            //{
            //    Console.WriteLine( "FOUND Employee: ID {1}, Name: {0}", 
            //        EmployeeWithId2.EmployeeName, EmployeeWithId2.EmployeeID );
            //}
            
            Console.WriteLine();


            Console.WriteLine( "--- Display using IEnumerator" );
            objCompany.Reset();                                 // ESSENTIAL: initialize the pointer
            while ( objCompany.MoveNext() )                       // ESSENTIAL: read the first item in collection
            {
                Employee? emp = objCompany.Current as Employee;  // ESSENTIAL: unbox to consume
                if ( emp is not null )
                {
                    Console.WriteLine( "{0} {1}", emp.EmployeeID, emp.EmployeeName );
                }
            }

            Console.WriteLine();

            Console.WriteLine( "--- adding some employees now." );
            objCompany.AddEmployee( "Bill Gates" );
            objCompany.AddEmployee( "Scott" );

            Console.WriteLine( "--- Displaying using the built in method from the Company object" );
            objCompany.DisplayAllEmployee();
            Console.WriteLine();

            Console.WriteLine( "--- Demo of IEnumerator interface implementation" );
            Console.WriteLine( "Employees of the {0}", objCompany.CompanyName );
            objCompany.Reset();                                 // ESSENTIAL: initialize the pointer
            while ( objCompany.MoveNext() )                       // ESSENTIAL: read the first item in collection
            {
                Employee emp = objCompany.Current as Employee;  // ESSENTIAL: unbox to consume
                Console.WriteLine( "{0} {1}", emp.EmployeeID, emp.EmployeeName );
            }

            Console.WriteLine( "-- output second time" );
            // objCompany.Reset();      // RUN THIS WITH COMMENT/UNCOMMENT
            while ( objCompany.MoveNext() )                       // ESSENTIAL: read the first item in collection
            {
                Employee emp = objCompany.Current as Employee;  // ESSENTIAL: unbox to consume
                Console.WriteLine( "{0} {1}", emp.EmployeeID, emp.EmployeeName );
            }
        }
    }
}
