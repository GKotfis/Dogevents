using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Dogevents.Core.Domain;
using Dogevents.Core.Helpers;
using Dogevents.Core.Services;
using Microsoft.AspNetCore.Mvc;

namespace Dogevents.Web.Areas.Administration.Controllers
{
    [Area("Administration")]
    public class FetchingController : Controller
    {
        private IEventsService _eventsService;
        private IFacebookService _facebookService;

        public FetchingController(IEventsService eventsService, IFacebookService facebookService)
        {
            _eventsService = eventsService;
            _facebookService = facebookService;
        }

        public IActionResult Index(IEnumerable<Feed> feeds)
        {
            return View(feeds);
        }

        public async Task<IActionResult> Fetch(DateTime since)
        {
            var feeds = await _facebookService.GetFeeds(since);
            return View("Index", feeds);
        }

        public async Task<IActionResult> AddFeeds(string[] feedLinks)
        {
            foreach (var link in feedLinks)
            {
                if (link.IsEmpty())
                {
                    //mark as wrong link, save somewhere, do something with that
                }

                var eventId = UrlParser.GetEventId(link);

                if (eventId.IsEmpty())
                {
                    //same as above ...
                    continue;
                }

                try
                {
                    var @event = await _facebookService.GetEventAsync(eventId);
                    await _eventsService.Add(@event);

                }
                catch (Exception)
                {
                    throw;
                }
            }

            return RedirectToAction("Index", "Events");
        }
    }
}
