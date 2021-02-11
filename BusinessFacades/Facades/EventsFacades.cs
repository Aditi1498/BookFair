using Shared;
using System.Collections.Generic;

namespace BusinessFacades.Facades
{
    public class EventsFacades :FacadeBase,IEventsFacade
    {
        public EventsFacades()
               : base(FacadeType.EventsFacade)
        {

        }

       

        public List<List<EventsDTO>> getEvents(int id)
        {
            IEventsBDC eventsBDC = (IEventsBDC)BDCFactory.Instance.Create(BDCType.EventsBDC);
            return eventsBDC.GetEvents(id);
        }

       

        public EventsDTO GetEventsDetails(int EventId)
        {
            IEventsBDC eventsDetailsBDC = (IEventsBDC)BDCFactory.Instance.Create(BDCType.EventsBDC);
            return eventsDetailsBDC.GetEventsDetails(EventId);
        }


        public List<List<EventsDTO>> GetMyEvents(int UserId)
        {
            IEventsBDC myEventsBDC = (IEventsBDC)BDCFactory.Instance.Create(BDCType.EventsBDC);
            return myEventsBDC.GetMyEvents(UserId);
        }


        public List<List<EventsDTO>> InvitedTo(int UserId)
        {
            IEventsBDC myInivitesBDC = (IEventsBDC)BDCFactory.Instance.Create(BDCType.EventsBDC);
            return myInivitesBDC.InvitedTo(UserId);
        }


        public OperationResult<EventsDTO> CreateEvents(EventsDTO eventsDTO)
        {
            IEventsBDC createEventsBDC = (IEventsBDC)BDCFactory.Instance.Create(BDCType.EventsBDC);
            return createEventsBDC.CreateEvents(eventsDTO);
        }


        public bool InvitePeople(int eventId, string invites)
        {
            IEventsBDC invitesBDC = (IEventsBDC)BDCFactory.Instance.Create(BDCType.EventsBDC);
            return invitesBDC.InvitePeople(eventId, invites);
        }


        public EventsDTO GetEditEvent(int EventId)
        {
            IEventsBDC invitesBDC = (IEventsBDC)BDCFactory.Instance.Create(BDCType.EventsBDC);
            return invitesBDC.GetEditEvent(EventId);
        }


        public OperationResult<EventsDTO> EditEvent(EventsDTO eventsDTO)
        {
            IEventsBDC invitesBDC = (IEventsBDC)BDCFactory.Instance.Create(BDCType.EventsBDC);
            return invitesBDC.EditEvent(eventsDTO);
        }
    }
}
