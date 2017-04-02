using System.Collections.Generic;
using System.Threading.Tasks;
using Dogevents.Core.Domain;
using Dogevents.Core.Services;
using Microsoft.AspNetCore.Mvc;

namespace Dogevents.Web.Controllers
{
    [Route("api/[controller]")]
    public class ViewEventsController : Controller
    {
        private IViewEventsService _viewEventService;

        public ViewEventsController(IViewEventsService popularEventService)
        {
            _viewEventService = popularEventService;
        }

        [HttpGet]
        [Route("GetPopular")]
        public async Task<IEnumerable<Event>> GetPopular()
        {
            return await _viewEventService.GetPopular();
        }

        [HttpGet]
        [Route("GetIncoming")]
        public async Task<IEnumerable<Event>> GetIncoming()
        {
            return await _viewEventService.GetIncoming();
        }

        [HttpGet]
        [Route("GetJustAdded")]
        public async Task<IEnumerable<Event>> GetJustAdded()
        {
            return await _viewEventService.GetJustAdded();
        }
    }
}