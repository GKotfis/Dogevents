using System;
using System.Collections.Generic;

namespace Dogevents.Core.Domain
{
    public class Event
    {
        public long Id { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public DateTime DateStart { get; set; }
        public DateTime DateEnd { get; set; }
        public IEnumerable<string> Categories { get; set; }
    }
}