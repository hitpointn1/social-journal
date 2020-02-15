using social_journal.Base;
using social_journal.Base.EFRImplementation;
using social_journal.DL.Entities;
using social_journal.DL.Interfaces;
using social_journal.DL.Repositories;

namespace social_journal.DL
{
    public class JournalRepositoryProvider : BaseRepositoryProvider<JournalDBContext>, IJournalRepositoryProvider
    {
        public JournalRepositoryProvider(JournalDBContext context, ILog logger)
            : base(context, logger)
        {
        }

        private BaseJournalRepository<Post> PostsRepositoryField;
        public BaseJournalRepository<Post> PostsRepository  
        {
            get
            {
                if (PostsRepositoryField == null)
                {
                    PostsRepositoryField = new BaseJournalRepository<Post>(DbContext, Logger);
                }
                return PostsRepositoryField;
            }
        }
    }
}
