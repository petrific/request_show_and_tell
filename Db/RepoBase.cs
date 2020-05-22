using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using MongoDB.Driver;

namespace request_show_and_tell.Db 
{
    public abstract class RepoBase<T> where T: IAggregate
    {
        protected IMongoClient client;
        protected IMongoDatabase database;

        protected IMongoCollection<T> collection;

        public RepoBase()
        {
            this.client = new MongoClient("mongodb://localhost:27017");
            this.database = this.client.GetDatabase("requestDb");
            this.collection = this.GetCollection();
        }

        protected abstract IMongoCollection<T> GetCollection();

        public async Task<T> FindOne(Guid id)
        {
            var filterDef = Builders<T>.Filter.Eq("_id", id);
            return (await this.collection.FindAsync<T>(filterDef)).FirstOrDefault();
        }

        public async Task<IEnumerable<T>> FindAll(bool active = true)
        {
            var filterDef = Builders<T>.Filter.Eq("Active", active);
            return (await this.collection.FindAsync<T>(filterDef)).ToList();
        }

        public async Task Insert(T newDoc){
            await this.collection.InsertOneAsync(newDoc);
        }

        public async Task Update(T newDoc)
        {
            var filterDef = Builders<T>.Filter.Eq("_id", newDoc.Id);
            await this.collection.FindOneAndReplaceAsync<T>(filterDef, newDoc);       
        }
    }

    public interface IAggregate
    {
        Guid Id { get; set;}
        bool Active { get; set;}
    }
}