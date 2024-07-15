using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using MultiShop.Cargo.BusinessLayer.Abstract;
using MultiShop.Cargo.DtoLayer.Dtos.CargoCompanyDtos;
using MultiShop.Cargo.EntityLayer.Concrete;

namespace MultiShop.Cargo.WebApi.Controllers
{
    [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class CargoCompaniesController : ControllerBase
    {
        private readonly ICargoCompanyService _cargoCompanyService;

        public CargoCompaniesController(ICargoCompanyService cargoCompanyService)
        {
            _cargoCompanyService = cargoCompanyService;
        }
        [HttpGet]
        public async Task<IActionResult> CargoCompanyList()
        {
            var result = await _cargoCompanyService.GetAll();
            return Ok(result);
        }
        [HttpPost]
        public async Task<IActionResult> CreateCompanyList(CreateCargoCompanyDto createCargoCompanyDto)
        {
            CargoCompany cargoCompany = new()
            {
                CargoCompanyName = createCargoCompanyDto.CargoCompanyName
            };
            await _cargoCompanyService.Insert(cargoCompany);
            return Ok("Kargo Şirketi Başarıyla Oluşturuldu.");
        }
        [HttpDelete]
        public async Task<IActionResult> RemoveCargoCompany(int id)
        {
            await _cargoCompanyService.Delete(id);
            return Ok("Kargo Şirketi Başarıyla Silindi.");
        }
        [HttpGet("{id}")]
        public async Task<IActionResult> GetCargoCompanyById(int id)
        {
            var result = await _cargoCompanyService.GetById(id);
            return Ok(result);
        }
        [HttpPut]
        public async Task<IActionResult> UpdateCargoCompany(UpdateCargoCompanyDto updateCargoCompanyDto)
        {
            CargoCompany cargoCompany = new()
            {
                CargoCompanyId = updateCargoCompanyDto.CargoCompanyId,
                CargoCompanyName = updateCargoCompanyDto.CargoCompanyName
            };
            await _cargoCompanyService.Update(cargoCompany);
            return Ok("Kargo Şirketi Başarıyla Güncellendi.");
        }
    }
}
