using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections;

namespace Demo_IEnumerator
{
    class Company : System.Collections.IEnumerator
    {
        // public string CompanyName { get; private set; }
        public readonly string CompanyName;

        private ArrayList Employees;            // Collection is not exposed!!
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

        public Employee? this[int employeeId]
        {
            get
            {
                Employee? empFound = null;
                for(int i = 0; i < this.NumberOfEmployees; i++)
                {
                    Employee emp = this.Employees[i] as Employee;
                    if( emp.EmployeeID == employeeId)
                    {
                        empFound = emp;
                        break;
                    }
                }
                return empFound;
            }
        }

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
            this.Employees.Add(newEmployee);
        }

        public void DisplayAllEmployee()
        {
            Console.WriteLine("Company Name: {0}", this.CompanyName);
            for(int i = 0; i < this.counter; i++)
            {
                Employee? emp = this.Employees[i] as Employee;
                if ( emp is not null )
                {
                    Console.WriteLine( "{0} {1}", emp.EmployeeID, emp.EmployeeName );
                }
            }
            Console.WriteLine("Number of Employees: {0}", this.NumberOfEmployees);
        }


        #region System.Collections.IEnumerable interface members

        private int _currentPosition;

        public object Current
        {
            get
            {
                return this.Employees[this._currentPosition];
            }
        }

        public bool MoveNext()
        {
            if (this._currentPosition < this.Employees.Count - 1)
            {
                this._currentPosition++;
                return true;
            }
            else
            {
                return false;
            }
        }

        public void Reset()
        {
            this._currentPosition = -1;
        }

        #endregion

    }
}
