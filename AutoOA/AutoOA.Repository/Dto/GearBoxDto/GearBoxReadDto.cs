using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AutoOA.Repository.Dto.GearBoxDto
{
    public class GearBoxReadDto
    {
        public int GearBoxId { get; set; }
        public string GearBoxName { get; set; }
        public int VehicleId { get; set; }
    }
}
