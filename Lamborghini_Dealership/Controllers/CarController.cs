using Lamborghini_Dealership.Entities;
using Lamborghini_Dealership.Services;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace Lamborghini_Dealership.Controllers
{
    [ApiController]
    public class CarController : ControllerBase
    {
        private readonly IMongoDBService _mongoDBService;

        public CarController(IMongoDBService mongoDBService)
        {
            _mongoDBService = mongoDBService;
        }

        [HttpGet("v1/Car/{id}")]
        public async Task<List<Car>> GetCar(string id)
        {
            return await _mongoDBService.GetOneAsync(id);
        }

        [HttpGet("v1/Cars")]
        public async Task<List<Car>> GetCars()
        {
            return await _mongoDBService.GetAllAsync();
        }

        [HttpGet("v1/Cars/Available")]
        public async Task<List<Car>> GetAvailableCars()
        {
            return await _mongoDBService.GetAvailableAsync();
        }

        [HttpPost("v1/Car")]
        public async Task<IActionResult> PostOneCar(
            [FromBody] Car model)
        {
            await _mongoDBService.CreateAsync(model);
            return Ok(model);
        }

        [HttpPost("v1/Cars")]
        public async Task<IActionResult> PostManyCars(
            [FromBody] List<Car> model)
        {
            await _mongoDBService.CreateManyAsync(model);
            return Ok(model);
        }

        [HttpPut("v1/Car/{id}")]
        public async Task<IActionResult> PutCarAsync(
            string id)
        {
            await _mongoDBService.SellCarAsync(id);
            return Ok("The car has been sold");
        }

        [HttpDelete("v1/Car/{id}")]
        public async Task<IActionResult> DeleteCar(
            string id)
        {
            await _mongoDBService.DeleteAsync(id);
            return Ok("The car was deleted");
        }
    }
}
