using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Demo_Task
{
    /// <summary>
    ///     Using the Delegate to execute the Task
    /// </summary>
    class Demo3
    {
        public static void Run()
        {
            Task task = new Task(delegate { Demo3.PrintMessage(); });
            task.Start();
        }

        private static void PrintMessage()
        {
            Console.WriteLine("Hello Task library! - 3");
        }
    }
}
