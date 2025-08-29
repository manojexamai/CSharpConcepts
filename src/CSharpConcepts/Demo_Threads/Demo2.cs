using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.Threading;

namespace Demo_Threads
{

    // Asynchronous code
    class Demo2
    {
        public static void DoThis()
        {
            Console.WriteLine("-- called in Thread: {0}", Thread.CurrentThread.ManagedThreadId);
        }

        public static void RunThis()
        {
            Console.WriteLine("Running in Thread: {0}", Thread.CurrentThread.ManagedThreadId);

            // ThreadStart objD = new ThreadStart(Demo2.DoThis);
            // Thread t = new Thread( objD );

            Thread t = new Thread( new ThreadStart(Demo2.DoThis) );
            t.Start();

            Console.WriteLine("Doing something else in Thread: {0}", Thread.CurrentThread.ManagedThreadId);

            Thread t2 = new Thread(() =>
            {
                Thread.Sleep(10000);
                Console.WriteLine("-- anonymous method called in Thread: {0}", Thread.CurrentThread.ManagedThreadId);
            });
            t2.Start();

            Console.WriteLine("--- back in the main Thread {0}", Thread.CurrentThread.ManagedThreadId);


        }


    }
}
