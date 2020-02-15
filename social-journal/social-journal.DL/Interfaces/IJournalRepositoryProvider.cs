using social_journal.Base;
using social_journal.DL.Entities;
using social_journal.DL.Repositories;

namespace social_journal.DL.Interfaces
{
    public interface IJournalRepositoryProvider : IRepositoryProvider<JournalDBContext>
    {
        public BaseJournalRepository<Post> PostsRepository { get; }
    }
}
