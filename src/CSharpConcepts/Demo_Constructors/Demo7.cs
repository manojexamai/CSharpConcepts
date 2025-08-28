using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Demo_Constructors
{
    class A
    {
        public int ID { get; set; }

        static A()
        {
            Console.WriteLine("Type Constructor of A called!");
        }

        public A(int id)
        {
            this.ID = id;
            Console.WriteLine("Instance Constructor of A called for ID: {0}", this.ID);
        }

    }

    class B : A
    {
        public string Name;

        static B()
        {
            Console.WriteLine("Type Constructor of B called!");
        }

        public B(int id): base(id)
        {
            Console.WriteLine("Instance Constructor of B called for ID: {0}", base.ID);
        }
    }

    class C : B
    {
        static C()
        {
            Console.WriteLine("Type Constructor of C called!");
        }

        public C(int id) : base(id)
        {
            Console.WriteLine("Instance Constructor of C called for ID: {0}", base.ID);
        }
    }

    class D : C
    {
        static D()
        {
            Console.WriteLine("Type Constructor of D called!");
        }

        public D(int id) : base(id)
        {
            Console.WriteLine("Instance Constructor of D called for ID: {0}", base.ID);
        }
    }

}
