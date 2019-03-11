using System;
using System.Collections.Generic;
using AzRedisEnhancements.Shared;

namespace AzRedisEnhancements.Persistence
{
    public partial class PersistenceManager
    {
        private Dictionary<StatType, StatsBuffer<MachineStat>> bufferMap;

        /// <summary>
        /// Creates a buffer for each type of statistic we are collecting and adds it to the buffer map
        /// </summary>
        private void InitBufferMap()
        {
            bufferMap = new Dictionary<StatType, StatsBuffer<MachineStat>>();

            foreach (StatType type in Enum.GetValues(typeof(StatType)))
            {
                AddNewBuffer(type);
            }
        }

        /// <summary>
        /// Adds a new buffer of the given type to the buffer map
        /// </summary>
        public void AddNewBuffer(StatType type)
        {
            bufferMap.Add(type, new StatsBuffer<MachineStat>(type, capacity));
        }

        public StatsBuffer<MachineStat> GetBuffer(StatType type)
        {
            return bufferMap[type];
        }

        /// <summary>
        /// Removes the buffer of the given type from the buffer map
        /// </summary>
        public void RemoveBuffer(StatType type)
        {
            bufferMap.Remove(type);
        }

        /// <summary>
        /// Empties the buffer of the given type from the buffer map
        /// </summary>
        public void FlushBuffer(StatType type)
        {
            RemoveBuffer(type);
            AddNewBuffer(type);
        }

        /// <summary>
        /// Calls FlushBuffer on every buffer in the bufferMap
        /// </summary>
        public void FlushAllBuffers()
        {
            foreach (var bufEntry in bufferMap)
            {
                FlushBuffer(bufEntry.Key);
            }
        }
    }
}
