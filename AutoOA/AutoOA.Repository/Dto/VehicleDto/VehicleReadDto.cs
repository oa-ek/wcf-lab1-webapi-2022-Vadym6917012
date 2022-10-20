using AutoOA.Core;

namespace AutoOA.Repository.Dto.VehicleDto
{
    public class VehicleReadDto
    {
        public int VehicleId { get; set; }

        public int BodyTypeId { get; set; }
        public BodyType BodyType { get; set; }

        public int ModelId { get; set; }
        public VehicleModel VehicleModel { get; set; }

        public DateTime ProductionDate { get; set; }

        public string VehicleBrand { get; set; }

        public int GearBoxId { get; set; }
        public GearBox GearBox { get; set; }

        public decimal Price { get; set; }
        public bool isNew { get; set; }

        public string MileageIconPath { get; set; }
        public int Mileage { get; set; }

        public string VehcileIconPath { get; set; }

        public int FuelTypeId { get; set; }
        public FuelType FuelType { get; set; }

        public string Color { get; set; }
    }
}
