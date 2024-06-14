using MongoDB.Bson.Serialization.Attributes;
using MongoDB.Bson;

namespace MongoDbNight.Entities
{
    public class OrderItem
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string OrderItemId { get; set; }
        public string OrderId { get; set; }
        public string ProductId { get; set; }  

        public string ProductName { get; set; }  

        [BsonRepresentation(BsonType.Decimal128)]
        public decimal Price { get; set; }  

        public int Quantity { get; set; }

        public decimal Total => Price * Quantity;
    }
}
