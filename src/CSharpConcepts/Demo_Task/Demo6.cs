using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Demo_Task
{
    /// <summary>
    ///     Using Task.Run in .NET 4.5
    /// </summary>
    class Demo6
    {
        public static void Run()
        {
            Task task = Demo6.RunAsync();
            Console.WriteLine("--- Run 6 completed!");
            task.Wait();
        }

        // NOTE: Name the method with "Async" suffix
        private async static Task RunAsync()
        {
            await Task.Run(() => Demo6.PrintMessage());
        }

        private static void PrintMessage()
        {
            Console.WriteLine("Hello Task library! - 6");
        }
    }
}
