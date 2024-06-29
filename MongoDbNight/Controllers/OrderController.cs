using Microsoft.AspNetCore.Mvc;
using MongoDbNight.Dtos.OrderDtos;
using MongoDbNight.Services.CustomerServices;
using MongoDbNight.Services.OrderServices;

namespace MongoDbNight.Controllers
{
   
    public class OrderController : Controller
    {
        private readonly IOrderService _orderService;
        private readonly ICustomerService _customerService;

        public OrderController(IOrderService orderService, ICustomerService customerService)
        {
            _orderService = orderService;
            _customerService = customerService;
        }

        [HttpPost]
        public async Task<IActionResult> CreateOrder(CreateOrderDto createOrderDto)
        {
            await _orderService.CreateOrderAsync(createOrderDto);
            return RedirectToAction("OrderList");
        }

        public async Task<IActionResult> OrderList()
        {
            var values = await _orderService.GetAllOrderAsync();
            return View(values);
        }

        public async Task<IActionResult> CustomerOrderList(string id)
        {
           
            var values = await _orderService.GetAllOrderCustomerIdAsync(id);
           
            return View(values);
        }
    }
}
