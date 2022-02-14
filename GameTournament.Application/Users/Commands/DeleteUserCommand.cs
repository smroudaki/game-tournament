using GameTournament.Application.Common.ViewModels;
using MediatR;
using System;
using System.Collections.Generic;
using System.Text;

namespace GameTournament.Application.Users.Commands
{
    public class DeleteUserCommand : IRequest<ResultViewModel>
    {
        public Guid UserGuid { get; set; }
    }
}
