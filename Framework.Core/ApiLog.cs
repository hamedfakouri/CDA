using System;
using System.Collections.Generic;
using System.Text;
using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace Framework.Core
{
    public class ApiLog
    {
        [BsonId]
        public ObjectId Id { get; set; }
        [BsonElement("Request")]
        public string Request { get; set; }
        [BsonElement("Response")]
        public string Response { get; set; }
        [BsonElement("LogStartTime")] public string LogStartTime { get; set; }
        [BsonElement("LogEndTime")] public string LogEndTime { get; set; }
    }
}
