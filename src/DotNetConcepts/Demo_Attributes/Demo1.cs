using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Demo_Attributes
{
    class Demo1
    {
        /// <summary>
        ///    This is a deprecated method.  May be you should use .....
        /// </summary>
        [Obsolete]
        public void MyFirstDeprecatedMethod()
        {
            Console.WriteLine("called MyFirstdeprecatedMethod().");
        }

        /// <summary>
        ///    Another way of indicating a deprecated method
        /// </summary>
        [ObsoleteAttribute]
        public void MySecondDeprecatedMethod()
        {
            Console.WriteLine("called MySecondDeprecatedMethod().");
        }

        /// <summary>
        ///    You can also provide your own comment
        /// </summary>
        [Obsolete("You shouldn't use this method anymore.")]
        public void MyThirdDeprecatedMethod()
        {
            Console.WriteLine("called MyThirdDeprecatedMethod().");
        }

        [Obsolete("You cannot use this method", false)]
        public void MyFourthDeprecatedMethod()
        {
            Console.WriteLine("called MyFourthDeprecatedMethod().");
        }

        [Obsolete( message: "You cannot use this method", error: true)]
        public void MyFifthDeprecatedMethod()
        {
            Console.WriteLine("called MyFifthDeprecatedMethod().");
        }

    }
}
