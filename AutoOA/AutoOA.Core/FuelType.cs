using System.ComponentModel.DataAnnotations;

namespace AutoOA.Core
{
    public class FuelType
    {
        [Key]
        public int FuelTypeId { get; set; }
        public string? FuelName { get; set; }

        public int VehicleId { get; set; }
        public virtual ICollection<Vehicle>? Vehicle { get; set; }
    }
}