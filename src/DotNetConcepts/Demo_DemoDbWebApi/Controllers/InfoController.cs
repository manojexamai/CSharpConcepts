using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Demo_DemoDbWebApi.Controllers;


[Route("api/[controller]")]
[ApiController]
public class InfoController : ControllerBase
{

    // /api/Info
    // /api/Info/Index
    [HttpGet]
    public IActionResult Index()
    {
        // return new OkResult();
        // return new OkObjectResult("Alter Domus India Pvt. Ltd.");
        return Ok("Alter Domus India Pvt. Ltd.");
    }


    [HttpGet]
    public async Task<IActionResult> IndexAsync()
    {
        var message = await Task<string>.Run(() => "Alter Domus India Pvt. Ltd.");

        return Ok(message);
    }

}
