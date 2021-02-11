using System.ComponentModel.DataAnnotations;

namespace EntityDataModel.EntityModel
{
    public class UserEventMapping
    {
        [Key]
        public int ID { get; set; }
        public int UserId { get; set; }
        public int EventId { get; set; }
        //public string Comments { get; set; }

        public User User { get; set; }
        public Event Event { get; set; }
    }
}
