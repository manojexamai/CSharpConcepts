var builder = WebApplication.CreateBuilder( args );

// Register the Controllers into Services DI container 
builder.Services.AddControllers();

var app = builder.Build();

// Activate the Controller registration routes.
app.MapControllers();


// Use View > Other Windows > Endpoints Explorer

// Create .http file and define API tests




app.MapGet( "/", () => "Hello world" );

app.MapGet( "/Demo", () =>
{
    string[] arrStrings = ["Hello world", "Another world"];

    return arrStrings;
} );


app.MapGet( "/Employees", () =>
{
    List<Employee> employees = new List<Employee>()
    {
        new Employee { ID = 10, Name = "First Employee"},
        new Employee { ID = 20, Name = "Second Employee"},
        new Employee { ID = 30, Name = "Third Employee"},
    };

    return employees;
} );

app.Run();


class Employee
{
    public int ID { get; set; }
    public string Name { get; set; }
}