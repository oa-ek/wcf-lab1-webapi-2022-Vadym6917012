using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AutoOA.Repository.Dto.VehicleModelDto
{
    public class VehicleModelReadDto
    {
        public int VehicleModelId { get; set; }
        public string? VehicleModelName { get; set; }
        public DateTime ProductionDate { get; set; } 
        public int VehicleBrandId { get; set; }
    }
}
