using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AzRedisEnhancements.Shared;

namespace AzRedisEnhancements.Shared
{
    public class StatBufferTypeException : Exception
    {
        public StatType itemType;
        public StatType bufferType;

        public StatBufferTypeException(StatType itemType, StatType bufferType)
        {
            this.itemType = itemType;
            this.bufferType = bufferType;
        }
    }
}
