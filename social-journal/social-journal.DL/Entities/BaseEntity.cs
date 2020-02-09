using social_journal.Base;
using System.ComponentModel.DataAnnotations;

namespace social_journal.DL.Entities
{
    public abstract class Base : IEntity
    {
        [Key]
        public int ID { get; set; }
    }
}
