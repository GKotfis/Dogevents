using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Dogevents.Core.Domain;
using Dogevents.Core.Helpers;
using Dogevents.Core.Mongo.Queries;
using MongoDB.Driver;

namespace Dogevents.Core.Services
{
    public class EventsService : IEventsService
    {
        private readonly IMongoDatabase _database;
        private readonly IEventValidator _eventValidator;

        public EventsService(IMongoDatabase database, IEventValidator eventValidator)
        {
            _database = database;
            _eventValidator = eventValidator;
        }

        public Task<List<Event>> GetAll()
        {
            return _database.Events().Find(_ => true).ToListAsync();
        }

        public async Task Add(Event @event)
        {
            if (@event == null || !_eventValidator.IsValid(@event))
                return;

            if (@event.Description.IsEmpty())
                @event.Description = string.Empty;

            await _database.Events().InsertOneAsync(@event);
        }

        public async Task Delete(long eventId)
        {
            await _database.Events().DeleteOneAsync(x => x.Id == eventId);
        }
    }
}