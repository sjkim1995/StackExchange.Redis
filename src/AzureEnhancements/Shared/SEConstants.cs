﻿using System;
using System.Collections.Generic;

namespace AzRedisEnhancements.Shared
{
    public static class SEConstants
    {
        const int BufHistoryTimeInMs = 120000;
        
        // Default log interval in milliseconds for each stat type
        public static Dictionary<StatType, TimeSpan> DefaultLogIntervals = new Dictionary<StatType, TimeSpan>()
        {
            { StatType.Bandwidth, TimeSpan.FromSeconds(5) },
            { StatType.CPU, TimeSpan.FromMilliseconds(250) },
            { StatType.PageFaults, TimeSpan.FromSeconds(1) },
            { StatType.ThreadPool, TimeSpan.FromMilliseconds(500) }
        };

        public static int GetBufferSize(StatType type)
        {
            int sz = (BufHistoryTimeInMs / (int) DefaultLogIntervals[type].TotalMilliseconds);
            return sz;
        }
    }
}
