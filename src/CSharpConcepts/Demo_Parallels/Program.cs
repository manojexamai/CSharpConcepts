using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;

/// <summary>
///     Demo of TPL (Task Parallel Library)
///     (1) Parallel.For
///     (2) Parallel.ForEach
///     Benefits:
///     a. You do not have to worry about how many threads to create.
///     b. You do not have to worry about lock shared objects between the threads.
///     c. You do not have to worry about starting and stopping threads.
///     d. You do not have to figure out how to pass values into the thread invokations.
/// </summary>
namespace Demo_Parallels
{
    class Program
    {
        private static void displayNumber(int i)
        {
            System.Threading.Thread.Sleep(100);     // 100 milliseconds
            Console.WriteLine("{0} (Thread: {1})", i, Thread.CurrentThread.ManagedThreadId);
        }

        private static void displayNumber ( object? i )
        {
            if ( i is not null )
            {
                int intVar = (int) i;
                System.Threading.Thread.Sleep( 100 );     // 100 milliseconds
                Console.WriteLine( "{0} (Thread: {1})", intVar, Thread.CurrentThread.ManagedThreadId );
            }
        }

        static void Main(string[] args)
        {
            int[] arr = new int[] { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10 };
            System.Diagnostics.Stopwatch stopwatch = new System.Diagnostics.Stopwatch();

            Console.WriteLine("--- Synchronous output using FOREACH");
            stopwatch.Start();
            foreach (int i in arr)                               // sync code
            {
                displayNumber(i);
            }
            Console.WriteLine();
            stopwatch.Stop();
            Console.WriteLine("Elapsed Time: {0} milliseconds ( {1} )",
                stopwatch.ElapsedMilliseconds, stopwatch.ElapsedTicks);

            Console.WriteLine();
            stopwatch.Reset();

            Console.WriteLine( "--- ASynchronous output using THREADS" );

            stopwatch.Start();
            Thread[] threads = new Thread[arr.Length];
            int counter = 0;
            foreach ( int i in arr )
            {
                //var par = new ParameterizedThreadStart( displayNumber );
                //Thread t = new Thread( par );
                //t.Start( i );

                threads[counter] = new Thread( displayNumber );
                threads[counter].Start(i);
                counter++;
            }
            foreach(Thread t in threads )
            {
                t.Join();
            }
            stopwatch.Stop();
            Console.WriteLine( "Elapsed Time: {0} milliseconds ( {1} )",
                stopwatch.ElapsedMilliseconds, stopwatch.ElapsedTicks );


            Console.WriteLine();
            stopwatch.Reset();

            Console.WriteLine( "--- Asychronous output using PARALLEL.FOREACH" );
            stopwatch.Start();
            //Parallel.ForEach( arr, i
            //    =>
            //    {
            //        displayNumber( i );           // async code
            //    } );
            Parallel.ForEach( arr, i => displayNumber( i ) );      // async code
            Console.WriteLine();
            stopwatch.Stop();
            Console.WriteLine( "Elapsed Time: {0} milliseconds ( {1} )",
                stopwatch.ElapsedMilliseconds, stopwatch.ElapsedTicks );

            Console.Write( "press any key to continue...." );
            Console.ReadLine();

            stopwatch.Reset();


            Console.WriteLine( "--- Sychronous output using FOR" );

            // Synchronous version for For Loop
            // for(int i = 0; i <= arr.Length - 1; i++)
            stopwatch.Start();
            for ( int i = 0 ; i < arr.Length ; i++ )
            {
                displayNumber( i );
            }
            stopwatch.Stop();
            Console.WriteLine( "Elapsed Time: {0} milliseconds ( {1} )",
                stopwatch.ElapsedMilliseconds, stopwatch.ElapsedTicks );

            Console.WriteLine();
            stopwatch.Reset();

            Console.WriteLine( "--- Asychronous output using PARALLEL.FOR" );

            // Parallel For loop
            stopwatch.Start();
            Parallel.For( 0, arr.Length, i =>
            {
                displayNumber( i );
            } );
            stopwatch.Stop();
            Console.WriteLine( "Elapsed Time: {0} milliseconds ( {1} )",
                stopwatch.ElapsedMilliseconds, stopwatch.ElapsedTicks );
        }
    }
}
