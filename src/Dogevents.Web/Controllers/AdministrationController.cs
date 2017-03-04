using Microsoft.AspNetCore.Mvc;

namespace Dogevents.Web.Controllers
{
    public class AdministrationController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult AddEvent()
        {
            return View();
        }
    }
}