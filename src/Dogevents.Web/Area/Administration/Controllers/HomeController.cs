using Microsoft.AspNetCore.Mvc;

namespace Dogevents.Web.Categories.Administration.Controllers
{
    [AreaAttribute("Administration")]
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}