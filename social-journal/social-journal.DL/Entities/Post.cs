using System;
using System.ComponentModel.DataAnnotations;

namespace social_journal.DL.Entities
{
    public class Post : BaseEntity
    {
        public Post(string title)
        {
            Title = title;
            Created = DateTime.Now;
        }

        [Required]
        [StringLength(100)]
        public string Title { get; set; }
        public string Content { get; set; }
        [Required]
        public DateTime Created { get; set; }
        public DateTime? LastUpdated { get; set; }
    }
}
