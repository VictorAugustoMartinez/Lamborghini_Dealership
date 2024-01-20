using Lamborghini_Dealership.ValueObjects;
using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace Lamborghini_Dealership.Entities
{
    public class Car
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string? Id { get; set; }
        public string? Model { get; set; }
        public string? Brand { get; set; }
        public string? Color { get; set; }
        public double Price_Usd { get; set; }
        public int TopSpeed_Kmph { get; set; }
        public int Power_Hp { get; set; }
        public bool Sold { get; set; } 
        public Manufactered Manufactured { get; set; } 
        public LicensePlate licensePlate { get; set; }
    }
}
