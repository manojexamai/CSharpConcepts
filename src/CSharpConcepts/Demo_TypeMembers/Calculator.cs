using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Demo_TypeMembers
{
    class Calculator
    {
        // Backing field (to store the data)
        private int _sumTotal;

        // Method signature - to GET the data
        public int GetTotal()
        {
            return this._sumTotal;
        }

        // Property signature - to GET the data
        public int Total
        {
            get
            {
                return this._sumTotal;
            }
        }

    }
}
