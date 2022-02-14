using GameTournament.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace GameTournament.Application.Common.Interfaces
{
    public interface IUserRepository : IRepository<User>
    {
        Task<User> GetByPhoneNumberAsync(string phoneNumber);
        Task<User> GetByGuidAsync(Guid userGuid);
        Task<User> GetByIdentifierAsync(string identifier);
        Task<bool> IsValidAsync(string phoneNumber);
    }
}
