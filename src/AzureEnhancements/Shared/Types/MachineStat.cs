using System;

namespace AzRedisEnhancements.Shared
{
    // Base for all stat types about with the client's machine

    public abstract class MachineStat 
    {
        public MachineStat(StatType type)
        {
            statType = type;
        }

        public StatType statType;

        public DateTimeOffset TimeStamp { get; set; }

        public abstract string ToLogString();
    }
}
