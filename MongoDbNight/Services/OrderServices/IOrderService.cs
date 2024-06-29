using MongoDbNight.Dtos.OrderDtos;

namespace MongoDbNight.Services.OrderServices
{
    public interface IOrderService
    {
        Task<List<ResultOrderDto>> GetAllOrderAsync();
        Task CreateOrderAsync(CreateOrderDto createOrderDto);
        Task UpdateOrderAsync(UpdateOrderDto updateOrderDto);
        Task DeleteOrderAsync(string id);
        Task<GetByIdOrderDto> GetByIdOrderAsync(string id);

        Task<List<ResultOrderDto>> GetAllOrderCustomerIdAsync(string id);
    }
}
