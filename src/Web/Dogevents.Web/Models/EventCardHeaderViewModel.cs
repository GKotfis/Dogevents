using System;
using Dogevents.Core.Domain;

namespace Dogevents.Web.Models
{
    public class EventCardHeaderViewModel : IViewEventModel
    {
        public long Id { get; set; }
        public string Name { get; set; }
        public DateTime StartTime { get; set; }

        public string Url { get => $"https://www.facebook.com/events/{Id}/"; }
    }
}