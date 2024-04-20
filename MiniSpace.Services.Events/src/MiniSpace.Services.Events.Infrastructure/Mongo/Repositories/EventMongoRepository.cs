﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Convey.Persistence.MongoDB;
using MiniSpace.Services.Events.Application.DTO;
using MiniSpace.Services.Events.Application.Wrappers;
using MiniSpace.Services.Events.Core.Entities;
using MiniSpace.Services.Events.Core.Repositories;
using MiniSpace.Services.Events.Infrastructure.Mongo.Documents;
using MongoDB.Driver;
using MongoDB.Driver.Linq;

namespace MiniSpace.Services.Events.Infrastructure.Mongo.Repositories
{
    public class EventMongoRepository : IEventRepository
    {
        private readonly IMongoRepository<EventDocument, Guid> _repository;

        public EventMongoRepository(IMongoRepository<EventDocument, Guid> repository)
        {
            _repository = repository;
        }

        public async Task<Event> GetAsync(Guid id)
        {
            var @event = await _repository.GetAsync(o => o.Id == id);

            return @event?.AsEntity();
        }

        public async Task<IEnumerable<Event>> GetAllAsync()
        {
            var events = _repository.Collection.AsQueryable();
            var filteredEvents = await events.Where(e 
                => e.State == State.ToBePublished || e.State == State.Published).ToListAsync();
            return filteredEvents.Select(e => e.AsEntity());
        }

        public async Task<Tuple<IEnumerable<Event>,int,int,int,int>> BrowseAsync(int pageNumber, int pageSize, string name, string organizer, 
            DateTime dateFrom, DateTime dateTo, IEnumerable<string> sortBy, string direction, State state, 
            IEnumerable<Guid> eventIds = null)
        {
            var filterDefinition = Repositories.Extensions.ToFilterDefinition(name, organizer, dateFrom, dateTo, state, eventIds);
            var sortDefinition = Repositories.Extensions.ToSortDefinition(sortBy, direction);
            
            var pagedEvents = await _repository.Collection.AggregateByPage(
                filterDefinition,
                sortDefinition,
                pageNumber,
                pageSize);
            
            return new Tuple<IEnumerable<Event>,int,int,int,int>(pagedEvents.data.Select(e => e.AsEntity()), 
                pageNumber, pageSize, pagedEvents.totalPages, pagedEvents.totalElements);
        }

        public Task AddAsync(Event @event) => _repository.AddAsync(@event.AsDocument());
        public Task UpdateAsync(Event @event) => _repository.UpdateAsync(@event.AsDocument());
        public Task DeleteAsync(Guid id) => _repository.DeleteAsync(id);
    }
}