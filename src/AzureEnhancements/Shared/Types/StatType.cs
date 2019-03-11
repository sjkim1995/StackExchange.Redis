namespace AzRedisEnhancements.Shared
{
    public enum StatType
    {
        Bandwidth,
        CPU,
        ThreadPool,
        PageFaults
    }

    public static class StatTypeExtentions
    {
        public static string ToFriendlyString(this StatType type)
        {
            switch (type)
            {
                case StatType.Bandwidth:
                    return "Bandwidth";
                case StatType.CPU:
                    return "CPU";
                case StatType.ThreadPool:
                    return "ThreadPool";
                case StatType.PageFaults:
                    return "Page Faults";
                default:
                    return "Type not found";
            }
        }
    }
}
