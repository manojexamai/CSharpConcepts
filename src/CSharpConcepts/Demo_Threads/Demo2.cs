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
            Console.WriteLine("(T1) -- called in Thread: {0}", Thread.CurrentThread.ManagedThreadId);
        }

        public static void RunThis()
        {
            Console.WriteLine("(MAIN) Running in Thread: {0}", Thread.CurrentThread.ManagedThreadId);

            // ThreadStart objD = new ThreadStart(Demo2.DoThis);
            // Thread t = new Thread( objD );

            Thread t1 = new Thread( new ThreadStart(Demo2.DoThis) );
            t1.Start();

            Thread t3 = new Thread( Demo2.DoThis );     // implicitly instantiating the ThreadStart Delegate object
            t3.Start();

            Console.WriteLine("(MAIN) Doing something else in Thread: {0}", Thread.CurrentThread.ManagedThreadId);

            // Anonymous Method for the ThreadStart Delegate
            Thread t2 = new Thread(() =>
            {
                Thread.Sleep(10000);
                Console.WriteLine("(T2) -- anonymous method called in Thread: {0}", Thread.CurrentThread.ManagedThreadId);
            });
            t2.Start();

            // force the branched out threads to join the parent thread
            t1.Join();
            t2.Join();
            t3.Join();

            Console.WriteLine("(MAIN) --- back in the main Thread {0}", Thread.CurrentThread.ManagedThreadId);


        }


    }
}
