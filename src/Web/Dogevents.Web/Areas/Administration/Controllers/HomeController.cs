using System.Threading.Tasks;
using Dogevents.Core.Services;
using Microsoft.AspNetCore.Mvc;

namespace Dogevents.Web.Categories.Administration.Controllers
{
    [Area("Administration")]
    public class HomeController : Controller
    {
        private IEventsService _eventsService;
        private IFacebookService _facebookService;


        public HomeController(IEventsService eventsService, IFacebookService facebookService)
        {
            _eventsService = eventsService;
            _facebookService = facebookService;
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

        public async Task<IActionResult> GetEvent(string eventId)
        {
            var @event = await _facebookService.GetEventAsync(eventId);
            return View(@event);
        }
    }
}