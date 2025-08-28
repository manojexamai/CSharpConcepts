using System;

namespace Demo_HelloWorld
{
    internal class Program
    {
        static int i;

        // This is a PUBLIC STATIC VOID MAIN Method.
        static void Main(string[] args)
        {
            Console.WriteLine("Hello, World!");
            Program.i = 16;

            SomeWorld.Demo.i = 20;
        }
    }
}


namespace SomeWorld
{
    class Demo          // by DEFAULT: internally visible
    {
        static internal int i;          // by DEFAULT: privately visible

        void m ()
        {
            i++;
        }
    }

    class DerivedDemo : Demo
    {
        void n()
        {
            // base.i++;
        }
    }
}