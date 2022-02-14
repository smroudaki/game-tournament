using GameTournament.Application.Common.ViewModels;
using MediatR;
using System;
using System.Collections.Generic;
using System.Text;

namespace GameTournament.Application.Users.Commands
{
    public class LoginUserCommand : IRequest<ResultViewModel>
    {
        public string PhoneNumber { get; set; }
    }
}
