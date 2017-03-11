using System;

namespace Dogevents.Core.Domain.Facebook
{
    public class Event
    {
        public Cover cover { get; set; }
        public int declined_count { get; set; }
        public int attending_count { get; set; }
        public bool can_guests_invite { get; set; }
        public string description { get; set; }
        public DateTime end_time { get; set; }
        public bool guest_list_enabled { get; set; }
        public string id { get; set; }
        public int interested_count { get; set; }
        public bool is_canceled { get; set; }
        public string name { get; set; }
        public Owner owner { get; set; }
        public Place place { get; set; }
        public DateTime start_time { get; set; }
        public string type { get; set; }
    }
}