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
    public class UserRepository : BaseRepository<User>, IUserRepository
    {
        public UserRepository(GameTournamentTournamentContext context)
            : base(context)
        {
        }

        public async Task<User> GetByPhoneNumberAsync(string phoneNumber)
        {
            return await _context.User
                .Include(u => u.ProfileDocument)
                .SingleOrDefaultAsync(u => u.PhoneNumber.Equals(phoneNumber));
        }

        public async Task<User> GetByGuidAsync(Guid userGuid)
        {
            return await _context.User
                .Include(u => u.ProfileDocument)
                .SingleOrDefaultAsync(u => u.UserGuid.Equals(userGuid));
        }

        public async Task<bool> IsValidAsync(string phoneNumber)
        {
            var user = await GetByPhoneNumberAsync(phoneNumber);
            return user.PhoneNumberConfirmed;
        }

        public async Task<User> GetByIdentifierAsync(string identifier)
        {
            return await _context.User
                .Include(u => u.ProfileDocument)
                .SingleOrDefaultAsync(u => u.Identifier.Equals(identifier));
        }
    }
}
