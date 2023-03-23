using Api;
using dartwebsite.models;
using Microsoft.AspNetCore.Mvc;

namespace dartwebsite.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult ShowData()
        {
            PlayerViewModel player = new PlayerViewModel() { id = 2, playername = "bert", score=501 };

            return View(player);
        }
    }
}
