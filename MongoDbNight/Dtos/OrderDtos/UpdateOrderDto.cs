using MongoDB.Bson.Serialization.Attributes;
using MongoDB.Bson;
using MongoDbNight.Entities;

namespace MongoDbNight.Dtos.OrderDtos
{
    public class UpdateOrderDto
    {
        public string OrderId { get; set; }

        public string CustomerId { get; set; }

        public List<OrderItem> Items { get; set; }

        public DateTime OrderDate { get; set; } = DateTime.Now;

        public decimal TotalAmount { get; set; }
    }
}
