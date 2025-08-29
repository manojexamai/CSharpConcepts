using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Demo_Task
{
    class Program
    {
        static void Main(string[] args)
        {
            Demo1.Run();
            Demo2.Run();
            Demo3.Run();
            Demo4.Run();
            Demo5.Run();

            Console.WriteLine();

            Demo6.Run();
            Demo7.Run();

            Console.WriteLine();

            Demo8_DemoOfParallel.Run();
            Console.WriteLine();

            Demo9.Run();
        }
    }
}
