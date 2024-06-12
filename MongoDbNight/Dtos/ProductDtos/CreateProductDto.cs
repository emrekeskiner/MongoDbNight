using MongoDB.Bson.Serialization.Attributes;
using MongoDB.Bson;

namespace MongoDbNight.Dtos.ProductDtos
{
    public class CreateProductDto
    {
        public string ProductName { get; set; }
        public Decimal Price { get; set; }
        public int Stock { get; set; }
        public string CategoryId { get; set; }
        
    }
}
