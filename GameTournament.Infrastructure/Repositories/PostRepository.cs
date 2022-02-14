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
    public class PostRepository : BaseRepository<Post>, IPostRepository
    {
        public PostRepository(GameTournamentTournamentContext context)
               : base(context)
        {
        }

        public async Task<Post> GetByGuidAsync(Guid postGuid)
        {
            return await _context.Post
                .Include(p => p.User)
                .Include(p => p.CoverDocument)
                .SingleOrDefaultAsync(u => u.PostGuid.Equals(postGuid));
        }
    }
}
