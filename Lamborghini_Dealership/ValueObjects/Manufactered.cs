namespace Lamborghini_Dealership.ValueObjects
{
    public class Manufactered
    {
        public int Year { get; set; }
        public int Month { get; set; }
        public int Day { get; set; }
        public string FullData => $"{Year}/{Month}/{Day}";
    }
}
