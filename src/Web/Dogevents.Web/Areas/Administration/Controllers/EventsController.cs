using System.Threading.Tasks;
using Dogevents.Core.Helpers;
using Dogevents.Core.Services;
using Microsoft.AspNetCore.Mvc;

namespace Dogevents.Web.Areas.Administration.Controllers
{
    [Area("Administration")]
    public class EventsController : Controller
    {
        private IEventsService _eventsService;
        private IFacebookService _facebookService;

        public EventsController(IEventsService eventsService, IFacebookService facebookService)
        {
            _eventsService = eventsService;
            _facebookService = facebookService;
        }

        public async Task<IActionResult> Index()
        {
            var dogevents = await _eventsService.GetAll();
            return View(dogevents);
        }

        public async Task<IActionResult> Add(string eventUrl)
        {
            var eventId = UrlParser.GetEventId(eventUrl);

            await _facebookService.GetEventAsync(eventId)
                                .ContinueWith(@event => _eventsService.Add(@event.Result));

            return RedirectToAction("Index");
        }

        public async Task<IActionResult> Delete(long id)
        {
            await _eventsService.Delete(id);
            return RedirectToAction("Index");
        }
    }
}