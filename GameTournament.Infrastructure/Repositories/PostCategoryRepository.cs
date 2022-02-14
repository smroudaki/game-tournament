using GameTournament.Application.Common.Interfaces;
using GameTournament.Domain.Entities;
using GameTournament.Infrastructure.Persistence;
using System;
using System.Collections.Generic;
using System.Text;

namespace GameTournament.Infrastructure.Repositories
{
    public class PostCategoryRepository : BaseRepository<PostCategory>, IPostCategoryRepository
    {
        public PostCategoryRepository(GameTournamentTournamentContext context)
               : base(context)
        {
        }
    }
}
