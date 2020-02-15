﻿using Microsoft.EntityFrameworkCore;
using social_journal.Base;
using System;

namespace social_journal.Tests
{
    public interface ITestingContextInvoker<TAppContext, TDBContext, TRepositoryProvider>
        where TDBContext : DbContext
        where TRepositoryProvider : IRepositoryProvider<TDBContext>
        where TAppContext : IBaseAppContext<TDBContext, TRepositoryProvider>
    {
        static ITestingContextInvoker<TAppContext, TDBContext, TRepositoryProvider> Instance { get; }
        void RunWithContext(Action<TAppContext> delegateWithContext);
    }
}
