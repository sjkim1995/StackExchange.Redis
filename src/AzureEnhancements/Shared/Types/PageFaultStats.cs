
using System;

namespace AzRedisEnhancements.Shared
{
    public class PageFaultStats : MachineStat
    {
        public PageFaultStats() : base(StatType.PageFaults) { }

        public uint LastPageFaultsPerSecond { get; set; }

        public uint LastPageReadsFaultedPerSecond { get; set; }

        public string LogMessage { get; set; }

        public override string ToLogString()
        {
            return String.Format("[{0}] Page faults per sec: [reads: {1}, faults: {2}]", TimeStamp, LastPageFaultsPerSecond, LastPageReadsFaultedPerSecond);
        }

    }
}
