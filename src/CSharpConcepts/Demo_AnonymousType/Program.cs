namespace Demo_AnonymousType
{
    internal class Program
    {
        static void Main ( string[] args )
        {

            Employee emp1 = new Employee();
            emp1.ID = 1;
            emp1.Name = "First Employee";
            Console.WriteLine( "ID: {0}, Name: {1}", emp1.ID, emp1.Name );
            Console.WriteLine( "Type: {0}", emp1.GetType() );
            Console.WriteLine();

            // Collection Initializer
            int[] arr = new int[5] { 1, 2, 3, 4, 5 };

            // Property Initializers
            Employee emp2 = new Employee() { ID = 2, Name = "Second Employee" };
            Console.WriteLine( "ID: {0}, Name: {1}", emp2.ID, emp2.Name );
            Console.WriteLine( "Type: {0}", emp2.GetType() );
            Console.WriteLine();

            var emp3 = new Employee() { ID = 3, Name = "Third Employee" };
            Console.WriteLine( "ID: {0}, Name: {1}", emp3.ID, emp3.Name );
            Console.WriteLine( "Type: {0}", emp3.GetType() );
            Console.WriteLine();

            Employee emp4 = new() { ID = 4, Name = "Fourth Employee" };
            Console.WriteLine( "ID: {0}, Name: {1}", emp4.ID, emp4.Name );
            Console.WriteLine( "Type: {0}", emp4.GetType() );
            Console.WriteLine();


            // Anonymous Type
            var obj1 = new { ID = 5, Name = "Fifth Employee" };
            Console.WriteLine( "ID: {0}, Name: {1}", obj1.ID, obj1.Name );
            Console.WriteLine( "Type: {0}", obj1.GetType() );
            Console.WriteLine();



            emp3.Name = emp3.Name.ToUpper();
            Console.WriteLine( "ID: {0}, Name: {1}", emp3.ID, emp3.Name );
            Console.WriteLine();

            // obj1.Name = obj1.Name.ToUpper();          // not possible. All Properties are READONLY


            var obj2 = new { ID = 5, Name = "Another Employee" };
            Console.WriteLine( "ID: {0}, Name: {1}", obj2.ID, obj2.Name );
            Console.WriteLine( "Type: {0}", obj2.GetType() );
            Console.WriteLine();

            var obj3 = new { Name = "Another Employee", ID = 5 };
            Console.WriteLine( "ID: {0}, Name: {1}", obj3.ID, obj3.Name );
            Console.WriteLine( "Type: {0}", obj3.GetType() );
            Console.WriteLine();

            var obj4 = new { Id = 5, Name = "Another Employee" };
            Console.WriteLine( "ID: {0}, Name: {1}", obj4.Id, obj4.Name );
            Console.WriteLine( "Type: {0}", obj4.GetType() );
            Console.WriteLine();
        }
    }


    class Employee
    {
        public int ID { get; set; }
        public string Name { get; set; }
    }
}
