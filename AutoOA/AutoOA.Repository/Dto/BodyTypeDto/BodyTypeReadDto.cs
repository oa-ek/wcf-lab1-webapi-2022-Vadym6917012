using AutoOA.Core;

namespace AutoOA.Repository.Dto.BodyTypeDto
{
    public class BodyTypeReadDto
    {
        public int BodyId { get; set; }
        public string BodyName { get; set; }

        public int VehicleId { get; set; }
        public Vehicle Vehicle { get; set; }
    }
}
