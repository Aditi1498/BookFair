using System;
using System.Collections.Generic;
using System.Linq;
using BookEvent.Controllers;
using Data.DataAccessComponents;
using EntityDataModel.EntityModel;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using Shared;

namespace UnitTestProject
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void MyEvents()
        {
            //Arrange

            List<Event> eventsDTOs = new List<Event>
            {
                new Event{EventID=1, BookTitle = "Harry Potter and the Philosophers Stone",StartDate = DateTime.Parse("2020-11-02"),Location="Gurugram",Duration=2,CreatedBy=1,EventType="public",Description="he first novel in the Harry Potter series, itis a fantasy novel"},
                new Event{EventID=2, BookTitle = "Harry Potter and the Chamber of Secrets",StartDate = DateTime.Parse("2020-11-09"),Location="Gurugram",Duration=3,CreatedBy=1,EventType="private",Description="The plot follows Harry's second year at Hogwarts School of Witchcraft and Wizardry, during which a series of messages on the walls of the school's corridors warn that the Chamber of Secrets has been opened"},
                new Event{EventID=3,BookTitle = "Harry Potter and the Prisoner of Azkaban",StartDate = DateTime.Parse("2020-11-16"),Location="Gurugram",Duration=2,CreatedBy=2,EventType="public",Description="Harry investigates Sirius Black, an escaped prisoner from Azkaban, the wizard prison, believed to be one of Lord Voldemort's old allies."},
                new Event{EventID=4,BookTitle = "Harry Potter and the Goblet of Fire",StartDate = DateTime.Parse("2020-11-23"),Location="Gurugram",Duration=2,CreatedBy=3,EventType="private",Description="In this series There is an upcoming tournament between the three major schools of magic, with one participant selected from each school by the Goblet of Fire."},
                new Event{EventID=5,BookTitle = "Harry Potter and the Order of the Phoenix",StartDate = DateTime.Parse("2020-11-30"),Location="Gurugram",Duration=2,CreatedBy=3,EventType="public",Description="In this Dumbledore's Army fights the Death Eaters until the Order of the Phoenix arrives."},
                new Event{EventID=6,BookTitle = "Harry Potter and the Half Blood Prince",StartDate = DateTime.Parse("2020-12-07"),Location="Gurugram",Duration=2,CreatedBy=2,EventType="private",Description="the novel explores the past of the boy wizard's nemesis, Lord Voldemort"},
                new Event{EventID=7,BookTitle = "Harry Potter and the Deathly Hollows",StartDate = DateTime.Parse("2020-12-14"),Location="Gurugram",Duration=2,CreatedBy=2,EventType="public",Description="Harry Potter, together with his teenage companions and the members of the Order of the Phoenix, enter the final struggle with Voldemort and his Death Eaters"},
            };

            List<List<Event>> eventsDTOList = new List<List<Event>>(3);

            //var facadeFactory = new Mock<IFacadeFactory>();
            //var facade = new Mock<IFacade>();
            //facade.Setup(e => e.FacadeType).Equals(FacadeType.EventsFacade);

            //facadeFactory.Setup(e => e.Create(FacadeType.EventsFacade)).Returns((IFacade)new object());
            //var result = facadeFactory.Setup(e => e.)

            //var mock = new Mock<IEventsDAC>();
            //mock.Setup(e => e.GetMyEvents(2)).Returns(eventsDTOs);
            //var mock2 = new Mock<BookContext>();
            //mock2.Setup(e1 => e1.Events.Where(e => e.CreatedBy == 2)).Returns(eventsDTOs.AsQueryable);
            // HomeController homeController = new HomeController();
            //var result = homeController.MyEvents(1);
            //mock.Setup(e => e.GetMyEvents(2)).Returns(new List<List<EventsDTO>>());

            //Act
            //ViewResult results = homeController.MyEvents(1) as ViewResult;

            IEventsDAC eventsDAC = new EventsDAC();

            var result = eventsDAC.GetMyEvents(2);

            //Assert
            Assert.IsNotNull(result);
        }
    }
}
