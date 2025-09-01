using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Demo_Task
{
    // For More information:
    // https://msdn.microsoft.com/en-us/library/dd537609(v=vs.110).aspx

    class Demo4_DemoOfParallel
    {
        public static void Run()
        {
            int[] arr = { 10, 20, 30 };

            // Example 1
            foreach ( var item in arr )
            {
                Task.Factory.StartNew( () => DoSomething( item ) );
            }
            Console.WriteLine();

            // Example 2 (A)
            Parallel.ForEach( arr, item => DoSomething( item ) );
            Console.WriteLine();

            // Example 2 (B)
            Parallel.ForEach( arr, DoSomething );
            Console.WriteLine();

            // Example 3
            Task.Factory.StartNew( () =>
                Parallel.ForEach<int>( arr, item => DoSomething( item ) )
            );
            Console.WriteLine();
        }

        private static void DoSomething(int item)
        {
            Console.WriteLine("{0} on Thread: {1}", item, Thread.CurrentThread.ManagedThreadId );
        }
    }
}
