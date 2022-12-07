using Microsoft.Build.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AutoOA.Repository.Dto.VehicleModelDto
{
    public class VehicleModelCreateDto
    {
        [Required]
        public string? VehicleModelName { get; set; }
    }
}
