var builder = WebApplication.CreateBuilder( args );

// Register the Controllers into Services DI container 
// builder.Services.AddControllers();

builder.Services
    .AddControllers( options =>
    {
        // Respect the Accept header sent by the browser/client
        options.RespectBrowserAcceptHeader = true;

        // Return 406 Not Acceptable if the client requests an unsupported format
        options.ReturnHttpNotAcceptable = true;

    } )
    .AddXmlSerializerFormatters();               // Add support for XML serialization


// Register CORS Policy for the Angular App.
builder.Services.AddCors( options =>
{
    options.AddPolicy( "AllowAngularApp", policy =>
    {
        policy.WithOrigins( "http://localhost:59947" )               // Angular App (NOTE: is running on HTTP not HTTPS)
              .AllowAnyHeader()
              // .WithMethods("POST", "GET")
              .AllowAnyMethod();
    } );
} );

var app = builder.Build();

// Enable auto-redirection to HTTPS protocol
app.UseHttpsRedirection();


// Enable CORS Policy
app.UseCors( "AllowAngularApp" );


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