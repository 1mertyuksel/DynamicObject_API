using Microsoft.AspNetCore.Mvc;

namespace DynamicObject_WebAPI.Controllers
{
    public class DynamicObjectsController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
