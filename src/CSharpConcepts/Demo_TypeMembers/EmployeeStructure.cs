using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Demo_TypeMembers
{
    struct EmployeeStructure
    {
        // DATA FIELD - INSTANCE MEMBER
        // - Noun
        // - Attribute / Qualities
        // - Purpose: To store the Data
        public int EmployeeID;


        // DATA FIELD - the backing data member
        private string _employeeName;

        // PROPERTY - the property using which the backing data member can be manipulated.
        public string EmployeeName
        {
            // GET ACCESSOR OF THE PROPERTY - returns the data from the backing datafield
            get
            {
                return this._employeeName;
            }

            // SET ACCESSOR OF THE PROPERTY - assigns/changes the value in the backing datafield
            set
            {
                if (value == "")
                {
                    Console.WriteLine("Sorry!  Name cannot be empty!");
                }
                else
                {
                    this._employeeName = value;
                }
            }
        }

        /***********************
        private string EmployeeName;
        public string GetEmployeeName()
        {
            return this.EmployeeName;
        }
        public void SetEmployeeName(string newemployeename)
        {
            this.EmployeeName = newemployeename;
        }
        *************/

        
        #region Example of Encapsulation using the Method 

        // DATA FIELD - acts as the backing variable to store the data
        private string Designation;

        // METHOD - to get the data from the backing variable
        public string GetDesignation()
        {
            // encapsulation steps - 1 to 5
            return this.Designation;
        }

        // METHOD - to assign/change the value in the backing variable.
        public void SetDesignation(string newdesignation)
        {
            // encapsulation steps - 1 to 5
            if(newdesignation != "INVALID")
            {
                this.Designation = newdesignation;
            }
            else
            {
                Console.WriteLine("Sorry.  Invalid Designation is not supported!");
            }
        }

        #endregion


        // DATA FIELD - TYPE MEMBER
        // - only one copy of this member will exist shared amongs all objects
        static public string CompanyName;

        // METHOD - INSTANCE MEMBER
        // - Verb
        // - Behaviour / Activity 
        // - Purpose: To manipulate the data stored in the object
        public void Work()
        {
            // accessing the type member inside an instance method
            Console.WriteLine("Company: {0}", EmployeeStructure.CompanyName);

            Console.WriteLine("{0} is working", this.EmployeeName);
        }

        // METHOD - TYPE MEMBER
        static public void BonusCalculation(EmployeeStructure emp)
        {
            // receiving the instance member into the type member.
            Console.WriteLine("Calculate the bonus of {0}!", emp.EmployeeName);
        }
    }
}
