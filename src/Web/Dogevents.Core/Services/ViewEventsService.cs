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

        public Task<List<T>> GetIncoming<T>() where T : IViewEventModel
        {
            var minDate = DateTime.Now.AddDays(14).Date;

            return _database.Events<T>()
                        .AsQueryable()
                        .Where(_ => _.StartTime >= minDate)
                        .OrderBy(_ => _.StartTime)
                        .Take(6)
                        .ToListAsync();
        }

        public Task<List<T>> GetJustAdded<T>() where T : IViewEventModel
        {
            return _database.Events<T>()
                                .AsQueryable()
                                .Take(6)
                                .ToListAsync();
        }

        public Task<List<T>> GetPopular<T>() where T : IViewEventModel
        {
            return _database.Events<T>()
                                .AsQueryable()
                                .Sample(6)
                                .ToListAsync();
        }
    }
}