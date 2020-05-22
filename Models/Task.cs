using System;
using System.Collections;
using System.Collections.Generic;
using MongoDB.Bson.Serialization.Attributes;
using request_show_and_tell.Db;

namespace request_show_and_tell.Models
{
    public class Thing : IAggregate
    {
        [BsonId]
        public Guid Id { get; set;}

        public bool Active { get; set; }

        public Thing()
        {
            this.Id = Guid.Empty;
            this.Active = true;
        }
    }
}