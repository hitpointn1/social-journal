using social_journal.DL.Identity;
using social_journal.DL.RepositoryProvider;

namespace social_journal.DL.AppContext
{
    public interface IJournalAppContext : IBaseAppContext<JournalDBContext, IJournalRepositoryProvider>
    {
        JournalRoleManager RoleManager { get; }
        JournalUserManager UserManager { get; }
    }
}
