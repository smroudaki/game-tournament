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
    public class CategoryRepository : BaseRepository<Category>, ICategoryRepository
    {
        public CategoryRepository(GameTournamentTournamentContext context)
               : base(context)
        {
        }

        public async Task<Category> GetByGuidAsync(Guid categoryGuid)
        {
            return await _context.Category
                .SingleOrDefaultAsync(u => u.CategoryGuid.Equals(categoryGuid));
        }
    }
}
