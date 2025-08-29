using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Demo_TypeInferences
{
    /// <summary>
    ///     Type Inferance
    ///     1. infer the data type on assignment.
    ///     2. HAS to be assigned!
    ///     3. can be only local variables (inside a code block - no private, public, protected...)
    /// </summary>
    class Program
    {
        // var x = 10;                      // not allowed (RULE #3)

        static void Main(string[] args)
        {
            int i = 10;

            object o = (short)10;                  // boxing
            o = 10L;
            int j = (int) o;                // unboxing

            // var y;                       // not allowed (RULE #2)
            var x = (short)10;              // infer type on first assignment.
            // x = 10L;

            string s = "hello";
            var s2 = s;                     // string? s2 = s;

            var z = o;                      // object? z = o;

            int i3a = m1();
            int i3b = Convert.ToInt32( m2() );      // m2() returns string
            int i3c = Convert.ToInt32( m3() );      // m3() return bool
            int i3d;

            object o3a = m1();
            object o3b = m2();
            object o3c = m3();
            object o3d;

            var x3a = m1();             // int x3a;
            var x3b = m2();             // string x3b;
            var x3c = m3();             // bool x3b;
            // var x3d;                 // cannot be done.  Needs assignment.
        }


        static int m1()
        {
            return 10;
        }

        static string m2()
        {
            return "hello world";
        }

        static bool m3()
        {
            return true;
        }

        static object m(bool giveInt)
        {
            if(giveInt)
            {
                return 10;
            }
            else
            {
                return "10";
            }
        }
    }
}
