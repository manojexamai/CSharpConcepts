using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Demo_Event
{
    public delegate void PercentageCompletedHandler (int percentage );

    public class Process
    {
        // Data-Field
        public event PercentageCompletedHandler? OnPercentageCompleted;

        internal void DoSomething ()
        {
            for(int i = 1 ; i <= 10; i++)
            {
                Console.WriteLine( "Completed Step # {0}, on Thread # {1}", 
                    i, System.Threading.Thread.CurrentThread.ManagedThreadId );

                if(OnPercentageCompleted is not null)        // check if EVENT IS SUBSCRIBED
                {
                    OnPercentageCompleted( i * 10 );         // RAISE THE EVENT (invoke delegate)
                }

                System.Threading.Thread.Sleep( 2000 );      // 1000 milliseconds = 1 second.
            }
        }
    }
}
