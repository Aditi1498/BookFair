using EntityDataModel.Converter;
using EntityDataModel.EntityModel;
using Shared;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Data.DataAccessComponents
{
    public class EventsDAC : DACBase, IEventsDAC
    {
        public EventsDAC()
            : base(DACType.EventsDAC)
        {

        }

        
        //Get all the events
        public List<List<EventsDTO>> GetEvents(int id)
        {
            List<List<Event>> events = new List<List<Event>>();
            List<Event> pastDates = new List<Event>();
            List<Event> futureDates = new List<Event>();
            List<List<EventsDTO>> result = new List<List<EventsDTO>>();
            try
            {
                using (BookContext db = new BookContext())
                {
                    DateTime todaysDate = DateTime.Today;

                    //if user is admin
                    if(id == 1)
                         pastDates = db.Events.Where(e => e.StartDate < todaysDate).ToList();
                    else
                        pastDates = db.Events.Where(e => e.StartDate < todaysDate && e.EventType == "public").ToList();
                    events.Add(pastDates);

                    if(id == 1)
                        futureDates = db.Events.Where(e => e.StartDate >= todaysDate).ToList();
                    else
                        futureDates = db.Events.Where(e => e.StartDate >= todaysDate && e.EventType == "public").ToList();
                    events.Add(futureDates);

                  

                    foreach (var temp in events)
                    {
                        List<EventsDTO> tempResult = new List<EventsDTO>();
                        foreach (var currentTemp in temp)
                        {
                            EventsDTO eventsDTO = new EventsDTO();
                            EntityConverter.FillDTOFromEntity(currentTemp, eventsDTO);

                            tempResult.Add(eventsDTO);
                        }
                        result.Add(tempResult);
                    }
                }
            }
            catch (Exception ex){
                ExceptionManager.HandleException(ex);
                throw new DACException(ex.Message, ex);
            }
            return result;
        }



        //Get Details of the Event
        public EventsDTO GetEventsDetails(int eventId)
        {
            List<Event> eventDetails = new List<Event>();
            EventsDTO result = new EventsDTO();
            try
            {
                using (BookContext db = new BookContext())
                {
                    eventDetails = db.Events.Where(e => e.EventID == eventId).ToList();
                    EntityConverter.FillDTOFromEntity(eventDetails[0], result);
                   
                }
                return result;
            }
            catch(Exception ex)
            {
                ExceptionManager.HandleException(ex);
                throw new DACException(ex.Message, ex);
            }
        }


        //Get events Mad by the User
        /// <summary>
        /// 
        /// </summary>
        /// <param name="UserId"></param>
        /// <returns></returns>
        public List<List<EventsDTO>> GetMyEvents(int UserId)
        {
            List<List<EventsDTO>> myEvents = new List<List<EventsDTO>>();
            List<EventsDTO> pastEvents = new List<EventsDTO>();
            List<EventsDTO> futureEvents = new List<EventsDTO>();
            DateTime todaysDate = DateTime.Today;

            try
            {
                using(BookContext db = new BookContext())
                {
                    var myEventsList = db.Events.Where(e => e.CreatedBy == UserId).ToList();
                    if(myEventsList != null)
                    {
                        foreach(var temp in myEventsList)
                        {
                            var eventDTO = new EventsDTO();
                            EntityConverter.FillDTOFromEntity(temp, eventDTO);
                            if (eventDTO.StartDate < todaysDate)
                                pastEvents.Add(eventDTO);
                            else
                                futureEvents.Add(eventDTO);
                        }
                        myEvents.Add(pastEvents);
                        myEvents.Add(futureEvents);
                    }
                }
            }
            catch (Exception ex)
            {
                ExceptionManager.HandleException(ex);
                throw new DACException(ex.Message, ex);
            }
            return myEvents;
        }


        //Get Events User is Invited to
        public List<List<EventsDTO>> InvitedTo(int UserId)
        {
            List<List<EventsDTO>> myInvites = new List<List<EventsDTO>>();
            List<EventsDTO> pastEvents = new List<EventsDTO>();
            List<EventsDTO> futureEvents = new List<EventsDTO>();
            DateTime todaysDate = DateTime.Today;

            try
            {
                using (BookContext db = new BookContext())
                {
                    var myEvent = from e in db.Events
                                  join m in db.UserEventMappings on e.EventID equals m.EventId
                                  join u in db.Users on m.UserId equals u.UserId
                                  where u.UserId == UserId
                                  select e;
                    if (myEvent != null)
                    {
                        foreach (var temp in myEvent)
                        {
                            EventsDTO eventsDTO = new EventsDTO();
                            EntityConverter.FillDTOFromEntity(temp, eventsDTO);
                            if (eventsDTO.StartDate < todaysDate)
                                pastEvents.Add(eventsDTO);
                            else
                                futureEvents.Add(eventsDTO);
                        }
                        myInvites.Add(pastEvents);
                        myInvites.Add(futureEvents);
                    }
                }
            }
            catch (Exception ex)
            {

                ExceptionManager.HandleException(ex);
                throw new DACException(ex.Message, ex);
            }
            return myInvites;
        }


        //Create a new Event
        public EventsDTO CreateEvents(EventsDTO eventsDTO)
        {
            Event events = new Event();
            try
            {
                using (BookContext db = new BookContext())
                {
                    EntityConverter.FillEntityFromDTO(eventsDTO, events);

                    db.Events.Add(events);
                     //events.EventID
                    db.SaveChanges();
                    EntityConverter.FillDTOFromEntity(events, eventsDTO);
                }

            }
            catch (Exception ex)
            {
                ExceptionManager.HandleException(ex);
                throw new DACException(ex.Message, ex);
            }
            return eventsDTO;
        }


        //Invite People to event
        public bool InvitePeople(int eventId, string invites)
        {

            string[] emails = invites.Split(',');
            UserEventMapping userEventMapping = new UserEventMapping();
            try
            {
                using (BookContext db = new BookContext())
                {

                    foreach(var email in emails)
                    {
                        userEventMapping.User = db.Users.Where(u => u.EmailId == email).SingleOrDefault();
                        userEventMapping.UserId = userEventMapping.User.UserId;
                        userEventMapping.EventId = eventId;
                        db.UserEventMappings.Add(userEventMapping);
                        db.SaveChanges();
                    }
                }

            }
            catch (Exception ex)
            {
                ExceptionManager.HandleException(ex);
                throw new DACException(ex.Message, ex);
            }
            return true;
        }


        //Get event to edit
        public EventsDTO GetEditEvent(int EventId)
        {
            EventsDTO eventsDTO = new EventsDTO();
            try
            {
                using (BookContext db = new BookContext())
                {
                    Event editEvent = db.Events.Where(e => e.EventID == EventId).SingleOrDefault();
                    EntityConverter.FillDTOFromEntity(editEvent, eventsDTO);
                }
            }
            catch (Exception ex)
            {
                ExceptionManager.HandleException(ex);
                throw new DACException(ex.Message, ex);
            }
            return eventsDTO;
        }


        //Edit an event
        public EventsDTO EditEvent(EventsDTO eventsDTO)
        {
            Event @event = new Event();
            try
            {
                using (BookContext db = new BookContext())
                {
                    var editEvent = db.Events.Where(e => e.EventID == eventsDTO.EventID).SingleOrDefault();
                    editEvent.BookTitle = eventsDTO.BookTitle;
                    editEvent.Description = eventsDTO.Description;
                    editEvent.Duration = eventsDTO.Duration;
                    editEvent.EventType = eventsDTO.EventType;
                    editEvent.Location = eventsDTO.Location;
                    editEvent.StartDate = editEvent.StartDate;
                    db.SaveChanges();
                }

            }
            catch (Exception ex)
            {
                ExceptionManager.HandleException(ex);
                throw new DACException(ex.Message, ex);
            }
            return eventsDTO;
        }
    }
}
