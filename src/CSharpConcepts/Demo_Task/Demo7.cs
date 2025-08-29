using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Demo_Task
{
    /// <summary>
    ///     Using Task.FromResult in .NET 4.5 to return a result from a Task
    /// </summary>
    class Demo7
    {
        public static void Run()
        {
            Task task = Demo7.AsyncRun();
            Console.WriteLine("--- Run 7 completed!");
            task.Wait();
        }

        private async static Task AsyncRun()
        {
            int result = await Task.FromResult<int>(Demo7.Add(10, 20));
            Console.WriteLine(result);
        }

        private static int Add(int a, int b)
        {
            return a + b;
        }
    }
}
