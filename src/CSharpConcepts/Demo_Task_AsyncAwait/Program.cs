using System;
using System.Threading;
using System.Threading.Tasks;

namespace Demo_Task_AsyncAwait
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Running Sync code....");
            bool retVal = Program.ProcessJob(10);
            Console.WriteLine("Returns {0}", retVal);
            Console.WriteLine();

            Console.WriteLine("Running Async code...");

            Task<bool> result = DoWorkAsync(10);
            Console.WriteLine("Async method called.\nResult will display once available from the async method.");

            result.Wait();

            Console.WriteLine($"Returns: {result.Result}");

            Console.WriteLine("Press any key to exit: ");
            Console.ReadKey();
        }

        private static async Task<bool> DoWorkAsync(int i)
        {
            // use await here, like so:
            return await Task.Run(() => ProcessJob(i));
        }

        private static bool ProcessJob(int i)
        {
            Console.WriteLine("-- ProcessJob going to sleep on Thread: {0}",
                System.Threading.Thread.CurrentThread.ManagedThreadId);

            // long running work code goes here
            Thread.Sleep(5000);

            Console.WriteLine("-- ProcessJob woke up on Thread: {0}",
                System.Threading.Thread.CurrentThread.ManagedThreadId);
            return true;
        }

    }
}
