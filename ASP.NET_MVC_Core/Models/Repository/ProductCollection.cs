using MongoDB.Bson;
using MongoDB.Driver;
using ASP.NET_MVC_Core.Models.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;


namespace ASP.NET_MVC_Core.Models.Repository
{
    public class ProductCollection
    {
        internal MongoDBRespository _repo = new MongoDBRespository();

//The IMongoCollection interface defines methods to insert, update, delete, and retrieve documents from a collection.
//It also provides methods to create indexes and execute database commands.

        public IMongoCollection<Product> Collection;
 //The IMongoCollection interface is part of the MongoDB.Driver namespace and
 //can be used to interact with a MongoDB database from a C# application.
        public ProductCollection()
        {
   //Use the GetCollection() method to access the MongoCollection object,
   //which is used to represent the specified collection
   // here we were created new MongoDB Collection with Products name
            this.Collection = _repo.db.GetCollection<Product>("Products");
        }
   //Use the BsonDocument class to insert a document into the collection
        public void InsertContact(Product contact)
        {
          //InsertOneAsync: Inserts a single document into the collection asynchronously.
            this.Collection.InsertOneAsync(contact);
        }

        public List<Product> GetAllProduct()
        {
            var query = this.Collection

  //Find: Returns a cursor that can be used to iterate over documents in the collection.
                .Find(new BsonDocument())
                .ToListAsync();
            return query.Result;
        }

        public Product GetProductById(string id)
        {
            var product = this.Collection.Find(
                    new BsonDocument { { "_id", new ObjectId(id) } })
                    .FirstAsync()
                    .Result;
            return product;
        }

        public void UpdateContact(string id, Product contact)
        {
            if(id !=null)
            contact.Id = new ObjectId(id);

            var filter = Builders<Product>
                .Filter
                .Eq(s => s.Id, contact.Id);
            this.Collection.ReplaceOneAsync(filter, contact);

        }

        public void DeleteContact(string productId)
        {
            Product contact = new Product();
            contact.Id = new ObjectId(productId);
            var filter = Builders<Product>.Filter.Eq(s => s.Id, contact.Id);

    // DeleteOneAsync: Deletes a single document from the collection that matches the specified filter.
            this.Collection.DeleteOneAsync(filter);

        }

    }
}
