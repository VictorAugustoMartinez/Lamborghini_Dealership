using Lamborghini_Dealership.Data;
using Lamborghini_Dealership.Entities;
using Microsoft.Extensions.Options;

namespace Lamborghini_Dealership.Services
{
    public interface IMongoDBService
    {
        Task CreateAsync(Car car);
        Task CreateManyAsync(List<Car> car);
        Task<List<Car>> GetOneAsync(string id);
        Task<List<Car>> GetAllAsync();
        Task<List<Car>> GetAvailableAsync();
        Task SellCarAsync(string id);
        Task DeleteAsync(string id);

    }
}
