using System.Collections.Generic;
using System.Web.Mvc;
using Shared;
using BookEvent.Models;

namespace BookEvent.Controllers
{

    [Authorize]
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }

        //Home page Events List:-
        [AllowAnonymous]
        public ActionResult EventsList()
        {
            //EventsDTO events = new EventsDTO();
            IEventsFacade eventsFacade = (IEventsFacade)FacadeFactory.Instance.Create(FacadeType.EventsFacade);
            List<List<EventsDTO>> result = new List<List<EventsDTO>>();
            if (Session["UserId"] != null)
                result = eventsFacade.getEvents((int)Session["UserId"]);
            else
                result = eventsFacade.getEvents(0);
            return View(result);
        }


       //Get Event's Details:-
        public ActionResult EventDetails(int EventId)
        {
            IEventsFacade eventsFacade = (IEventsFacade)FacadeFactory.Instance.Create(FacadeType.EventsFacade);
            EventsDTO result = eventsFacade.GetEventsDetails(EventId);

            Event eventDetail = new Event();
            ModelConverter.ModelConverter.FillModelFromDTO(result, eventDetail);

            //to diaplay all comments:-
            ICommentsFacade commentsFacade = (ICommentsFacade)FacadeFactory.Instance.Create(FacadeType.CommentsFacade);
            List<CommentsDTO> comments = commentsFacade.ViewComments(EventId);
            ViewBag.Comments = comments;

            return View(eventDetail);
        }


        //Get Event's Created by User:-
        public ActionResult MyEvents(int UserId)
        {
            ViewBag.Message = "MyEvents";
            IEventsFacade eventsFacade = (IEventsFacade)FacadeFactory.Instance.Create(FacadeType.EventsFacade);
            List<List<EventsDTO>> result = eventsFacade.GetMyEvents(UserId);
            return View("EventsList", result);
        }


        //Get Events User is Invited to:-
        public ActionResult InvitedTo(int UserId)
        {
            IEventsFacade eventsFacade = (IEventsFacade)FacadeFactory.Instance.Create(FacadeType.EventsFacade);
            List<List<EventsDTO>> result = eventsFacade.InvitedTo(UserId);
            return View("EventsList",result);
        }


        //Create new Events:-
        [HttpGet]
        public ActionResult CreateEvent()
        {
            return View();
        }

        [HttpPost]
        public ActionResult CreateEvent(Event newEvent)
        {
            EventsDTO eventsDTO = new EventsDTO();
            ModelConverter.ModelConverter.FillDTOFromModel(newEvent, eventsDTO);
            eventsDTO.CreatedBy = (int)Session["UserId"];
            IEventsFacade eventsFacade = (IEventsFacade)FacadeFactory.Instance.Create(FacadeType.EventsFacade);
            OperationResult<EventsDTO> result = eventsFacade.CreateEvents(eventsDTO);
            if (result.IsValid())
            {
                newEvent.EventID = result.Data.EventID;
                //to print the list of all the available users to invite them:-
                IUsersFacade usersFacade = (IUsersFacade)FacadeFactory.Instance.Create(FacadeType.UsersFacade);
                ViewBag.Users = usersFacade.GetUsers();
            }
            return View(newEvent);
        }



        //Invite People after creating event:-
        public ActionResult InvitePeople(int eventId, string invites)
        {
            IEventsFacade eventsFacade = (IEventsFacade)FacadeFactory.Instance.Create(FacadeType.EventsFacade);
            bool result = eventsFacade.InvitePeople(eventId, invites);
            return RedirectToAction("CreateEvent", new { EventId = eventId });
        }


        [HttpGet]
        public ActionResult EditEvent(int eventId)
        {
            IEventsFacade eventsFacade = (IEventsFacade)FacadeFactory.Instance.Create(FacadeType.EventsFacade);
            EventsDTO eventsDTO = eventsFacade.GetEditEvent(eventId);
            Event @event = new Event();
            ModelConverter.ModelConverter.FillModelFromDTO(eventsDTO, @event);
            return View(@event);
        }

        [HttpPost]
        public ActionResult EditEvent(Event @event)
        {
            EventsDTO eventsDTO = new EventsDTO();
            ModelConverter.ModelConverter.FillDTOFromModel(@event, eventsDTO);
            IEventsFacade eventsFacade = (IEventsFacade)FacadeFactory.Instance.Create(FacadeType.EventsFacade);
            OperationResult<EventsDTO> result = eventsFacade.EditEvent(eventsDTO);
            if(result.IsValid())
                return RedirectToAction("MyEvents", new { UserId = Session["UserId"] });
            return View(@event);
        }



        [HttpPost]
        public ActionResult AddComment(int eventId,string comment)
        {
            ICommentsFacade commentsFacade = (ICommentsFacade)FacadeFactory.Instance.Create(FacadeType.CommentsFacade);
            Comments comments = new Comments();
            comments.EventId = eventId;
            comments.Comment = comment;
            comments.UserId = (int)Session["UserId"];
            CommentsDTO commentsDTO = new CommentsDTO();
            ModelConverter.ModelConverter.FillDTOFromModel(comments, commentsDTO);

            OperationResult<CommentsDTO> result = commentsFacade.AddComment(commentsDTO);
            if(result.IsValid())
                return RedirectToAction("EventDetails",new { EventId = eventId });
            return RedirectToAction("EventsList");
        }

        
    }
}