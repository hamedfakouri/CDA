using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MongoDB.Bson;
using MongoDB.Driver;
using MongoDB.Driver.Builders;

namespace Framework.Core
{
    public interface ILogService<T>
    {
        IEnumerable<T> GetLogs();

        T GetLog(ObjectId id);


        T Create(T p);


        void Update(ObjectId id, T p);

        void Remove(ObjectId id);
    }

    public interface IApiLogService :ILogService<ApiLog>
    {
        


    }
    public class ApiLogService : LogService, IApiLogService
    {

        public ApiLogService(MongoSetting mongoSetting) : base(mongoSetting)
        {

            filter = new BsonDocument();
        }


    }

    public class LogService :ILogService <ApiLog>
    {
        protected MongoClient _client;
        protected BsonDocument filter = null;
        protected IMongoDatabase _db;
        public LogService(MongoSetting mongoSetting)
        {
            _client = new MongoClient(mongoSetting.serverUrl);
            _db = _client.GetDatabase(mongoSetting.databaseName);
        }

     
        public IEnumerable<ApiLog> GetLogs()
        {


            var collection = _db.GetCollection<ApiLog>("ApiLogs");
            var docs = collection.Find(filter).ToList();
            return docs;

        }


        public ApiLog GetLog(ObjectId id)
        {
            var res = Query<ApiLog>.EQ(p => p.Id, id);
            return null;
            //  return _db.GetCollection<ApiLog>("ApiLogs").InsertOne(res);
        }

        public ApiLog Create(ApiLog p)
        {
           
            
            _db.GetCollection<ApiLog>("ApiLogs").InsertOne(p);
            return p;
        }

        public void Update(ObjectId id, ApiLog p)
        {
            p.Id = id;
            var res = Query<ApiLog>.EQ(pd => pd.Id, id);
            var operation = Update<ApiLog>.Replace(p);
            //_db.GetCollection<ApiLog>("ApiLogs").UpdateOne(res, operation);
        }
        public void Remove(ObjectId id)
        {
            var res = Query<ApiLog>.EQ(e => e.Id, id);
            // var operation = _db.GetCollection<ApiLog>("ApiLogs").Remove(res);
        }

    }


    
}
