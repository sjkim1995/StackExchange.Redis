using System;
using System.Collections.Generic;
using AzRedisEnhancements.Logging;
using AzRedisEnhancements.Persistence;
using AzRedisEnhancements.Shared;

namespace AzRedisEnhancements.Logging
{
    public class LoggingManager
    {
        // Set of loggers/perf counters
        private HashSet<MachineStatLogger> loggerSet;

        private PersistenceManager persistenceMgr;

        public LoggingManager(PersistenceManager persistenceMgr)
        {
            this.persistenceMgr = persistenceMgr;

            // Instantiate loggerSet and add loggers
            InitLoggerSet();
        }


        private void InitLoggerSet()
        {
            loggerSet = new HashSet<MachineStatLogger>
            { 
                // Add new loggers here...
                new BandwidthLogger(SEConstants.DefaultLogIntervals[StatType.Bandwidth], persistenceMgr.GetBuffer(StatType.Bandwidth)),
                new CPULogger(SEConstants.DefaultLogIntervals[StatType.CPU], persistenceMgr.GetBuffer(StatType.CPU)),
                new ThreadPoolLogger(SEConstants.DefaultLogIntervals[StatType.ThreadPool], persistenceMgr.GetBuffer(StatType.ThreadPool)),
                new PageFaultLogger(SEConstants.DefaultLogIntervals[StatType.PageFaults], persistenceMgr.GetBuffer(StatType.PageFaults))
            };
        }

        public void StartLoggers()
        {
            foreach (var logger in loggerSet)
            {
                logger.StartLogging();
            }
        }

        public void StopLoggers()
        {
            foreach (var logger in loggerSet)
            {
                logger.Dispose();
            }
        }

    }
}
