using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Demo_Task
{
    class Demo1
    {
        public static void Run()
        {
            // ThreadStart t = new ThreadStart(() => {
            //      Console.WriteLine("Hello");
            // });
            // t.Start();

            Task.Factory.StartNew(() =>
            {
                Console.WriteLine("Hello Task library! - 1");
            });
        }
    }
}
