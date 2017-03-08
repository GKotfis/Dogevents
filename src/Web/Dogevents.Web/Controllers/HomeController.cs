using Microsoft.AspNetCore.Mvc;

namespace Dogevents.Web.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}