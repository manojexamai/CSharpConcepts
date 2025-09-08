using Demo_SecuredWebApi.DtoModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;


namespace Demo_SecuredWebApi.Controllers;


[Route( "api/[controller]" )]
[ApiController]
public class AuthController : ControllerBase
{

    private readonly IConfiguration _config;


    public AuthController ( IConfiguration config )
    {
        _config = config;
    }


    // POST /api/auth/login             // to get the JWT ( check at https://jwt.io )
    [HttpPost( "login" )]
    public IActionResult Login ( [FromBody] LoginRequestDto login )
    {
        //TODO: In production, validate against a DB or Identity
        if ( (login.Username == "admin" || login.Username == "user" ) 
             && login.Password == "password" )
        {
            var token = GenerateJwtToken( login.Username );
            return Ok( new LoginResponseDto { Token = token } );
        }
        return Unauthorized();
    }


    #region Helper Methods

    private string GenerateJwtToken ( string username )
    {
        var securityKey = new SymmetricSecurityKey( Encoding.UTF8.GetBytes( _config["Jwt:Key"]! ) );
        var credentials = new SigningCredentials( securityKey, SecurityAlgorithms.HmacSha256 );

        var roles = username == "admin" 
                    ? new[] { "SuperUser", "User" }
                    : new[] { "User" };

        var claims = new List<Claim>
        {
            new Claim(ClaimTypes.Name, username),
        };

        // Add the roles
        claims.AddRange( roles.Select( r => new Claim( ClaimTypes.Role, r) ) );

        var token = new JwtSecurityToken(
            issuer: _config["Jwt:Issuer"],
            audience: _config["Jwt:Issuer"],
            claims: claims,
            expires: DateTime.Now.AddMinutes( 5 ),
            signingCredentials: credentials 
        );

        return new JwtSecurityTokenHandler().WriteToken( token );
    }

    #endregion

}
