using System.Collections.Generic;
using System.Linq;
using Dogevents.Core.Domain;
using Dogevents.Core.Mongo.Queries;
using MongoDB.Driver;

namespace Dogevents.Core.Services
{
    public class EventsService : IEventsService
    {
        private readonly IMongoDatabase _database;

        public EventsService(IMongoDatabase database)
        {
            _database = database;
        }

        public IEnumerable<Event> GetAll()
        {
            return _database.Events().Find(_ => true).ToList();
        }
    }
}