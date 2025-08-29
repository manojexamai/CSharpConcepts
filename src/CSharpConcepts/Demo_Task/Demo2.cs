using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Demo_Task
{
    /// <summary>
    ///     Using the Action to execute the Task
    /// </summary>
    class Demo2
    {
        public static void Run()
        {
            // version 1
            Action objD = new Action(Demo2.PrintMessage);
            Task objTask = new Task(objD);
            objTask.Start();

            // version 2
            Task task = new Task(new Action(Demo2.PrintMessage));
            task.Start();
        }

        private static void PrintMessage()
        {
            Console.WriteLine("Hello Task library! - 2");
        }
    }
}
