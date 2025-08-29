namespace Demo_Delegate
{
    // 1. Define the Method Signature (without defining the name of the method)
    delegate int ComputeHandler( int a, int b );

    internal class Calculator
    {
        internal int Add(int a, int b )
        {
            int result = -1;

            Console.WriteLine( "1. Authenciation" );
            Console.WriteLine( "2. Authorization" );
            Console.WriteLine( "3. Validation" );

            Console.WriteLine( "4. Activity" );
            result = a + b;

            Console.WriteLine( "5. Audit Logging" );
            return result;
        }

        // 2. Define the method that Receives the Delegate object
        internal int Compute(int a, int b, ComputeHandler? objD)
        {
            int result = -1;

            Console.WriteLine( "1. Authenciation" );
            Console.WriteLine( "2. Authorization" );
            Console.WriteLine( "3. Validation" );
            
            Console.WriteLine( "4. Activity" );
            if ( objD is not null )             // 3. Check if the delegate is "subscribed" (i.e, pointing to a method)
            {
                
                result = objD( a, b );          // 4. Invoke the method pointed to by the Delegate.

                // SAME AS ABOVE:
                // result = objD.Invoke( a, b );
            }

            Console.WriteLine( "5. Audit Logging" );
            return result;
        }
    }
}
