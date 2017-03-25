using System;
using System.Collections.Generic;
using System.Threading.Tasks;
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

        public Task<List<Event>> GetAll()
        {
            return _database.Events().Find(_ => true).ToListAsync();
        }

        public async Task Add(Event @event)
        {
            if (@event == null)
                return;

            bool eventExist = await _database.Events().Find(x => x.Id == @event.Id).AnyAsync();

            if (eventExist)
                return;

            await _database.Events().InsertOneAsync(@event);
        }

        public async Task Delete(long eventId)
        {
            await _database.Events().DeleteOneAsync(x => x.Id == eventId);
        }
    }
}