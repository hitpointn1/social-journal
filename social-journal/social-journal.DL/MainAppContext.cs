using social_journal.Base;

namespace social_journal.DL
{
    public class MainAppContext : BaseContext
    {
        public MainAppContext(ILog logger, MainDBContext eFContext) : base(logger, eFContext)
        {
        }
    }
}
