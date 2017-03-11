using System;
using System.Collections.Generic;

namespace Dogevents.Core.Domain
{
    public class Event
    {
        public long Id { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public DateTime TimeStart { get; set; }
        public DateTime TimeEnd { get; set; }
        public string Url { get; set; }
        public string ImageUrl { get; set; }
        public IEnumerable<string> Categories { get; set; }
    }
}