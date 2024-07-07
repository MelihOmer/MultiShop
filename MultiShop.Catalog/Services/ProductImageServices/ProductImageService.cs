using AutoMapper;
using MongoDB.Driver;
using MultiShop.Catalog.Dtos.ProductImageDtos;
using MultiShop.Catalog.Entities;
using MultiShop.Catalog.Services.ProductImageServices;
using MultiShop.Catalog.Settings;

namespace MultiShop.Catalog.Services.ProductImageServices
{
    public class ProductImageService : IProductImageService
    {


        private readonly IMongoCollection<ProductImage> _ProductImageCollection;
        private readonly IMapper _mapper;
        public ProductImageService(IMapper mapper, IDatabaseSettings _dbSettings)
        {
            var client = new MongoClient(_dbSettings.ConnectionString);
            var database = client.GetDatabase(_dbSettings.DatabaseName);
            _ProductImageCollection = database.GetCollection<ProductImage>(_dbSettings.ProductImageCollectionName);
            _mapper = mapper;
        }
        public async Task CreateProductImageAsync(CreateProductImageDto ProductImageDto)
        {
            var value = _mapper.Map<ProductImage>(ProductImageDto);
            await _ProductImageCollection.InsertOneAsync(value);
        }

        public async Task DeleteProductImageAsync(string id)
        {
            await _ProductImageCollection.DeleteOneAsync(x => x.ProductImageId == id);
        }

        public async Task<List<ResultProductImageDto>> GetAllProductImageAsync()
        {
            var values = await _ProductImageCollection.Find(x => true).ToListAsync();

            return _mapper.Map<List<ResultProductImageDto>>(values);
        }

        public async Task<GetByIdProductImageDto> GetByIdProductImageAsync(string id)
        {
            var value = await _ProductImageCollection.Find(x => x.ProductImageId == id).FirstOrDefaultAsync();
            return _mapper.Map<GetByIdProductImageDto>(value);
        }

        public async Task UpdateProductImageAsync(UpdateProductImageDto ProductImageDto)
        {
            var value = _mapper.Map<ProductImage>(ProductImageDto);
            await _ProductImageCollection.FindOneAndReplaceAsync(x => x.ProductImageId == ProductImageDto.ProductImageId, value);
        }
    }
}
