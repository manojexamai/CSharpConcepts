namespace Demo_Event
{
    internal class Program
    {
        static void Main ( string[] args )
        {
            Process p = new Process();

            p.OnPercentageCompleted
                += ( percentage ) =>
                {
                    Console.WriteLine( "-- Percentage Completed: {0}, on Thread {1}",
                        percentage, System.Threading.Thread.CurrentThread.ManagedThreadId );
                   
                };

            p.DoSomething();

            Console.WriteLine( "-- exiting main" );
        }

    }
}
