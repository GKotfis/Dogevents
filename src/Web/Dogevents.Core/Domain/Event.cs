using System;
using System.Collections.Generic;
using MongoDB.Bson.Serialization.Attributes;
using Newtonsoft.Json;

namespace Dogevents.Core.Domain
{
    public class Event
    {
        [BsonId]
        public long Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }

        [JsonProperty("start_time")]
        public DateTime StartTime { get; set; }

        [JsonProperty("end_time")]
        public DateTime EndTime { get; set; }

        [BsonIgnore]
        public string Url { get => $"https://www.facebook.com/events/{Id}/"; }

        public string CoverUrl { get => Cover.source; }

        [JsonProperty("is_canceled")]
        public bool IsCanceled { get; set; }

        public Cover Cover { get; set; }
        public Owner Owner { get; set; }
        public Place Place { get; set; }
        public IEnumerable<string> Categories { get; set; }
    }

    public class Cover
    {
        public int offset_x { get; set; }
        public int offset_y { get; set; }
        public string source { get; set; }
        public string id { get; set; }
    }

    public class Owner
    {
        public string Id { get; set; }
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
        public string Country { get; set; }
        public float Latitude { get; set; }
        public float Longitude { get; set; }
        public string Street { get; set; }
        public string Zip { get; set; }
    }
}