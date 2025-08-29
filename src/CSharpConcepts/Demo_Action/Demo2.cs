
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Demo_Action
{
    class Demo2
    {

        public static void RunThis()
        {
            // NOTE: Action return type is always VOID!
            // delegate void delegateHandler();
            Action action = () => Console.WriteLine("hello world");
            action();
            Console.WriteLine();

            // Calling though the built-in Action Delegate
            // delegate void delegateHandler(int i);
            // DelegateHandler objD = new DelegateHandler( DoSomething );
            // DelegateHandler objD = DoSomething;
            Action<int> doActionDelegate = DoSomething;
            doActionDelegate(10);
            Console.WriteLine();

            // delegate void delegateHandler(string message);
            Action<string> doActionDelegate2
                = (message) => Console.WriteLine($"Message: {message}");
            doActionDelegate2("hello world");
            Console.WriteLine();
        }

        static void DoSomething(int i)
        {
            Console.WriteLine($"do something called with {i}");
        }
    }
}
