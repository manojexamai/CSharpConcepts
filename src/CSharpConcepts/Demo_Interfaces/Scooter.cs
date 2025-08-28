using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Demo_Interfaces
{
    class Scooter : IAutomobile
    {
        private string _registrationNumber;
        public string RegistrationNumber 
        {
            get
            {
                return this._registrationNumber.ToUpper();
            }
            set
            {
                this._registrationNumber = value;
            }
        }

        public void Drive()
        {
            Console.WriteLine("Scooter {0} is being driven!", this.RegistrationNumber);
        }
    }
}
