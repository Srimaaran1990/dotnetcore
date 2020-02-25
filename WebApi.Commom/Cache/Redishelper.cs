using StackExchange.Redis;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.IO;
using System.Linq;
using System.Runtime.Serialization.Formatters.Binary;
using System.Web;

namespace DotnetCore.Web
{
    public class Redishelper
    {
        private static readonly Lazy<ConnectionMultiplexer> LazyConnection;

        static Redishelper()
        {
            var elasticCache = "localhost";// ConfigurationManager.AppSettings["ElasticCache"].ToString();
            var configurationOptions = new ConfigurationOptions
            {
                EndPoints = { elasticCache }
            };

            LazyConnection = new Lazy<ConnectionMultiplexer>(() => ConnectionMultiplexer.Connect(configurationOptions));
        }

        public static ConnectionMultiplexer Connection => LazyConnection.Value;

        public static IDatabase RedisCache => Connection.GetDatabase();

        public static void SetItem<T>(string key, TimeSpan period, T value)
        {
            IDatabase db = Redishelper.RedisCache;
            db.StringSet(key, ToByteArray<T>(value));
        }

        public static void DeleteItem(string key)
        {
            IDatabase db = Redishelper.RedisCache;
            db.KeyDelete(key);
        }

        public static bool KeyExists(string key)
        {
            IDatabase db = Redishelper.RedisCache;
            if (db.KeyExists(key))
            {
                return true;
            }
            return false;
        }

        public static T GetItem<T>(string key)
        {
            IDatabase db = Redishelper.RedisCache;
            RedisValue redisResult = db.StringGet(key);
            T objResult = FromByteArray<T>(redisResult);
            return objResult;
        }

        public static byte[] ToByteArray<T>(T obj)
        {
            if (obj == null)
                return null;
            BinaryFormatter bf = new BinaryFormatter();
            using (MemoryStream ms = new MemoryStream())
            {
                bf.Serialize(ms, obj);
                return ms.ToArray();
            }
        }

        public static T FromByteArray<T>(byte[] data)
        {
            if (data == null)
                return default(T);
            BinaryFormatter bf = new BinaryFormatter();
            using (MemoryStream ms = new MemoryStream(data))
            {
                object obj = bf.Deserialize(ms);
                return (T)obj;
            }
        }

    }
}