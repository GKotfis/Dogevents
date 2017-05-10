using Dogevents.Core.Services;
using Dogevents.Core.Settings;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;
using MongoDB.Driver;

namespace Dogevents.Web.Categories.Administration.Controllers
{
    [Area("Administration")]
    public class HomeController : Controller
    {
        private readonly IEventsService _eventsService;
        private readonly IOptions<DatabaseSettings> _dbSettings;

        public HomeController(IEventsService eventsService, IOptions<DatabaseSettings> dbSettings)
        {
            _eventsService = eventsService;
            _dbSettings = dbSettings;
        }

        public IActionResult Index()
        {
            MongoClientSettings settings = MongoClientSettings.FromUrl(new MongoUrl(_dbSettings.Value.ConnectionString));
            ViewBag.MongoServer = settings.Server.ToString();
            ViewBag.MongoDB = "";

            return View();
        }
    }
}