using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Demo_Destructor_FW
{
    internal class Program
    {
        static void Main ( string[] args )
        {
            // RunThis1();

            // RunThis2();

            RunThis3();

            Console.WriteLine();
            Console.WriteLine( "---- exiting MAIN" );
        }

        static void RunThis3()
        {
            // Resource Management
            using ( DisposableEmployee empObj = new DisposableEmployee( 100, "Resource Managed Employee" ) )
            {
                empObj.Work();
            }                               // implicitly call Dispose() method 
        }

        static void RunThis2()
        {
            DisposableEmployee emp1 = new DisposableEmployee( 1, "First Employee" );
            DisposableEmployee emp2 = new DisposableEmployee( 2, "Second Employee" );
            DisposableEmployee emp3 = new DisposableEmployee( 3, "Third Employee" );

            Console.WriteLine();
            emp1.Work();

            Console.WriteLine();
            emp1.Dispose();
            emp2.Dispose();
            emp3.Dispose();

            Console.WriteLine();
            try
            {
                emp1.Dispose();

                //emp1.Name = emp1.Name.ToUpper();
                //Console.WriteLine( "--- after Name change: {0}", emp1.Name );
                //Console.WriteLine();

                // emp1.Work();
            }
            catch(System.ObjectDisposedException exp)
            {
                Console.WriteLine( "Object: {0}, Message: {1}", exp.ObjectName, exp.Message );
            }

            Console.WriteLine();
            Console.WriteLine( "--- after calling the Dispose for individual objects" );
            Console.WriteLine();

            DisposableEmployee[] empArr = new DisposableEmployee[3];
            empArr[0] = new DisposableEmployee( 10, "Employee 10" );
            empArr[1] = new DisposableEmployee( 20, "Employee 20" );
            empArr[2] = new DisposableEmployee( 30, "Employee 30" );

            empArr = new DisposableEmployee[0];

        }

        static void RunThis1()
        {
            Employee emp1 = new Employee( 1, "First Employee" );


            Console.WriteLine( "--- Calling Demo()" );
            Demo();
            Console.WriteLine( "--- Finished Demo()" );

            Console.WriteLine();

            Console.WriteLine( "--- Calling DemoArray()" );
            DemoArray();
            Console.WriteLine( "--- Finished DemoArray()" );

        }

        static void Demo ()
        {
            Employee emp2 = new Employee( 2, "Second Employee" );
            Employee emp3 = new Employee( 3, "Third Employee" );
        }

        static void DemoArray ()
        {
            Employee[] empArr = new Employee[5];
            empArr[0] = new Employee( 10, "Employee 10" );
            empArr[1] = new Employee( 20, "Employee 20" );
            empArr[2] = new Employee( 30, "Employee 30" );
            empArr[3] = new Employee( 40, "Employee 40" );
            empArr[4] = new Employee( 50, "Employee 50" );
        }

    }
}
