using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Demo_Attributes
{
    [Developer("Manoj Kumar Sharma", "80")]
    public class ClassA
    {
    }


    [Developer(name:"Manoj Kumar Sharma", level:"34", Reviewed = true)]
    class ClassB
    {
    }


    class ClassC
    {
    }


    [Developer(name: "Manoj", level: "20", Reviewed = false)]
    [Developer( name: "Sharma", level: "23", Reviewed = true )]
    class ClassD
    {

    }

}
