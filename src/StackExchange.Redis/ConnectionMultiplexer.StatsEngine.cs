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
        public AzStatsEngine statsEngine = new AzStatsEngine();
    }
}
