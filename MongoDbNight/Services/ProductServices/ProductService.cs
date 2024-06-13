using AutoMapper;
using MongoDB.Driver;
using MongoDbNight.Dtos.ProductDtos;
using MongoDbNight.Entities;
using MongoDbNight.Settings;

namespace MongoDbNight.Services.ProductServices
{
    public class ProductService : IProductService
    {
        public readonly IMongoCollection<Product> _productCollection;
        private readonly IMongoCollection<Category> _categoryCollection;
        public readonly IMapper _mapper;

        public ProductService(IMapper mapper, IDatabaseSettings _databaseSettings)
        {
            var client =new MongoClient(_databaseSettings.ConnectionString);
            var database = client.GetDatabase(_databaseSettings.DatabaseName);
            _productCollection = database.GetCollection<Product>(_databaseSettings.ProductCollectionName);
            _categoryCollection = database.GetCollection<Category>(_databaseSettings.CategoryCollectionName);
            _mapper = mapper;
        }

        public async Task CreateProductAsync(CreateProductDto createProductDto)
        {
            var value = _mapper.Map<Product>(createProductDto);
            await _productCollection.InsertOneAsync(value);
        }

        public async Task DeleteProductAsync(string id)
        {
            await _productCollection.DeleteOneAsync(x=>x.ProductId == id);
        }

        public async Task<List<ResultProductDto>> GetAllProductAsync()
        {

            var products = await _productCollection.Find(x => true).ToListAsync();
            var categories = await _categoryCollection.Find(x => true).ToListAsync();

            var result = products.Select(product =>
            {
                var category = categories.FirstOrDefault(c => c.CategoryId == product.CategoryId);
                var resultProductDto = _mapper.Map<ResultProductDto>(product);
                if(category != null) { 
                resultProductDto.CategoryName = category.CategoryName; 
                }
                return resultProductDto;
            }).ToList();

            return result;
        }

        public async Task<GetByIdProductDto> GetByIdProductAsync(string id)
        {
            var value = await _productCollection.Find(x=>x.ProductId==id).FirstOrDefaultAsync();
            return _mapper.Map<GetByIdProductDto>(value);
        }

        public async Task UpdateProductAsync(UpdateProductDto updateProductDto)
        {
            var value = _mapper.Map<Product>(updateProductDto);
            await _productCollection.FindOneAndReplaceAsync(x=>x.ProductId== updateProductDto.ProductId,value);
        }
    }
}
