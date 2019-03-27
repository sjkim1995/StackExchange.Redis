using System;
using System.Collections.Generic;

namespace AzRedisEnhancements.Shared
{
    public static class SEConstants
    {
        const int BufHistoryTimeInMs = 120000;
        
        // Default log interval in milliseconds for each stat type
        public static Dictionary<StatType, TimeSpan> DefaultLogIntervals = new Dictionary<StatType, TimeSpan>()
        {
            { StatType.Bandwidth, TimeSpan.FromMilliseconds(5000) },
            { StatType.CPU, TimeSpan.FromMilliseconds(250) },
            { StatType.PageFaults, TimeSpan.FromMilliseconds(1) },
            { StatType.ThreadPool, TimeSpan.FromMilliseconds(500) }
        };

        public static int GetBufferSize(StatType type)
        {
            return (BufHistoryTimeInMs / (int) DefaultLogIntervals[type].TotalMilliseconds);
        }
    }
}
