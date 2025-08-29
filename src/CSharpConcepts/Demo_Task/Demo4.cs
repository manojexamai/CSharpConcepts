using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Demo_Task
{
    /// <summary>
    ///     Using Lambda and named method to execute the Task
    /// </summary>
    class Demo4
    {
        public static void Run()
        {
            Task task = new Task(() => Demo4.PrintMessage());
            task.Start();

            Console.WriteLine("Run in Demo4!");
            task.Wait();
        }

        private static void PrintMessage()
        {
            Console.WriteLine("Hello Task library! - 4");
        }
    }
}
