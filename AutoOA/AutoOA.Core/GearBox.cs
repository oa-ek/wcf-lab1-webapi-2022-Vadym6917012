using System.ComponentModel.DataAnnotations;

namespace AutoOA.Core
{
    public class GearBox
    {
        [Key]
        public int GearBoxId { get; set; }
        public string? GearBoxName { get; set; }

        public virtual ICollection<Vehicle> Vehicle { get; set; }
    }
}