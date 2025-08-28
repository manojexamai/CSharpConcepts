using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Demo_Constructors
{
    /// <summary>
    ///     Developer defines the CONSTRUCTOR
    ///          NOTE: Language Compiler will not add add any constructor
    ///                if the Developer defines any constructor in the type.
    ///     And adds a DESTRUCTOR
    /// </summary>
    class Demo2
    {
        // Constructor (example of DEFAULT constructor)
        // Any constructor without any parameters is known as DEFAULT / PARAMETERLESS constructor
        public Demo2()
        {
            Console.WriteLine("Constructor of Demo2 called successfully!");
        }

        // Destructor
        // 1. It cannot have any ACCESS MODIFIER specified
        // 2. It cannot receive any arguments
        // 3. It will not return any value
        ~Demo2()
        {
            Console.WriteLine("Destructor of Demo2 called successfully!");
        }
    }
}
