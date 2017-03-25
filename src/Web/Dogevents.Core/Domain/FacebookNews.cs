using System;

namespace Dogevents.Core.Domain
{
    public class Feeds
    {
        public Feed[] data { get; set; }
        public Paging paging { get; set; }
    }

    public class Paging
    {
        public string previous { get; set; }
        public string next { get; set; }
    }

    public class Feed
    {
        public string link { get; set; }
        public string name { get; set; }
        public DateTime created_time { get; set; }
        public DateTime updated_time { get; set; }
        public string id { get; set; }
    }
}