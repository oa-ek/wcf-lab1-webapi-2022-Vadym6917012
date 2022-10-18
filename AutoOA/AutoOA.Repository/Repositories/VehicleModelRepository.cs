using AutoOA.Core;
using AutoOA.Repository.Dto.VehicleModelDto;

namespace AutoOA.Repository.Repositories
{
    public class VehicleModelRepository
    {
        private readonly AutoOADbContext _ctx;

        public VehicleModelRepository(AutoOADbContext ctx)
        {
            _ctx = ctx;
        }

        public async Task<IEnumerable<VehicleModelReadDto>> GetVehicleModelsAsync()
        {
            var models = new List<VehicleModelReadDto>();

            foreach (var u in _ctx.VehicleModels.ToList())
            {
                var modelsDto = new VehicleModelReadDto
                {
                    VehicleModelId = u.VehicleModelId,
                    VehicleModelName = u.VehicleModelName,
                    ProductionDate = u.ProductionDate,
                    VehicleBrandId = u.VehicleBrandId
                };

                models.Add(modelsDto);
            }

            return models;
        }
    }
}
