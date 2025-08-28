using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Demo_Interfaces
{
    // Consumer of the Interface
    class Driver
    {
        // VERSION 4 (1-3 are in the Inheritance example project Demo10)
        // BENEFITS of using Interface:
        // 1. Plug and play code (no longer depends upon anything)
        // 2. Future ready (can work with any object which adheres to the interface signature)
        public void DriveVehicle(IAutomobile objAutomobile)
        {
            Console.WriteLine("The Driver is driving: {0}", objAutomobile.RegistrationNumber);
            objAutomobile.Drive();
        }
    }
}
