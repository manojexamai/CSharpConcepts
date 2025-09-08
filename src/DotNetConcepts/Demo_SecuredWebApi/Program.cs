/************************************
    Add the following Nuget Packages:
        Microsoft.AspNetCore.Authentication.JwtBearer
        System.IdentityModel.Tokens.Jwt
******************/

using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.Tokens;
using System.Text;

var builder = WebApplication.CreateBuilder( args );

// Add services to the container.

// Check for JWT configuration
// NOTE: The default Jwt:Key uses the HMAC-SHA256 (HS256) algorithm.
//       Ensure that the Jwt:Key has at least 32 characters (32 bytes = 256 bits).
var jwtKey 
    = builder.Configuration["Jwt:Key"] 
      ?? throw new InvalidOperationException( $"Jwt:Key not configured!!!" );
var jwtIssuer 
    = builder.Configuration["Jwt:Issuer"] 
      ?? throw new InvalidOperationException( $"Jwt:Issuer not configured!!!" );


// Configure JWT authentication
builder.Services
    .AddAuthentication( options =>
    {
        options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
        options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
    } )
    .AddJwtBearer( options =>
    {
        options.TokenValidationParameters = new TokenValidationParameters
        {
            ValidateIssuer = true,
            ValidateAudience = true,
            ValidateLifetime = true,
            ValidateIssuerSigningKey = true,
            ValidIssuer = jwtIssuer,
            ValidAudience = jwtIssuer,
            IssuerSigningKey = new SymmetricSecurityKey( Encoding.UTF8.GetBytes( jwtKey ) )
        };
    } );


// Configure Authorization
builder.Services
    .AddAuthorization();


builder.Services.AddControllers();

// Learn more about configuring OpenAPI at https://aka.ms/aspnet/openapi
builder.Services.AddOpenApi();



var app = builder.Build();


// Configure the HTTP request pipeline.
if ( app.Environment.IsDevelopment() )
{
    app.MapOpenApi();
}

app.UseHttpsRedirection();

// Enable Authentication and Authorization middleware
app.UseAuthentication();
app.UseAuthorization();

app.MapControllers();

app.MapGet( "/", () => "SecuredWebApi started successfully!" );

app.Run();
