using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Demo_Enum
{
    internal enum Position
    {
        First,
        Second,
        Third
    }

    internal enum Position2
    {
        First = 1,
        Second = 2,
        Third = 3
    }

    internal enum Position3
    {
        First = 1,
        Uno = 1,
        One = 1,

        Second = 2,
        Duo = 2,
        Two = 2,

        Third = 3,
        Three = 3
    }
}
