using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Demo_Interfaces
{

    // Implementor of the Interface
    class Car : IAutomobile
    {
        public string RegistrationNumber { get; set; }

        public void Drive()
        {
            Console.WriteLine("Car is being driven! {0}", this.RegistrationNumber);
        }
    }
}
