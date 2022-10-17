using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoOA.Core;
using AutoOA.Repository.Dto;
using Microsoft.EntityFrameworkCore;

namespace AutoOA.Repository
{
    public class BodyTypeRepository
    {
        private readonly AutoOADbContext _ctx;

        BodyTypeRepository(AutoOADbContext ctx)
        {
            _ctx = ctx;
        }

        public async Task<BodyType?> GetTypeByIdAsync(int id)
        {
            return await _ctx.BodyTypes.FindAsync(id);
        }
    }
}
