using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AzRedisEnhancements;

namespace StackExchange.Redis
{
    public partial class ConnectionMultiplexer
    {
        /// <summary>
        /// Statistics logger for client-side metrics such as Bandwidth, CPU, PageFaults, etc.
        /// </summary>
        internal AzStatsEngine StatsEngine { get; private set; }

        partial void OnCreateStatsEngine(ConfigurationOptions configuration)
        {
            StatsEngine = configuration.IncludeAzStats ? new AzStatsEngine() : null;
        }

        partial void OnCloseStatsEngine()
        {
            StatsEngine = null;
        }
    }
}
