using Microsoft.AspNetCore.Mvc;

namespace dartwebsite.Controllers
{
    public class EmailController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
