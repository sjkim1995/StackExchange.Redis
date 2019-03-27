using System;
using System.Diagnostics;
using System.Threading.Tasks;
using AzRedisEnhancements.Persistence;
using AzRedisEnhancements.Shared;

namespace AzRedisEnhancements.Logging
{
    internal abstract class MachineStatLogger : IDisposable
    {
        protected TimeSpan _logFrequency;
        private bool _disposed;
        protected StatsBuffer<MachineStat> _buf;

        public MachineStatLogger(TimeSpan logFrequency, StatsBuffer<MachineStat> buf)
        {
            if (logFrequency <= TimeSpan.Zero)
            {
                throw new ArgumentOutOfRangeException("logFrequency");
            }

            _logFrequency = logFrequency;
            _buf = buf;
        }

        /// <summary>
        /// Calls GetStat() and passes the result to LogStat on the TimeInterval specified by logFrequency
        /// </summary>
        public async void StartLogging()
        {
            try
            {
                MachineStat stat;
                while (!_disposed)
                {
                    await Task.Delay(_logFrequency);

                    stat = GetStat();

                    LogStat(stat);

                    stat = null;
                }
            }
            catch (Exception e)
            {
                Trace.WriteLine(e);
            }
        }

        /// <summary>
        /// Writes an IMachineStat to the front of a circular buffer in persistence layer
        /// </summary>
        public void LogStat(MachineStat stat)
        {
            _buf.PushStat(stat);
        }

        /// <summary>
        /// Returns an IMachineStat about the system (threadpool, bandwidth, CPU, etc.)
        /// </summary>
        public abstract MachineStat GetStat();

        /// <summary>
        /// Stops logging when called
        /// </summary>
        public void Dispose()
        {
            _disposed = true;
        }
    }
}
