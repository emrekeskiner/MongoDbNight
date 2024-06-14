using Microsoft.AspNetCore.Mvc;
using MongoDbNight.Dtos.CustomerDtos;
using MongoDbNight.Services.CustomerServices;

namespace MongoDbNight.Controllers
{
    public class CustomerController : Controller
    {
        private readonly ICustomerService _customerService;

        public CustomerController(ICustomerService customerService)
        {
            _customerService = customerService;
        }

        public async Task<IActionResult> CustomerList()
        {
            var customers = await _customerService.GetAllCustomerAsync();
            return View(customers);
        }
        [HttpGet]
        public IActionResult CreateCustomer()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> CreateCustomer(CreateCustomerDto createCustomerDto)
        {
            await _customerService.CreateCustomerAsync(createCustomerDto);
            return RedirectToAction("CustomerList");
        }

        [HttpGet]
        public async Task<IActionResult> UpdateCustomer(string id)
        {
            var value = await _customerService.GetByIdCustomerAsync(id);
            return View(value);
        }

        [HttpPost]
        public async Task<IActionResult> UpdateCustomer(UpdateCustomerDto UpdateCustomer)
        {
            await _customerService.UpdateCustomerAsync(UpdateCustomer);
            return RedirectToAction("CustomerList");
        }
    }
}
