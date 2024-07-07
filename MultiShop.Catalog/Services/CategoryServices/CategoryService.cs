using AutoMapper;
using MongoDB.Driver;
using MultiShop.Catalog.Dtos.CategoryDtos;
using MultiShop.Catalog.Entities;
using MultiShop.Catalog.Settings;

namespace MultiShop.Catalog.Services.CategoryServices
{
    public class CategoryService : ICategoryService
    {
        private readonly IMongoCollection<Category> _categoryCollection;
        private readonly IMapper _mapper;
        public CategoryService( IMapper mapper,IDatabaseSettings _dbSettings)
        {
            var client = new MongoClient(_dbSettings.ConnectionString);
            var database = client.GetDatabase(_dbSettings.DatabaseName);
            _categoryCollection = database.GetCollection<Category>(_dbSettings.CategoryCollectionName);
            _mapper = mapper;
        }
        public async Task CreateCategoryAsync(CreateCategoryDto categoryDto)
        {
            var value = _mapper.Map<Category>(categoryDto);
            await _categoryCollection.InsertOneAsync(value);
        }

        public async Task DeleteCategoryAsync(string id)
        {
            await _categoryCollection.DeleteOneAsync(x=> x.CategoryId == id);
        }

        public async Task<List<ResultCategoryDto>> GetAllCategoryAsync()
        {
            var values = await _categoryCollection.Find(x => true).ToListAsync();
            
            return _mapper.Map<List<ResultCategoryDto>>(values);
        }

        public async Task<GetByIdCategoryDto> GetByIdCategoryAsync(string id)
        {
            var value = await _categoryCollection.Find(x => x.CategoryId == id).FirstOrDefaultAsync();
            return _mapper.Map<GetByIdCategoryDto>(value);
        }

        public async Task UpdateCategoryAsync(UpdateCategoryDto categoryDto)
        {
            var value = _mapper.Map<Category>(categoryDto);
            await _categoryCollection.FindOneAndReplaceAsync(x => x.CategoryId == categoryDto.CategoryId, value);
        }
    }
}
