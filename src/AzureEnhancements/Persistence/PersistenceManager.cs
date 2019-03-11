using System;
using System.Collections.Generic;
using AzRedisEnhancements.Shared;

namespace AzRedisEnhancements.Persistence
{
    public partial class PersistenceManager
    {
        private readonly int capacity;

        public PersistenceManager(int capacity)
        {
            this.capacity = capacity;

            InitBufferMap();
        }

        public PersistenceManager() : this(SEConstants.DefaultBufferSize)
        {
        }
    }
}
