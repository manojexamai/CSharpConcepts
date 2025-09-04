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

var app = builder.Build();

// Configure the HTTP request pipeline.
if ( app.Environment.IsDevelopment() )
{
    app.MapOpenApi();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
