using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Demo_ExtensionMethods
{
    // Singleton
    internal static class MyExtensions
    {
        // First Parameter
        // Decorated with "this" instance modifier
        public static int Subtract( this Calculator objC, int x, int y)
        {
            return x - y;
        }


        public static void Author(this object obj)
        {
            Console.WriteLine( "Author of {0} is Microsoft", obj.GetType() );
        }
    }
}
