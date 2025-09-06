var builder = WebApplication.CreateBuilder( args );

// Add services to the container.

const string DatabaseCONNECTION = "ApplicationDbContext";
string connString
    = builder.Configuration.GetConnectionString(DatabaseCONNECTION)
     ?? throw new InvalidOperationException($"Connection string '{DatabaseCONNECTION}' not found.");
builder.Services
    .AddDbContext<ApplicationDbContext>(options =>
    {
        options.UseSqlServer(connString);
    });


builder.Services
    .AddControllers();


// Learn more about configuring OpenAPI at https://aka.ms/aspnet/openapi
builder.Services
    .AddOpenApi();


// Register CORS Policy for the Angular Client App.
builder.Services.AddCors( options =>
{
    options.AddPolicy( "AllowAngularApp", policy =>
    {
        policy.WithOrigins( "http://localhost:60842" )               // Angular App (NOTE: is running on HTTP not HTTPS)
              .AllowAnyHeader()
              // .WithMethods("POST", "GET")
              .AllowAnyMethod();
    } );
} );



var app = builder.Build();



// Configure the HTTP request pipeline.
if ( app.Environment.IsDevelopment() )
{

    // OpenAPI 3.x response schema: https://localhost:7178/openapi/v1.json
    app.MapOpenApi();


    // To access the Swagger UI: https://localhost:7178/swagger/index.html
    // Install Nuget Package: Swashbuckle.AspNetCore.SwaggerUI
    //  Check out: Milan Jovanovic's Youtube video for other alternatives: https://www.youtube.com/watch?v=0qtwYT4n2CM 
    //   and Nick Chapsas
    app.UseSwaggerUI(setupOptions =>
    {
        setupOptions.SwaggerEndpoint( url:"/openapi/v1.json", name:"My DemoDB Web API v1");
    });

}


app.UseHttpsRedirection();

app.UseAuthorization();

// Enable CORS Policy
app.UseCors( "AllowAngularApp" );

app.MapControllers();

app.Run();
