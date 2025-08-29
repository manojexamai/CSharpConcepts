using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Demo_Interfaces.Demo2
{
    internal interface IDemo
    {
        void m ();
    }

    internal interface IAnotherDemo : IDemo
    {
        int m();

        void n ();
    }

    class Example : IAnotherDemo
    {
        public int m ()
        {
            throw new NotImplementedException();
        }

        public void n ()
        {
            throw new NotImplementedException();
        }

        void IDemo.m ()
        {
            throw new NotImplementedException();
        }
    }

}
