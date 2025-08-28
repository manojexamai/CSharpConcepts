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
        int i = 10;
        object o = 10;
        // var j = 10;                      // not possible.

        static void Main(string[] args)
        {
            int i = 10;
            int i2;                     // declare the variable without intialization
            string s = "hello world";
            Console.WriteLine("DATA TYPE: {0} is of the type {1}", i, i.GetType());
            int j = i;

            object o = 10;      // boxing
            Console.WriteLine("BOXING: {0} is of the type {1}", o, o.GetType());
            int j2 = (int)o;    // unboxing

            var x = 10;
            var x2 = 0;                    // have to initialize
            Console.WriteLine("TYPE INFERENCE: {0} is of the type {1}", x, x.GetType());
            int j3 = x;



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
    }
}
