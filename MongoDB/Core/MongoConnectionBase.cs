using MongoDB.Driver;

namespace MongoDB.Core
{
    public abstract class MongoConnectionBase<TCollection> where TCollection : CollectionBase
    {
        protected MongoClient Connection { get; set; }
        protected IMongoCollection<TCollection> Collection { get; set; }

        protected MongoConnectionBase()
        {
            Connection = new MongoClient("mongodb://admin:admin@localhost:27017/admin");

            var db = Connection.GetDatabase("admin");
            Collection = db.GetCollection<TCollection>(typeof(TCollection).Name);
        }
    }
}
