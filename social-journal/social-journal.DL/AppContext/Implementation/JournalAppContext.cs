using social_journal.Base;
using social_journal.DL.RepositoryProvider;
using social_journal.DL;

namespace social_journal.DL.AppContext
{
    public class JournalAppContext : BaseContext<JournalDBContext, IJournalRepositoryProvider>, IJournalAppContext
    {
        public JournalAppContext(ILog logger, JournalDBContext eFContext, IJournalRepositoryProvider provider)
            : base(logger, eFContext, provider)
        {
        }
    }
}
