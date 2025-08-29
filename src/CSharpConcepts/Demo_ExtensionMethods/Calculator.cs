using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Demo_ExtensionMethods
{
    internal class Calculator
    {
        public int Add(int a,  int b)
        {
            return a + b;
        }

        public void Author ()
        {
            Console.WriteLine( "Author of {0} is Manoj Kumar Sharma", this.GetType() );
        }
    }


}
