using System.Data.Entity;

namespace EntityDataModel.EntityModel
{
    public class BookContext : DbContext
    {
        public DbSet<User> Users { get; set; }
        public DbSet<Event> Events { get; set; }
        public DbSet<UserEventMapping> UserEventMappings { get; set; }
        public DbSet<Comments> Comments { get; set; }
    }
}
