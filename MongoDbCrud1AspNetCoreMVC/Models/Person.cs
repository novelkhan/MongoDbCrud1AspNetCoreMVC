using MongoDB.Bson.Serialization.Attributes;
using MongoDB.Bson;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MongoDbCrud1AspNetCoreMVC.Models
{
    public class Person
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string PersonId { get; set; }

        public string PersonName { get; set; }

        public int PersonAge { get; set; }

        public string HomeTown { get; set; }
    }
}
