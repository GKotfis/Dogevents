using System;
using System.Collections.Generic;
using Dogevents.Core.Domain;

namespace Dogevents.Core.Services.FakeImplementations
{
    public class EventsService : IEventsService
    {
        public IEnumerable<Event> GetAll()
        {
            Random random = new Random(int.MaxValue);

            yield return new Event
            {
                Id = random.Next(),
                Title = $"Some Event",
                Description = "Lorem ipsum",
                DateStart = DateTime.Now,
                DateEnd = DateTime.Now.AddHours(new Random().Next(1, 10)),
                Categories = new string[] { "Flyball", "Rally-O", "Seminarium" }
            };

            yield return new Event
            {
                Id = random.Next(),
                Title = $"Some Event #2",
                Description = "Lorem ipsum",
                DateStart = DateTime.Now,
                DateEnd = DateTime.Now.AddHours(new Random().Next(1, 10)),
                Categories = new string[] { "Seminarium" }
            };

            yield return new Event
            {
                Id = random.Next(),
                Title = $"Some Event #3",
                Description = "Lorem ipsum",
                DateStart = DateTime.Now,
                DateEnd = DateTime.Now.AddHours(new Random().Next(1, 10)),
                Categories = new string[] { "Rally-O" }
            };
        }
    }
}