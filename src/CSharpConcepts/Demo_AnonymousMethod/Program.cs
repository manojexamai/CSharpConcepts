using System.Linq.Expressions;

namespace Demo_AnonymousMethod
{
    internal class Program
    {
        static void Main ( string[] args )
        {
            Calculator objCalc = new Calculator();

            int a = 10, b = 20, result;

            // implicit instantiation of the delegate variable
            result = objCalc.Compute( a, b, Program.Add );
            Console.WriteLine( "Sum of {0} and {1} is {2}", a, b, result );
            Console.WriteLine();

            // explicit instantiation of the delegate variable.
            ComputeHandler objD = new ComputeHandler( Program.Subtract );
            result = objCalc.Compute( a, b, objD );
            Console.WriteLine( "Subracting {1} from {0} is {2}", a, b, result );
            Console.WriteLine();

            // Anonymous method
            ComputeHandler objD2 
                = delegate( int a, int b )
                {
                    Console.WriteLine( "-- Anonymous Method called" );
                    return a * b;
                };
            result = objCalc.Compute( a, b, objD2 );
            Console.WriteLine( "Product of {0} and {1} is {2}", a, b, result );
            Console.WriteLine();

            // Anonymous method
            int x = 100;                        // <-- hook variable
            ComputeHandler objD3
                = delegate ( int a, int b )
                {
                    Console.WriteLine( "-- Anonymous Method called (with HOOK)" );
                    return a * b + x;           // <--- hook
                };
            result = objCalc.Compute( a, b, objD3 );
            Console.WriteLine( "Product of {0} and {1} is {2}", a, b, result );
            Console.WriteLine();

            // Anonymous method - Version 2
            ComputeHandler objD4
                = ( int a, int b )  =>              // "=>" GOES TO operator
                {
                    Console.WriteLine( "-- Anonymous Method using GOES TO operator" );
                    return a * b;
                };
            result = objCalc.Compute( a, b, objD4 );
            Console.WriteLine( "Product of {0} and {1} is {2}", a, b, result );
            Console.WriteLine();

            // Anonymous method - Version 3 (GOES TO operator + without argument type)
            ComputeHandler objD5
                = ( a, b ) =>              // "=>" GOES TO operator 
                {
                    return a * b;
                };
            result = objCalc.Compute( a, b, objD5 );
            Console.WriteLine( "Product of {0} and {1} is {2}", a, b, result );
            Console.WriteLine();

            // LAMBDA version
            ComputeHandler objD9
                = ( a, b ) => a * b;
            result = objCalc.Compute( a, b, objD9 );
            Console.WriteLine( "Product of {0} and {1} is {2}", a, b, result );
            Console.WriteLine();

            // Expression Tree
            // System.Func<>
            // System.Linq.Expressions.Expression lhs, rhs;


            Console.WriteLine( "--- using the LAMBDA Expression directly" );
            result = objCalc.Compute( a, b, ( a, b ) => a * b );
            Console.WriteLine( "Product of {0} and {1} is {2}", a, b, result );
            Console.WriteLine();
        }

        private static int Add ( int a, int b )
        {
            Console.WriteLine( "--- Add called" );
            return a + b;
        }

        private static int Subtract ( int a, int b )
        {
            Console.WriteLine( "--- Subtract called" );
            return b - a;
        }

    }
}
