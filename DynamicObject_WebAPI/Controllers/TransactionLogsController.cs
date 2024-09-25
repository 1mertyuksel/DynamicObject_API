using Microsoft.AspNetCore.Mvc;

namespace DynamicObject_WebAPI.Controllers
{
    public class TransactionLogsController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
