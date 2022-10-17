using AutoOA.Core;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AutoOA.Repository.Dto
{
    public class VehicleRenewalDto
    {
        public int VehicleId { get; set; }
        public virtual ICollection<BodyType> BodyTypes { get; set; }
        public VehicleModel VehicleModel { get; set; }
        public virtual ICollection<GearBox> GearBoxes { get; set; }
        public decimal Price { get; set; }
        public bool isNew { get; set; }
        public int Mileage { get; set; }
        public string? IconPath { get; set; }
        public virtual ICollection<FuelType> FuelTypes { get; set; }
        public string Color { get; set; }

    }
}
