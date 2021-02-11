using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace BookEvent.Models
{
    public class User
    {
        [Key]
        public int UserId { get; set; }

        [Required]
        [EmailAddress]
        public string EmailId { get; set; }

        [Required]
        public string Name { get; set; }

        [Required]
        [StringLength(15, MinimumLength = 5, ErrorMessage = "Password should have atleast 5 characters")]
        [RegularExpression(@"^.*(?=.*[!@#$%^&*\(\)_\-+=]).*$",ErrorMessage ="Password should contain atleast one secialcharacter")]
        public string Password { get; set; }

        public virtual ICollection<UserEventMapping> UserEventMappings { get; set; }
        public virtual ICollection<Comments> Comments { get; set; }


    }
}