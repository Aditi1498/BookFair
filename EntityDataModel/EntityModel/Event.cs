using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace EntityDataModel.EntityModel
{
    public class Event
    {
        [Key]
        public int EventID { get; set; }

        [Required]
        public string BookTitle { get; set; }

        [Required]
        public DateTime StartDate { get; set; }

        [Required]
        public string Location { get; set; }

        [Range(1,4, ErrorMessage = "Duration cannot be above 4 hours")]
        [Required]
        public int Duration { get; set; }

        public int CreatedBy { get; set; }

        public string EventType { get; set; }

        [MaxLength(50)]
        public string Description { get; set; }

        public virtual ICollection<UserEventMapping> UserEventMappings { get; set; }
        public virtual ICollection<Comments> Comments { get; set; }
    }
}
