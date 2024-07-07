using MultiShop.Discount.Dtos;

namespace MultiShop.Discount.Services
{
    public interface IDiscountService
    {
        Task<List<ResultDiscountCouponDto>> GetAllDiscountCouponAsync();
        Task CreateDiscountCouponDto(CreateDiscountCouponDto createCouponDto);
        Task UpdateDiscountCouponDto(UpdateDiscountCouponDto updateCouponDto);
        Task DeleteDiscountCouponDto(int id);
        Task<GetByIdDiscountCouponDto> GetByIdDiscountCouponAsync(int id);
    }
}
