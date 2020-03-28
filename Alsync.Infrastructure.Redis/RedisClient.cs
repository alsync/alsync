using Newtonsoft.Json;
using StackExchange.Redis;
using System;
using System.Threading.Tasks;

namespace Alsync.Infrastructure.Redis
{
    public sealed class RedisClient
    {
        private static readonly object _lockObj = new object();

        private ConnectionMultiplexer redisMultiplexer;

        IDatabase db = null;

        private static RedisClient instance;

        public static RedisClient Instance
        {
            get
            {
                if (instance == null)
                    lock (_lockObj)
                    {
                        if (instance == null)
                            instance = new RedisClient();
                    }
                return instance;
            }
        }

        //public RedisClient()
        //{
        //    //ConnectionMultiplexer conn = ConnectionMultiplexer.Connect("");
        //    //var db = conn.GetDatabase(0);
        //    //db.
        //}

        public void InitConnect(string connectionString)
        {
            try
            {
                redisMultiplexer = ConnectionMultiplexer.Connect(connectionString);
                db = redisMultiplexer.GetDatabase();
            }
            catch (Exception ex)
            {
                redisMultiplexer = null;
                db = null;
                Console.WriteLine(ex.Message);
            }
        }

        public bool SetString(string key, string value, TimeSpan? expiry = null)
        {
            return db.StringSet(key, value.ToString(), expiry);
        }

        public bool SetStringKey<T>(string key, T obj, TimeSpan? expiry = default(TimeSpan?))
        {
            if (db == null)
            {
                return false;
            }
            string json = JsonConvert.SerializeObject(obj);
            return db.StringSet(key, json, expiry);
        }

        public async Task<bool> SetStringAsync(string key, string value, TimeSpan? expiry = null)
        {
            return await db.StringSetAsync(key, value, expiry);
        }

        public string GetString(string key)
        {
            return db.StringGet(key);
        }

        public async Task<string> GetStringAsync(string key)
        {
            return await db.StringGetAsync(key);
        }

        public bool Remove(string key)
        {
            return db.KeyDelete(key);
        }
    }
}
