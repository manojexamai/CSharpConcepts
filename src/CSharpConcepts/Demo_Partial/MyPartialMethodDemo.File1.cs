namespace Demo_Partial;

internal partial class MyPartialMethodDemo
{
    partial void Step2();       // partial methods are always private

    public void DoSomething()
    {
        Step1();
        Step2();
        Step3();
    }

    private void Step1()
    {
        Console.WriteLine("step 1 called");
    }


    private void Step3()
    {
        Console.WriteLine("step 3 called");
    }
}
