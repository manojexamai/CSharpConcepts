namespace Demo_Delegate
{
    internal class Program
    {
        static void Main ( string[] args )
        {
            Calculator objCalc = new Calculator();

            int a = 10, b = 20, result;
            
            result = objCalc.Add( a, b );
            Console.WriteLine("Sum of {0} and {1} is {2}", a, b, result);
            Console.WriteLine();

            //Console.WriteLine( "---- Derived Class object" );
            //DerivedCalculator objDerived = new DerivedCalculator();
            //result = objDerived.Add( a, b );
            //Console.WriteLine( "Sum of {0} and {1} is {2}", a, b, result );
            //result = objDerived.Subtract( a, b );
            //Console.WriteLine( "Subracting {1} from {0} is {2}", a, b, result );

            result = objCalc.Compute( a, b, Program.Subtract );
            Console.WriteLine( "Subracting {1} from {0} is {2}", a, b, result );
        }


        private static int Subtract ( int a, int b )
        {
            Console.WriteLine( "--- Subtract called" );
            return b - a;
        }

    }

    class DerivedCalculator : Calculator
    {
        internal int Subtract(int a, int b)
        {
            return b - a;
        }
    }
}
