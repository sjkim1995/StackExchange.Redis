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

        public StatsEngine()
        {
            Init();
        }

        private void Init()
        {
            persistenceMgr = new PersistenceManager();
            loggingMgr = new LoggingManager(persistenceMgr);
            analysisMgr = new AnalysisManager(persistenceMgr);

            SetOSPlatform();
        }


        private void SetOSPlatform()
        {
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


    }
}
