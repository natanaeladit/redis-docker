using StackExchange.Redis;
using System;

namespace ConsoleApp
{
    class Program
    {
        static void Main(string[] args)
        {
            ConnectionMultiplexer redis = ConnectionMultiplexer.Connect("192.168.99.100");
            Console.WriteLine("Connected!");

            IDatabase db = redis.GetDatabase();

            string value = "abcdefg";
            db.StringSetAsync("mykey", value, flags: CommandFlags.FireAndForget);
            Console.WriteLine("mykey is stored!");

            string valueStored = db.StringGet("mykey");
            Console.WriteLine("Read mykey from redis: " + valueStored);

            Console.ReadLine();
        }
    }
}
