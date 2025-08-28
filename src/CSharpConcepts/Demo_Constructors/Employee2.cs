using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Demo_Constructors
{
    class Employee2
    {
        // TYPE member - Data Field
        static private int _counter;
        
        // TYPE member - Type Constructor
        // 1. Cannot have any access modifier
        // 2. Cannot receive any arguments
        // 3. PURPOSE: to initialize all Type members
        // 4. It is called ONLY ONCE during the lifetime of the type
        // 5. It is called by the CLASS LOADER OF THE CLR when the class is loaded 
        // 6. Execution of Static Constructors in an inheritance chain are NON-DETERMINISTIC
        static Employee2()
        {
            _counter = 0;
        }

        // TYPE member - Property
        static public int CountOfEmployees
        {
            get
            {
                return _counter;
            }
        }

        // INSTANCE member - Property
        public int ID { get; private set; }
        public string Name { get; private set; }


        private string _designation;
        public string Designation
        {
            get
            {
                return _designation;
            }
            set
            {
                _designation = value;
            }
        }

        // INSTANCE member - Parameterized Constructor
        // PURPOSE: To initialize all instance members
        // INSTANCE constructor is called whenever the NEW keyword is used to instantiate an object.
        public Employee2(string name)
        {
            this.ID = ++_counter;
            this.Name = name;
        }
    }
}
