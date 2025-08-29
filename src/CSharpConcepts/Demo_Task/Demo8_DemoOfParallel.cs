using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Demo_Task
{
    // For More information:
    // https://msdn.microsoft.com/en-us/library/dd537609(v=vs.110).aspx

    class Demo8_DemoOfParallel
    {
        public static void Run()
        {
            int[] arr = { 10, 20, 30 };

            // Example 1
            foreach(var item in arr)
            {
              Task.Factory.StartNew(() => DoSomething(item));
            }

            // Example 2
            Parallel.ForEach<int>(arr, item => DoSomething(item));

            // Example 3
            Task.Factory.StartNew(() => 
                Parallel.ForEach<int>(arr, item => DoSomething(item))
            );
        }

        private static void DoSomething(int item)
        {
            Console.WriteLine(item);
        }
    }
}
