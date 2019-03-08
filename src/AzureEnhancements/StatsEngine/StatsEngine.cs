using System;
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

        private OSPlatform _OSPlatform;

        public AzStatsEngine() : this(autoStart: true)
        {
        }

        public AzStatsEngine(bool autoStart)
        {
            persistenceMgr = new PersistenceManager();
            loggingMgr = new LoggingManager(persistenceMgr);
            analysisMgr = new AnalysisManager(persistenceMgr);

            SetOSPlatform();

            if (autoStart)
            {
                StartLogging();
            }
        }

        private void SetOSPlatform()
        {
            // will eventually need to add support for Linux and potentially OSX...
            if (!RuntimeInformation.IsOSPlatform(OSPlatform.Windows))
            {
                throw new OSNotSupportedException();
            }

            _OSPlatform = OSPlatform.Windows;
        }

        public void StartLogging()
        {
            loggingMgr.StartLogging();
        }

        public void StopLogging()
        {
            loggingMgr.StopLogging();
        }

        public string GetMostRecentStats()
        {
            return analysisMgr.GetStatsInLogFormat();
        }

    }
}
