using social_journal.Base;
using social_journal.DL.Interfaces;

namespace social_journal.DL
{
    public class JournalAppContext : BaseContext<JournalDBContext, IJournalRepositoryProvider>, IJournalAppContext
    {
        public JournalAppContext(ILog logger, JournalDBContext eFContext, IJournalRepositoryProvider provider)
            : base(logger, eFContext, provider)
        {
        }
    }
}
