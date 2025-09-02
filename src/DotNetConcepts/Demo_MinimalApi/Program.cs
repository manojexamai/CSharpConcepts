// Created using ASP.NET CORE EMPTY PROJECT TEMPLATE

var builder = WebApplication.CreateBuilder( args );
var app = builder.Build();

app.MapGet( "/", () => "Hello World!" );

app.MapGet( "/Birds", () =>
{
    // return new string[3] { "Eagle", "Sparrow", "Crow" };

    return new string[3] { "Eagle", "Sparrow", "Crow" };
} );

app.MapGet( "/api/Employees", () =>
{
    List<Employee> employees = new List<Employee>
    {
        new Employee { Id = 1, Name = "First Employee" },
        new Employee { Id = 2, Name = "Second Employee" }
    };

    return employees;
} );

app.Run();



class Employee
{
    public int Id { get; set; }

    public string Name { get; set; } = string.Empty;
}