﻿using System;
using Convey.CQRS.Commands;
using MiniSpace.Services.Events.Core.Entities;

namespace MiniSpace.Services.Events.Application.Commands
{
    public class AddEvent : ICommand
    {
        public Guid EventId { get; }
        public string Name { get; }
        public Guid OrganizerId { get; }
        public Guid OrganizationId { get; }
        public Guid RootOrganizationId { get; }
        public string StartDate { get; }
        public string EndDate { get; }
        public string BuildingName { get; }
        public string Street { get; }
        public string BuildingNumber { get; }
        public string ApartmentNumber { get; }
        public string City { get; }
        public string ZipCode { get; }
        public string Description { get; }
        public int Capacity { get; }
        public decimal Fee { get; }
        public string Category { get; }
        public string PublishDate { get; }

        public AddEvent(Guid eventId, string name, Guid organizerId, Guid organizationId, Guid rootOrganizationId,
            string startDate, string endDate, string buildingName, string street, string buildingNumber,
            string apartmentNumber, string city, string zipCode, string description, int capacity, decimal fee, 
            string category, string publishDate)
        {
            EventId = eventId == Guid.Empty ? Guid.NewGuid() : eventId;
            Name = name;
            OrganizerId = organizerId;
            OrganizationId = organizationId;
            RootOrganizationId = rootOrganizationId;
            StartDate = startDate;
            EndDate = endDate;
            BuildingName = buildingName;
            Street = street;
            BuildingNumber = buildingNumber;
            ApartmentNumber = apartmentNumber;
            City = city;
            ZipCode = zipCode;
            Description = description;
            Capacity = capacity;
            Fee = fee;
            Category = category;
            PublishDate = publishDate;
        }
    }
}