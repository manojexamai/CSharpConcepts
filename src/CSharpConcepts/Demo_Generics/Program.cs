using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Demo_Generics
{
    class Program
    {
        static void Main(string[] args)
        {
            int i = 10;
            string s = "hello world";

            object o;
            o = 10;                     // boxing
            i = (int)o;                 // unboxing

            o = "hello world";          // boxing
            s = (string)o;              // unboxing

            MyGenericType<int> myInt = new MyGenericType<int>();
            myInt.PropertyValue = 10;
            // myInt.PropertyValue = "hello world";    // type-safety enforced.
            myInt.ShowAuthorInfo();

            MyGenericType<string> myString = new MyGenericType<string>();
            myString.PropertyValue = "hello world";
            myString.ShowAuthorInfo();


            int[] arr = new int[10];

            ArrayList arrayList = new ArrayList();
            arrayList.Add( 10 );
            arrayList.Add( "hello world" );


            System.Collections.Generic.List<int> intList = new List<int>();
            intList.Add( 10 );


            System.Collections.Generic.Dictionary<int, Employee> objDict
                = new Dictionary<int, Employee>();


            MyGenericType<Employee> emp = new MyGenericType<Employee>();
            emp.PropertyValue = new Employee();
            emp.ShowAuthorInfo();

        }

        class Employee
        {

        }
    }
}
