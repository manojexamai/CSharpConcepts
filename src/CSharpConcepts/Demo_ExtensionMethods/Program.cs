namespace Demo_ExtensionMethods
{
    internal class Program
    {
        static void Main ( string[] args )
        {
            Calculator objC = new Calculator ();
            int result;

            result = objC.Add( 10, 20 );
            Console.WriteLine("Sum of {0} and {1} is {2}", 
                10, 20, result );

            Console.WriteLine( "-- call using Extension Method" );
            result = objC.Subtract( 20, 5 );
            Console.WriteLine( "Difference between {0} and {1} is {2}",
                20, 5, result );


            Console.WriteLine( "-- call Method Directly from the Static (Singleton) class" );
            result = MyExtensions.Subtract ( objC, 10, 20 );
            Console.WriteLine( "Difference between {0} and {1} is {2}",
                20, 5, result );


            int i = 10;
            i.Author();

            objC.Author();
            MyExtensions.Author( objC );
        }
    }
}
