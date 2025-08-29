using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections;

namespace Demo_IEnumerable
{
    class Company : System.Collections.IEnumerable
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

        public int NumberOfEmployees
        {
            get
            {
                return this.counter;
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
                Employee emp = this.Employees[i] as Employee;
                Console.WriteLine("{0} {1}", emp.EmployeeID, emp.EmployeeName);
            }
            Console.WriteLine("Number of Employees: {0}", this.NumberOfEmployees);
        }

        #region System.Collections.IEnumerable interface members

        public IEnumerator GetEnumerator()
        {
            if (this.Employees != null)
            {
                for ( int i = 0 ; i < this.counter ; i++ )
                {
                    Employee emp = this.Employees[i] as Employee;
                    yield return emp;
                }

                //foreach (Employee emp in this.Employees)
                //{
                //    yield return emp;
                //}
            }
            else
            {
                yield break;
            }
        }

        #endregion
    }
}
