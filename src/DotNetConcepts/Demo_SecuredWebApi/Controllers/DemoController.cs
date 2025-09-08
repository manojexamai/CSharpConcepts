using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Demo_SecuredWebApi.Controllers;



[Route( "api/[controller]" )]
[ApiController]
public class DemoController : ControllerBase
{

    // GET /api/demo/public                       // no JWT token required
    [HttpGet( "public" )]
    public IActionResult PublicEndpoint () 
        => Ok( "This is a public api endpoint" );


    // GET /api/demo/private                      // requires the header token "Authorization: Bearer <token>"
    [Authorize]
    [HttpGet( "private" )]
    public IActionResult PrivateEndpoint () 
        => Ok( "This is a protected api endpoint - log in to access" );


    // GET /api/demo/private4admin
    [Authorize(Roles = "SuperUser" )]
    [HttpGet( "private4Admin" )]
    public IActionResult Private4AdminEndpoint ()
        => Ok( "This is a protected api endpoint accessible only to SuperUser" );


    // GET /api/demo/private4user
    [Authorize( Roles = "SuperUser,User" )]
    [HttpGet( "private4User" )]
    public IActionResult Private4UserEndpoint ()
        => Ok( "This is a protected api endpoint accessible to any User" );


    // GET /api/demo/checkmyrole
    [Authorize]
    [HttpGet("CheckMyRole")]
    public IActionResult CheckMyRole ()
    {
        if ( User.IsInRole( "SuperUser" ) )
        {
            return Ok( "You are a super user " );
        }

        return Ok( "You are a regular user" );
    }

}
