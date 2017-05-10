using System;
using Dogevents.Core.Mongo.Queries;
using MongoDB.Driver;

namespace Dogevents.Core.Domain
{
    public interface IEventValidator
    {
        bool IsValid(Event @event);
    }

    public class EventValidator : IEventValidator
    {
        private readonly IMongoDatabase _database;

        public EventValidator(IMongoDatabase database)
        {
            _database = database;
        }

        public bool IsValid(Event @event)
        {
            if (@event == null)
                return false;

            Func<bool> isNotOutdated = () => @event.StartTime >= DateTime.Now.AddDays(-7);
            var eventExist = _database.Events().Find(x => x.Id == @event.Id).AnyAsync();

            return isNotOutdated() && !eventExist.Result;
        }
    }
}