using System;

namespace AzRedisEnhancements.Shared
{
    public class OSNotSupportedException : Exception
    {
        public OSNotSupportedException() : base("Only Windows is supported at this time.")
        {
        }
    }
}
