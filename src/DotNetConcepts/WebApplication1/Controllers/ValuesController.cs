using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace WebApplication1.Controllers
{
    [Route( "api/[controller]" )]
    [ApiController]
    public class ValuesController : ControllerBase
    {

        public string Get()
        {
            return "Something";
        }

        [HttpGet]
        public string GetSomething ()
        {
           return "Something else";
        }

        [HttpGet("Another")]
        public object GetSomethingElse ()
        {
            return new { Message = "Something different" };
        }

        [HttpGet( nameof(GetDtoExample) )]
        public object GetDtoExample ()
        {
            return new MyResponseDto { 
                Message1 = "Something different",
                Message2 = "Something else"
            };
        }

        [HttpGet( nameof( GetDtoExample ) )]
        public IActionResult GetDtoWithSuccessStatus ()
        {
            var returnedObject = new MyResponseDto
            {
                Message1 = "Something different",
                Message2 = "Something else"
            };

            // HTTP Response Code = 200 "Ok"
            return Ok (returnedObject);
        }

        [HttpGet]
        public IActionResult GetDtoWithNoResponse()
        {
            return NoContent();
        }


        [HttpGet("GetContent")]
        public IActionResult GetGeneratedContent(string name)
        {
            //string output = "<!doctype html>";
            //output += "<html>";
            //output += "<body><h1>" + name + "</h1></body>";
            //output += "</html>";

            System.Text.StringBuilder sb = new System.Text.StringBuilder();
            sb.AppendLine( "<!doctype html>" );
            sb.AppendLine( "<html>" );
            sb.AppendLine( "<body>" );
            sb.AppendLine( $"<h1>{name}</h1>" );
            sb.AppendLine( "</body>" );
            sb.AppendLine( "</html>" );

            this.Response.ContentType = "text/html";
            return Ok( sb.ToString() );
        }
    }


    // DTO: Data Transform Object
    public class MyResponseDto
    {
        public string Message1 = string.Empty;
        public string Message2 { get; set; } = string.Empty;
    }

}
