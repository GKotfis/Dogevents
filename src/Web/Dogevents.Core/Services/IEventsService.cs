using System.Collections.Generic;
using Dogevents.Core.Domain;

namespace Dogevents.Core.Services
{
    public interface IEventsService
    {
        IEnumerable<Event> GetAll();
    }
}