using Demo_Exceptions_Library;

namespace Demo_Exceptions
{
    internal class Program
    {
        static void Main ( string[] args )
        {

        first:
            Console.Write( value: "Enter a number:" );
            string? input = Console.ReadLine();
            int.TryParse( input, out int a );
            if ( input is null || a.ToString() != input )
            {
                Console.WriteLine( "First number is invalid.  Try again..." );
                goto first;
            }

        second:
            Console.Write( "Enter another number:" );
            int.TryParse( Console.ReadLine(), out int b );
            if( b == 0 )
            {
                Console.WriteLine( "Second number cannot be ZERO" );
                goto second;
            }

            Demo_Exceptions_Library.Calculator objCalc = new Demo_Exceptions_Library.Calculator();

            try
            {
                if ( b != 0 )
                {
                    int result = objCalc.Divide( a, b );

                    Console.WriteLine( "Result = {0}", result );
                }
            }
            catch( CalculatorException e)
            {

            }
            catch( System.Exception e)
            {
                Console.WriteLine( "Something went wrong in MAIN" );
                Console.WriteLine("Type: {0}", e.GetType() );
                Console.WriteLine( "Message: {0}", e.Message );
                Console.WriteLine( "Source: {0}", e.Source );
                Console.WriteLine( "TargetSite: {0}", e.TargetSite);
                if(e.InnerException is not null)
                {
                    Console.WriteLine( "Type: {0}", e.InnerException.GetType() );
                    Console.WriteLine( "Message: {0}", e.InnerException.Message );
                    Console.WriteLine( "Source: {0}", e.InnerException.Source );
                    Console.WriteLine( "TargetSite: {0}", e.InnerException.TargetSite );
                }
            }

            Console.WriteLine( "Thank you for using my software" );
        }
    }
}
