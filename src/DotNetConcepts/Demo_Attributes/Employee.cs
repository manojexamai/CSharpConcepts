using System.ComponentModel.DataAnnotations;

namespace Demo_Attributes
{
    internal class Employee
    {
        private string _firstName;
        public string FirstName
        {
            get
            {
                return _firstName;
            }
            set
            {
                if (!string.IsNullOrEmpty(value))
                {
                    _firstName = value;
                }
            }
        }

        //System.ComponentModel.DataAnnotations.RequiredAttribute
        [Required]
        public int LastName { get; set; } 
    }
}
