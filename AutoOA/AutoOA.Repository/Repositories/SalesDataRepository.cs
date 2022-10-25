using AutoOA.Core;
using AutoOA.Repository.Dto.SalesDataDto;
using Microsoft.EntityFrameworkCore;

namespace AutoOA.Repository.Repositories
{
    public class SalesDataRepository
    {
        private readonly AutoOADbContext _ctx;

        public SalesDataRepository(AutoOADbContext ctx)
        {
            _ctx = ctx;
        }

        public SalesData GetDataByCreatedData(DateTime time)
        {
            return _ctx.SalesData.FirstOrDefault(x => x.CreatedOn == time);
        }

        public async Task<IEnumerable<SalesDataReadDto>> GetSalesDatasAsync()
        {
            var saleDataDto = _ctx.SalesData.
                Select(x => new SalesDataReadDto 
                {
                    SalesDataId = x.SalesDataId,
                    VehicleId = x.VehicleId,
                    CreatedOn = x.CreatedOn,
                    UpdatedOn = x.UpdatedOn
                }).ToList();

            return saleDataDto;
        }

        public async Task<SalesDataReadDto> GetSaleDataAsync(int id)
        {
            var u = await _ctx.SalesData.FirstAsync(x => x.SalesDataId == id);

            var saleDataDto = new SalesDataReadDto
            {
                SalesDataId = u.SalesDataId,
                VehicleId = u.VehicleId,
                CreatedOn = u.CreatedOn,
                UpdatedOn = u.UpdatedOn
            };

            return saleDataDto;
        }
    }
}
