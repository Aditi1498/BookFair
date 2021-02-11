using System.ComponentModel.DataAnnotations;

namespace EntityDataModel.EntityModel
{
    public class Comments
    {
        [Key]
        public int CommentId { get; set; }
        public int EventId { get; set; }
        public int UserId { get; set; }
        public string UserName { get; set; }
        public string Comment { get; set; }

        public virtual Event Event{get;set;}
        public virtual User User { get; set; }
    }
}
