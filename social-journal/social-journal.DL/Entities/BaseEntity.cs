using System.ComponentModel.DataAnnotations;

namespace social_journal.DL.Entities
{
    public abstract class BaseEntity : IEntity
    {
        [Key]
        public int ID { get; set; }
    }
}
