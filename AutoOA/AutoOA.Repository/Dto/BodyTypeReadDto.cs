using AutoOA.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AutoOA.Repository.Dto
{
    public class BodyTypeReadDto
    {
        public int BodyTypeId { get; set; }
        public string BodyTypeName { get; set; }

        public int VehicleId { get;set; }
        public Vehicle Vehicle { get; set; }
    }
}
