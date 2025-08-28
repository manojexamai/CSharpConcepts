using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections;

namespace Demo_Indexer
{
    // Indexers are added only to the class, which can create an object
    // that will have an internal collection of objects.
    // Eg: Company has a collection of Employees
    class Company
    {
        // public string CompanyName { get; private set; }
        public readonly string CompanyName;
        public ArrayList Employees;
        private int counter;

        public Company(string companyname)
        {
            this.CompanyName = companyname;
            this.Employees = new ArrayList();
            this.counter = 0;
        }

        // Read-Only Property
        public int NumberOfEmployees
        {
            get
            {
                return this.counter;
            }
        }





        public Employee? this[int findEmployeeId]
        {
            get
            {
                Employee? empFound = null;
                for(int i = 0; i < this.NumberOfEmployees; i++)
                {
                    Employee? emp = this.Employees[i] as Employee;       // safe unboxing
                    if( emp is not null && emp.EmployeeID == findEmployeeId)
                    {
                        empFound = emp;
                        break;
                    }
                }
                return empFound;
            }
        }

        public Employee GetEmployeeByName(string employeeName)
        {
            Employee empFound = null;
            foreach (Employee emp in this.Employees)
            {
                if (emp.EmployeeName == employeeName)
                {
                    empFound = emp;
                    break;
                }
            }
            return empFound;
        }

        // The Indexer shown below does the same thing as the Method shown above.
        // public Employee GetEmployeeByName(string employeeName)
        public Employee this[string employeeName]
        {
            get
            {
                // Encapsulation: 1...5
                Employee empFound = null;
                foreach (Employee emp in this.Employees)
                {
                    if (emp.EmployeeName == employeeName)
                    {
                        empFound = emp;
                        break;
                    }
                }
                return empFound;
            }
        }


        public void AddEmployee(string name)
        {
            Employee newEmployee = new Employee(++this.counter, name);
            this.Employees.Add(newEmployee);            // boxing
        }

        public void DisplayAllEmployee()
        {
            Console.WriteLine("Company Name: {0}", this.CompanyName);
            for(int i = 0; i < this.counter; i++)
            {
                Employee emp = this.Employees[i] as Employee;
                Console.WriteLine("{0} {1}", emp.EmployeeID, emp.EmployeeName);
            }
            Console.WriteLine("Number of Employees: {0}", this.NumberOfEmployees);
        }
    }
}
