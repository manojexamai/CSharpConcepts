using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Demo_Constructors
{
    class Program
    {
        static void Main(string[] args)
        {
            Demo07d();
        }

        static void Demo01()
        { 
            Demo1 obj = new Demo1();
        }

        static void Demo02()
        {
            Demo2 obj = new Demo2();
        }

        static void Demo03()
        {
            Demo3 obj1 = new Demo3();
            Demo3 obj2 = new Demo3(10);
            Demo3 obj3 = new Demo3(10, "hello world");
        }

        static void Demo04()
        {
            Employee emp1 = new Employee(1, "First Employee");
            Employee emp2 = new Employee(2, "Second Employee");
            Employee emp3 = new Employee(3, "Third Employee");

            // emp1.ID = 10;

            Console.WriteLine("{0} {1}", emp1.ID, emp1.Name);
            Console.WriteLine("{0} {1}", emp2.ID, emp3.Name);
            Console.WriteLine("{0} {1}", emp2.ID, emp3.Name);
        }

        static void Demo05()
        {
            Console.WriteLine("Number of Employees: {0}", Employee2.CountOfEmployees);

            Employee2 emp1 = new Employee2("First Employee");
            Employee2 emp2 = new Employee2("Second Employee");
            emp2.Designation = "Manager";
            Employee2 emp3 = new Employee2("Third Employee") { Designation = "Clerk" };

            // emp1.ID = 10;
            Console.WriteLine("Number of Employees: {0}", Employee2.CountOfEmployees);
            Console.WriteLine("{0} {1}", emp1.ID, emp1.Name);
            Console.WriteLine("{0} {1}", emp2.ID, emp2.Name);
            Console.WriteLine("{0} {1}", emp3.ID, emp3.Name);
        }
    
        static void Demo06()
        {
            MyBaseClass objBase = new MyBaseClass();
            Console.WriteLine();

            MyDerivedClass myDerivedClass = new MyDerivedClass();
            Console.WriteLine();
        }

        static void Demo06b()
        {
            //MyBaseClass2 objBase = new MyBaseClass2();              
            //Console.WriteLine();

            //MyDerivedClass2 myDerivedClass = new MyDerivedClass2(); 
            //Console.WriteLine();

            //MyBaseClass2 objBase2 = new MyBaseClass2(10); 
            //Console.WriteLine();

            MyDerivedClass2 myDerivedClass2 = new MyDerivedClass2(10);
            Console.WriteLine();
        }

        static void Demo07a()
        {
            A objA1 = new A(1);         // static, instance constuctor
            A objA2 = new A(2);         // instance constructor
        }

        static void Demo07b()
        {
            B objB10 = new B(10);       // static (B), static (A), instance (A), instance (B)
            B objB11 = new B(11);       // instance (A), instance (B)
        }

        // Run this demo with the Static Constructors commented out.
        static void Demo07c()
        {
            A a = new A(1);
            a.ID = 10;

            B b = new B(2);
            b.ID = 20;
            b.Name = "hello world";

            A objA = new B(100);            // parent with the behaviours of the child.
            objA.ID = 10000;
            // objA.Name = "not possible";

            // B objB = new A(10);  --- not possible.
        }

        static void Demo07d()
        {
            // compare this with Line #94
            // A objA = new B(100);        // static (B), static (A), instance (A), instance (B)

            A objA = new D(100);
        }
    }
}
