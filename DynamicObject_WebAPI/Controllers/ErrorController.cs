using Microsoft.AspNetCore.Diagnostics;
using Microsoft.AspNetCore.Mvc;

namespace DynamicObject_WebAPI.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ErrorController : ControllerBase
    {
        // HTTP POST yöntemi olarak tanımlandı
        [HttpPost("handle-error")] // Örneğin /api/error/handle-error
        public IActionResult HandleError()
        {
            // Genel bir hata mesajı veya özel hata yönetimi
            return Problem("An unexpected error occurred.");
        }
    }
}
