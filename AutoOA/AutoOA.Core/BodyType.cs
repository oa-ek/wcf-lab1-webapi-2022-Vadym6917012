using System.ComponentModel.DataAnnotations;

namespace AutoOA.Core
{
    public class BodyType
    {
        [Key]
        public int BodyTypeId { get; set; }
        public string? BodyTypeName { get; set; }

        public int VehicleId { get; set; }   
        public Vehicle? Vehicle{ get; set; }
    }
}