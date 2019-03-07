using System;
using System.Collections.Generic;
using StatsEngine.Logging;
using StatsEngine.Persistence;
using StatsEngine.Shared;

namespace StatsEngine.Logging
{
    public class LoggingManager
    {
        // Set of loggers/perf counters
        private HashSet<MachineStatLogger> loggerSet;
        private TimeSpan _logFrequency;

        private PersistenceManager persistenceMgr;

        public LoggingManager(PersistenceManager persistenceMgr, TimeSpan logFrequency)
        {
            if (logFrequency <= TimeSpan.Zero)
            {
                throw new ArgumentOutOfRangeException("logFrequency");
            }

            _logFrequency = logFrequency;
            this.persistenceMgr = persistenceMgr;

            // Instantiate loggerSet and add loggers
            InitLoggerSet();
        }

        public LoggingManager(PersistenceManager persistenceMgr) : this(persistenceMgr, TimeSpan.FromSeconds(SEConstants.DefaultLogInterval))
        {
        }

        private void InitLoggerSet()
        {
            loggerSet = new HashSet<MachineStatLogger>
            { 
                // Add new loggers here...
                new BandwidthLogger(_logFrequency, persistenceMgr.GetBuffer(StatType.Bandwidth)),
                new CPULogger(_logFrequency, persistenceMgr.GetBuffer(StatType.CPU)),
                new ThreadPoolLogger(_logFrequency, persistenceMgr.GetBuffer(StatType.ThreadPool)),
                new PageFaultLogger(_logFrequency, persistenceMgr.GetBuffer(StatType.PageFaults))
            };
        }

        public void StartLogging()
        {
            foreach (var logger in loggerSet)
            {
                logger.StartLogging();
            }
        }

        public void StopLogging()
        {
            foreach (var logger in loggerSet)
            {
                logger.Dispose();
            }
        }

    }
}
