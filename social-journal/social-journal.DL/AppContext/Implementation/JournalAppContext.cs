using social_journal.Base;
using social_journal.DL.Identity;
using social_journal.DL.RepositoryProvider;

namespace social_journal.DL.AppContext
{
    public class JournalAppContext : BaseContext<JournalDBContext, IJournalRepositoryProvider>, IJournalAppContext
    {
        public JournalAppContext(ILog logger,
            JournalDBContext eFContext, IJournalRepositoryProvider provider,
            JournalRoleManager roleManager, JournalUserManager userManager)
            : base(logger, eFContext, provider)
        {
            RoleManager = roleManager;
            UserManager = userManager;
        }

        public JournalRoleManager RoleManager { get; }
        public JournalUserManager UserManager { get; }
    }
}
