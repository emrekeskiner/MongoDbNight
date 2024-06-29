using MongoDbNight.Dtos.OrderItemDtos;
using MongoDbNight.Services.OrderItemItemServices;

namespace MongoDbNight.Services.OrderItemServices
{
    public class OrderItemService : IOrderItemService
    {
        public Task CreateOrderItemAsync(CreateOrderItemDto createOrderItemDto)
        {
            throw new NotImplementedException();
        }

        public Task DeleteOrderItemAsync(string id)
        {
            throw new NotImplementedException();
        }

        public Task<List<ResultOrderItemDto>> GetAllOrderItemAsync()
        {
            throw new NotImplementedException();
        }

        public Task<GetByIdOrderItemDto> GetByIdOrderItemAsync(string id)
        {
            throw new NotImplementedException();
        }

        public Task UpdateOrderItemAsync(UpdateOrderItemDto updateOrderItemDto)
        {
            throw new NotImplementedException();
        }
    }
}
