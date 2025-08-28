using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Demo_Constructors
{
    class MyBaseClass
    {
        public MyBaseClass()
        {
            Console.WriteLine("MyBaseClass() DEFAULT constructor called!");
        }
    }


    class MyDerivedClass : MyBaseClass
    {
        public MyDerivedClass()
        {
            Console.WriteLine("MyDerivedClass() DEFAULT constructor called!");
        }
    }

}
