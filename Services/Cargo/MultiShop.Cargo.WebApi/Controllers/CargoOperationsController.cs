using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MultiShop.Cargo.BusinessLayer.Abstract;
using MultiShop.Cargo.DtoLayer.Dtos.CargoOperationDtos;
using MultiShop.Cargo.EntityLayer.Concrete;

namespace MultiShop.Cargo.WebApi.Controllers
{
    [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class CargoOperationsController : ControllerBase
    {
        private readonly ICargoOperationService _cargoOperationService;

        public CargoOperationsController(ICargoOperationService cargoOperationService)
        {
            _cargoOperationService = cargoOperationService;
        }
        [HttpGet]
        public async Task<IActionResult> CargoOperationList()
        {
            var result = await _cargoOperationService.GetAll();
            return Ok(result);
        }
        [HttpGet("{id}")]
        public async Task<IActionResult> CargoOperationGetById(int id)
        {
            var result = await _cargoOperationService.GetById(id);
            return Ok(result);
        }
        [HttpPost]
        public async Task<IActionResult> CreateCargoOperation(CreateCargoOperationDto createCargoOperationDto)
        {
            CargoOperation cargoOperation = new()
            {
                Barcode = createCargoOperationDto.Barcode,
                Description = createCargoOperationDto.Description,
                OperationDate = createCargoOperationDto.OperationDate
            };
            await _cargoOperationService.Insert(cargoOperation);
            return Ok("Kargo Operasyonu Başarıyla Eklendi.");
        }
        [HttpDelete]
        public async Task<IActionResult> RemoveCargoOperation(int id)
        {
            await _cargoOperationService.Delete(id);
            return Ok("Kargo Operasyonu Başarıyla Silindi.");
        }
        [HttpPut]
        public async Task<IActionResult> UpdateCargoOperation(UpdateCargoOperationDto updateCargoOperationDto)
        {
            CargoOperation cargoOperation = new()
            {
                Barcode= updateCargoOperationDto.Barcode,
                CargoOperationId = updateCargoOperationDto.CargoOperationId,
                Description= updateCargoOperationDto.Description,
                OperationDate= updateCargoOperationDto.OperationDate
            };
            await _cargoOperationService.Update(cargoOperation);
            return Ok("Kargo Operasyonu Başarıyla Güncellendi.");
        }
    }
}
