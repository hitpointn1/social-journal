using social_journal.DL.Entities;
using social_journal.DL.Repositories;

namespace social_journal.DL.RepositoryProvider
{
    public interface IJournalRepositoryProvider : IRepositoryProvider<JournalDBContext>
    {
        public BaseJournalRepository<Post> PostsRepository { get; }
    }
}
