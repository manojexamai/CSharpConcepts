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
                    // RAISE THE EVENT (invoke delegate) on the same thread - running synchronously
                    // OnPercentageCompleted( i * 10 );         

                    // Raise the event, allowing handlers to run asynchronously
                    Delegate[]? array = OnPercentageCompleted?.GetInvocationList();
                    if( array is not null)
                    {
                        // for ( int counter = 0 ; counter < array.Length ; counter++ )
                        // {
                        //    PercentageCompletedHandler? handler = array[counter] as PercentageCompletedHandler;
                        //    Task.Run( () => handler?.Invoke( i * 10 ) );
                        // }

                        foreach ( PercentageCompletedHandler handler in array.Cast<PercentageCompletedHandler>() )
                        {
                            Task.Run( () => handler?.Invoke( i * 10 ) );
                        }
                    }
                }

                System.Threading.Thread.Sleep( 2000 );      // 1000 milliseconds = 1 second.
            }
        }
    }
}
