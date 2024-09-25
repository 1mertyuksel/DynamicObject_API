using Microsoft.AspNetCore.Diagnostics;
using Microsoft.AspNetCore.Mvc;

namespace DynamicObject_WebAPI.Controllers
{
    [ApiController]
    public class ErrorController : ControllerBase
    {
        [Route("/error")]
        public IActionResult HandleError()
        {
            // Genel bir hata mesajı veya özel hata yönetimi
            return Problem("An unexpected error occurred.");
        }
    }

}
