using Dapper;
using MultiShop.Discount.Context;
using MultiShop.Discount.Dtos;

namespace MultiShop.Discount.Services
{
    public class DiscountService : IDiscountService
    {
        private readonly DapperContext _dbContext;
        

        public DiscountService(DapperContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task CreateDiscountCouponDto(CreateDiscountCouponDto createCouponDto)
        {
            string query = "insert into Coupons (Code,Rate,IsActive,ValidDate) values (@code,@rate,@isActive,@validDate)";
            var parameters = new DynamicParameters();
            parameters.Add("@code", createCouponDto.Code);
            parameters.Add("@rate", createCouponDto.Rate);
            parameters.Add("@isActive", createCouponDto.IsActive);
            parameters.Add("@validDate", createCouponDto.ValidDate);

            using (var connection = _dbContext.CreateConnection())
            {
                await connection.ExecuteAsync(query, parameters);
            }
        }

        public async Task DeleteDiscountCouponDto(int id)
        {
            string query = "delete from Coupons where CouponId = @couponId";
            var parameters = new DynamicParameters();
            parameters.Add("@couponId", id);
            using (var connection = _dbContext.CreateConnection())
            {
                await connection.ExecuteAsync(query, parameters);
            }
        }

        public async Task<List<ResultDiscountCouponDto>> GetAllDiscountCouponAsync()
        {
            string query = "select * from Coupons";
            using (var connection = _dbContext.CreateConnection())
            {
                var values = await connection.QueryAsync<ResultDiscountCouponDto>(query);
                return values.ToList();
            }

        }

        public async Task<GetByIdDiscountCouponDto> GetByIdDiscountCouponAsync(int id)
        {
            string query = "select * from Coupons where CouponId = @couponId";
            var parameters = new DynamicParameters();
            parameters.Add("@couponId", id);
            using (var connection = _dbContext.CreateConnection())
            {
                var values = await connection.QueryFirstOrDefaultAsync<GetByIdDiscountCouponDto>(query,parameters);
                return values;
            }
        }

        public async Task UpdateDiscountCouponDto(UpdateDiscountCouponDto updateCouponDto)
        {
            string query = "update coupons set code = @code,rate = @rate,IsActive = @isActive,validDate = @validDate where couponId = @couponId";
            var parameters = new DynamicParameters();
            parameters.Add("@couponId", updateCouponDto.CouponId);
            parameters.Add("@code", updateCouponDto.Code);
            parameters.Add("@rate", updateCouponDto.Rate);
            parameters.Add("@isActive", updateCouponDto.IsActive);
            parameters.Add("@validDate", updateCouponDto.ValidDate);
            using (var connection = _dbContext.CreateConnection())
            {
                await connection.ExecuteAsync(query,parameters);
            }
        }
    }
}
