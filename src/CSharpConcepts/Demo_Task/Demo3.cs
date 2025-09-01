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
    class Demo3
    {
        public static async void Run()
        {
            Demo3.RunSync(10, 20);
            Console.WriteLine();

            Demo3.RunAsync( 10, 20 );
            Console.WriteLine();

            int result;

            result = Demo3.RunWithAsyncReturn( 10, 20 ).Result;
            Console.WriteLine( "RED" );                 // will be printed only after result is received
            Console.WriteLine( "Result : {0}", result );

            result = await Demo3.RunWithAsyncReturn( 10, 20 );
            Console.WriteLine( "GREEN" );               // will be printed before result is received
            Console.WriteLine( "Result : {0}", result );

            Console.WriteLine();
        }

        private static void RunSync(int x, int y)
        {
            Console.WriteLine( "-- RunSync called on Thread: {0}", System.Threading.Thread.CurrentThread.ManagedThreadId );
            Task<int> taskResult = Task.FromResult<int>(Demo3.Add(x, y));
            int result = taskResult.Result;

            Console.WriteLine( "Result = {0}", result );
        }

        private async static void RunAsync (int x, int y)
        {
            Console.WriteLine( "-- RunAsync called on Thread: {0}", System.Threading.Thread.CurrentThread.ManagedThreadId );

            int result = await Task.FromResult<int>( Demo3.Add( x, y ) );
            Console.WriteLine( "Result = {0}", result );
        }


        private static Task<int> RunWithAsyncReturn ( int x, int y )
        {
            Console.WriteLine( "-- RunWithAsyncReturn called on Thread: {0}", System.Threading.Thread.CurrentThread.ManagedThreadId );

            return Task.FromResult<int>( Demo3.Add( x, y ) );
        }

        private static int Add(int a, int b)
        {
            System.Threading.Thread.Sleep( 2000 );
            Console.WriteLine( "-- Add called on Thread: {0}", System.Threading.Thread.CurrentThread.ManagedThreadId );
            return a + b;
        }
    }
}
