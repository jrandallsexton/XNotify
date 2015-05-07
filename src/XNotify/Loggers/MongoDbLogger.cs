
using System;

using MongoDB.Bson;
using MongoDB.Driver;

using XNotify.Contracts;

namespace XNotify.Loggers
{
    public class MongoDbLogger : INotificationLogger
    {
        public void Log(string message)
        {
            var client = new MongoClient();
            var db = client.GetDatabase("log");
            var collection = db.GetCollection<BsonDocument>("logs");
            var log = new BsonDocument();
            log["Created"] = DateTime.Now;
            log["LogText"] = message;
            collection.InsertOneAsync(log);
            Console.WriteLine(log);
        }

        public void Log(LogEntry exception)
        {
            throw new NotImplementedException();
        }
    }
}
