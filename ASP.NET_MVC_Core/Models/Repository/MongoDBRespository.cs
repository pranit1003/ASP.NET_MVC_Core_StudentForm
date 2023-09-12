using MongoDB.Driver;

namespace ASP.NET_MVC_Core.Models.Repository
{
    public class MongoDBRespository
    {
        // MongoClient is used for connect to server 
        public MongoClient client;
        // IMongoDatabase interface is used for database transactions
        public IMongoDatabase db;

        public MongoDBRespository()
        {
            //here we are connected to server 
            this.client = new MongoClient("mongodb://localhost:27017");
            // if database is not exist we create new one with ExampleMongoDB name
            this.db = this.client.GetDatabase("ExampleMongoDB");
        }

    }
}
