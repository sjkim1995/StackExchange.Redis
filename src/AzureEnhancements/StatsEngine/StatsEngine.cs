using System;
using System.Runtime.InteropServices;
using StatsEngine.Persistence;
using StatsEngine.Logging;
using StatsEngine.Analysis;
using StatsEngine.Shared;


namespace StatsEngine
{
    public class StatsEngine
    {

        // Architecture:
        // [Logging] writes to ------> [Persistence] <------ reads from [Analysis]
        private PersistenceManager persistenceMgr;
        private LoggingManager loggingMgr;
        private AnalysisManager analysisMgr;

        private OSPlatform _OSPlatform;

        public StatsEngine() : this(autoStart: true)
        {
        }

        public StatsEngine(bool autoStart)
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
