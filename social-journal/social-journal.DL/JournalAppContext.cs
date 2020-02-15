using social_journal.Base;
using social_journal.DL.Interfaces;

namespace social_journal.DL
{
    public class JournalAppContext : BaseContext<JournalDBContext>, IJournalAppContext
    {
        public JournalAppContext(ILog logger, JournalDBContext eFContext) : base(logger, eFContext)
        {
        }
    }
}
