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
        /// Set of type <see cref="ConnectionFailureType"/> that maintains the subset of ConnectionFailureTypes that
        /// AzStatsEngine should output statistics on when a <see cref="RedisConnectionException"/> is thrown
        /// </summary>
        private readonly ISet<ConnectionFailureType> includedConnectionFailureTypes = new HashSet<ConnectionFailureType>()
        {
            ConnectionFailureType.UnableToResolvePhysicalConnection,
            ConnectionFailureType.SocketFailure,
            ConnectionFailureType.InternalFailure,
            ConnectionFailureType.SocketClosed,
            ConnectionFailureType.ConnectionDisposed
        };

        /// <summary>
        /// Statistics logger for client-side metrics such as Bandwidth, CPU, PageFaults, etc.
        /// </summary>
        internal AzStatsEngine StatsEngine { get; private set; }

        internal bool IncludeAzStatsOnConnectionFailure(ConnectionFailureType failureType)
        {
            return includedConnectionFailureTypes.Contains(failureType);
        }

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
