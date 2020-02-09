using System;

namespace social_journal.Base
{
    public interface ILog
    {
        void Info(string message);
        void Info(Exception ex, string message);
        void Warning(string message);
        void Warning(Exception ex, string message);
        void Error(string message);
        void Error(Exception ex, string message);
    }
}
