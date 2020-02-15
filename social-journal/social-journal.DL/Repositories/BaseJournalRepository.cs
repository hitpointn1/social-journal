using social_journal.Base;
using social_journal.DL.Entities;

namespace social_journal.DL.Repositories
{
    public class BaseJournalRepository<TEntity> : BaseRepository<TEntity, JournalDBContext>
       where TEntity : BaseEntity
    {
        public BaseJournalRepository(JournalDBContext context, ILog logger)
            : base(context, logger)
        {
        }
    }
}
