using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace MongoDbNight.Entities
{
    public class Product
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string ProductId { get; set; }
        public string ProductName { get; set; }
        [BsonRepresentation(BsonType.Decimal128)]
        public Decimal Price { get; set; }
        public int Stock { get; set; }
        public string? CategoryId { get; set; }
    }
}
