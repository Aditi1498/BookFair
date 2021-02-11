namespace EntityDataModel.Migrations
{
    using EntityDataModel.EntityModel;
    using System;
    using System.Collections.Generic;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;

    internal sealed class Configuration : DbMigrationsConfiguration<EntityDataModel.EntityModel.BookContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
        }

        protected override void Seed(EntityDataModel.EntityModel.BookContext context)
        {
            //  This method will be called after migrating to the latest version.

            //  You can use the DbSet<T>.AddOrUpdate() helper extension method
            //  to avoid creating duplicate seed data.
            var users = new List<User>
            {
                new User{EmailId = "myadmin@bookevent.com",Name="Admin",Password="admin!"},
                new User{EmailId = "user1@bookevent.com",Name="User1",Password="abcde!"},
                new User{EmailId = "user2@bookevent.com",Name="User2",Password="abcde!"},
                new User{EmailId = "user3@bookevent.com",Name="User2",Password="abcde!"},


            };
            users.ForEach(u => context.Users.Add(u));
            context.SaveChanges();

            var events = new List<Event>
            {
                new Event{BookTitle = "Harry Potter and the Philosophers Stone",StartDate = DateTime.Parse("2020-12-02"),Location="Gurugram",Duration=2,CreatedBy=1,EventType="public",Description="the first novel in series, it is fantasy novel"},
                new Event{BookTitle = "Harry Potter and the Chamber of Secrets",StartDate = DateTime.Parse("2021-01-09"),Location="Gurugram",Duration=3,CreatedBy=1,EventType="private",Description="messages on walls of school's corridors warn"},
                new Event{BookTitle = "Harry Potter and the Prisoner of Azkaban",StartDate = DateTime.Parse("2021-01-16"),Location="Gurugram",Duration=2,CreatedBy=2,EventType="public",Description="Harry investigates escaped prisoner from Azkaban"},
                new Event{BookTitle = "Harry Potter and the Goblet of Fire",StartDate = DateTime.Parse("2020-12-23"),Location="Gurugram",Duration=2,CreatedBy=3,EventType="private",Description="participant from each school selected by Goblet"},
                new Event{BookTitle = "Harry Potter and the Order of the Phoenix",StartDate = DateTime.Parse("2021-01-30"),Location="Gurugram",Duration=2,CreatedBy=3,EventType="public",Description="Dumbledore's Army fights Death Eaters"},
                new Event{BookTitle = "Harry Potter and the Half Blood Prince",StartDate = DateTime.Parse("2020-12-07"),Location="Gurugram",Duration=2,CreatedBy=2,EventType="private",Description="explores past of boy nemesis, Lord Voldemort"},
                new Event{BookTitle = "Harry Potter and the Deathly Hollows",StartDate = DateTime.Parse("2020-12-14"),Location="Gurugram",Duration=2,CreatedBy=2,EventType="public",Description="Harry enter final struggle with Voldemort"},

            };
            events.ForEach(e => context.Events.Add(e));
            context.SaveChanges();

            var userEventMappings = new List<UserEventMapping>
            {
                new UserEventMapping{UserId=2,EventId=1},
                new UserEventMapping{UserId=2,EventId=7},
                new UserEventMapping{UserId=2,EventId=2},
                new UserEventMapping{UserId=2,EventId=3},
                new UserEventMapping{UserId=2,EventId=6},
                new UserEventMapping{UserId=2,EventId=1},
                new UserEventMapping{UserId=2,EventId=4},
                new UserEventMapping{UserId=3,EventId=5},
                new UserEventMapping{UserId=3,EventId=2},
                new UserEventMapping{UserId=3,EventId=6},

            };
            userEventMappings.ForEach(u => context.UserEventMappings.Add(u));
            context.SaveChanges();
        }
    }
}
