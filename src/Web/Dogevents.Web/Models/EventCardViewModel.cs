using System;
using Dogevents.Core.Domain;
using Newtonsoft.Json;

namespace Dogevents.Web.Models
{
    public class EventCardViewModel : IViewEventModel
    {
        public long Id { get; set; }
        public string Name { get; set; }

        [JsonProperty("start_time")]
        public DateTime StartTime { get; set; }

        [JsonProperty("end_time")]
        public DateTime EndTime { get; set; }

        public string Url { get => $"https://www.facebook.com/events/{Id}/"; }

        public string CoverUrl { get => Cover.source; }

        public Cover Cover { get; set; }
        public Place Place { get; set; }
    }

    public class Cover
    {
        public string source { get; set; }
    }

    public class Owner
    {
        public string Name { get; set; }
    }

    public class Place
    {
        public string Name { get; set; }
        public Location Location { get; set; }
    }

    public class Location
    {
        public string City { get; set; }
        public float Latitude { get; set; }
        public float Longitude { get; set; }
    }
}