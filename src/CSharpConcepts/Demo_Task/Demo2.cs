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
    class Demo2
    {
        public static void Run()
        {
            // Syncrhonous Version
            PrintMessage();

            // Asynchronous Version
            Task task = Demo2.PrintMessageAsync();
            task.Wait();

            Console.WriteLine( "--- Run 6 completed!" );
        }

        // NOTE: Name the method with "Async" suffix
        private async static Task PrintMessageAsync()
        {
            await Task.Run(() => Demo2.PrintMessage());
        }

        private static void PrintMessage()
        {
            Console.WriteLine("Hello Task library! - 6");
        }
    }
}
