using StatsEngine.Persistence;
using StatsEngine.Shared;

namespace StatsEngine.Analysis
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

        public MachineStat GetLatestStat(StatType statType)
        {
            var buf = GetStatBuffer(statType);
            MachineStat latestStat = buf.PeekMostRecentStat();

            return latestStat;
        }

    }
}
