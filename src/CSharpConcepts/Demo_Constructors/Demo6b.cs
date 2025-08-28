using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Demo_Constructors
{
    class MyBaseClass2
    {
        public MyBaseClass2()
        {
            Console.WriteLine("MyBaseClass-2() DEFAULT constructor called!");
        }

        public MyBaseClass2(int id)
        {
            Console.WriteLine("MyBaseClass-2() PARAMETERIZED constructor called with {0}!", id);
        }
    }


    class MyDerivedClass2 : MyBaseClass2
    {
        public MyDerivedClass2() : this(0)
        {
            Console.WriteLine("MyDerivedClass-2() DEFAULT constructor called!");
        }

        public MyDerivedClass2(int id) : base()
        {
            Console.WriteLine("MyDerivedClass2-2() PARAMETERIZED constructor called with {0}!", id);
        }
    }

}
