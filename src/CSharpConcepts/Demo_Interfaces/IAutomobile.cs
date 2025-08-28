using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Demo_Interfaces
{
    // 1. All signatures are PUBLIC in nature
    // 2. All signature are ALWAYS ABSTRACT
    // 3. Cannot have any non-abstract signature (only method signatures supported)
    // 4. All Interface Signatures HAVE TO BE IMPLEMENTED!
    // 5. All Interface names are RECOMMENDED to follow the naming convention: Begin with "I"
    interface IAutomobile
    {
        string RegistrationNumber { get; set; }

        void Drive();
    }


    class X : IAutomobile
    {
        // Implicit version of Interface implementation
        public string RegistrationNumber { get; set; } = string.Empty;

        public void Drive()
        {
            // drive method of the class
        }

        // Explicit version of Interface implementation
        void IAutomobile.Drive()
        {
            // drive method of the class as defined by the Interface!
        }
    }

    class Y
    {
        public void m()
        {
            X obj = new X();
            obj.Drive();                        // -- X.Drive()
            ((IAutomobile)obj).Drive();         // -- IAutomobile.Drive() called explicitly

            IAutomobile obj2 = new X();
            obj2.Drive();                       // -- IAutomobile.Drive();
            (obj2 as X)?.Drive();                // -- X.Drive()
        }
    }
}
