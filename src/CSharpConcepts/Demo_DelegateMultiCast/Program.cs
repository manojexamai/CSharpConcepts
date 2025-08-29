namespace Demo_DelegateMultiCast
{
    internal class Program
    {
        static void Main ( string[] args )
        {
            Process p = new Process();
            Workflow workflow = new Workflow();

            workflow.Workflow1( p );
            Console.WriteLine();

            workflow.Workflow2( p );
            Console.WriteLine();

            Console.WriteLine( "-- SingleCast Delegate Version" );
            workflow.DoWorkflow( p, p.Step4 );          // single-cast delegate (implicit instantiation)
            Console.WriteLine();

            // single-cast delegate (explicit instantiation)
            Console.WriteLine( "-- SingleCast Delegate Version" );
            StepHandler objD = new StepHandler( p.Step2 );
            workflow.DoWorkflow( p, objD );
            Console.WriteLine();

            // multi-cast delegate version
            Console.WriteLine( "-- Multicast Delegate Version" );
            StepHandler? objD2;
            objD2 = new StepHandler( p.Step4 );
            objD2 += new StepHandler( p.Step2 );        // subscribe to the delegate
            objD2 += new StepHandler( p.Step2 );
            objD2 += new StepHandler( p.Step5 );
            workflow.DoWorkflow( p, objD2 );
            Console.WriteLine();

            objD2 -= new StepHandler( p.Step2 );        // unsubscribe the last subscription
            objD2 -= new StepHandler( p.Step1 );        // unsubscribe the last subscription
            workflow.DoWorkflow( p, objD2 );
            Console.WriteLine();
        }

    }

    delegate void StepHandler ();

    class Workflow
    {
        internal void DoWorkflow(Process p, StepHandler? objD )
        {
            Console.WriteLine( "Authentication, Authorization, Validation" );

            Console.WriteLine( "The Activity" );
            if(objD is not null)
            {
                objD();
            }
            Console.WriteLine( "Audit Logging" );
        }


        internal void Workflow1 ( Process p )
        {
            p.Step1();
            p.Step2();
            p.Step3();
            p.Step4();
            p.Step5();
        }

        internal void Workflow2 ( Process p )
        {
            p.Step1();
            p.Step3();
            p.Step5();
        }
    }
}
