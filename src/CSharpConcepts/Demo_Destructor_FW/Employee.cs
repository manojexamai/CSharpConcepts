using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Demo_Destructor_FW
{
    internal class Employee
    {
        public int Id { get; set; }
        public string Name { get; set; }

        public Employee(int id, string name )
        {
            Id = id;
            Name = name;
            Console.WriteLine($"Employee with ID: {Id}, Name: {Name} INSTANTIATED");
        }

        ~Employee ()
        {
            Console.WriteLine( $"Employee with ID: {Id}, Name: {Name} DESTROYED" );
        }
    }
}
