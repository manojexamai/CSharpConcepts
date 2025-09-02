using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace WebApplication1.Controllers
{
    [Route( "api/[controller]" )]
    [ApiController]
    public class MyDemoController : ControllerBase
    {

        private readonly ILogger<MyDemoController> _logger;

        public MyDemoController (ILogger<MyDemoController> logger)
        {
            _logger = logger;
        }


        // https://localhost:7160/api/MyDemo
        [HttpGet("GetSomething")]
        public IActionResult GetSomething ()
        {
            _logger.LogInformation( "GetSomething was called" );
            return Ok("hello world");

        }


        // https://localhost:7160/api/MyDemo/GetSomethingElse?message=My%20Demo
        // https://localhost:7160/api/MyDemo/GetSomethingElse?message=My+Demo
        [HttpGet( "GetSomethingElse" )]
        public IActionResult GetSomething (string message)
        {
            _logger.LogInformation( "GetSomething was called" );
            return Ok( "hello world" );

        }

    }
}
