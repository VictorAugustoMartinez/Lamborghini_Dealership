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

        /// <summary>
        ///     Get a specific Car
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        /// <response code="200">Returns a Car by the Id</response>
        /// <response code="400">The Id must be passed inside the url</response>
        [HttpGet("v1/Car/{id}")]
        [Produces("application/json")]
        public async Task<List<Car>> GetCar(string id)
        {
            return await _mongoDBService.GetOneAsync(id);
        }

        /// <summary>
        ///     Get all the Cars
        /// </summary>
        /// <returns></returns>
        /// <response code="200">Returns a Car by the Id</response>
        [HttpGet("v1/Cars")]
        [Produces("application/json")]
        public async Task<List<Car>> GetCars()
        {
            return await _mongoDBService.GetAllAsync();
        }

        /// <summary>
        /// Get just the available Cars
        /// </summary>
        /// <returns></returns>
        /// <response code="200">Returns a Car by the Id</response>
        [HttpGet("v1/Cars/Available")]
        [Produces("application/json")]
        public async Task<List<Car>> GetAvailableCars()
        {
            return await _mongoDBService.GetAvailableAsync();
        }


        /// <summary>
        ///     Creates a Car
        /// </summary>
        /// <param name="model"></param>
        /// <returns>Car</returns>
        /// <remarks>
        /// Sample request:
        ///
        ///     POST /v1/Car
        ///     {
        ///         "id": "",
        ///         "model": "Aventador",
        ///         "brand": "Lamborghini",
        ///         "color": "Purple",
        ///         "price_Usd": 550542.0,
        ///         "topspeed_kmph": 355,
        ///         "power_Hp": 780,
        ///         "sold": false,
        ///         "manufactured": {
        ///             "year": 2021,
        ///             "month": 3,
        ///             "day": 30,
        ///             "fulldata": "2021-03-30"
        ///         },
        ///         "licenseplate": {
        ///             "plate": "EAI1064"
        ///         }
        ///     }
        /// </remarks>
        /// <response code="201">Return newly created item</response>
        /// <response code="400">The object in the req body must be an Car</response>
        [HttpPost("v1/Car")]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [Produces("application/json")]
        public async Task<IActionResult> PostOneCar(
            [FromBody] Car model)
        {
            await _mongoDBService.CreateAsync(model);
            return Ok(model);
        }


        /// <summary>
        ///     Creates many Cars
        /// </summary>
        /// <param name="model"></param>
        /// <returns>List of Car</returns>
        /// <remarks>
        /// Sample request:
        ///
        ///     POST /v1/Cars
        ///     [
        ///         {
        ///            "id": "",
        ///            "model": "Aventador",
        ///            "brand": "Lamborghini",
        ///            "color": "Purple",
        ///            "price_Usd": 550542.0,
        ///            "topspeed_kmph": 355,
        ///            "power_Hp": 780,
        ///            "sold": false,
        ///            "manufactured": {
        ///                "year": 2021,
        ///                "month": 3,
        ///                "day": 30,
        ///                "fulldata": "2021-03-30"
        ///            },
        ///            "licenseplate": {
        ///                "plate": "EAI1064"
        ///            }
        ///         }
        ///     ]
        /// </remarks>
        /// <response code="201">Returns newly created items</response>
        /// <response code="400">The object in the req body must be an List of Car</response>

        [HttpPost("v1/Cars")]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [Produces("application/json")]
        public async Task<IActionResult> PostManyCars(
            [FromBody] List<Car> model)
        {
            await _mongoDBService.CreateManyAsync(model);
            return Ok(model);
        }

        /// <summary>
        ///     Sell a specific Car
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        /// <response code="200">The Car has been sold</response>
        /// <response code="400">The Id must be passed inside the url</response>
        [HttpPut("v1/Car/{id}")]
        public async Task<IActionResult> PutCarAsync(
            string id)
        {
            await _mongoDBService.SellCarAsync(id);
            return Ok("The car has been sold");
        }

        /// <summary>
        ///     Deletes a specific Car
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        /// <response code="200">The Car has been deleted</response>
        /// <response code="400">The Id must be passed inside the url</response>
        [HttpDelete("v1/Car/{id}")]
        public async Task<IActionResult> DeleteCar(
            string id)
        {
            await _mongoDBService.DeleteAsync(id);
            return Ok("The car was deleted");
        }
    }
}
