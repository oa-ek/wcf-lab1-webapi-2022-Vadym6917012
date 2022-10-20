using System.ComponentModel.DataAnnotations;

namespace AutoOA.Core
{
    public class BodyType
    {
        [Key]
        public int BodyTypeId { get; set; }
        public string? BodyTypeName { get; set; }
        public string? IconPath { get; set; } = @"Images\BodyTypeIcon.png";

        public virtual ICollection<Vehicle> Vehicle { get; set; }
    }
}