using GameTournament.Application.Users.ViewModels;
using MediatR;
using System;
using System.Collections.Generic;
using System.Text;

namespace GameTournament.Application.Users.Queries
{
    public class GetUserQuery : IRequest<UserViewModel>
    {
        public Guid UserGuid { get; set; }
    }
}
