using System;

namespace social_journal.Base.Loggers
{
    public class Logger : ILog
    {
        public void Error(string message)
        {
            Console.WriteLine(message);
        }

        public void Error(Exception ex, string message)
        {
            Console.WriteLine(message + "\n" + ex.ToString());
        }

        public void Info(string message)
        {
            Console.WriteLine(message);
        }

        public void Info(Exception ex, string message)
        {
            Console.WriteLine(message + "\n" + ex.ToString());
        }

        public void Warning(string message)
        {
            Console.WriteLine(message);
        }

        public void Warning(Exception ex, string message)
        {
            Console.WriteLine(message + "\n" + ex.ToString());
        }
    }
}
