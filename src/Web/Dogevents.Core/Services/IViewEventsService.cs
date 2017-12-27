using System.Collections.Generic;
using System.Threading.Tasks;
using Dogevents.Core.Domain;

namespace Dogevents.Core.Services
{
    public interface IViewEventsService
    {
        Task<List<T>> GetPopular<T>() where T : IViewEventModel;

        Task<List<T>> GetIncoming<T>() where T : IViewEventModel;

        Task<List<T>> GetJustAdded<T>() where T : IViewEventModel;
    }
}