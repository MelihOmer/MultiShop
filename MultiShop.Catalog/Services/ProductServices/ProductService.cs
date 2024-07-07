using AutoMapper;
using MongoDB.Driver;
using MultiShop.Catalog.Dtos.ProductDtos;
using MultiShop.Catalog.Entities;
using MultiShop.Catalog.Settings;

namespace MultiShop.Catalog.Services.ProductServices
{
    public class ProductService : IProductService
    {
        private readonly IMapper _mapper;
        private readonly IMongoCollection<Product> _productCollection;
        public ProductService(IMapper mapper,IDatabaseSettings dbSettings)
        {
            var client = new MongoClient(dbSettings.ConnectionString);
            var database = client.GetDatabase(dbSettings.DatabaseName);
            _productCollection = database.GetCollection<Product>(dbSettings.ProductCollectionName);
            _mapper = mapper;
        }
        public async Task CreateProductAsync(CreateProductDto ProductDto)
        {
            var value = _mapper.Map<Product>(ProductDto);
            await _productCollection.InsertOneAsync(value);
        }

        public async Task DeleteProductAsync(string id)
        {
            await _productCollection.DeleteOneAsync(x=> x.ProductId == id);
        }

        public async Task<List<ResultProductDto>> GetAllProductAsync()
        {
            var values = await _productCollection.Find(x => true).ToListAsync();
            return _mapper.Map<List<ResultProductDto>>(values);
        }

        public async Task<GetByIdProductDto> GetByIdProductAsync(string id)
        {
            var value = await _productCollection.Find(x => x.ProductId == id).FirstOrDefaultAsync();
            return _mapper.Map<GetByIdProductDto>(value);
        }

        public async Task UpdateProductAsync(UpdateProductDto ProductDto)
        {
            var value = _mapper.Map<Product>(ProductDto);
            await _productCollection.FindOneAndReplaceAsync(x => x.ProductId == ProductDto.ProductId, value);
        }
    }
}
