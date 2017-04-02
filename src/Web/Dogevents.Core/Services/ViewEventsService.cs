using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Dogevents.Core.Domain;
using Dogevents.Core.Mongo.Queries;
using MongoDB.Driver;

namespace Dogevents.Core.Services
{
    public class ViewEventsService : IViewEventsService
    {
        private readonly IMongoDatabase _database;

        public ViewEventsService(IMongoDatabase database)
        {
            _database = database;
        }

        public Task<List<Event>> GetIncoming()
        {
            return _database.Events().Find(_ => true).Skip(10).Limit(5).ToListAsync();
        }

        public Task<List<Event>> GetJustAdded()
        {
            return _database.Events().Find(_ => true).Skip(15).Limit(5).ToListAsync();
        }

        public Task<List<Event>> GetPopular()
        {
            return _database.Events().Find(_ => true).Limit(5).ToListAsync();
        }
    }
}