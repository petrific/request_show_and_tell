using MongoDB.Driver;
using request_show_and_tell.Models;

namespace request_show_and_tell.Db 
{
    public class ThingRepo : RepoBase<Thing>
    {
        protected override IMongoCollection<Thing> GetCollection()
        {
            return this.database.GetCollection<Thing>("Things");
        }
    }
}