using AutoOA.Core;

namespace AutoOA.Repository.Dto.VehicleDto
{
    public class VehicleReadDto
    {
        public int VehicleId { get; set; }
        public int BodyTypeId { get; set; }
        public int ModelId { get; set; }
        public int GearBoxId { get; set; }
        public decimal Price { get; set; }
        public bool isNew { get; set; }
        public int Mileage { get; set; }
        public string IconPath { get; set; }
        public int FuelTypeId { get; set; }
        public string Color { get; set; }
    }
}
