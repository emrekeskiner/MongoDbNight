using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using MongoDbNight.Dtos.ProductDtos;
using MongoDbNight.Services.CategoryServices;
using MongoDbNight.Services.ProductServices;

namespace MongoDbNight.Controllers
{
    public class ProductController : Controller
    {
        private readonly IProductService _productService;
        private readonly ICategoryService _categoryService;

        public ProductController(IProductService productService, ICategoryService categoryService)
        {
            _productService = productService;
            _categoryService = categoryService;
        }

        public async Task<IActionResult> ProductList()
        {
            var values = await _productService.GetAllProductAsync();
            return View(values);
        }

        [HttpGet]
        public async Task<IActionResult> CreateProduct()
        {
            var categories = await _categoryService.GetAllCategoryAsync();
            var categoryList = categories.Select(c => new { c.CategoryId, c.CategoryName }).ToList();
            categoryList.Insert(0, new { CategoryId = (string)null, CategoryName = "Seçiniz" });

            ViewBag.categoryList = new SelectList(categoryList, "CategoryId", "CategoryName");

            return View();
        }
        [HttpPost]
        public async Task<IActionResult> CreateProduct(CreateProductDto createProductDto)
        {
            await _productService.CreateProductAsync(createProductDto);
            return RedirectToAction("ProductList");
        }

        [HttpGet]
        public async Task<IActionResult> UpdateProduct(string id)
        {
            var value = await _productService.GetByIdProductAsync(id);
            //CategoryId ve Name Alanını doldur
            var categories = await _categoryService.GetAllCategoryAsync();
            ViewBag.categoryList = new SelectList(categories, "CategoryId", "CategoryName");

            return View(value);
        }
        [HttpPost]
        public async Task<IActionResult> UpdateProduct(UpdateProductDto updateProductDto)
        {
            await _productService.UpdateProductAsync(updateProductDto);
            return RedirectToAction("ProductList");
        }

        public async Task<IActionResult> DeleteProduct(string id)
        {
            await _productService.DeleteProductAsync(id);
            return RedirectToAction("ProductList");
        }
    }
}
