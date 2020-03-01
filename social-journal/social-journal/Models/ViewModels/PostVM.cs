using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace social_journal.Models.ViewModels
{
    public class PostVM
    {
        public int ID { get; set; }
        public string Title { get; set; }
        public DateTime CreatedDate { get; set; }
        public string Content { get; set; }
    }
}
