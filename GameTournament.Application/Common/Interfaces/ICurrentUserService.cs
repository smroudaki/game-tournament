using System;
using System.Collections.Generic;
using System.Text;

namespace GameTournament.Application.Common.Interfaces
{
    public interface ICurrentUserService
    {
        Guid UserGuid { get; }
        int UserId { get; }
        string PhoneNumber { get; }
        string Email { get; }
    }
}
