using GameTournament.Application.Common.Interfaces;
using GameTournament.Domain.Entities;
using GameTournament.Infrastructure.Persistence;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace GameTournament.Infrastructure.Repositories
{
    public class ProvinceRepository : BaseRepository<Province>, IProvinceRepository
    {
        public ProvinceRepository(GameTournamentTournamentContext context)
            : base(context)
        {
        }

        public async Task<Province> GetByGuidAsync(Guid provinceGuid)
        {
            return await _context.Province
                .SingleOrDefaultAsync(p => p.ProvinceGuid.Equals(provinceGuid));
        }
    }
}
