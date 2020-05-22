using MongoDB.Driver;
using request_show_and_tell.Models;

namespace request_show_and_tell.Db 
{
    public class RequestRepo : RepoBase<Request>
    {
        protected override IMongoCollection<Request> GetCollection()
        {
            return this.database.GetCollection<Request>("Requests");
        }
    }
}