using MongoDbNight.Dtos.OrderItemDtos;

namespace MongoDbNight.Services.OrderItemItemServices
{
    public interface IOrderItemService
    {
        Task<List<ResultOrderItemDto>> GetAllOrderItemAsync();
        Task CreateOrderItemAsync(CreateOrderItemDto createOrderItemDto);
        Task UpdateOrderItemAsync(UpdateOrderItemDto updateOrderItemDto);
        Task DeleteOrderItemAsync(string id);
        Task<GetByIdOrderItemDto> GetByIdOrderItemAsync(string id);

    }
}
