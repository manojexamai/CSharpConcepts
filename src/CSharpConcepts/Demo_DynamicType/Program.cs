#nullable disable

namespace Demo_DynamicType
{
    internal class Program
    {
        static void Main ( string[] args )
        {
            Demo1();
            Console.WriteLine();

            Demo2();
            Console.WriteLine();

            Demo3();
            Console.WriteLine();
        }


        /// <summary>
        ///     Using Explicit Type
        /// </summary>
        static void Demo1 ()
        {
            Calculator objCalc = new Calculator();
            int result = objCalc.Add( 10, 20 );
            Console.WriteLine( "Sum of 10 and 20 is {0}", result );
        }

        /// <summary>
        ///     Using Reflection
        /// </summary>
        static void Demo2 ()
        {
            object calc = System.Activator.CreateInstance( typeof( Calculator ) ); // = new Calculator();
            Type calcType = calc.GetType();
            object res = calcType.InvokeMember( "Add",
                System.Reflection.BindingFlags.InvokeMethod, null, calc,
                new object[] { 10, 20 } );
            int result = Convert.ToInt32( res );
            Console.WriteLine( "Sum of 10 and 20 is {0}", result );
        }

        /// <summary>
        ///     Using dynamic type
        /// </summary>
        static void Demo3 ()
        {
            dynamic d1 = System.Activator.CreateInstance( typeof( Calculator ) );
            int result = d1.Add( 10, 20 );
            Console.WriteLine( "Sum of 10 and 20 is {0}", result );

            object d2 = System.Activator.CreateInstance( typeof( Calculator ) );

            dynamic calc = new Calculator();
            int result2 = calc.Add( 10, 20 );
            Console.WriteLine( "Sum of 10 and 20 is {0}", result2 );
        }
    }
}
