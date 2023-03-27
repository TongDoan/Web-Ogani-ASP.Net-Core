using Microsoft.AspNetCore.Mvc;

namespace BTH1.Controllers
{
    public class TestController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
