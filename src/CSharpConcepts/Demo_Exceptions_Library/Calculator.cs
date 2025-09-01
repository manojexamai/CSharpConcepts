namespace Demo_Exceptions_Library
{
    public class Calculator
    {
        public int Divide(int a, int b )
        {
            int result = -1;
            try
            {
                result = a / b;
            }
            catch( System.DivideByZeroException e )
            {
                // throw new System.ArgumentException( "SECOND NUMBER CANNOT BE ZERO", e);
                var exp = new CalculatorException("SECOND NUMBER CANNOT BE ZERO", e);
            }
            catch ( Exception e )
            {
                Console.WriteLine( "\tSomething went wrong in ClassLibrary" );
                Console.WriteLine( "\tType: {0}", e.GetType() );
                Console.WriteLine( "\tMessage: {0}", e.Message );
                Console.WriteLine( "\tSource: {0}", e.Source );
                Console.WriteLine( "\tTargetSite: {0}", e.TargetSite );
            }

            return result;
        }
    }
}
