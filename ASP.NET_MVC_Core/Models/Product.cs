using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Runtime.Intrinsics.X86;
using System.Web;

namespace ASP.NET_MVC_Core.Models
{
    public class Product
    {
    //The BsonId attribute specifies a field that must always be unique.
        [BsonId]
        public ObjectId Id { get; set; }
        [Required]
    //The BsonElement attribute maps to the BSON field name.
        [BsonElement("ProductName")]
        public string ProductName { get; set; }
        [Required]
        [BsonElement("BarcodeNumber")]
        public string BarcodeNumber { get; set; }
        [Required]
        [BsonElement("Quantity")]
        public string Quantity { get; set; }

        // BsonDocument --->
        // Use the BsonDocument class to insert a document into the collection.Within the parentheses of InsertOne(), include an object that contains the document data. For example:
        // var accountsCollection = database.GetCollection<BsonDocument>("account");

        // var document = new BsonDocument
        /*{
      { "account_id", "MDB829001337" },
      { "account_holder", "Linus Torvalds" },
      { "account_type", "checking" },
      { "balance", 50352434 }
         };*/

        //accountsCollection.InsertOne(document);


    }
}
