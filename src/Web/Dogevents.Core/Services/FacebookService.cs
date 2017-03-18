using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Dogevents.Core.Domain;

namespace Dogevents.Core.Services
{
    public class FacebookService : IFacebookService
    {
        private readonly IFacebookClient _facebookClient;

        public FacebookService(IFacebookClient facebookClient)
        {
            _facebookClient = facebookClient;
        }

        public async Task<Event> GetEventAsync(string eventId)
        {
            if (string.IsNullOrWhiteSpace(eventId))
                return null;

            var result = await _facebookClient.GetAsync<Event>(eventId, "fields=id,name,description,is_canceled,cover,start_time,end_time,place");

            return result;
        }
    }
}
