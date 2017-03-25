using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Dogevents.Core.Domain;

namespace Dogevents.Core.Services
{
    public interface IFacebookService
    {
        Task<Event> GetEventAsync(string eventId);
        Task<IEnumerable<Feed>> GetFeeds(DateTime since);
    }
}
