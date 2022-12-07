using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace AutoOA.Core
{
    public class VehicleModel
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int VehicleModelId { get; set; }
        public string? VehicleModelName { get; set; } = string.Empty;

        public int VehicleBrandId { get; set; }
        public VehicleBrand? VehicleBrand { get; set; }

        public virtual ICollection<Vehicle>? Vehicles { get; set; }
    }
}