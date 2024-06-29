using AutoMapper;
using MongoDB.Driver;
using MongoDbNight.Dtos.OrderDtos;
using MongoDbNight.Dtos.ProductDtos;
using MongoDbNight.Entities;
using MongoDbNight.Settings;

namespace MongoDbNight.Services.OrderServices
{
    public class OrderService : IOrderService
    {
        private readonly IMongoCollection<Order> _ordersCollection;
        private readonly IMongoCollection<Customer> _customerCollection;
        private readonly IMapper _mapper;

        public OrderService(IMapper mapper,IDatabaseSettings _databaseSettings)
        {
            var client = new MongoClient(_databaseSettings.ConnectionString);
            var database = client.GetDatabase(_databaseSettings.DatabaseName);
            _ordersCollection = database.GetCollection<Order>(_databaseSettings.OrderCollectionName);
            _customerCollection = database.GetCollection<Customer>(_databaseSettings.CustomerCollectionName);
            _mapper = mapper;
        }
        public async Task CreateOrderAsync(CreateOrderDto createOrderDto)
        {
            var value = _mapper.Map<Order>(createOrderDto);
            await _ordersCollection.InsertOneAsync(value);
        }

        public async Task DeleteOrderAsync(string id)
        {
            await _ordersCollection.DeleteOneAsync(id);
        }

        public async Task<List<ResultOrderDto>> GetAllOrderAsync()
        {
            var orders = await _ordersCollection.Find(x=> true).ToListAsync();
            var customers = await _customerCollection.Find(x=> true).ToListAsync();

            var result = orders.Select(order =>
            {
                var customer = customers.FirstOrDefault(c => c.CustomerId == order.CustomerId);
                var resultOrderDto = _mapper.Map<ResultOrderDto>(order);
                if (customer != null)
                {
                    resultOrderDto.CustomerName = customer.Name+' '+customer.Lastname;
                }
                return resultOrderDto;
            }).ToList();

            return result;
        }

        public async Task<GetByIdOrderDto> GetByIdOrderAsync(string id)
        {
            var value = await _ordersCollection.Find<Order>(x=>x.OrderId==id).FirstOrDefaultAsync();
            return _mapper.Map<GetByIdOrderDto>(value);
        }

        public async Task UpdateOrderAsync(UpdateOrderDto updateOrderDto)
        {
            var value = _mapper.Map<Order>(updateOrderDto);
            await _ordersCollection.FindOneAndReplaceAsync(x=>x.OrderId==updateOrderDto.OrderId, value);
        }

        public async Task<List<ResultOrderDto>> GetAllOrderCustomerIdAsync(string id)
        {
            var orders = await _ordersCollection.Find<Order>(x => x.CustomerId==id).ToListAsync();
            var customers = await _customerCollection.Find(x => true).ToListAsync();

            var result = orders.Select(order =>
            {
                var customer = customers.FirstOrDefault(c => c.CustomerId == order.CustomerId);
                var resultOrderDto = _mapper.Map<ResultOrderDto>(order);
                if (customer != null)
                {
                    resultOrderDto.CustomerName = customer.Name + ' ' + customer.Lastname;
                }
                return resultOrderDto;
            }).ToList();

            return result;
        }

    }
}
