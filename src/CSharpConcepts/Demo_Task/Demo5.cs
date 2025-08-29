using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Demo_Task
{
    /// <summary>
    ///     Using Lambda and anonymous method to execute the Task
    /// </summary>
    class Demo5
    {
        public static void Run()
        {
            Task task = new Task(() => { 
                Console.WriteLine("Hello Task library! - 5"); 
            });
            task.Start();
        }
    }
}
