using Microsoft.EntityFrameworkCore;
using social_journal.Base.Loggers;
using social_journal.DL;
using social_journal.DL.Interfaces;
using System;

namespace social_journal.Tests
{
    public class BaseTestProvider : ITestingContextInvoker<IJournalAppContext, JournalDBContext, IJournalRepositoryProvider>
    {
        public static ITestingContextInvoker<IJournalAppContext, JournalDBContext, IJournalRepositoryProvider> Instance { get; } = new BaseTestProvider();

        public void RunWithContext(Action<IJournalAppContext> delegateWithContext)
        {
            var logger = new Logger();
            using var dbContext = new JournalDBContext(true);
            var context = new JournalAppContext(logger, dbContext, new JournalRepositoryProvider(dbContext, logger));
            delegateWithContext(context);
            dbContext.Dispose();
        }
    }
}
