using System;
using System.Collections.Generic;
using System.Text;
using MongoDB.Bson;

namespace Framework.Domain
{
    public class Log
    {
        public ObjectId ObjectId { get; set; }

        public string Request { get; set; }

        public string Response { get; set; }
    }
}
