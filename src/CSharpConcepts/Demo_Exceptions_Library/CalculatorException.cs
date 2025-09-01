using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Demo_Exceptions_Library
{
    public class CalculatorException : System.ApplicationException
    {
        private const string DEFAULTMESSAGE = "An exception occurred in Calculator";

        public CalculatorException() : base( message: DEFAULTMESSAGE )
        { 
        }

        public CalculatorException ( string message ) : base( message ) { }

        public CalculatorException ( string message, Exception innerException ) : base( message, innerException ) { }

    }
}
