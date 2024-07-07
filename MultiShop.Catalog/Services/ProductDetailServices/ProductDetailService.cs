using AutoMapper;
using MongoDB.Driver;
using MultiShop.Catalog.Dtos.ProductDetailDtos;
using MultiShop.Catalog.Entities;
using MultiShop.Catalog.Settings;

namespace MultiShop.Catalog.Services.ProductDetailServices
{
    public class ProductDetailService : IProductDetailService
    {
        private readonly IMongoCollection<ProductDetail> _ProductDetailCollection;
        private readonly IMapper _mapper;
        public ProductDetailService(IMapper mapper, IDatabaseSettings _dbSettings)
        {
            var client = new MongoClient(_dbSettings.ConnectionString);
            var database = client.GetDatabase(_dbSettings.DatabaseName);
            _ProductDetailCollection = database.GetCollection<ProductDetail>(_dbSettings.ProductDetailCollectionName);
            _mapper = mapper;
        }
        public async Task CreateProductDetailAsync(CreateProductDetailDto ProductDetailDto)
        {
            var value = _mapper.Map<ProductDetail>(ProductDetailDto);
            await _ProductDetailCollection.InsertOneAsync(value);
        }

        public async Task DeleteProductDetailAsync(string id)
        {
            await _ProductDetailCollection.DeleteOneAsync(x => x.ProductDetailId == id);
        }

        public async Task<List<ResultProductDetailDto>> GetAllProductDetailAsync()
        {
            var values = await _ProductDetailCollection.Find(x => true).ToListAsync();

            return _mapper.Map<List<ResultProductDetailDto>>(values);
        }

        public async Task<GetByIdProductDetailDto> GetByIdProductDetailAsync(string id)
        {
            var value = await _ProductDetailCollection.Find(x => x.ProductDetailId == id).FirstOrDefaultAsync();
            return _mapper.Map<GetByIdProductDetailDto>(value);
        }

        public async Task UpdateProductDetailAsync(UpdateProductDetailDto ProductDetailDto)
        {
            var value = _mapper.Map<ProductDetail>(ProductDetailDto);
            await _ProductDetailCollection.FindOneAndReplaceAsync(x => x.ProductDetailId == ProductDetailDto.ProductDetailId, value);
        }
    }
}
