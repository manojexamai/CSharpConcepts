using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Demo_StringFormatting
{
    class Program
    {
        static void Main(string[] args)
        {
            bool b = true;
            string name = "Manoj Kumar Sharma";
            int i = 10;
            double cost = 50.85;
            decimal salary = 5000.75M;          // same as = (decimal) 5000.75;

            Console.WriteLine("bool : {0}", b);
            Console.WriteLine("name: {0}, salary: {1}", name, salary);

            string message;
            message = "name: " + name + ", salary: " + salary.ToString();
            Console.WriteLine("after CONCATENATION: {0}", message);
            message = string.Format("name: {0}, salary: {1}", name, salary);
            Console.WriteLine("after String.Format(): {0}", message);

            message = string.Format("name: {0,30}, salary: {1:C}", name, salary);
            Console.WriteLine("after String.Format(): {0}", message);

            Console.WriteLine();

            System.DateTime dt = System.DateTime.Now;
            Console.WriteLine("LongDateString: {0}", dt.ToLongDateString());
            Console.WriteLine("ShortDateString: {0}", dt.ToShortDateString());
            Console.WriteLine("{0:dd-MMM-yyyy}", dt);
            message = string.Format("{0:dd-MMM-yyyy}", dt);
            Console.WriteLine(message);
            Console.WriteLine(string.Format("{0:dd-MMM-yyyy}", dt));

            // C# > 10
            // - String Interpolation
            string x = "hello world";
            int y = 50;
            Console.WriteLine("x = {0}", x);
            Console.WriteLine($"x = {x}");      // "x = " + x.ToString() // string.Format("x = {x}")
            Console.WriteLine($"x = {x}, y = {y}");
            Console.WriteLine($"x = {x, -30}, y = {y:C}");
            Console.WriteLine($"{dt:dd-MMM-YYYY hh:mm:ss tt}");
        }
    }
}
