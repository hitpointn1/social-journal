using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace social_journal.Models.ViewModels
{
    public class ProfileVM
    {
        public int ID { get; set; }
        public string Title { get; set; }
        public string Survey { get; set; }
        public string Birthday { get; set; }
        public string Country { get; set; }
    }
}
