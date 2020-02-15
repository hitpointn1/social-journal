using social_journal.Base;
using social_journal.DL.Entities;
using social_journal.DL.Interfaces;

namespace social_journal.DL.Repositories
{
    public class BaseJournalRepository<TEntity> : BaseRepository<TEntity, IJournalAppContext, JournalDBContext>
       where TEntity : BaseEntity
    {
        public BaseJournalRepository(IJournalAppContext context) : base(context)
        {
        }
    }
}
