using System;

namespace StatsEngine.Shared
{
    // Base class for all stat types collected about the client machine

    public abstract class MachineStat
    {

        public MachineStat()
        {
           
        }

        public DateTimeOffset TimeStamp { get; set; }

        public abstract string ToLogString();

    }
}
