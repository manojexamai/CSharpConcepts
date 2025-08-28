namespace Demo_ConvertingTypes
{
    internal class Program
    {
        static void Main ( string[] args )
        {
            // Demo1();

            // Demo2();


            Demo_ConvertingTypes.Demo3.Demo.RunThis();

        }


        // Boxing and Unboxing
        static void Demo2 ()
        {
            object o;

            int i = 10;
            string s = "Hello world";
            bool b = false;

            o = i;              // boxing - implicit typecasting.
            int j = (int)o;     // unboxing = explicit typecasting.

            o = s;
            o = b;


        }


        // Implicit and Explicit Typecasting
        static void Demo1 ()
        {
            int i = 10;
            bool b = true;
            string s = "hello world";

            Console.WriteLine( s );
            Console.WriteLine( i );
            Console.WriteLine( b );


            int x = short.MaxValue + 1;
            short y = short.MaxValue;

            unchecked
            {
                int z1 = y;              // implicit typecasting   int z = (int)y;
                short z2 = (short) x;    // explicit typecasting is required - it can fail at runtime
                Console.WriteLine( "z1 = {0}, z2 = {1}", z1, z2 );
            }

        }
    }
}
