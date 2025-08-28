namespace Demo_TypeMembers
{
    public class Employee
    {

        #region Data Fields

        private int EmployeeID;

        public string EmployeeName;

        #endregion

        # region Method Verison to handle DataField
        public int GetEmployeeID()
        {
            // 1.2.3.4.5
            return EmployeeID;
        }

        public void SetEmployeeID( int id )
        {
            // 1 Authentication
            // 2 Authorization

            // 3. Validation
            if ( id <= 0 )
            {
                Console.WriteLine( "Invalid Id" );
            }
            else
            {
                // 4. The Process
                this.EmployeeID = id;
            }

            // 5. Audit Logging
        }

        #endregion

        /************
                private int ID;
                public int GetId()
                {
                    return ID;
                }
                public void SetID(int id)
                {
                    this.ID = id;
                }
        *************/

        #region PROPERTY member

        private int _ID;            // backing DataField

        public int ID
        {
            // GET ACCESSOR
            get
            {
                // 1.2.3.4.5.
                return this._ID;
            }

            // SET ACCESSOR
            set
            {
                // 1.2.3.4.5.
                this._ID = value;
            }
        }

        #endregion


        // Auto-Implemented Property
        public string Designation
        {
            get; set;
        }
    }

}
