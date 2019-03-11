using System;
using System.Text;
using System.Runtime.InteropServices;
using AzRedisEnhancements.Persistence;
using AzRedisEnhancements.Logging;
using AzRedisEnhancements.Analysis;
using AzRedisEnhancements.Shared;

namespace AzRedisEnhancements
{
    public class AzStatsEngine
    {
        private readonly PersistenceManager persistenceMgr;
        private LoggingManager loggingMgr;
        private AnalysisManager analysisMgr;

        public AzStatsEngine() : this(autoStart: true)
        {
        }

        public AzStatsEngine(bool autoStart)
        {
            persistenceMgr = new PersistenceManager();
            loggingMgr = new LoggingManager(persistenceMgr);
            analysisMgr = new AnalysisManager(persistenceMgr);

            CheckOSPlatform();

            if (autoStart)
            {
                StartLogging();
            }
        }

        private void CheckOSPlatform()
        {
            // will eventually need to add support for Linux and potentially OSX...
            if (!RuntimeInformation.IsOSPlatform(OSPlatform.Windows))
            {
                throw new OSNotSupportedException();
            }
        }

        public void StartLogging()
        {
            loggingMgr.StartLoggers();
        }

        public void StopLogging()
        {
            loggingMgr.StopLoggers();
        }

        public string GetStatsInLogFormat()
        {
            var sb = new StringBuilder();
            sb.AppendLine().AppendLine();
            sb.AppendLine("Additional Statistics: ");
            string stats = analysisMgr.GetAllRecentStats();
            sb.AppendLine(stats);

            return sb.ToString();
        }

    }
}
