using System.Linq;
using System.Threading.Tasks;
using Dogevents.Core.Domain;
using MongoDB.Driver;
using MongoDB.Driver.Linq;

namespace Dogevents.Core.Mongo.Queries
{
    public static class EventsQueries
    {
        public static IMongoCollection<Event> Events(this IMongoDatabase database) =>
            database.GetCollection<Event>("Events");

        public static IMongoCollection<T> Events<T>(this IMongoDatabase database) =>
            database.GetCollection<T>("Events");

        public static async Task<Event> GetByIdAsync(this IMongoCollection<Event> events, long id)
        {
            return await events.AsQueryable().FirstOrDefaultAsync(x => x.Id == id);
        }
    }
}