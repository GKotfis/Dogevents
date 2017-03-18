using System.Collections.Generic;
using System.Threading.Tasks;
using Dogevents.Core.Domain;

namespace Dogevents.Core.Services
{
    public interface IEventsService
    {
        Task<List<Event>> GetAll();
        Task Add(Event @event);
        Task Delete(long eventId);
    }
}