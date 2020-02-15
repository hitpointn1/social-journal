using social_journal.Base.EFRImplementation;
using social_journal.DL.Entities;
using social_journal.DL.Interfaces;
using social_journal.DL.Repositories;

namespace social_journal.DL
{
    public class JournalRepositoryProvider : BaseRepositoryProvider<IJournalAppContext, JournalDBContext>, IJournalRepositoryProvider
    {
        public JournalRepositoryProvider(IJournalAppContext context) : base(context)
        {
        }

        private BaseJournalRepository<Post> PostsRepositoryField;
        public BaseJournalRepository<Post> PostsRepository  
        {
            get
            {
                if (PostsRepositoryField == null)
                {
                    PostsRepositoryField = new BaseJournalRepository<Post>(Context);
                }
                return PostsRepositoryField;
            }
        }
    }
}
