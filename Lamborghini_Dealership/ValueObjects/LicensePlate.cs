using System.Text.RegularExpressions;

namespace Lamborghini_Dealership.ValueObjects
{
    public class LicensePlate
    {
        public LicensePlate(string plate)
        {
            var platePattern = new Regex("[a-zA-Z]{3}[0-9]{4}");

            if (string.IsNullOrWhiteSpace(plate))
            { throw new ArgumentNullException(); }

            if (plate.Length > 8)
            { throw new Exception("A placa deve conter no minimo 8 caracteres"); }

            if (!platePattern.IsMatch(plate))
            {
                throw new Exception("A placa esta com o formato errado");
            }
            Plate = plate.Replace("-", "").Trim();
        }
        public string Plate { get; set; }
    }
}
