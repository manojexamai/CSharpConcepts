namespace Demo_TypeMembers
{
    internal class Program
    {
        static void Main ( string[] args )
        {
            Employee emp;               // Declaration
            emp = new Employee();       // Instantiation

            // Initialization
            // emp.EmployeeID = 10;
            emp.SetEmployeeID( 10 );
            emp.EmployeeName = "First Employee";
            Console.WriteLine("ID: {0} Name {1}", emp.GetEmployeeID(), emp.EmployeeName );


            Employee emp2 = new Employee();
            // emp.EmployeeID = -5;
            emp2.SetEmployeeID( -5 );
            emp2.EmployeeName = "First Employee";
            Console.WriteLine( "ID: {0} Name {1}", emp2.GetEmployeeID(), emp2.EmployeeName );


            emp2.EmployeeName = emp2.EmployeeName.ToUpper();
            // emp2.SetEmployeeName( emp2.GetEmployeeName().ToUpper() );


            Employee emp3 = new Employee();
            // emp3.EmployeeId = emp2.EmployeeId + 1;
            // emp3.EmployeeID++;
            emp3.ID = emp2.ID + 1;
            emp3.ID++;
            emp3.SetEmployeeID( emp2.GetEmployeeID() + 1 );

            Console.WriteLine();

            int[] arr = new int[5] { 1, 2, 3, 4, 5 };

            for ( int i = 0 ; i < arr.Length ; i++ )
            {
                Console.Write("{0} ", arr[i] );
            }
            Console.WriteLine("Number of elements in array using arr.Length: {0}", arr.Length );
            Console.WriteLine();

            for ( int i = 0 ; i < arr.GetLength(0); i++ )
            {
                Console.Write( "{0} ", arr[i] );
            }
            Console.WriteLine( "Number of elements in array using arr.GetLength(0): {0}", arr.GetLength(0) );
            Console.WriteLine();

            int count = arr.GetLength( 0 );
            for ( int i = 0 ; i < count ; i++ )
            {
                Console.Write( "{0} ", arr[i] );
            }
            Console.WriteLine( "Number of elements in array using arr.GetLength(0): {0}", count );
            Console.WriteLine();

        }
    }
}
