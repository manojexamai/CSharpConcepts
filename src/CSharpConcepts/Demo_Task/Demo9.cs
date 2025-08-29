using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Demo_Task
{
    class Demo9
    {
        public static void Run()
        {
            Task task1 = Task.Factory.StartNew(Demo9.DoSomething);
            Task task2 = Task.Factory.StartNew(Demo9.DoSomething);
            Task task3 = Task.Factory.StartNew(Demo9.DoSomething);

            // Wait for tasks to finish
            Task.WaitAll(task1, task2, task3);

            // example of Fluid Code invocations / Chain Calls.
            // Execute another task when current task is done
            Task.Factory
                .StartNew(Demo9.DoSomething)
                .ContinueWith( (t) =>
                {
                    Console.WriteLine("Hello Task library continued! - 9");
                })
                .ContinueWith((t) =>
                 {
                     Console.WriteLine("Hello Task library continued again! - 9");
                 });
        }

        private static void DoSomething()
        {
            Console.WriteLine("Hello Task library! - 9");
        }

    }
}
