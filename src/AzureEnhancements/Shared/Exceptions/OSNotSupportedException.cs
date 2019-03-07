using System;

namespace StatsEngine.Shared
{
    public class OSNotSupportedException : Exception
    {
        public OSNotSupportedException()
        {
            Console.WriteLine("Only Windows is supported at the moment.");
        }
    }
}
