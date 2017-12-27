using System.Collections.Generic;
using System.Threading.Tasks;
using Dogevents.Core.Domain;
using Dogevents.Core.Services;
using Dogevents.Web.Models;
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
        public async Task<IEnumerable<EventCardViewModel>> GetPopular()
        {
            return await _viewEventService.GetPopular<EventCardViewModel>();
        }

        [HttpGet]
        [Route("GetIncoming")]
        public async Task<IEnumerable<EventCardViewModel>> GetIncoming()
        {
            return await _viewEventService.GetIncoming<EventCardViewModel>();
        }

        [HttpGet]
        [Route("GetJustAdded")]
        public async Task<IEnumerable<EventCardViewModel>> GetJustAdded()
        {
            return await _viewEventService.GetJustAdded<EventCardViewModel>();
        }
    }
}