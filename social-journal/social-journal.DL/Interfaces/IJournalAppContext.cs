using social_journal.Base;

namespace social_journal.DL.Interfaces
{
    public interface IJournalAppContext : IBaseAppContext<JournalDBContext, IJournalRepositoryProvider>
    {
    }
}
