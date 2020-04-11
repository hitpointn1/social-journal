using System.Collections.Generic;

namespace social_journal.Models
{
    public class ProfileVM
    {
        public int ID { get; set; }
        public string Title { get; set; }
        public string Survey { get; set; }
        public string Birthday { get; set; }
        public string Country { get; set; }

        public IEnumerable<AchievementVM> Achievements { get; set; }
    }
}
