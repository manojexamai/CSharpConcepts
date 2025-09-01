namespace Demo_Task
{
    class Demo5
    {
        public static void Run()
        {
            int i = 10;
            string s = ("hello world " + i).ToUpper().Replace("HELLO", "DEMO");     // CHAINED CALLS


            Task task1 = Task.Factory.StartNew(Demo5.DoSomething);
            Task task2 = Task.Factory.StartNew(Demo5.DoSomething);
            Task task3 = Task.Factory.StartNew(Demo5.DoSomething);

            // Wait for tasks to finish
            Task.WaitAll(task1, task2, task3);

            // example of Fluid Code invocations / Chain Calls.
            // Execute another task when current task is done
            Task.Factory
                .StartNew(Demo5.DoSomething)
                .ContinueWith( (t) =>
                {
                    Console.WriteLine("Hello Task library continued!");
                })
                .ContinueWith( (t) =>
                {
                    Console.WriteLine("Hello Task library continued again!");
                });
        }

        private static void DoSomething()
        {
            Console.WriteLine("Hello Task library!");
        }

    }
}
