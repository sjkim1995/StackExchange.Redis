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
        public MachineStat GetSingleRecentStat(StatType statType)
        {
            var buf = GetStatBuffer(statType);
            MachineStat latestStat = buf.PeekFront();

            return latestStat;
        }

        /// <summary>
        // Retrieves the most recent stat from each StatBuffer and return them as a newline-separated string.
        /// </summary>
        public string GetAllRecentStats()
        {
            var sb = new StringBuilder();

            // get the latest statistic for each StatType and append to sb
            foreach (StatType type in Enum.GetValues(typeof(StatType)))
            {
                string statMessage;
                try
                {
                    MachineStat stat = GetSingleRecentStat(type);
                    statMessage = stat.ToLogString();
                }
                catch(Exception)
                {
                    statMessage = $"Latest stat not available for {StatTypeExtentions.ToFriendlyString(type)}";
                }
                sb.AppendLine(statMessage);
            }

            return sb.ToString();
        }

    }
}
