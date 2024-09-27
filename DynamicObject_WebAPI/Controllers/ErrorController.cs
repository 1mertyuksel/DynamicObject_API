using Microsoft.AspNetCore.Diagnostics;
using Microsoft.AspNetCore.Mvc;

namespace DynamicObject_WebAPI.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ErrorController : ControllerBase
    {
        [HttpPost("handle-error")] 
        public IActionResult HandleError()
        {
            
            return Problem("An unexpected error occurred.");
        }
    }
}
