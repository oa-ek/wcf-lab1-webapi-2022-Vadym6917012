using System.ComponentModel.DataAnnotations;

namespace AutoOA.Repository.Dto.BodyTypeDto
{
    public class BodyTypeCreateDto
    {
        [Required(ErrorMessage = "Введіть назву")]
        [StringLength(32, ErrorMessage = "Must be between 1 and 32 characters", MinimumLength = 1)]
        [RegularExpression("^[a-zA-Z0-9_.-]", ErrorMessage = "Must be a valid name")]
        public string? BodyName { get; set; }
    }
}
