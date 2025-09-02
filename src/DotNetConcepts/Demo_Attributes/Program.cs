using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Demo_Attributes
{
    class Program
    {
        static void Main(string[] args)
        {
            Demo1();
            Demo2();
        }

        public static void fGetAttribute(System.Type tClassType)
        {
            // Get instance of the attribute  
            DeveloperAttribute myAttribute
                = (DeveloperAttribute)Attribute.GetCustomAttribute(
                                            tClassType, typeof(DeveloperAttribute));
            if (myAttribute is null)
            {
                Console.WriteLine("No Developer attributes were found.");
            }
            else
            {
                // Get the Name value   
                Console.WriteLine("The Name Attribute is: {0}.", myAttribute.Name);

                // Get the Level value 
                Console.WriteLine("The Level Attribute is: {0}.", myAttribute.Level);

                // Get the Reviewed value
                Console.WriteLine("The Reviewed Attribute is: {0}.", myAttribute.Reviewed);
                myAttribute.Reviewed = false;    // setting the value
                Console.WriteLine("The Reviewed Attribute is: {0}.", myAttribute.Reviewed);
            }
        }


        
        static void Demo1()
        {
            Demo1 obj = new Demo1();

            obj.MyFirstDeprecatedMethod();


            obj.MySecondDeprecatedMethod();
            obj.MyThirdDeprecatedMethod();
            obj.MyFourthDeprecatedMethod();
            // obj.MyFifthDeprecatedMethod();
        }

        static void Demo2()
        {
            Console.WriteLine("ATTRIBUTES OF ClassA:");
            fGetAttribute(typeof(ClassA));
            Console.WriteLine();

            Console.WriteLine("ATTRIBUTES OF ClassB:");
            fGetAttribute(typeof(ClassB));
            Console.WriteLine();

            Console.WriteLine("ATTRIBUTES OF ClassC:");
            fGetAttribute(typeof(ClassC));
            Console.WriteLine();

        }
    }
}
