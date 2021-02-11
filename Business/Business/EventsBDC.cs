using Shared;
using System;
using System.Collections.Generic;

namespace Business.Business
{
    class EventsBDC : BDCBase, IEventsBDC
    {
        public EventsBDC()
            : base(BDCType.EventsBDC)
        {

        }

        
        //Get Public Events
        public List<List<EventsDTO>> GetEvents(int id)
        {
            IEventsDAC eventsDAC = (IEventsDAC)DACFactory.Instance.Create(DACType.EventsDAC);
            List<List<EventsDTO>> resultEvents = eventsDAC.GetEvents(id);
            return resultEvents;
        }


        //Get Details of Events
        public EventsDTO GetEventsDetails(int EventId)
        {
            IEventsDAC eventsDetails = (IEventsDAC)DACFactory.Instance.Create(DACType.EventsDAC);
            EventsDTO resultEvent = eventsDetails.GetEventsDetails(EventId);
            return resultEvent;
        }


        //Get Events Mad by User
        public List<List<EventsDTO>> GetMyEvents(int UserId)
        {
            IEventsDAC myEvents = (IEventsDAC)DACFactory.Instance.Create(DACType.EventsDAC);
            List<List<EventsDTO>> resultEvents = myEvents.GetMyEvents(UserId);
            return resultEvents;
        }


        //Get Events User is Invited to
        public List<List<EventsDTO>> InvitedTo(int UserId)
        {
            IEventsDAC myInvites = (IEventsDAC)DACFactory.Instance.Create(DACType.EventsDAC);
            List<List<EventsDTO>> resultEvents = myInvites.InvitedTo(UserId);
            return resultEvents;
        }


        //Create a new Event
        public OperationResult<EventsDTO> CreateEvents(EventsDTO eventsDTO)
        {
            OperationResult<EventsDTO> result = null;
            try
            {
                IEventsDAC eventsDAC = (IEventsDAC)DACFactory.Instance.Create(DACType.EventsDAC);
                EventsDTO resultDTO = eventsDAC.CreateEvents(eventsDTO);
                if (resultDTO != null)
                {
                    
                    result = OperationResult<EventsDTO>.CreateSuccessResult(resultDTO);
                }
                else
                {
                    result = OperationResult<EventsDTO>.CreateFailureResult("User With This email address does not exists");
                }
               
            }
            catch (DACException dacEx)
            {
                result = OperationResult<EventsDTO>.CreateErrorResult(dacEx.Message, dacEx.StackTrace);
            }
            catch (Exception e)
            {
                result = OperationResult<EventsDTO>.CreateErrorResult(e.Message, e.StackTrace);
            }
            return result;
        }



       //Invite People to event
        public bool InvitePeople(int eventId, string invites)
        {
            IEventsDAC eventsDAC = (IEventsDAC)DACFactory.Instance.Create(DACType.EventsDAC);
            return eventsDAC.InvitePeople(eventId, invites);

        }


        //Get event to edit
        public EventsDTO GetEditEvent(int EventId)
        {
            IEventsDAC eventsDAC = (IEventsDAC)DACFactory.Instance.Create(DACType.EventsDAC);
            return eventsDAC.GetEditEvent(EventId);
        }


        //Edit an event
        public OperationResult<EventsDTO> EditEvent(EventsDTO eventsDTO)
        {
            OperationResult<EventsDTO> result = null;
            try
            {
                IEventsDAC eventsDAC = (IEventsDAC)DACFactory.Instance.Create(DACType.EventsDAC);
                EventsDTO resultDTO = eventsDAC.EditEvent(eventsDTO);
                if (resultDTO != null)
                {
                   
                    result = OperationResult<EventsDTO>.CreateSuccessResult(resultDTO);
                }
                else
                {
                    result = OperationResult<EventsDTO>.CreateFailureResult("User With This email address does not exists");
                }
                
            }
            catch (DACException dacEx)
            {
                result = OperationResult<EventsDTO>.CreateErrorResult(dacEx.Message, dacEx.StackTrace);
            }
            catch (Exception e)
            {
                result = OperationResult<EventsDTO>.CreateErrorResult(e.Message, e.StackTrace);
            }
            return result;
        }

        
    }
}

