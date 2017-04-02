using System.Collections.Generic;
using System.Threading.Tasks;
using Dogevents.Core.Domain;

namespace Dogevents.Core.Services
{
    public interface IViewEventsService
    {
        Task<List<Event>> GetPopular();
        Task<List<Event>> GetIncoming();
        Task<List<Event>> GetJustAdded();


    }
}