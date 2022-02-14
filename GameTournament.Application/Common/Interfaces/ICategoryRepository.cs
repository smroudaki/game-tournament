using GameTournament.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace GameTournament.Application.Common.Interfaces
{
    public interface ICategoryRepository : IRepository<Category>
    {
        Task<Category> GetByGuidAsync(Guid categoryGuid);
    }
}
