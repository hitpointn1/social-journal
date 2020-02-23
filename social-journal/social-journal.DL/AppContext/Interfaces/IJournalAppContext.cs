using social_journal.DL.RepositoryProvider;
using social_journal.DL;

namespace social_journal.DL.AppContext
{
    public interface IJournalAppContext : IBaseAppContext<JournalDBContext, IJournalRepositoryProvider>
    {
    }
}
