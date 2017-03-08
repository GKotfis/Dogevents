using Dogevents.Core.Services;
using Microsoft.AspNetCore.Mvc;

namespace Dogevents.Web.Categories.Administration.Controllers
{
    [Area("Administration")]
    public class HomeController : Controller
    {
        private IEventsService _eventsService;

        public HomeController(IEventsService eventsService)
        {
            _eventsService = eventsService;
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Events()
        {
            var dogevents = _eventsService.GetAll();
            return View(dogevents);
        }
    }
}