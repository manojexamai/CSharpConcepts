using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Demo_Generics
{
    /// <summary>
    ///     Demo of Generic Type.  Which can be a ValueType or ReferenceType
    /// </summary>
    /// <typeparam name="T">the underlying datatype</typeparam>
    class MyGenericType<T>
    {
        public T? PropertyValue { get; set; }

        public void ShowAuthorInfo()
        {
            Console.WriteLine("Author: Microsoft");
        }
    }

    class MyDerivedGeneric<T1, T2> : MyGenericType<T1>
    {

    }
}


