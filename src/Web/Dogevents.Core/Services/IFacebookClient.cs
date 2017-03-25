using System.Threading.Tasks;

namespace Dogevents.Core.Services
{
    public interface IFacebookClient
    {
        Task<T> GetAsync<T>(string endpoint, string args = null);
        Task<T> GetAsync<T>(string url);
    }
}