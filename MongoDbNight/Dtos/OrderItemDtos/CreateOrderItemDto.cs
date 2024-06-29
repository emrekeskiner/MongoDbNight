using MongoDB.Bson.Serialization.Attributes;
using MongoDB.Bson;

namespace MongoDbNight.Dtos.OrderItemDtos;

public class CreateOrderItemDto
{
    public string OrderId { get; set; }
    public string ProductId { get; set; }

    public string ProductName { get; set; }

    public decimal Price { get; set; }

    public int Quantity { get; set; }

    public decimal Total => Price * Quantity;
}
