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
    public class ActivityRepository : BaseRepository<Activity>, IActivityRepository
    {
        public ActivityRepository(GameTournamentTournamentContext context)
            : base(context)
        {
        }

        public async Task<Activity> GetByGuidAsync(Guid activityGuid)
        {
            return await _context.Activity
                .SingleOrDefaultAsync(u => u.ActivityGuid.Equals(activityGuid));
        }
    }
}
