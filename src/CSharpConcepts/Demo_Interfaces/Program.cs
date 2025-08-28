using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Demo_Interfaces
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Demo of using Interfaces!");
            Console.WriteLine();

            Person person = new Person()                // Declaration & Instantion
            {
                Name = "Bill Gates",                    // initializing the property
                DriverOfPerson = new Driver()           // initializing the aggregated object
            };

            // Automobile vehicle = new Automobile();
            Car objCar = new Car() { RegistrationNumber = "Car - KA 01 Z 3409" };
            Scooter objScooter = new Scooter() { RegistrationNumber = "Scooter - KA 01 EE 1234" };

            person.DriverOfPerson.DriveVehicle(objCar);
            Console.WriteLine();

            person.DriverOfPerson.DriveVehicle(objScooter);
            Console.WriteLine();
        }
    }
}
