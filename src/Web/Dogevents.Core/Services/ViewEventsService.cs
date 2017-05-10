using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Dogevents.Core.Domain;
using Dogevents.Core.Mongo.Queries;
using MongoDB.Driver;
using MongoDB.Driver.Linq;

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
            var minDate = DateTime.Now.AddDays(-14).Date;

            return _database.Events()
                        .AsQueryable()
                        .Where(_ => _.StartTime <= minDate)
                        .Take(6)
                        .ToListAsync();
        }

        public Task<List<Event>> GetJustAdded()
        {
            return _database.Events()
                                .AsQueryable()
                                .Take(6)
                                .ToListAsync();
        }

        public Task<List<Event>> GetPopular()
        {
            return _database.Events()
                                .AsQueryable()
                                .Sample(6)
                                .ToListAsync();
        }
    }
}