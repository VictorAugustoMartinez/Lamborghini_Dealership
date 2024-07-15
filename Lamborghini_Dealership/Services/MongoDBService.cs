using Lamborghini_Dealership.Data;
using Lamborghini_Dealership.Entities;
using Microsoft.Extensions.Options;
using MongoDB.Bson;
using MongoDB.Driver;
using System.Security.Cryptography.X509Certificates;

namespace Lamborghini_Dealership.Services
{
    public class MongoDBService : IMongoDBService
    {
        private readonly IMongoCollection<Car> _carCollection;

        public MongoDBService(IOptions<MongoDBSettings> mongoDBSettings)
        {
            MongoClient client = new MongoClient(mongoDBSettings.Value.ConnectionURI);
            IMongoDatabase database = client.GetDatabase(mongoDBSettings.Value.DatabaseName);
            _carCollection = database.GetCollection<Car>(mongoDBSettings.Value.CollectionName);
        }

        public async Task CreateAsync(Car car)
        {
            await _carCollection.InsertOneAsync(car);
            return;
        }

        public async Task CreateManyAsync(List<Car> car)
        {
            await _carCollection.InsertManyAsync(car);
            return;
        }

        public async Task<Car> GetOneAsync(string id)
        {
            FilterDefinition<Car> filter = Builders<Car>.Filter.Eq("Id", id);
            return await _carCollection.Find(filter).FirstOrDefaultAsync();
        }
        public async Task<List<Car>> GetAllAsync()
        {
            return await _carCollection.Find(new BsonDocument()).ToListAsync();
        }

        public async Task<List<Car>> GetAvailableAsync()
        {
            return await _carCollection.Find(x => x.Sold == false).ToListAsync();
        }

        public async Task SellCarAsync(string id)
        {
            FilterDefinition<Car> filter = Builders<Car>.Filter.Eq("Id", id);
            UpdateDefinition<Car> update = Builders<Car>.Update.Set("Sold", true);
            await _carCollection.UpdateOneAsync(filter, update);
            return;
        }

        public async Task DeleteAsync(string id)
        {
            FilterDefinition<Car> filter = Builders<Car>.Filter.Eq("Id", id);
            await _carCollection.DeleteOneAsync(filter);
            return;
        }
    }
}
