using System.ComponentModel.DataAnnotations;

namespace AutoOA.Core
{
    public class GearBox
    {
        [Key]
        public int GearBoxId { get; set; }
        public string? GearBoxName { get; set; }

        public int VehicleId { get; set; }
        public Vehicle? Vehicle { get; set; }
    }
}