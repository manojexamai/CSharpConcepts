using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Demo_Destructor_FW
{
    internal class DisposableEmployee : System.IDisposable
    {
        public int Id { get; set; }

        private string _name;
        public string Name
        {
            get
            {

                return _name;
            }
            set
            {
                CheckIfDisposing();

                _name = value;
            }
        }

        public DisposableEmployee(int id, string name) 
        {
            Id = id;
            Name = name;
            Console.WriteLine( $"Employee with ID: {Id}, Name: {Name} INSTANTIATED" );

            isDisposing = false;
        }

        public void Work()
        {
            CheckIfDisposing();

            Console.WriteLine( $"Employee {Id} is working" );
        }

        ~DisposableEmployee()
        {
            Console.WriteLine( $"Employee with ID: {Id}, Name: {Name} DESTROYED" );
        }

        #region System.IDisposable members

        // Destructor Signature

        private bool isDisposing;

        private void CheckIfDisposing()
        {
            if ( isDisposing )
            {
                throw new ObjectDisposedException(
                    objectName: $"ID: {Id}",
                    message: "This Employee has been DISPOSED!!!!" );
            }
        }

        public void Dispose ()
        {
            if ( isDisposing )
                return;

            isDisposing = true;
            Console.WriteLine( $"Employee with ID: {Id}, Name: {Name} DISPOSED" );

            // remove the reference of the Destructor method from the call stack of the GarbageCollector
            System.GC.SuppressFinalize( this );
        }

        #endregion

    }
}
