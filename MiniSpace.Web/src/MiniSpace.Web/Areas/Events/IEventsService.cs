﻿using System;
using System.Collections;
using System.Collections.Generic;
using System.Threading.Tasks;
using MiniSpace.Web.DTO;
using MiniSpace.Web.DTO.Wrappers;
using MiniSpace.Web.HttpClients;

namespace MiniSpace.Web.Areas.Events
{
    public interface IEventsService
    {
        Task<EventDto> GetEventAsync(Guid eventId);
        Task<PagedResponseDto<IEnumerable<EventDto>>> GetStudentEventsAsync(Guid studentId,
            string engagementType, int page, int numberOfResults);
        Task<HttpResponse<object>> CreateEventAsync(Guid eventId, string name, Guid organizerId, Guid organizationId,
            Guid rootOrganizationId, string startDate, string endDate, string buildingName, string street,
            string buildingNumber, string apartmentNumber, string city, string zipCode, IEnumerable<Guid> mediaFiles,
            string description, int capacity, decimal fee, string category, string publishDate);
        Task<HttpResponse<object>> UpdateEventAsync(Guid eventId, string name, Guid organizerId,
            string startDate, string endDate, string buildingName, string street, string buildingNumber,
            string apartmentNumber, string city, string zipCode, IEnumerable<Guid> mediaFiles, string description,
            int capacity, decimal fee, string category, string publishDate);
        Task DeleteEventAsync(Guid eventId);
        Task SignUpToEventAsync(Guid eventId, Guid studentId);
        Task CancelSignUpToEventAsync(Guid eventId, Guid studentId);
        Task ShowInterestInEventAsync(Guid eventId, Guid studentId);
        Task CancelInterestInEventAsync(Guid eventId, Guid studentId);
        Task RateEventAsync(Guid eventId, int rating, Guid studentId);
        Task<HttpResponse<PagedResponseDto<IEnumerable<EventDto>>>> SearchEventsAsync(string name, string organizer, 
            Guid organizationId, Guid rootOrganizationId, string category, string state, IEnumerable<Guid> friends,
            string friendsEngagementType, string dateFrom, string dateTo, PageableDto pageable);
        Task<HttpResponse<PagedResponseDto<IEnumerable<EventDto>>>> SearchOrganizerEventsAsync(Guid organizerId,
            string name, string state, string dateFrom, string dateTo, PageableDto pageable);
        Task<EventParticipantsDto> GetEventParticipants(Guid eventId);
        Task AddEventParticipant(Guid eventId, Guid studentId, string studentName);
        Task RemoveEventParticipant(Guid eventId, Guid participantId);
    }
}