using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.AccessControl;
using System.Text;
using System.Threading.Tasks;

namespace ph_model
{
    public sealed class Log
    {
        private static volatile Log s_instance;
        private static object s_syncRoot = new Object();

        private static Queue<LogMessage> s_logQueue = new Queue<LogMessage>();
        private static int s_maxLogAge = 5;
        private static DateTime s_lastFlushed = DateTime.Now;
        private static int s_queueSize = 10;

        private class LogMessage
        {
            public DateTime Time { get; set; }
            public Level Level { get; set; }
            public string MemberName { get; set; }
            public string Message { get; set; }
            public int LineNumber { get; set; }
        }

        public static Log Instance
        {
            get
            {
                if (s_instance == null)
                {
                    lock (s_syncRoot)
                    {
                        if (s_instance == null)
                            s_instance = new Log();
                    }
                }

                return s_instance;
            }
        }

        private Log() { }

        public static void Info(string message, [System.Runtime.CompilerServices.CallerMemberName] string memberName = "", [System.Runtime.CompilerServices.CallerLineNumber] int sourceLineNumber = 0)
        {
            Instance.AddMessageToQueue(Level.Info, memberName, sourceLineNumber, message, DateTime.Now);
        }

        public static void Warning(string message, [System.Runtime.CompilerServices.CallerMemberName] string memberName = "", [System.Runtime.CompilerServices.CallerLineNumber] int sourceLineNumber = 0)
        {
            Instance.AddMessageToQueue(Level.Warning, memberName, sourceLineNumber, message, DateTime.Now);
        }

        public static void Error(string message, [System.Runtime.CompilerServices.CallerMemberName] string memberName = "", [System.Runtime.CompilerServices.CallerLineNumber] int sourceLineNumber = 0)
        {
            Instance.AddMessageToQueue(Level.Error, memberName, sourceLineNumber, message, DateTime.Now);
        }

        public static void Fatal(string message, [System.Runtime.CompilerServices.CallerMemberName] string memberName = "", [System.Runtime.CompilerServices.CallerLineNumber] int sourceLineNumber = 0)
        {
            Instance.AddMessageToQueue(Level.Fatal, memberName, sourceLineNumber, message, DateTime.Now);
        }

        private void AddMessageToQueue(Level level, string memberName, int lineNumber, string message, DateTime time)
        {
            var logMessage = new LogMessage() { Level = level, LineNumber = lineNumber, MemberName = memberName, Message = message, Time = time };
            s_logQueue.Enqueue(logMessage);

            if (s_logQueue.Count >= s_queueSize || DoPeroidicFlush())
            {
                FlushLog();
            }
        }

        private bool DoPeroidicFlush()
        {
            TimeSpan logAge = DateTime.Now - s_lastFlushed;
            if (logAge.TotalSeconds >= s_maxLogAge)
            {
                s_lastFlushed = DateTime.Now;
                return true;
            }
            return false;
        }

        public void FlushLog()
        {
            if (s_logQueue.Count <= 0) return;
            using (LogContext db = LogContext.CreateContext())
            {
                while (s_logQueue.Count > 0)
                {
                    var logMessage = s_logQueue.Dequeue();
                    var logEntry = db.LogEntrySet.Create();
                    logEntry.Level = logMessage.Level;
                    logEntry.LineNumber = logMessage.LineNumber;
                    logEntry.MemberName = logMessage.MemberName;
                    logEntry.Message = logMessage.Message;
                    logEntry.Time = logMessage.Time;
                    db.LogEntrySet.Add(logEntry);
                }
                db.SaveChanges();
            }
        }
    }
}
