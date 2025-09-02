using System.Diagnostics;

int[] arr = [ 19, 21, 77, 45, 52, 81, 99, 100, 86, 42, 15, 16, 35, 30, 25, 18, 26, 11, 43, 73 ];

// between 25 and 79

Console.WriteLine( "---- output from for loop and filtering" );
for( int i = 0 ; i < arr.Length ; i++ )
{
    if( arr[i] > 24 && arr[i] < 80 )
    {
        Console.Write( "{0} ", arr[i] );
    }
}
Console.WriteLine();


Console.WriteLine();
Console.WriteLine( "---- output from foreach loop after cloning and sorting and filtering with early exit" );

int[]? arrClone = arr.Clone() as int[];
if(arrClone is not null)
{
    Array.Sort( arrClone );

    foreach(int i in arrClone )
    {
        if (i > 24 && i < 80 )
        {
            Console.Write( "{0} ", i );
        }
        else if (i >= 80 )
        {
            break;
        }
    }
    Console.WriteLine();
}

Console.WriteLine();
Console.WriteLine( "---- output from foreach loop after cloning, sorting, reversing and filtering with early exit" );

System.Diagnostics.Stopwatch sw = new System.Diagnostics.Stopwatch();

sw.Start();

arrClone = arr.Clone() as int[];
if ( arrClone is not null )
{
    Array.Sort( arrClone );
    arrClone = arrClone.Reverse().ToArray();

    foreach ( int i in arrClone )
    {
        if ( i > 24 && i < 80 )
        {
            Console.Write( "{0} ", i );
        }
        else if ( i < 25 )
        {
            break;
        }
    }
    Console.WriteLine();
}

sw.Stop();
Console.WriteLine( "Elapsed Time: {0} milliseconds ({1} ticks)", sw.ElapsedMilliseconds, sw.ElapsedTicks );


//foreach ( int i in arr )
//{
//    if ( i > 24 && i < 80 )
//    {
//        Console.Write( "{0} ", i );
//    }
//}

// LINQ: Language INtegrated Query
Console.WriteLine();
Console.WriteLine( "Demo of LINQ" );
IEnumerable<int>? query1 = from i in arr
                           select i;
foreach ( int i in query1 )
{
    Console.Write( "{0} ", i );
}


Console.WriteLine();
Console.WriteLine( "Demo of LINQ - with FILTER" );
var query2 = from i in arr
             where i > 24 && i < 80
             select i;
foreach ( int i in query2 )
{
    Console.Write( "{0} ", i );
}

Console.WriteLine();
Console.WriteLine( "Demo of LINQ - with FILTER, SORTED" );

sw.Restart();

var query3 = from i in arr
             orderby i descending
             where i > 24 && i < 80
             select i;
foreach ( int i in query3 )         // query3.GetEnumerator() invokes the clone, sort, reversing, filtering
{
    Console.Write( "{0} ", i );
}
Console.WriteLine();
sw.Stop();
Console.WriteLine( "Elapsed Time: {0} milliseconds ({1} ticks)", sw.ElapsedMilliseconds, sw.ElapsedTicks );


// Lambda Version with Chained Calls
sw.Restart();
var query4 = arr.Where( i => i > 24 && i < 80 )
                .OrderByDescending( i => i )
                .ToArray();
foreach ( int i in query4 )
{
    Console.Write( "{0} ", i );
}
Console.WriteLine();
sw.Stop();
Console.WriteLine( "Elapsed Time: {0} milliseconds ({1} ticks)", sw.ElapsedMilliseconds, sw.ElapsedTicks );

Console.WriteLine();

List<Employee> employees = new List<Employee>()
{
    new Employee { Id = 3, Name = "Third Employee", Salary = 2000.00M }
    , new Employee { Id = 1, Name = "First Employee", Salary = 200.00M }
    , new Employee { Id = 2, Name = "Second Employee", Salary = 225000.00M }
    , new Employee { Id = 5, Name = "Fifth Employee", Salary = 1000.00M }
    , new Employee { Id = 4, Name = "Fourth Employee", Salary = 2000.75M }
    , new Employee { Id = 6, Name = "Sixth Employee", Salary = 20.81M }
};

foreach( Employee emp in employees )
{
    Console.WriteLine( $"{emp.Id} {emp.Name, -25} {emp.Salary, 20:C}" );
}

Console.WriteLine( "-- after sorting using IComparable implementation" );
employees.Sort();

foreach ( Employee emp in employees )
{
    Console.WriteLine( $"{emp.Id} {emp.Name,-25} {emp.Salary,20:C}" );
}

Console.WriteLine( "-- after sorting using LINQ" );
var empQuery = from emp in employees
               orderby emp.Name descending
               select emp;
foreach ( Employee emp in empQuery )
{
    Console.WriteLine( $"{emp.Id} {emp.Name,-25} {emp.Salary,20:C}" );
}

// PROJECTION (project the selected object into another object (in this case an Anonymous Object)
Console.WriteLine( "Demo of LINQ with PROJECTION" );
var empQuery2 = from emp in employees
               orderby emp.Name descending
               select new
               {
                   EmpId = emp.Id,
                   EmployeeName = emp.Name,
                   EmpSalary = emp.Salary,
                   Bonus = emp.Salary * 0.10M
               };
foreach ( var emp in empQuery2 )
{
    Console.WriteLine( $"{emp.EmpId} {emp.EmployeeName,-25} {emp.EmpSalary,20:C} {emp.Bonus,20:C}" );
}


var empQuery3 = from emp in empQuery2
                where emp.EmpSalary > 1000M
                select emp;

class Employee : IComparable
{
    public int Id { get; set; }

    public string Name { get; set; } = string.Empty;

    // public string? Name { get; set; }

    public decimal Salary { get; set; }

    #region IComparable members

    public int CompareTo ( object? obj )
    {
        Employee? otherEmployee = obj as Employee;
        if(otherEmployee is not null )
        {
            return this.Id.CompareTo( otherEmployee.Id );
        }

        throw new InvalidCastException( "The object being compared is not an Employee" );
    }

    #endregion
}