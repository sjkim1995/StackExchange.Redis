﻿using System;
using System.Threading;
using System.Threading.Tasks;
using StackExchange.Redis;

namespace TestConsole
{
    class Program
    {
        const int KB = 1024;
        const int MB = KB * 1024;

        static async Task Main(string[] args)
        {
            var conn = Connect();
            IDatabase cache = conn.GetDatabase();

            await Task.Delay(20000);

            cache.StringSet("foo", 423);

            conn.Dispose();
        }

        public static void AddData(IDatabase cache, string key, int valueSize)
        {
            var rand = new Random();
            byte[] value = new byte[valueSize];
            rand.NextBytes(value);
            cache.StringSet(key, value);
        }

        private static ConnectionMultiplexer Connect()
        {
            string configString = "SETester.redis.cache.windows.net:6380,password=moAWjI4RLFDQH8p5go2fTKa6+8ZzqjVeoceX2UwqXUs=,ssl=True,abortConnect=False";
            ConfigurationOptions options = ConfigurationOptions.Parse(configString);
            options.SyncTimeout = 1; //ms
            options.IncludeAzStats = true;
            return ConnectionMultiplexer.Connect(options);
        }
    }
}
