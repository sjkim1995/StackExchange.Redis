using System;
using System.Runtime.InteropServices;


namespace StatsEngine.Shared
{

    class OSNotSupportedException : Exception
    {
        public OSNotSupportedException()
        {
            Console.WriteLine("We only support Windows/Linux/OSX");
        }

#if NET472
        public OSNotSupportedException(OSPlatform platform, StatType statType)
        {
            Console.WriteLine($"We currently do not support logging for {statType.ToString()} on {platform.ToString()}");
        }
#endif

    }
}
