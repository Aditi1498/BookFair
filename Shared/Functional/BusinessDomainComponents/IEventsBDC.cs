﻿using System.Collections.Generic;

namespace Shared
{
    public interface IEventsBDC : IBusinessDomainComponent
    {
        List<List<EventsDTO>> GetEvents(int id);

        EventsDTO GetEventsDetails(int EventId);

        List<List<EventsDTO>> GetMyEvents(int UserId);

        List<List<EventsDTO>> InvitedTo(int UserId);

        OperationResult<EventsDTO> CreateEvents(EventsDTO eventsDTO);

        bool InvitePeople(int eventId, string invites);

        EventsDTO GetEditEvent(int EventId);

        OperationResult<EventsDTO> EditEvent(EventsDTO eventsDTO);


    }
}