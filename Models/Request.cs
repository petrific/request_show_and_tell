using System;
using System.Collections;
using System.Collections.Generic;
using MongoDB.Bson.Serialization.Attributes;
using request_show_and_tell.Db;

namespace request_show_and_tell.Models
{
    public class Request : IAggregate
    {
        [BsonId]
        public Guid Id { get; set;}

        public bool Active { get; set; }

        public List<Guid> Tasks { get; set;}

        public Request()
        {
            this.Active = true;
            this.Id = Guid.Empty;
            this.Tasks = new List<Guid>();
        }
    }
}