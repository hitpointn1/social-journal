using System;

namespace social_journal.BL.DTO
{
    public class ProfileDTO : BaseDTOEntity
    {
        public DateTime? Birthday { get; set; }
        public string Country { get; set; }
        public string Title { get; set; }
        public string Survey { get; set; }
    }
}
