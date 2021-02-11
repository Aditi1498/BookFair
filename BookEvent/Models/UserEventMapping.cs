using System.ComponentModel.DataAnnotations;

namespace BookEvent.Models
{
    public class UserEventMapping
    {
        [Key]
        public int ID { get; set; }
        public int UserId { get; set; }
        public int EventId { get; set; }

        public User User { get; set; }
        public Event Event { get; set; }
    }
}