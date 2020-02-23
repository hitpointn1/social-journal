using System;

namespace social_journal.BL.DTO
{
    public class PostDTO : BaseDTOEntity
    {
        public string Title { get; set; }
        public string Content { get; set; }
        public DateTime Created { get; set; }
        public DateTime? LastUpdated { get; set; }
    }
}
