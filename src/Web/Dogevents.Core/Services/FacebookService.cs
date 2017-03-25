using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Dogevents.Core.Domain;
using Dogevents.Core.Helpers;

namespace Dogevents.Core.Services
{
    public class FacebookService : IFacebookService
    {
        private readonly string groupId = "410345642430814"; //move to configuration or some provider

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

        public async Task<IEnumerable<Feed>> GetFeeds(DateTime since)
        {
            var dateFormat = "yyyy-MM-dd";
            var sinceFormat = since != null ? since.ToString(dateFormat) : DateTime.Now.ToString(dateFormat);
            var endpoint = $"{groupId}/feed";

            var feeds = await _facebookClient.GetAsync<Feeds>(endpoint, $"fields=link,name,created_time,updated_time&since={sinceFormat}");

            if (feeds == null || !feeds.data.IsAny())
                return Enumerable.Empty<Feed>();

            List<Feed> result = new List<Feed>();

            result.AddRange(feeds.data);

            var nextUrl = feeds.paging?.next;

            while (nextUrl.IsNotEmpty())
            {
                var nextFeeds = await GetFeeds(nextUrl);
                nextUrl = nextFeeds.Item1;
                result.AddRange(nextFeeds.Item2);
            }

            return result;
        }

        private async Task<Tuple<string, IEnumerable<Feed>>> GetFeeds(string currentUrl)
        {
            var feeds = await _facebookClient.GetAsync<Feeds>(currentUrl);
            return new Tuple<string, IEnumerable<Feed>>(feeds.paging?.next, feeds.data ?? Enumerable.Empty<Feed>());
        }
    }
}