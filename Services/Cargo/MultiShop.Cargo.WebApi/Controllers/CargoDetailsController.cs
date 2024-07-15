using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using MultiShop.Cargo.BusinessLayer.Abstract;
using MultiShop.Cargo.DtoLayer.Dtos.CargoDetailsDtos;
using MultiShop.Cargo.EntityLayer.Concrete;

namespace MultiShop.Cargo.WebApi.Controllers
{
    [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class CargoDetailsController : ControllerBase
    {
        private readonly ICargoDetailService _cargoDetailService;

        public CargoDetailsController(ICargoDetailService cargoDetailService)
        {
            _cargoDetailService = cargoDetailService;
        }
        [HttpGet]
        public async Task<IActionResult> CargoDetailList()
        {
            var result =  await _cargoDetailService.GetAll();
            return Ok(result);
        }
        [HttpGet("{id}")]
        public async Task<IActionResult> CargoDetailGetById(int id)
        {
            var result = await _cargoDetailService.GetById(id);
            return Ok(result);
        }
        [HttpPost]
        public async Task<IActionResult> CreateCargoDetail(CreateCargoDetailsDto createCargoDetailsDto)
        {
            CargoDetail cargoDetail = new()
            {
                Barcode = createCargoDetailsDto.Barcode,
                CargoCompanyId = createCargoDetailsDto.CargoCompanyId,
                ReceiverCustomer = createCargoDetailsDto.ReceiverCustomer,
                SenderCustomer = createCargoDetailsDto.SenderCustomer,
            };
            await _cargoDetailService.Insert(cargoDetail);
            return Ok("Kargo Detay Ekleme İşlemi Başarılı.");
        }
        [HttpDelete]
        public async Task<IActionResult> RemoveCargoDetail(int id)
        {
            await _cargoDetailService.Delete(id);
            return Ok("Kargo Detay Silme İşlemi Başarılı.");
        }
        [HttpPut]
        public async Task<IActionResult> UpdateCargoDetail(UpdateCargoDetailsDto updateCargoDetailsDto)
        {
            CargoDetail cargoDetail = new()
            {
                Barcode=updateCargoDetailsDto.Barcode,
                CargoCompanyId = updateCargoDetailsDto.CargoCompanyId,
                ReceiverCustomer=updateCargoDetailsDto.ReceiverCustomer,
                SenderCustomer=updateCargoDetailsDto.SenderCustomer,
                CargoDetailId = updateCargoDetailsDto.CargoDetailId               
            };
            await _cargoDetailService.Update(cargoDetail);
            return Ok("Kargo Detay Güncelleme İşlemi Başarılı.");
        }
    }
}
