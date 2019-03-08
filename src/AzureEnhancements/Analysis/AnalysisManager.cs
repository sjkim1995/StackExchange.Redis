using System;
using System.Text;
using AzRedisEnhancements.Persistence;
using AzRedisEnhancements.Shared;

namespace AzRedisEnhancements.Analysis
{
    public class AnalysisManager
    {
        private PersistenceManager _persistenceMgr;

        public AnalysisManager(PersistenceManager persistenceMgr)
        {
            _persistenceMgr = persistenceMgr;
        }

        public StatsBuffer<MachineStat> GetStatBuffer(StatType statType)
        {
            return _persistenceMgr.GetBuffer(statType);
        }

        /// <summary>
        /// Returns the most recent stat for the given type.
        /// </summary>
        /// <param name="statType"></param>
        public MachineStat GetMostRecentStat(StatType statType)
        {
            var buf = GetStatBuffer(statType);
            MachineStat latestStat = buf.PeekFront();

            return latestStat;
        }

        /// <summary>
        // Returns the most recent statistic from each StatBuffer as a concatenated string.
        /// </summary>
        public string GetStatsInLogFormat()
        {
            var sb = new StringBuilder();

            // get the latest statistic for each StatType and append to sb
            foreach (StatType type in Enum.GetValues(typeof(StatType)))
            {
                string statMessage = GetMostRecentStat(type).ToLogString();
                sb.AppendLine(statMessage);
            }

            return sb.ToString();
        }

    }
}
