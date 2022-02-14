using GameTournament.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace GameTournament.Application.Common.Interfaces
{
    public interface IJwtService
    {
        Task<string> GenerateToken(User user, DateTime expireDate);
    }
}
