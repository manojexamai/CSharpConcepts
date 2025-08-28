using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Demo_ConvertingTypes
{
    namespace Demo3

    {
        internal class Demo
        {
            internal static void RunThis ()
            {
                int i = 10;
                bool b = false;
                string s = "hello world";
                System.DateTime dt = DateTime.Now;

                Show( i );          // no boxing is required

                object x = b;
                Show( x );      
                Show( b );              // Same as previous two lines.

                Show( s );              // boxing done here
                Show( dt );             // boxing done here
            }
            

            private static void Show(int v)
            {
                Console.WriteLine( "Integer version" );
                Console.WriteLine( "Received {0}, Value = {1}", v.GetType(), v );

                v++;
                Console.WriteLine( "After manipulation: {0}", v );
                Console.WriteLine();
            }

            /******

            private static void Show ( bool v )
            {
                Console.WriteLine( "Received {0}, Value = {1}", v.GetType(), v );
            }

            private static void Show ( string v )
            {
                Console.WriteLine( "Received {0}, Value = {1}", v.GetType(), v );
            }

            ****/

            public static void Show(object v)
            {
                Console.WriteLine( "Boxing version" );
                Console.WriteLine( "Received {0}, Value = {1}", v.GetType(), v );

                if ( v.GetType() == typeof( int ) )         // type-checking
                {
                    int j = (int) v;            // unboxing always explicit
                    j++;
                    Console.WriteLine( "After manipulation: {0}", j );
                }
                // IS operator is used for type-checking
                else if ( v is string )           // v.GetType() == typeof( string ) )
                {
                    // explicit unboxing by typecasting
                    // WILL THROW RUNTIME ERROR if underlying boxed object is not String
                    string s1 = (string) v;           

                    // Will return NULL if underlying boxed object is not String.
                    string? s = v as string;            // AS OPERATOR (Safe TypeCasting operator)
                    if (s is not null)                      // ( s != null)
                    {
                        s = s.ToUpper();
                        Console.WriteLine( "Received a STRING Variable {0}", s );
                    }
                }
                else if ( v is DateTime )
                {
                    DateTime dt = (DateTime) v; // unboxing
                    Console.WriteLine( "DateTime: {0}", dt.ToLongDateString() );
                }

                Console.WriteLine();
            }

        }
    }
}
