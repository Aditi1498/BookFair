using System;
using System.Collections.Generic;
using System.Web.Mvc;
using BookEvent.Controllers;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using NUnit.Framework;
using Shared;
using Assert = Microsoft.VisualStudio.TestTools.UnitTesting.Assert;
//using Shared;
//using Assert = NUnit.Framework.Assert;

namespace Testing
{
    [TestClass]
    public class UnitTest1
    {
        [SetUp]
        public void SetUp()
        {

        }

        [Test]
        public void MyEvents()
        {
            //Arrange

            List<EventsDTO> eventsDTOs = new List<EventsDTO>
            {
                new EventsDTO{EventID=1, BookTitle = "Harry Potter and the Philosophers Stone",StartDate = DateTime.Parse("2020-11-02"),Location="Gurugram",Duration=2,CreatedBy=1,EventType="public",Description="he first novel in the Harry Potter series, itis a fantasy novel"},
                new EventsDTO{EventID=2, BookTitle = "Harry Potter and the Chamber of Secrets",StartDate = DateTime.Parse("2020-11-09"),Location="Gurugram",Duration=3,CreatedBy=1,EventType="private",Description="The plot follows Harry's second year at Hogwarts School of Witchcraft and Wizardry, during which a series of messages on the walls of the school's corridors warn that the Chamber of Secrets has been opened"},
                new EventsDTO{EventID=3,BookTitle = "Harry Potter and the Prisoner of Azkaban",StartDate = DateTime.Parse("2020-11-16"),Location="Gurugram",Duration=2,CreatedBy=2,EventType="public",Description="Harry investigates Sirius Black, an escaped prisoner from Azkaban, the wizard prison, believed to be one of Lord Voldemort's old allies."},
                new EventsDTO{EventID=4,BookTitle = "Harry Potter and the Goblet of Fire",StartDate = DateTime.Parse("2020-11-23"),Location="Gurugram",Duration=2,CreatedBy=3,EventType="private",Description="In this series There is an upcoming tournament between the three major schools of magic, with one participant selected from each school by the Goblet of Fire."},
                new EventsDTO{EventID=5,BookTitle = "Harry Potter and the Order of the Phoenix",StartDate = DateTime.Parse("2020-11-30"),Location="Gurugram",Duration=2,CreatedBy=3,EventType="public",Description="In this Dumbledore's Army fights the Death Eaters until the Order of the Phoenix arrives."},
                new EventsDTO{EventID=6,BookTitle = "Harry Potter and the Half Blood Prince",StartDate = DateTime.Parse("2020-12-07"),Location="Gurugram",Duration=2,CreatedBy=2,EventType="private",Description="the novel explores the past of the boy wizard's nemesis, Lord Voldemort"},
                new EventsDTO{EventID=7,BookTitle = "Harry Potter and the Deathly Hollows",StartDate = DateTime.Parse("2020-12-14"),Location="Gurugram",Duration=2,CreatedBy=2,EventType="public",Description="Harry Potter, together with his teenage companions and the members of the Order of the Phoenix, enter the final struggle with Voldemort and his Death Eaters"},
            };

            List<List<EventsDTO>> eventsDTOList = new List<List<EventsDTO>>(3);

            //var facadeFactory = new Mock<IFacadeFactory>();
            //var facade = new Mock<IFacade>();
            //facade.Setup(e => e.FacadeType).Equals(FacadeType.EventsFacade);

            //facadeFactory.Setup(e => e.Create(FacadeType.EventsFacade)).Returns((IFacade)new object());
            //var result = facadeFactory.Setup(e => e.)

            var mock = new Mock<IEventsFacade>();
            mock.Setup(e => e.GetMyEvents(2)).Returns(eventsDTOList);
            HomeController homeController = new HomeController();
            var result = homeController.MyEvents(1);


            //Act
            ViewResult results = homeController.MyEvents(1) as ViewResult;



            //Assert
            Assert.IsNotNull(result);
        }
    }
}
